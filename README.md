# WebJobActivator #

[BADGE_HERE]

This provides core implementations of `IJobActivator` for Azure WebJob to be used by various IoC container libraries.


## Overview ##

Azure WebJob SDK provides the `IJobActivator` interface so that we can easily manage dependencies. `WebJobActivator.Core` provides abstraction classes that are inherited and interfaces that are implemented by IoC container libraries. `WebJobActivator.Autofac` is one of implementations using `WebJobActivator.Core`.


## Getting Started ##

### `WebJobActivator.Autofac` ###

TBD


### `WebJobActivator.Core` ###

TBD


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
