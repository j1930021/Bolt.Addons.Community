﻿using Bolt.Addons.Community.Fundamentals;
using Ludiq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bolt.Addons.Community.Variables.Editor.UnitOptions
{
    [FuzzyOption(typeof(PlusEquals))]
    public class PlusEqualUnitOption : UnifiedVariableUnitOption<PlusEquals>
    {
        [Obsolete(Serialization.ConstructorWarning)]
        public PlusEqualUnitOption() : base() { }

        public PlusEqualUnitOption(VariableKind kind, string defaultName = null) : base(kind, defaultName) { }

        protected override string DefaultNameLabel()
        {
            return $"Plus Equal {defaultName}";
        }

        protected override string GenericLabel()
        {
            return $"Plus Equal {kind} Variable";
        }
    }
}