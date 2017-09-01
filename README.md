# WebJobActivator #

* Build Status [![Build status](https://ci.appveyor.com/api/projects/status/uhe9ias4mh99xptf/branch/dev?svg=true)](https://ci.appveyor.com/project/justinyoo/webjobactivator/branch/dev)
* WebJobActivator.Core [![](https://img.shields.io/nuget/dt/WebJobActivator.Core.svg)](https://www.nuget.org/packages/WebJobActivator.Core/)
[![](https://img.shields.io/nuget/v/WebJobActivator.Core.svg)](https://www.nuget.org/packages/WebJobActivator.Core/)
* WebJobActivator.Autofac [![](https://img.shields.io/nuget/dt/WebJobActivator.Autofac.svg)](https://www.nuget.org/packages/WebJobActivator.Autofac/)
[![](https://img.shields.io/nuget/v/WebJobActivator.Autofac.svg)](https://www.nuget.org/packages/WebJobActivator.Autofac/)


This provides core implementations of `IJobActivator` for Azure WebJob to be used by various IoC container libraries.


## Overview ##

Azure WebJob SDK provides the `IJobActivator` interface so that we can easily manage dependencies. `WebJobActivator.Core` provides abstraction classes that are inherited and interfaces that are implemented by IoC container libraries. `WebJobActivator.Autofac` is one of implementations using `WebJobActivator.Core`.


## Getting Started ##

### Using `WebJobActivator.Autofac` ###

There is a WebJob function looks after a queue.

```csharp
public class Functions
{
    private readonly Helper _helper;

    public Functions(Helper helper)
    {
        if (helper == null)
        {
            throw new ArgumentNullException(nameof(helper));
        }

        this._helper = helper;
    }

    public void Run([QueueTrigger("queue")] string message, TextWriter log)
    {
        var output = this._helper.GetValue(message);
        log.WriteLine(output);
    }
}
```

This class has a method of `Run()` without the `static` modifier. Therefore this class allows dependency injection. It currently has the `Helper` instance as its dependency.

Now, we need to prepare dependencies using [`Autofac`](https://autofac.org/)'s container builder. You can add dependencies individually, but it's easier to use `RegisterModule()` method.

```csharp
public class WebJobModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<Helper>().AsSelf().InstancePerDependency();
        builder.RegisterType<Functions>().AsSelf().InstancePerDependency();
    }
}
```

Finally, we need to create an instance of `AutofacJobHostBuilder` to create a WebJob host and run it.

```csharp
public static class Program
{
    // Initialises the WebJob host builder by injecting dependencies and configurations
    public static IJobHostBuilder WebJobHost { get; set; } = new AutofacJobHostBuilder(new WebJobModule())
                                                                 .AddConfiguration(p => p.UseDevelopmentSettingsIfNecessary())
                                                                 // Add as many number of extensions as possible
                                                                 .AddConfiguration(p => p.UseTimers())
                                                                 .AddConfiguration(p => p.UserSendGrid())
                                                                 ;
    public static void Main()
    {
        WebJobHost.BuildHost();
        WebJobHost.IsRunning = true;
        WebJobHost.RunAndBlock();
    }
}
```

By implementing WebJob host in this way, we can easily test all instances including the `Program.cs` class.

```csharp
[TestClass]
public class ProgramTests
{
    [TestMethod]
    public void Given_JobHostBuilder_Main_ShouldReturn_Result()
    {
        // Mock IJobHostBuilder
        var builder = new Mock<IJobHostBuilder>();
        builder.SetupProperty(p => p.IsRunning);

        // Inject the mocked instance
        Program.WebJobHost = builder.Object;

        // Run the method
        Program.Main();

        // Check the result
        builder.Object.IsRunning.Should().BeTrue();
    }
}
```


## Exetending `WebJobActivator.Core` ##

If you want to use another IoC container library, extending `WebJobActivator.Core` couldn't be easier. Here is how `WebJobActivator.Autofac` extends it.


### Extending `WebJobActivator` ###

First of all, `WebJobActivator` class needs to be extended:

```csharp
public class AutofacJobActivator : Core.WebJobActivator
{
    private readonly ContainerBuilder _builder;
    private IContainer _container;

    public AutofacJobActivator()
    {
        this._builder = new ContainerBuilder();
    }

    public override IWebJobActivator RegisterDependencies<THandler>(THandler handler = default(THandler))
    {
        if (handler == null)
        {
            this._container = this._builder.Build();
            return this;
        }

        ...

        this._container = this._builder.Build();
        return this;
    }

    public override T CreateInstance<T>()
    {
        return this._container.Resolve<T>();
    }
}
```


### Extending `RegistrationHandler` ###

As `WebJobActivator` optionally requires `RegistrationHandler`, it would be great to extend it so that your preferred IoC container can easily register dependencies.

```csharp
public class AutofacRegistrationHandler : RegistrationHandler
{
    public Action<ContainerBuilder> RegisterModule { get; set; }

    public Action<ContainerBuilder> RegisterType { get; set; }
}
```

For `Autofac`, the handler contains `RegisterModule` to register depdendencies all one go, or `RegisterType` to register dependencies individually.


### Extending `JobHostBuilder` ###

Finally, in order to build `JobHost` with `Autofac`, we need to extend `JobHostBuilder`.

```csharp
public class AutofacJobHostBuilder : JobHostBuilder
{
    public AutofacJobHostBuilder(IModule module)
        : this(GetJobHostConfiguration(module))
    {
    }

    private static JobHostConfiguration GetJobHostConfiguration(IModule module)
    {
        if (module == null)
        {
            return null;
        }

        var handler = new AutofacRegistrationHandler() { RegisterModule = p => p.RegisterModule(module) };
        var activator = new AutofacJobActivator().RegisterDependencies(handler);
        var builder = new JobHostConfigurationBuilder(activator);

        return builder.Build();
    }
}
```

This is specific implementation for `Autofac`. As long as a module is ready, it builds `JobHost` for WebJob controller to use.

The example above is only for `Autofac`. However, if you prefer using [`SimpleInjector`](https://simpleinjector.org/), [`Ninject`](http://www.ninject.org/) or anything else for your IoC container library, you can easily integrate it like above.


## Limitations ##

* **WebJobActivator** won't support .NET Standard until the referencing [Azure WebJob SDK](https://www.nuget.org/packages/Microsoft.Azure.WebJobs/) supports it.


## Contributions ##

Your contributions are always welcome! All your work should be done in your forked repository. Once you finish your work with corresponding tests, please send us a pull request onto our `dev` branch for review.


## License ##

**WebJobActivator** is released under [MIT License](http://opensource.org/licenses/MIT)

> The MIT License (MIT)
>
> Copyright (c) 2017 [Aliencube Community](http://aliencube.org)
> 
> Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
> 
> The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
> 
> THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
