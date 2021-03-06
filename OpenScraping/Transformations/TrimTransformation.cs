﻿// -----------------------------------------------------------------------
// <copyright file="TrimTransformation.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace OpenScraping.Transformations
{
    using HtmlAgilityPack;
    using System.Collections.Generic;

    public class TrimTransformation : ITransformationFromObject, ITransformationFromHtml
    {
        public object Transform(Dictionary<string, object> settings, object input)
        {
            if (input != null && input is string)
            {
                var text = (string)input;
                return text.Trim();
            }

            return null;
        }

        public object Transform(Dictionary<string, object> settings, HtmlNodeNavigator nodeNavigator, List<HtmlAgilityPack.HtmlNode> logicalParents)
        {
            var text = nodeNavigator?.Value ?? nodeNavigator?.CurrentNode?.InnerText;

            if (text != null)
            {
                return text.Trim();
            }

            return null;
        }
    }
}
