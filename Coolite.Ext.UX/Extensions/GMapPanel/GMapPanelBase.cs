﻿/******** 
* Copyright (c) 2009 Coolite Inc.

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

* @version:	    0.8.0
* @author:	    Coolite Inc. http://www.coolite.com/
* @date:		2008-05-25
* @copyright:   Copyright (c) 2006-2009, Coolite Inc, or as noted within each 
* 			    applicable file LICENSE.txt file
* @license:	    MIT
* @website:	    http://www.coolite.com/
********/

using System.ComponentModel;
using System.Web;
using System.Web.UI;
using Coolite.Ext.Web;

namespace Coolite.Ext.UX
{
    public abstract class GMapPanelBase : Panel
    {
        [Browsable(false)]
        public override ITemplate Body
        {
            get { return null; }
            set { base.Body = value; }
        }

        [Browsable(false)]
        [ClientConfig(JsonMode.Ignore)]
        public override string Html
        {
            get { return base.Html; }
            set { base.Html = value; }
        }

        [Browsable(false)]
        public override void UpdateBody(string text)
        {
            //base.UpdateContent(text);
        }

        [Browsable(false)]
        [ClientConfig(JsonMode.Ignore)]
        public override string ContentEl
        {
            get { return base.ContentEl; }
        }

        [ClientConfig]
        [DefaultValue(3)]
        [NotifyParentProperty(true)]
        [Description("The zoom level of the blowup map in the info window.")]
        public int ZoomLevel
        {
            get
            {
                object o = this.ViewState["ZoomLevel"];
                return o != null ? (int) o : 3; 
            }
            set
            {
                this.ViewState["ZoomLevel"] = value;
            }
        }

        [ClientConfig]
        [DefaultValue(180)]
        [NotifyParentProperty(true)]
        [Description("Used by street view. The camera yaw in degrees relative to true north. True north is 0 degrees, east is 90 degrees, south is 180 degrees, west is 270 degrees.")]
        public int Yaw
        {
            get
            {
                object o = this.ViewState["Yaw"];
                return o != null ? (int)o : 180;
            }
            set
            {
                this.ViewState["Yaw"] = value;
            }
        }

        [ClientConfig]
        [DefaultValue(0)]
        [NotifyParentProperty(true)]
        [Description("Used by street view. The camera pitch in degrees, relative to the street view vehicle. Ranges from 90 degrees (directly upwards) to -90 degrees (directly downwards).")]
        public int Pitch
        {
            get
            {
                object o = this.ViewState["Pitch"];
                return o != null ? (int)o : 0;
            }
            set
            {
                this.ViewState["Pitch"] = value;
            }
        }

        [ClientConfig]
        [DefaultValue(0)]
        [NotifyParentProperty(true)]
        [Description("Used by street view. The zoom level. Fully zoomed-out is level 0, zooming in increases the zoom level.")]
        public int Zoom
        {
            get
            {
                object o = this.ViewState["Pitch"];
                return o != null ? (int)o : 0;
            }
            set
            {
                this.ViewState["Pitch"] = value;
            }
        }

        [ClientConfig("gmapType", JsonMode.ToLower)]
        [DefaultValue(GMapType.Map)]
        [NotifyParentProperty(true)]
        [Description("GMap type")]
        public GMapType GMapType
        {
            get
            {
                object o = this.ViewState["GMapType"];
                return o != null ? (GMapType)o : GMapType.Map;
            }
            set
            {
                this.ViewState["GMapType"] = value;
            }
        }

        private MapConfiguration mapConfiguration;

        [ClientConfig("mapConfOpts",typeof(MapPropertiesJsonConverter))]
        [Category("Config Options")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [ViewStateMember]
        public MapConfiguration MapConfiguration
        {
            get
            {
                if(this.mapConfiguration == null)
                {
                    this.mapConfiguration = new MapConfiguration();
                    this.mapConfiguration.TrackViewState();
                }

                return this.mapConfiguration;
            }
        }

        private MapControls mapControls;

        [ClientConfig("mapControls",typeof(MapPropertiesJsonConverter))]
        [Category("Config Options")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [ViewStateMember]
        public MapControls MapControls
        {
            get
            {
                if (this.mapControls == null)
                {
                    this.mapControls = new MapControls();
                    this.mapControls.TrackViewState();
                }

                return this.mapControls;
            }
        }

        private CenterMarker centerMarker;

        [ClientConfig("setCenter", JsonMode.Object)]
        [Category("Config Options")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [ViewStateMember]
        public CenterMarker CenterMarker
        {
            get
            {
                if (this.centerMarker == null)
                {
                    this.centerMarker = new CenterMarker();
                    this.centerMarker.TrackViewState();
                }

                return this.centerMarker;
            }
        }

        private MarkerCollection markers;

        [ClientConfig("markers", JsonMode.AlwaysArray)]
        [Category("Config Options")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [ViewStateMember]
        public MarkerCollection Markers
        {
            get
            {
                if (this.markers == null)
                {
                    this.markers = new MarkerCollection();
                    this.markers.TrackViewState();
                }

                return this.markers;
            }
        }

        [DefaultValue("ABQIAAAAJDLv3q8BFBryRorw-851MRT2yXp_ZAY8_ufC3CFXhHIE1NvwkxTyuslsNlFqyphYqv1PCUD8WrZA2A")]
        [NotifyParentProperty(true)]
        [Description("GMaps API Key. Default key -  GMaps API Key that works for localhost")]
        public string APIKey
        {
            get
            {
                return (string)this.ViewState["ApiKey"] ?? "ABQIAAAAJDLv3q8BFBryRorw-851MRT2yXp_ZAY8_ufC3CFXhHIE1NvwkxTyuslsNlFqyphYqv1PCUD8WrZA2A";
            }
            set
            {
                this.ViewState["ApiKey"] = value;
                if(!this.DesignMode)
                {
                    HttpContext.Current.Items["GMapApiKey"] = value;
                }
            }
        }

        [DefaultValue("http://maps.google.com/maps?file=api&amp;v=2.x&amp;key={0}")]
        [NotifyParentProperty(true)]
        [Description("GMaps API Key. Default key -  GMaps API Key that works for localhost")]
        public string APIBaseUrl
        {
            get
            {
                return (string)this.ViewState["APIBaseUrl"] ?? "http://maps.google.com/maps?file=api&amp;v=2.x&amp;key={0}";
            }
            set
            {
                this.ViewState["APIBaseUrl"] = value;
            }
        }
    }
}
