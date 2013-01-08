﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Cfg;
using NHibernate;
using FluentNHibernate.Cfg;
using System.IO;
using System.Reflection;
using FluentNHibernate.Cfg.Db;
using NHibernate.Tool.hbm2ddl;

namespace KeWeiOMS.NhibernateHelper
{
    public class NHibernateHelper
    {

        private static ISessionFactory sessionFactory = null;

        public static ISessionFactory SessionFactory
        {
            get
            {
                if (sessionFactory == null)
                {

                    FluentConfiguration fluentConfiguration = Fluently.Configure().Database(
             MsSqlConfiguration.MsSql2008.ConnectionString(
             c => c.FromConnectionStringWithKey("db")));
                    string path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
                    string assemblyFile = Path.Combine(path, "bin/KeWeiOMS.Domain.dll");
                    fluentConfiguration.Mappings(delegate(MappingConfiguration m)
                    {
                        Assembly assembly = Assembly.LoadFrom(assemblyFile);
                        m.HbmMappings.AddFromAssembly(assembly);
                        m.FluentMappings.AddFromAssembly(assembly).Conventions.AddAssembly(assembly);
                    });
                    return fluentConfiguration.BuildSessionFactory();
                }
                else
                {
                    return sessionFactory;
                }
            }
        }

        public static ISession CreateSession()
        {
            return SessionFactory.OpenSession();
        }


        private static void BuildSchema(Configuration config)
        {
          
            new SchemaExport(config)
                .Create(false, true);
        }

    }
}
