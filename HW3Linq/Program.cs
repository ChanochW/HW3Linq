namespace HW3Linq;

public static class Linq {
    public static void Main(string[] args) {
        var sales = new Sale[] {
            new() {
                Item = "Tea", Customer = "ABC LLC", PricePerItem = 12.0, Quantity = 2, Address = "123 Main St",
                ExpeditedShipping = false
            },
            new() {
                Item = "Tea", Customer = "DEF LLC", PricePerItem = 9.0, Quantity = 1, Address = "456 Main St",
                ExpeditedShipping = false
            },
            new() {
                Item = "Chocolate", Customer = "GHI LLC", PricePerItem = 50.0, Quantity = 6, Address = "789 Main St",
                ExpeditedShipping = false
            },
            new() {
                Item = "Coffee", Customer = "XYZ LLC", PricePerItem = 8.0, Quantity = 1, Address = "987 Main St",
                ExpeditedShipping = true
            }
        };

        var expensive = from sale in sales
            where sale.PricePerItem > 10.0
            select sale;

        var singleQuantity = from sale in sales
            where sale.Quantity == 1
            orderby sale.PricePerItem descending
            select sale;

        var teaWoExpeditedShipping = from sale in sales
            where sale.Item == "Tea" && sale.ExpeditedShipping == false
            select sale;

        var addressesWithTotalOver100 = from sale in sales
            where (sale.PricePerItem * sale.Quantity) > 100.0
            select sale.Address;

        var custom = from sale in sales
        where sale.Customer.ToLower().Contains("llc")
            orderby sale.PricePerItem * sale.Quantity
            select new {
                sale.Item,
                TotalPrice = sale.PricePerItem * sale.Quantity,
                Shipping = sale.ExpeditedShipping ? sale.Address + " EXPEDITE" : sale.Address
            };


        Console.WriteLine("Expensive Sales:");
        foreach (var sale in expensive) {
            Console.WriteLine($"{sale.Item}, Price: {sale.PricePerItem}");
        }
        Console.WriteLine("\nSingle Quantity Sales:");
        foreach (var sale in singleQuantity) {
            Console.WriteLine($"{sale.Item}, Price: {sale.PricePerItem}");
        }
        Console.WriteLine("\nTea without Expedited Shipping:");
        foreach (var sale in teaWoExpeditedShipping) {
            Console.WriteLine($"{sale.Item}, Address: {sale.Address}");
        }
        Console.WriteLine("\nAddresses with Total Cost Over 100:");
        foreach (var address in addressesWithTotalOver100) {
            Console.WriteLine(address);
        }
        Console.WriteLine("\nCustom Sales:");
        foreach (var sale in custom) {
            Console.WriteLine($"{sale.Item}, Total Price: {sale.TotalPrice}, Shipping: {sale.Shipping}");
        }
    }
}