using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leftover10
{
    using System.Xml.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            XDocument doc = GetStarbuzzData();
            Console.WriteLine(doc.ToString());
            doc.Save("starbuzzData.xml");
            XDocument anotherDoc = XDocument.Load("starbuzzData.xml");

            var data = from item in doc.Descendants("person")
                       select new
                       {
                           drink = item.Element("favoriteDrink").Value,
                           moneySpent = item.Element("moneySpent").Value,
                           zipCode = item.Element("personalInfo").Element("zip").Value
                       };
            foreach (var p in data)
                Console.WriteLine(p.ToString());

            var zipcodeGroups = from item in doc.Descendants("person")
                                group item.Element("favoriteDrink").Value
                                by item.Element("personalInfo").Element("zip").Value
                                    into zipcodeGroup
                                    select zipcodeGroup;
            foreach (var group in zipcodeGroups)
                Console.WriteLine("{0} favorite drinks in {1}",
                                group.Distinct().Count(), group.Key);

            XDocument ourBlog = XDocument.Load("http://www.stellman-greene.com/feed");
            Console.WriteLine(ourBlog.Element("rss").Element("channel").Element("title").Value);
            var posts = from post in ourBlog.Descendants("item")
                        select new
                        {
                            Title = post.Element("title").Value,
                            Date = post.Element("pubDate").Value
                        };
            foreach (var post in posts)
                Console.WriteLine(post.ToString());
        }

        private static XDocument GetStarbuzzData()
        {
            XDocument doc = new XDocument(
               new XDeclaration("1.0", "utf-8", "yes"),
               new XComment("Starbuzz Customer Loyalty Data"),
               new XElement("starbuzzData",
                   new XAttribute("storeName", "Park Slope"),
                   new XAttribute("location", "Brooklyn, NY"),
                   new XElement("person",
                       new XElement("personalInfo",
                           new XElement("name", "Janet Venutian"),
                           new XElement("zip", 11215)),
                       new XElement("favoriteDrink", "Choco Macchiato"),
                       new XElement("moneySpent", 255),
                       new XElement("visits", 50)),
                   new XElement("person",
                       new XElement("personalInfo",
                           new XElement("name", "Liz Nelson"),
                           new XElement("zip", 11238)),
                       new XElement("favoriteDrink", "Double Cappuccino"),
                       new XElement("moneySpent", 150),
                       new XElement("visits", 35)),
                   new XElement("person",
                       new XElement("personalInfo",
                           new XElement("name", "Matt Franks"),
                           new XElement("zip", 11217)),
                       new XElement("favoriteDrink", "Zesty Lemon Chai"),
                       new XElement("moneySpent", 75),
                       new XElement("visits", 15)),
                   new XElement("person",
                       new XElement("personalInfo",
                           new XElement("name", "Joe Ng"),
                           new XElement("zip", 11217)),
                       new XElement("favoriteDrink", "Banana Split in a Cup"),
                       new XElement("moneySpent", 60),
                       new XElement("visits", 10)),
                   new XElement("person",
                       new XElement("personalInfo",
                           new XElement("name", "Sarah Kalter"),
                           new XElement("zip", 11215)),
                       new XElement("favoriteDrink", "Boring Coffee"),
                       new XElement("moneySpent", 110),
                       new XElement("visits", 15))));
            return doc;
        }
    }
}
