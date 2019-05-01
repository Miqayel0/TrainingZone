using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using TrainingZone.Core.Interfaces.Services;
using TrainingZone.EFCore.Auth;

namespace TrainingZone.EFCore
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<JwtFactory>().As<IJwtFactory>().SingleInstance();
        }
    }
}
