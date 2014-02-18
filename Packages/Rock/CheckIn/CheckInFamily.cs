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
using System.Collections.Generic;
using System.Runtime.Serialization;

using Rock.Model;

namespace Rock.CheckIn
{
    /// <summary>
    /// A family option for the current check-in
    /// </summary>
    [DataContract]
    public class CheckInFamily : DotLiquid.ILiquidizable
    {
        /// <summary>
        /// Gets or sets the group.
        /// </summary>
        /// <value>
        /// The group.
        /// </value>
        [DataMember]
        public Group Group { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="CheckInFamily" /> is selected for check-in
        /// </summary>
        /// <value>
        ///   <c>true</c> if selected; otherwise, <c>false</c>.
        /// </value>
        [DataMember]
        public bool Selected { get; set; }

        /// <summary>
        /// Gets or sets the people that this family can check-in
        /// </summary>
        /// <value>
        /// The people.
        /// </value>
        [DataMember]
        public List<CheckInPerson> People { get; set; }

        /// <summary>
        /// An optional value that can be set to display family name.  If not set, the Group name will be used
        /// </summary>
        [DataMember]
        public string Caption { get; set; }

        /// <summary>
        /// Gets or sets the sub caption.
        /// </summary>
        /// <value>
        /// The sub caption.
        /// </value>
        [DataMember]
        public string SubCaption { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckInFamily" /> class.
        /// </summary>
        public CheckInFamily()
            : base()
        {
            People = new List<CheckInPerson>();
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            if ( !string.IsNullOrWhiteSpace( Caption ) )
            {
                return Caption;
            }
            else
            {
                return Group != null ? Group.ToString() : string.Empty;
            }
        }

        /// <summary>
        /// To the liquid.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public object ToLiquid()
        {
            var dictionary = new Dictionary<string, object>();
            dictionary.Add( "Group", Group );
            dictionary.Add( "Selected", Selected );
            dictionary.Add( "People", People );
            dictionary.Add( "Caption", Caption );
            dictionary.Add( "SubCaption", SubCaption );
            return dictionary;
        }
    }
}