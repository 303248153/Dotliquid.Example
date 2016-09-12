using Dotliquid.Example.Dotliquid;
using DotLiquid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dotliquid.Example.Controllers
{
    public class HomeController : DotliquidController
    {
        public ActionResult Index()
        {
            return DotliquidView();
        }

        public ActionResult HelloWorld()
        {
            var template = Template.Parse("Hello, {{ name }}!");
            var result = template.Render(Hash.FromAnonymousObject(new { name = "World" }));
            return Content(result);
        }
        
        public ActionResult HelloFilter()
        {
            var template = Template.Parse("Hello, {{ name | escape | upcase }}!");
            var result = template.Render(Hash.FromAnonymousObject(new { name = "<World>" }));
            return Content(result);
        }

        public ActionResult CustomFilter()
        {
            var template = Template.Parse("Hello, {{ name | substr: 1, 3 }}!");
            var result = template.Render(Hash.FromAnonymousObject(new { name = "World" }));
            return Content(result);
        }

        public ActionResult HelloTag()
        {
            var template = Template.Parse(@"
                {% assign name = 'World' %}
                {% if visible %}
                Hello, {{ name }}!
                {% endif %}
            ");
            var result = template.Render(Hash.FromAnonymousObject(new { visible = true }));
            return Content(result);
        }

        public ActionResult CustomTag()
        {
            var template = Template.Parse("{% conditional cond foo bar %}");
            var result = template.Render(Hash.FromAnonymousObject(new { cond = false, foo = "Foo", bar = "Bar" }));
            return Content(result);
        }

        public ActionResult HelloTemplateFile()
        {
            return DotliquidView();
        }
        
        public ActionResult HelloInclude()
        {
            return DotliquidView();
        }

        public ActionResult HelloExtends()
        {
            return DotliquidView();
        }

        public ActionResult CustomObject()
        {
            var template = Template.Parse("Name: {{ model.Name }}, Age: {{ model.Age }}");
            var model = new ExampleViewModel() { Name = "john", Age = 35 };
            var result = template.Render(Hash.FromAnonymousObject(new { model }));
            return Content(result);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}