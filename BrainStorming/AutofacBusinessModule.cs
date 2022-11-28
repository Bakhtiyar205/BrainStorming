using Autofac;
using Autofac.Extras.DynamicProxy;
using BrainStorming.Connection;
using BrainStorming.Intrefaces;
using Castle.DynamicProxy;
using System.Reflection;
using Module = Autofac.Module;

namespace BrainStorming
{
    public class AutofacBusinessModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<IsbService>().As<IIsbService>();

            var assembly = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
