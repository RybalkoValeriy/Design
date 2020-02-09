using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design.Patterns.Creational.Builder
{
    // Description The Builder design pattern
    // lets us create an object one step at a time
    // use this pattern for creating a complex object.
    // https://code-maze.com/fluent-builder-recursive-generics/
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }


    public class ProductReport
    {
        public string HeaderPart { get; set; }
        public string BodyPart { get; set; }
        public string FooterPart { get; set; }

        public override string ToString()
            => new StringBuilder()
                .AppendLine(HeaderPart)
                .AppendLine(BodyPart)
                .AppendLine(FooterPart)
                .ToString();
    }


    public interface IProductReportBuilder
    {
        void BuildHeader();
        void BuildBody();
        void BuildFooter();
        ProductReport GetReport();
    }

    public class ProductReportBuilder : IProductReportBuilder
    {
        private ProductReport _productReport;
        private IEnumerable<Product> _products;

        public ProductReportBuilder(IEnumerable<Product> products)
        {
            _products = products;
            _productReport = new ProductReport();
        }

        public void BuildHeader()
            => _productReport.HeaderPart = "some header for report";

        public void BuildBody()
            => _productReport.BodyPart = string.Join("/n", _products.Select(p => $"Product name:{p.Name} price:{p.Price}"));

        public void BuildFooter()
        {
            _productReport.FooterPart = "some footer for report";
        }

        public ProductReport GetReport()
        {
            var pr = _productReport;
            Clear();
            return pr;
        }

        private void Clear()
            => _productReport = new ProductReport();
    }

    public class ProductReportDirector
    {
        private readonly IProductReportBuilder _productReportBuilder;

        public ProductReportDirector(IProductReportBuilder productReportBuilder)
        {
            _productReportBuilder = productReportBuilder;
        }

        public void BuildReport()
        {
            _productReportBuilder.BuildHeader();
            _productReportBuilder.BuildBody();
            _productReportBuilder.BuildFooter();
        }
    }
}
