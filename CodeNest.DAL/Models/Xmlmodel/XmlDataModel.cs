// ***********************************************************************************************
//
//  (c) Copyright 2023, Computer Task Group, Inc. (CTG)
//
//  This software is licensed under a commercial license agreement. For the full copyright and
//  license information, please contact CTG for more information.
//
//  Description: Sample Description.
//
// ***********************************************************************************************

using CodeNest.DTO.Common.Helper;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeNest.DTO.Models.XmlModel
{
    public class XmlDataModel : Audit
    {
        [BsonId] 
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Name")]
        public string? Name { get; set; }
        [BsonElement("XmlInput")]
        public string? XmlInput { get; set; }
        [BsonElement("BeautifiedXml")]
        public string? BeautifiedXml { get; set; }
        [BsonElement("WorkSpaceId")]
        public string? WorkSpaceId { get; set; }
        [BsonElement("Version")]
        public string? Version { get; set; }
    }
}
