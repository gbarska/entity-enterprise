using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Maintenance.Data;
using Maintenance.Domain;

namespace Tests
{
    [TestClass]
    public class UnitTests
    {
    [TestMethod, TestCategory("Product")]
    public void NewProductIsAvailable() {
      Assert.IsTrue((new Product()).IsAvailable);
    }

    [TestMethod, TestCategory("Product")]
    public void NewProductWithDataIsAvailable() {
      var product = new Product
      {
        Name = "test",
        Description = "testing",
        ProductionStart = DateTime.Today
      };
      Assert.IsTrue(product.IsAvailable);
    }

    [TestMethod, TestCategory("Product")]
    public void CanDisableProduct() {
      var product = new Product();
      product.RemoveFromProduction();
      Assert.IsFalse(product.IsAvailable);
    }
    }
}
