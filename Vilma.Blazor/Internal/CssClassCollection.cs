using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vilma.Blazor.Internal
{
    /// <summary>
    /// Custom list created to hold and manipulate css classes.
    /// </summary>
    internal class CssClassCollection : HashSet<string>
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public CssClassCollection() : base() { }

        /// <summary>
        /// Creates a new instance and adds all the classes 
        /// passed. Classes can be a single class name or
        /// multiple classes separed by space.
        /// </summary>
        /// <param name="classes">Space separed class values to add</param>
        public CssClassCollection(string? classes) : base()
        {
            if (!string.IsNullOrWhiteSpace(classes))
                AddClasses(classes);
        }

        /// <summary>
        /// Add a new Css Class to the list. A check is performed
        /// before the new value is added, if the value doesn't 
        /// exists it will be added. If value exists in the list
        /// this value won't be added.
        /// </summary>
        /// <param name="cssClass"></param>
        public new void Add(string cssClass)
        {
            if (!Contains(cssClass))
            {
                base.Add(cssClass);
            }
        }


        /// <summary>
        /// Adds a list of css classes separed by 'space'
        /// </summary>
        /// <param name="classes">Css classes list separed by spaces</param>
        public void AddClasses(string? classes)
        {
            if (!string.IsNullOrWhiteSpace(classes))
            {
                var tokens = classes.Split(' ');

                foreach (var token in tokens)
                {
                    Add(token);
                }
            }
        }

        /// <summary>
        /// Return an string containing all the classes of this
        /// list separed by 'space'
        /// </summary>
        /// <returns>A list of css classes separed by spaces</returns>
        public override string ToString()
        {
            return string.Join(' ', this);
        }

        /// <summary>
        /// Returns all the classes of this list as a class HTML attribute
        /// </summary>
        /// <returns></returns>
        public string ToClassAttribute()
        {
            var classes = ToString();

            if (classes.Length > 0)
            {
                return $"class=\"{classes}\"";
            }

            return "";
        }

        /// <summary>
        /// Returns an attributes dictionary containing the classes defined in this list.
        /// If the parameter existingDictionary is provided, it verifies if the class
        /// attribute is present. If class attribute is present it appends the classes 
        /// after the existing ones. If no existing class attribute is present, it will 
        /// create this attribute.
        /// If no dictionary is provided, a new one is created and returned.
        /// </summary>
        /// <param name="existingDictionary">An existing dictionary of attributes</param>
        /// <returns>A dictionary with the new css classes added.</returns>
        public Dictionary<string, object> ToAttributesDictionary(Dictionary<string, object>? existingDictionary = null)
        {
            Dictionary<string, object> dict;
            var classes = ToString();

            if (existingDictionary != null)
                dict = existingDictionary;
            else
                dict = new Dictionary<string, object>();


            if (classes.Length > 0)
            {
                if (dict.ContainsKey("class"))
                {
                    dict["classes"] += " " + classes;
                }
                else
                {
                    dict.Add("class", classes);
                }
            }

            return dict;
        }
    }
}
