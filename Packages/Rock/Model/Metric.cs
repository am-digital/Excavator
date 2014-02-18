﻿// <copyright>
// Copyright 2013 by the Spark Development Network
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Runtime.Serialization;

using Rock.Data;

namespace Rock.Model
{
    /// <summary>
    /// Metric POCO Entity.
    /// </summary>
    [Table( "Metric" )]
    [DataContract]
    public partial class Metric : Model<Metric>, IOrdered
    {
        /// <summary>
        /// Gets or sets a flag indicating if this Metric is part of the Rock core system/framework. This property is required.
        /// </summary>
        /// <value>
        /// A <see cref="System.Boolean"/> that is <c>true</c> if the Metric is part of the core system/framework; otherwise <c>false</c>.
        /// </value>
        [Required]
        [DataMember( IsRequired = true )]
        public bool IsSystem { get; set; }
        
        /// <summary>
        /// Gets or sets a flag indicating if this Metric supports multiple values.
        /// </summary>
        /// <value>
        /// A <see cref="System.Boolean"/> that is <c>true</c> if it supports multiple values; otherwise <c>false</c>.
        /// </value>
        [DataMember]
        public bool Type { get; set; }
        
        /// <summary>
        /// Gets or sets the category that this Metric belongs to.
        /// </summary>
        /// <value>
        /// A <see cref="System.String"/> representing the category that this Metric belongs to.
        /// </value>
        [MaxLength( 100 )]
        [DataMember]
        public string Category { get; set; }
        
        /// <summary>
        /// Gets or sets the Title of this Metric.
        /// </summary>
        /// <value>
        /// A <see cref="System.String"/> representing the user defined title of this Metric. This property is required.
        /// </value>
        [Required]
        [MaxLength( 100 )]
        [DataMember( IsRequired = true )]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the Subtitle of the Metric.
        /// </summary>
        /// <value>
        /// A <see cref="System.String"/> representing the Subtitle of the Metric.
        /// </value>
        [MaxLength( 100 )]
        [DataMember]
        public string Subtitle { get; set; }
    
        /// <summary>
        /// Gets or sets a user defined description of the Metric.
        /// </summary>
        /// <value>
        /// A <see cref="System.String"/> representing the description of the Metric.
        /// </value>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Minimum Value for the Metric.
        /// </summary>
        /// <value>
        /// A <see cref="System.Int32"/> representing the minimum value for the Metric. If no minimum is provided, this value will be null.
        /// </value>
        [DataMember]
        public int? MinValue { get; set; }

        /// <summary>
        /// Gets or sets the Maximum Value for the Metric.
        /// </summary>
        /// <value>
        /// A <see cref="System.Int32"/> representing the Maximum Value for the Metric. If no maximum value is provided, this value will be null.
        /// </value>
        [DataMember]
        public int? MaxValue { get; set; }

        /// <summary>
        /// Gets or sets the DefinedValueId of the CollectionFrequency <see cref="Rock.Model.DefinedValue"/> that indicates how often data for the Metric
        /// will be collected.
        /// </summary>
        /// <value>
        /// A <see cref="System.Int32"/> representing the DefinedValueId of the CollectionFrequency <see cref="Rock.Model.DefinedValue"/> that indicates how often 
        /// data for the Metric is collected.
        /// </value>
        [DataMember]
        public int? CollectionFrequencyValueId { get; set; }

        /// <summary>
        /// Gets or sets the date and time that data for this Metric was last collected 
        /// </summary>
        /// <value>
        /// A <see cref="System.DateTime"/> that represents the last time that data for this Metric was last collected.
        /// </value>
        [DataMember]
        public DateTime? LastCollectedDateTime { get; set; }

        /// <summary>
        /// Gets or sets a value that describes the data source of the metric.
        /// </summary>
        /// <value>
        /// A <see cref="System.String"/> that describes the data source of the metric.
        /// </value>
        [MaxLength( 100 )]
        [DataMember]
        public string Source { get; set; }

        /// <summary>
        /// Gets or sets the SQL query that returns the data for the Metric.
        /// </summary>
        /// <value>
        /// A <see cref="System.String"/> that represents the SQL Query that returns the data for the Metric.
        /// </value>
        [DataMember]
        public string SourceSQL { get; set; }

        /// <summary>
        /// Gets or sets the display order for the Metric. Metric order is in ascending order, so the lower the number the higher the display priority for the Metric. This value is required.
        /// </summary>
        /// <value>
        /// A <see cref="System.Int32" /> representing the display order for this Metric.
        /// </value>
        [Required]
        [DataMember( IsRequired = true )]
        public int Order { get; set; }

        /// <summary>
        /// Gets or sets a collection that contains all the <see cref="MetricValue">Metric Values</see> (values) for this Metric.
        /// </summary>
        /// <value>
        /// A collection of <see cref="Rock.Model.MetricValue">MetricValues</see> that are associated with this Metric.
        /// </value>
        [DataMember]
        public virtual ICollection<MetricValue> MetricValues { get; set; }

        /// <summary>
        /// Gets or sets the CollectionFrequency <see cref="Rock.Model.DefinedValue"/> that is associated with this Metric. How often the data for this Metric should be retrieved.
        /// </summary>
        /// <value>
        /// A <see cref="Rock.Model.DefinedValue"/> that represents how often the data for this Metric should be retrieved.
        /// </value>
        [DataMember]
        public virtual Model.DefinedValue CollectionFrequencyValue { get; set; }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this Metric
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this Metric
        /// </returns>
        public override string ToString()
        {
            return this.Title;
        }
    }
    /// <summary>
    /// Metric Configuration class.
    /// </summary>
    public partial class MetricConfiguration : EntityTypeConfiguration<Metric>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MetricConfiguration"/> class.
        /// </summary>
        public MetricConfiguration()
        {
            this.HasOptional( p => p.CollectionFrequencyValue ).WithMany().HasForeignKey( p => p.CollectionFrequencyValueId ).WillCascadeOnDelete( false );
        }
    }
}
