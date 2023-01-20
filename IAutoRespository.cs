using AutoStand.Models;

namespace AutoStandpro.Contracts
{
    public interface IAutoRepository
    {
        public Task<IEnumerable<autoDetails>> autoavailable();
        //public Task<autoDetails> createUser(autoDetailsRequest request);
        public Task<IEnumerable<autoTiming>> GetAutoTimings();
        public Task<IEnumerable<currentState>> GetCurrentStates();
        public Task<IEnumerable<rideCollection>> GetRideCollections();
        public Task<IEnumerable<rideCount>> GetRideCounts();
        public Task<dynamic> destinationRegister(DestinationDetailwihtId register);
        void createUser(autoDetailsResponse response);
        //void createUser(autoDetailsResponse response);
        public Task<dynamic> checkin(isAvailableResponse loginavailable);
        public Task<dynamic> userRegistration(autoDetailsResponse register);
        public Task<IEnumerable<nowisavailable>> GetNowisavailable();
    }
}
