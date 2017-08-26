using Aliencube.WebJobActivator.Core;

using Autofac;

namespace Aliencube.WebJobActivator.Autofac
{
    /// <summary>
    /// This represents the activator entity for WebJob using Autofac.
    /// </summary>
    public class AutofacJobActivator : Core.WebJobActivator
    {
        private readonly ContainerBuilder _builder;

        private IContainer _container;

        /// <summary>
        /// Initializes a new instance of the <see cref="AutofacJobActivator"/> class.
        /// </summary>
        public AutofacJobActivator()
        {
            this._builder = new ContainerBuilder();
        }

        /// <inheritdoc />
        public override IWebJobActivator RegisterDependencies<THandler>(THandler handler = default(THandler))
        {
            if (handler == null)
            {
                return this;
            }

            var autofac = handler as AutofacRegistrationHandler;
            if (autofac == null)
            {
                return this;
            }

            if (autofac.RegisterModule != null)
            {
                autofac.RegisterModule.Invoke(this._builder);
            }

            if (autofac.RegisterType != null)
            {
                autofac.RegisterType.Invoke(this._builder);
            }

            handler.IsRegistered = true;

            this._container = this._builder.Build();

            return this;
        }

        /// <inheritdoc />
        public override T CreateInstance<T>()
        {
            return this._container.Resolve<T>();
        }
    }
}
