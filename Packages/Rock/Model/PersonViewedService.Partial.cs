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
using System.Linq;

using Rock.Data;

namespace Rock.Model
{
    /// <summary>
    /// Data Access/service class for <see cref="Rock.Model.PersonViewed"/> entities.
    /// </summary>
    public partial class PersonViewedService 
    {
        /// <summary>
        /// Returns an enumerable collection of <see cref="Rock.Model.PersonViewed"/> entities by the Id of the Target <see cref="Rock.Model.Person"/>
        /// </summary>
        /// <param name="targetPersonId">An <see cref="System.Int32"/> representing the Id of the Target <see cref="Rock.Model.Person"/> to search by.</param>
        /// <returns>An enumerable collection of <see cref="Rock.Model.PersonViewed"/> entities where the Id of the target <see cref="Rock.Model.Person"/> matches the provided value.</returns>
        public IEnumerable<PersonViewed> GetByTargetPersonId( int? targetPersonId )
        {
            return Repository.Find( t => ( t.TargetPersonId == targetPersonId || ( targetPersonId == null && t.TargetPersonId == null ) ) );
        }
        
        /// <summary>
        /// Returns an enumerable collection of <see cref="Rock.Model.PersonViewed"/> entities by the Id of the Viewer <see cref="Rock.Model.Person"/>.
        /// </summary>
        /// <param name="viewerPersonId">A <see cref="System.Int32"/> representing the Id of the Viewer <see cref="Rock.Model.Person"/></param>
        /// <returns>An enumerable collection of <see cref="Rock.Model.PersonViewed"/> entities where the Id of the viewer <see cref="Rock.Model.Person"/> matches the provided value.</returns>
        public IEnumerable<PersonViewed> GetByViewerPersonId( int? viewerPersonId )
        {
            return Repository.Find( t => ( t.ViewerPersonId == viewerPersonId || ( viewerPersonId == null && t.ViewerPersonId == null ) ) );
        }
    }
}
