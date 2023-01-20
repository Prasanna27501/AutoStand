using AutoStandpro.Contracts;
using AutoStandpro.Config;
using AutoStand.Models;
using Dapper;
using System.Data;

namespace AutoStandpro.Service
{
    public class autoRepository : IAutoRepository
    {
        private readonly DapperContext _context;
        public autoRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<autoDetails>> autoavailable()
        {
            var query = "SELECT autoid, autonumber, ownername, mobilenumber, password, ratting, isavailable FROM autostand.autodetails WHERE(isavailable = 'Yes')";

            using (var connection = _context.CreateConnection())
            {
                var companies = await connection.QueryAsync<autoDetails>(query);
                return companies.ToList();
            }
        }

        public async Task<dynamic> checkin(isAvailableResponse loginavailable)
        {
            bool result = true;
            var query = "UPDATE autostand.autodetails SET isavailable ='" + loginavailable.isAvailable + "' WHERE (mobilenumber = '" + loginavailable.mobileNumber + "')";

            Console.WriteLine("in query");
            Console.WriteLine(query);
            using (var connection = _context.CreateConnection())
            {
                try
                {
                    var resultData = await connection.QueryAsync<dynamic>(query);
                    // check result is fine or not.
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    throw;
                }
                finally
                {
                    _context.ReleaseServerConnection(connection);
                }
            }
        }

        public async Task<Boolean> createUser(autoDetailsRequest register)
        {
            var query = "INSERT INTO autostand.autodetails(autoid, autonumber, ownername, mobilenumber, password, ratting) VALUES('" + register.autoId + "', '" + register.autoNumber + "', '" + register.ownerName + "', '" + register.mobileNumber + "','" + register.password + "', '" + register.ratting + "')";

            Console.WriteLine("in query");
            Console.WriteLine(query);
            using (var connection = _context.CreateConnection())
            {
                try
                {
                    var resultData = await connection.QueryAsync<dynamic>(query);
                    // check result is fine or not.
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    throw;
                }
                finally
                {
                    _context.ReleaseServerConnection(connection);
                }
            }    
            // var query = "INSERT INTO auto_stand.auto_details(autoid, autonumber, ) VALUES (@Name, @Address, @Country)";
            // var parameters = new DynamicParameters();
            // parameters.Add("Name", request.Name, DbType.String);
            // parameters.Add("Address", request.Address, DbType.String);
            // parameters.Add("Country", request.Country, DbType.String);
            // using (var connection = _context.CreateConnection())
            // {
            //     var id = await connection.QuerySingleAsync<int>(query, parameters);
            //     var createdCompany = new autoDetails
            //     {
            //         autoId = ,
            //         autoNumber = request.autoNumber,
            //         ownerName = request.,
            //         Country = company.Country
            //     };
            //     return createdCompany;
            // }
        }

        public void createUser(autoDetailsResponse response)
        {
            throw new NotImplementedException();
        }

        // public void createUser(autoDetailsResponse response)
        // {
        //     throw new NotImplementedException();
        // }

        public async Task<dynamic> destinationRegister(DestinationDetailwihtId register)
        {
            bool result = true;
            var query = "INSERT INTO autostand.destination_details(destinationid, destinationname, amount, kilometre)VALUES('" + register.destinationId + "', '" + register.destinationName + "', '" + register.amount + "', '" + register.kilometre + "')";

            Console.WriteLine("in query");
            Console.WriteLine(query);
            using (var connection = _context.CreateConnection())
            {
                try
                {
                    var resultData = await connection.QueryAsync<dynamic>(query);
                    // check result is fine or not.
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    throw;
                }
                finally
                {
                    _context.ReleaseServerConnection(connection);
                }
            }
        }

        public async Task<IEnumerable<autoTiming>> GetAutoTimings()
        {
            var query = "SELECT autostand.autoride.autoid, autonumber, autostand.autoride.checkin, autostand.autoride.checkout FROM autostand.autoride INNER JOIN autostand.autodetails ON(autostand.autoride.autoid = autostand.autodetails.autoid)";
            // var query = "SELECT rideid, autoid, checkin, checkout FROM autostand.autoride WHERE(autoid = '1004')";

//             SELECT Orders.OrderID, Customers.CustomerName
// FROM Orders
// INNER JOIN Customers ON Orders.CustomerID = Customers.CustomerID; 
            using (var connection = _context.CreateConnection())
            {
                var companies = await connection.QueryAsync<autoTiming>(query);
                Console.WriteLine(companies);
                return companies.ToList();
            }
        }
        public async Task<IEnumerable<currentState>> GetCurrentStates()
        {
            var query = "SELECT autostand.autoride.autoid, autonumber, autostand.destinationdetails.destinationid, destinationname, autostand.autoride.checkin, autostand.autoride.checkout, ratting, isAvailable FROM autostand.autodetails INNER JOIN autostand.autoride ON(autostand.autoride.autoid = autostand.autodetails.autoid) INNER JOIN autostand.destinationdetails ON(autostand.destinationdetails.destinationid = autostand.autoride.destinationid)";

            using (var connection = _context.CreateConnection())
            {
                var current = await connection.QueryAsync<currentState>(query);
                return current.ToList();
            }
        }

        public async Task<IEnumerable<nowisavailable>> GetNowisavailable()
        {

            var query = "SELECT autostand.autodetails.autoid, autostand.autodetails.autonumber, autostand.autodetails.isavailable,autostand.autoride.destinationid, autostand.autodetails.ratting FROM autostand.autodetails LEFT JOIN autostand.autoride ON(autostand.autoride.autoid = autostand.autodetails.autoid)WHERE autostand.autodetails.isavailable = 'Yes'AND autostand.autoride.destinationid ISNULL AND autostand.autodetails.ratting = '5'";
            using (var connection = _context.CreateConnection())
            {
                var nowavailable = await connection.QueryAsync<nowisavailable>(query);
                return nowavailable.ToList();
            }
        }
        public async Task<IEnumerable<rideCollection>> GetRideCollections()
        {
            var query = "SELECT autoid, SUM(amount) as collection FROM autostand.autoride GROUP BY autoid";

            using (var connection = _context.CreateConnection())
            {
                var collection = await connection.QueryAsync<rideCollection>(query);
                return collection.ToList();
            }
        }

        public async Task<IEnumerable<rideCount>> GetRideCounts()
        {
            var query = "SELECT autoid, COUNT(destinationid) FROM autostand.autoride GROUP BY autoid";

            using (var connection = _context.CreateConnection())
            {
                var collection = await connection.QueryAsync<rideCount>(query);
                return collection.ToList();
            }
        }

        public async Task<dynamic> userRegistration(autoDetailsResponse register)
        {
            bool result = true;
            var query = "INSERT INTO autostand.autodetails(autoid, autonumber, ownername, mobilenumber, password, ratting, isavailable) VALUES('" + register.autoId + "', '" + register.autoNumber + "', '" + register.ownerName + "', '" + register.mobileNumber + "','" + register.password + "', '" + register.ratting + "','" + register.isAvailable + "')";

            Console.WriteLine("in query");
            Console.WriteLine(query);
            using (var connection = _context.CreateConnection())
            {
                try
                {
                    var resultData = await connection.QueryAsync<dynamic>(query);
                    // check result is fine or not.
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    throw;
                }
                finally
                {
                    _context.ReleaseServerConnection(connection);
                }
            }
        }

        /*public async Task<autoDetails> IAutoRepository.createUser(autoDetailsRequest register)
        {
            var query = "INSERT INTO auto_stand.auto_details(autoid, autonumber, ownername, mobilenumber, password, ratting) VALUES('" + register.autoId + "', '" + register.autoNumber + "', '" + register.ownerName + "', '" + register.mobileNumber + "','" + register.password + "', '" + register.ratting + "')";

            Console.WriteLine("in query");
            Console.WriteLine(query);
            using (var connection = _context.CreateConnection())
            {
                try
                {
                    var resultData = await connection.QueryAsync<dynamic>(query);
                    // check result is fine or not.
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    throw;
                }
                finally
                {
                    _context.ReleaseServerConnection(connection);
                }
            }    
        }*/

        // public void createUser(autoDetailsResponse response)
        // {
        //     throw new NotImplementedException();
        // }
    }
}