﻿using Microsoft.AnalysisServices.Tabular;
using System.ComponentModel;
using TabularEditor.PropertyGridUI;
using System;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;
using TOM = Microsoft.AnalysisServices.Tabular;

namespace TabularEditor.TOMWrapper
{
    public partial class Culture: IDynamicPropertyObject
    {
        internal override void Undelete(ITabularObjectCollection collection)
        {
            var tom = new TOM.Culture();
            MetadataObject.CopyTo(tom);
            tom.IsRemoved = false;
            MetadataObject = tom;

            base.Undelete(collection);
        }

        [Browsable(false)]
        public bool Unassigned { get; private set; } = false;

        public Culture() : base(TabularModelHandler.Singleton, new Microsoft.AnalysisServices.Tabular.Culture() { Name = TabularModelHandler.Singleton.Model.Cultures.MetadataObjectCollection.GetNewName("Culture") }, false)
        {
            Unassigned = true;
        }

        [Browsable(false)]
        public string DisplayName {
            get {
                if (_displayName == null) UpdateDisplayName();
                return _displayName;
            }
        }
        private string _displayName = null;

        protected override void OnPropertyChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnPropertyChanged(propertyName, oldValue, newValue);
            if (propertyName == "Name") base.OnPropertyChanged("DisplayName", null, newValue);
        }

        [Browsable(false)]
        public ObjectTranslationCollection ObjectTranslations { get { return MetadataObject.ObjectTranslations; } }

        public bool Browsable(string propertyName)
        {
            switch(propertyName)
            {
                case "Name":
                case "ObjectType":
                    return true;
                default: return false;
            }
            
        }

        public bool Editable(string propertyName)
        {
            return propertyName == "Name";
        }

        [TypeConverter(typeof(CultureConverter)), NoMultiselect()]
        public override string Name
        {
            get
            {
                return MetadataObject.Name;
            }

            set
            {
                Unassigned = false;
                MetadataObject.Name = value;
                UpdateDisplayName();
            }
        }

        private void UpdateDisplayName()
        {
            _displayName = Unassigned ? Name : string.Format("{0} -- ({1})", CultureInfo.GetCultureInfo(Name).DisplayName, Name);
        }
    }

    public class CultureConverter: TypeConverter
    {
        Dictionary<string, CultureInfo> Cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures).ToDictionary(c => c.Name, c => c);

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(Cultures.Values.OrderBy(c => c.DisplayName).Select(c => c.Name + " - " + c.DisplayName).ToList());
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(string);
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string)
            {
                return (value as string).Split(' ').First();
            }
            else
                throw new InvalidOperationException();
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if(value is string)
            {
                var cn = (value as string).Split(' ').First();
                CultureInfo c;
                if(Cultures.TryGetValue(cn, out c))
                {
                    return c.Name + " - " + c.DisplayName;
                }
                return "Unknown culture";
            }
            else
                throw new InvalidOperationException();
        }        
    }
}
