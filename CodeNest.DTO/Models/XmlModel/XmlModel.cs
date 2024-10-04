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
    public class XmlModel 
    {
        public int NodeCount;

        public string? Name { get; set; }

        public string? XmlInput { get; set; }

        public string? BeautifiedXml { get; set; }

        public string? WorkSpaceId { get; set; }
        public string? Version { get; set; }
    }
}
