﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.16.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace IntelligenAPICaller.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;

    public partial class DOListboxItem
    {
        /// <summary>
        /// Initializes a new instance of the DOListboxItem class.
        /// </summary>
        public DOListboxItem() { }

        /// <summary>
        /// Initializes a new instance of the DOListboxItem class.
        /// </summary>
        public DOListboxItem(string text = default(string), string value = default(string))
        {
            Text = text;
            Value = value;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Text")]
        public string Text { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Value")]
        public string Value { get; set; }

    }
}
