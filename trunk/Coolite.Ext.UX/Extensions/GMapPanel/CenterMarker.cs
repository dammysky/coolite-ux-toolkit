﻿/******** 
* Copyright (c) 2008 Coolite Inc.

* Permission is hereby granted, free of charge, to any person obtaining a copy
* of this software and associated documentation files (the "Software"), to deal
* in the Software without restriction, including without limitation the rights
* to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
* copies of the Software, and to permit persons to whom the Software is
* furnished to do so, subject to the following conditions:

* The above copyright notice and this permission notice shall be included in
* all copies or substantial portions of the Software.

* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
* IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
* FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
* AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
* LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
* OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
* THE SOFTWARE.

* @version:	    0.7.0
* @author:	    Coolite Inc. http://www.coolite.com/
* @date:		2008-11-21
* @copyright:   Copyright (c) 2006-2008, Coolite Inc, or as noted within each 
* 			    applicable file LICENSE.txt file
* @license:	    MIT
* @website:	    http://www.coolite.com/
********/

using System.ComponentModel;
using Coolite.Ext.Web;

namespace Coolite.Ext.UX
{
    public class CenterMarker : Marker
    {
        [ClientConfig("geoCodeAddr")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("Sends a request to Google servers to geocode the specified address.")]
        public string GeoCodeAddress
        {
            get
            {
                object o = this.ViewState["GeoCodeAddress"];
                return o != null ? (string)o : "";
            }
            set
            {
                this.ViewState["GeoCodeAddress"] = value;
            }
        }
    }
}
