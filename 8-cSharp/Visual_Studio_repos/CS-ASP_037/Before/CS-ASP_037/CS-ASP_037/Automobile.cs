using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS_ASP_037
{
    public class Automobile
    {
        // an example of low cohesion aka too much stuff
        // its doing too much stuff even if they're related to an automobile
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public int DaysOnLot { get; set; }
        public string PromotionalOffers { get; set; }
        public double MarketValue { get; set; }
        public string PurchasedByName { get; set; }
        public string PurchasedByAddress { get; set; }
        public string PurchasedByPhone { get; set; }
        public string SoldBy { get; set; }
        public double TotalSaleAmount { get; set; }
        public int CarLotParkingSpace { get; set; }
        public bool HasBeenDetailed { get; set; }
        public string DetailedServiceHistory { get; set; }

        public void DetermineMarketValue() { }
        public void MoveCarOnLot() { }
        public void SendCarToDetailer() { }
        public void AddToServiceHistory() { }
        public void AddPromotionalOffer() { }
        public void DiscountCar() { }
        public void SellCar() { }
        public void PrintCarDetails() { }
        public void RetrieveCarFromDatabase() { }
        public void SaveChangesToDatabase() { }
    }
}