XmlItems-cSharp
===============

Class for loading xml and getting a collection of items based on xpath parameter

this class will handle the base functionality of loading an xml url and getting a collection of items 

The project as a whole will contain some classes to represent an individual item type , inheriting from XmlItem( YahooRssItem, etc)


the XmlItems object will parse the url and store items resulting from the xpath parameter as XElements

the purpose of the XmlItem class is to represent each individual item and store values of child nodes in properties

YahooRssItem inherits from XmlItem and will store values of the child nodes of each item first checking for the nodes existance to prevent runtime errors


The WnlDisplayMethods is a public static class intended to have public static string methods ( methods that return a string ) to write out html to webpages from the
items in XmlItems.items

Place all of the .cs file in your App_Code folder and these methods will be available to you under the OUC namespace.

An example of calling a method that adds the response to a container is in the Default.aspx.cs file 

