namespace AutoStand.Models
{
    public class autoDetails
    {
        public string autoId { get; set; }
        public string autoNumber { get; set; }
        public string ownerName { get; set; }
        public string mobileNumber { get; set; }
        public string password { get; set; }
        public string ratting { get; set; }
        public string isAvailable { get; set; }

    }
    public class autoDetailsResponse{
        public string autoId { get; set; }
        public string autoNumber { get; set; }
        public string ownerName { get; set; }
        public string mobileNumber { get; set; }
        public string password { get; set; }
        public string ratting { get; set; }
        public string isAvailable { get; set; }
    }
    public class DestinationDetail
    {
        public string destinationId { get; set; }
        public string destinationName { get; set; }
        public string amount { get; set; }
        public string kilometre { get; set; }
    }
    public class DestinationDetailwihtId{
         public string destinationId { get; set; }
        public string destinationName { get; set; }
        public string amount { get; set; }
        public string kilometre { get; set; }
    }
    public class autoDetailsRequest
    {
        public string autoId { get; set; }
        public string autoNumber { get; set; }
        public string ownerName { get; set; }
        public string mobileNumber { get; set; }
        public string password { get; set; }
        public string ratting { get; set; }

    }
    public class autoTiming
    {
        public string autoId { get; set; }
        public string autoNumber { get; set; }
        public string checkIn { get; set; }
        public string checkOut { get; set; }
    }
    public class currentState
    {
        public string autoId { get; set; }
        public string autoNumber { get; set; }
        public string destinationId { get; set; }
        public string destinationName { get; set; }
        public string checkIn { get; set; }
        public string checkOut { get; set; }
        public string ratting { get; set; }
        //public int amount { get; set; }
        public string isAvailable { get; set; }

    }
    public class rideCollection{
        public string autoId { get; set; }
        public string collection{get; set;}
    }
    public class rideCount{
        public string autoId{get;set;}
        public string rideCounting {get;set;}
    }
    public class Response{
        public int status{get;set;}
        public string Message{get;set;}
    }
    public class userLogin
    {
        public string mobileNumber { get; set; }
        public string password { get; set; }
    }
    public class isAvailableResponse
    {
        public string mobileNumber { get; set; }
        public string isAvailable { get; set; }
    }
    public class nowisavailable{
        public string autoId{get;set;}
        public string autoNumber{get;set;}
        public string isAvailable{get;set;}
        public string destinationId{get;set;}
    }
}