using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIConsume.Models
{
    public class xmlToAddressObject
    {
        // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class prestashop
        {

            private prestashopAddress addressField;

            /// <remarks/>
            public prestashopAddress address
            {
                get
                {
                    return this.addressField;
                }
                set
                {
                    this.addressField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class prestashopAddress
        {

            private string idField;

            private prestashopAddressId_customer id_customerField;

            private string id_manufacturerField;

            private string id_supplierField;

            private string id_warehouseField;

            private prestashopAddressId_country id_countryField;

            private string id_stateField;

            private string aliasField;

            private string companyField;

            private string lastnameField;

            private string firstnameField;

            private string vat_numberField;

            private string address1Field;

            private object address2Field;

            private string postcodeField;

            private string cityField;

            private object otherField;

            private string phoneField;

            private string phone_mobileField;

            private string dniField;

            private string deletedField;

            private string date_addField;

            private string date_updField;

            /// <remarks/>
            public string id
            {
                get
                {
                    return this.idField;
                }
                set
                {
                    this.idField = value;
                }
            }

            /// <remarks/>
            public prestashopAddressId_customer id_customer
            {
                get
                {
                    return this.id_customerField;
                }
                set
                {
                    this.id_customerField = value;
                }
            }

            /// <remarks/>
            public string id_manufacturer
            {
                get
                {
                    return this.id_manufacturerField;
                }
                set
                {
                    this.id_manufacturerField = value;
                }
            }

            /// <remarks/>
            public string id_supplier
            {
                get
                {
                    return this.id_supplierField;
                }
                set
                {
                    this.id_supplierField = value;
                }
            }

            /// <remarks/>
            public string id_warehouse
            {
                get
                {
                    return this.id_warehouseField;
                }
                set
                {
                    this.id_warehouseField = value;
                }
            }

            /// <remarks/>
            public prestashopAddressId_country id_country
            {
                get
                {
                    return this.id_countryField;
                }
                set
                {
                    this.id_countryField = value;
                }
            }

            /// <remarks/>
            public string id_state
            {
                get
                {
                    return this.id_stateField;
                }
                set
                {
                    this.id_stateField = value;
                }
            }

            /// <remarks/>
            public string alias
            {
                get
                {
                    return this.aliasField;
                }
                set
                {
                    this.aliasField = value;
                }
            }

            /// <remarks/>
            public string company
            {
                get
                {
                    return this.companyField;
                }
                set
                {
                    this.companyField = value;
                }
            }

            /// <remarks/>
            public string lastname
            {
                get
                {
                    return this.lastnameField;
                }
                set
                {
                    this.lastnameField = value;
                }
            }

            /// <remarks/>
            public string firstname
            {
                get
                {
                    return this.firstnameField;
                }
                set
                {
                    this.firstnameField = value;
                }
            }

            /// <remarks/>
            public string vat_number
            {
                get
                {
                    return this.vat_numberField;
                }
                set
                {
                    this.vat_numberField = value;
                }
            }

            /// <remarks/>
            public string address1
            {
                get
                {
                    return this.address1Field;
                }
                set
                {
                    this.address1Field = value;
                }
            }

            /// <remarks/>
            public object address2
            {
                get
                {
                    return this.address2Field;
                }
                set
                {
                    this.address2Field = value;
                }
            }

            /// <remarks/>
            public string postcode
            {
                get
                {
                    return this.postcodeField;
                }
                set
                {
                    this.postcodeField = value;
                }
            }

            /// <remarks/>
            public string city
            {
                get
                {
                    return this.cityField;
                }
                set
                {
                    this.cityField = value;
                }
            }

            /// <remarks/>
            public object other
            {
                get
                {
                    return this.otherField;
                }
                set
                {
                    this.otherField = value;
                }
            }

            /// <remarks/>
            public string phone
            {
                get
                {
                    return this.phoneField;
                }
                set
                {
                    this.phoneField = value;
                }
            }

            /// <remarks/>
            public string phone_mobile
            {
                get
                {
                    return this.phone_mobileField;
                }
                set
                {
                    this.phone_mobileField = value;
                }
            }

            /// <remarks/>
            public string dni
            {
                get
                {
                    return this.dniField;
                }
                set
                {
                    this.dniField = value;
                }
            }

            /// <remarks/>
            public string deleted
            {
                get
                {
                    return this.deletedField;
                }
                set
                {
                    this.deletedField = value;
                }
            }

            /// <remarks/>
            public string date_add
            {
                get
                {
                    return this.date_addField;
                }
                set
                {
                    this.date_addField = value;
                }
            }

            /// <remarks/>
            public string date_upd
            {
                get
                {
                    return this.date_updField;
                }
                set
                {
                    this.date_updField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class prestashopAddressId_customer
        {

            private string hrefField;

            private string valueField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/xlink")]
            public string href
            {
                get
                {
                    return this.hrefField;
                }
                set
                {
                    this.hrefField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlTextAttribute()]
            public string Value
            {
                get
                {
                    return this.valueField;
                }
                set
                {
                    this.valueField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class prestashopAddressId_country
        {

            private string hrefField;

            private string valueField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/xlink")]
            public string href
            {
                get
                {
                    return this.hrefField;
                }
                set
                {
                    this.hrefField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlTextAttribute()]
            public string Value
            {
                get
                {
                    return this.valueField;
                }
                set
                {
                    this.valueField = value;
                }
            }
        }


    }
}
