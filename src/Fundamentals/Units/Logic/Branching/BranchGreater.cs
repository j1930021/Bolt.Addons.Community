﻿using Ludiq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Bolt.Addons.Community.Fundamentals
{
    /// <summary>
    /// Branches flow by checking if a condition is true or false.
    /// </summary>
    [UnitCategory("Community\\Control")]
    [RenamedFrom("Bolt.Addons.Community.Logic.Units.BranchGreater")]
    [UnitOrder(1)]
    public sealed class BranchGreater : ComparisonBranch
    {
        public BranchGreater() : base() { }

        /// <summary>
        /// Whether to consider equals as true.
        /// </summary>
        [DoNotSerialize]
        public ValueInput AllowEquals { get; private set; }

        protected override void Definition()
        {
            a = ValueInput<float>(nameof(a));
            b = ValueInput<float>(nameof(b), 0);
            AllowEquals = ValueInput<bool>(nameof(AllowEquals), false);

            base.Definition();

            Relation(AllowEquals, ifTrue);
            Relation(AllowEquals, ifFalse);
        }

        public override bool Comparison()
        {
            return NumericComparison(a.GetValue<float>(), b.GetValue<float>(), AllowEquals.GetValue<bool>());
        }

        private bool NumericComparison(float a, float b, bool allowEquals)
        {
            return (a > b) || (allowEquals && Mathf.Approximately(a, b));
        }
    }
}