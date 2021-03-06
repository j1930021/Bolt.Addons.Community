﻿using Ludiq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Bolt.Addons.Community.Fundamentals
{
    /// <summary>
    /// Takes a given float input (0-1) and scales it across the specified range.
    /// </summary>
    [UnitCategory("Community\\Math\\Functions")]
    [RenamedFrom("Bolt.Addons.Community.Custom_Units.Math.Functions.ExponentialFunctionOfRange")]
    [UnitTitle("Exponential Function of Range")]
    [UnitOrder(4)]
    public class ExponentialFunctionOfRange : Unit
    {
        public ExponentialFunctionOfRange() : base() { }

        /// <summary>
        /// The (0-1) input to interpolate onto the range between minimum and maximum
        /// </summary>
        [DoNotSerialize]
        [PortLabelHidden]
        public ValueInput input { get; private set; }

        /// <summary>
        /// The minimum valid output.  Returned when the input is 0.
        /// </summary>
        [DoNotSerialize]
        [PortLabel("MinimumRange")]
        public ValueInput minimumRange { get; private set; }


        /// <summary>
        /// The minimum valid output.  Returned when the input is 0.
        /// </summary>
        [DoNotSerialize]
        [PortLabel("MaximumRange")]
        public ValueInput maximumRange { get; private set; }

        /// <summary>
        /// The minimum valid output.  Returned when the input is 0.
        /// </summary>
        [DoNotSerialize]
        [PortLabel("MinimumValue")]
        public ValueInput minimumValue { get; private set; }


        /// <summary>
        /// The maximum valid output.  Returned when the input is 1.
        /// </summary>
        [DoNotSerialize]
        [PortLabel("Exponent")]
        public ValueInput exponent { get; private set; }

        /// <summary>
        /// The maximum valid output.  Returned when the input is 1.
        /// </summary>
        [DoNotSerialize]
        [PortLabel("Scale")]
        public ValueInput scale { get; private set; }


        /// <summary>
        /// The result of the interpolation (minimum-maximum).
        /// </summary>
        [DoNotSerialize]
        [PortLabelHidden]
        public ValueOutput output { get; private set; }

        [DoNotSerialize]
        protected float defaultMinimumRange => 0;

        [DoNotSerialize]
        protected float defaultMaximumRange => 100;

        [DoNotSerialize]
        protected float defaultMinimum => 0;

        [DoNotSerialize]
        protected float defaultExponent => 1;

        [DoNotSerialize]
        protected float defaultScale => 1;

        protected override void Definition()
        {
            input = ValueInput<float>(nameof(input), 0);
            minimumRange = ValueInput<float>(nameof(minimumRange),defaultMinimumRange);
            maximumRange = ValueInput<float>(nameof(maximumRange), defaultMaximumRange);
            minimumValue = ValueInput<float>(nameof(minimumValue), defaultMinimum);
            exponent = ValueInput<float>(nameof(exponent), defaultExponent);
            scale = ValueInput<float>(nameof(scale), defaultScale);
            output = ValueOutput<float>(nameof(output), (x) => output.GetValue<float>());

            Relation(minimumRange, input);
            Relation(maximumRange, input);
            Relation(input, output);
            Relation(minimumValue, output);
            Relation(exponent, output);
            Relation(scale, output);
        }

        private float Operation(Recursion recursion)
        {
            return MathLibrary.ExponentialFunctionOfRange(input.GetValue<float>(), minimumRange.GetValue<float>(), maximumRange.GetValue<float>(), maximumRange.GetValue<float>(), exponent.GetValue<float>(), scale.GetValue<float>());
        }
    }
}