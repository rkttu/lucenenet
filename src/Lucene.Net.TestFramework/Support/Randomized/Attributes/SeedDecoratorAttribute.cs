﻿#if FEATURE_RANDOMIZEDCONTEXT
/*
 * Licensed to the Apache Software Foundation (ASF) under one or more
 * contributor license agreements.  See the NOTICE file distributed with
 * this work for additional information regarding copyright ownership.
 * The ASF licenses this file to You under the Apache License, Version 2.0
 * (the "License"); you may not use this file except in compliance with
 * the License.  You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Lucene.Net.Randomized.Attributes
{
    // LUCENENET NOTE: Not used (and not CLS compliant because of the constructor),
    // so marking internal instead of public
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    internal class SeedDecoratorAttribute : System.Attribute
    {
        public IList<Type> Decorators { get; set; }

        public SeedDecoratorAttribute(params Type[] decorators)
        {
            this.Decorators = new List<Type>();

            foreach (Type item in decorators)
            {
                if (item.ImplementedInterfaces.Contains(typeof(ISeedDecorator)))
                    this.Decorators.Add(item);
            }
        }
    }
}
#endif