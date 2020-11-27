﻿using Fluxor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Client.Shared
{
    public class LoggingMiddleware : Middleware
    {
        private IStore Store;

        public override Task InitializeAsync(IStore store)
        {
            Store = store;
            Console.WriteLine(nameof(InitializeAsync));
            return Task.CompletedTask;
        }

        public override void AfterInitializeAllMiddlewares()
        {
            Console.WriteLine(nameof(AfterInitializeAllMiddlewares));
        }

        public override bool MayDispatchAction(object action)
        {
            Console.WriteLine(nameof(MayDispatchAction) + ObjectInfo(action));
            return true;
        }

        public override void BeforeDispatch(object action)
        {
            Console.WriteLine(nameof(BeforeDispatch) + ObjectInfo(action));
        }

        public override void AfterDispatch(object action)
        {
            Console.WriteLine(nameof(AfterDispatch) + ObjectInfo(action));
            Console.WriteLine();
        }

        private string ObjectInfo(object obj)
            => ": " + obj.GetType().Name + " " + JsonConvert.SerializeObject(obj, Formatting.Indented);
    }
}