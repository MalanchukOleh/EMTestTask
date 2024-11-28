using EMTestTask.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace EMTestTask.Sevices;


public class CustomersService
{
    private readonly IMongoCollection<Customer> _customersCollection;
    public CustomersService(){/*Сonstructor for Moq lib. Without it Moq can't use virtual methods.*/}
    public CustomersService(
        IOptions<CustomersDatabaseSettings> customersDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            customersDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            customersDatabaseSettings.Value.DatabaseName);

        _customersCollection = mongoDatabase.GetCollection<Customer>(
            customersDatabaseSettings.Value.CustomersCollectionName);
    }

    public virtual async Task<List<Customer>> GetAsync() =>
        await _customersCollection.Find(_ => true).ToListAsync();

    public virtual async Task CreateAsync(Customer newCustomer) =>
        await _customersCollection.InsertOneAsync(newCustomer);

    public virtual async Task<bool> EmailExistsAsync(string email)
    {
        var existingCustomer = await _customersCollection.Find(x => x.Email == email).FirstOrDefaultAsync();
        return existingCustomer != null;
    }

    public virtual async Task<bool> PhoneExistsAsync(string phoneNumber)
    {
        var existingCustomer = await _customersCollection.Find(x => x.PhoneNumber == phoneNumber).FirstOrDefaultAsync();
        return existingCustomer != null;
    }
}