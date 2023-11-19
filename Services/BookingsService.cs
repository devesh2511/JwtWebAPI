using JwtWebAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace JwtWebAPI.Services;

public class BookingsService
{
    private readonly IMongoCollection<Bookings> _bookingsCollection;

    public BookingsService(
        IOptions<BookingsDatabaseSettings> BookingsDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            BookingsDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            BookingsDatabaseSettings.Value.DatabaseName);

        _bookingsCollection = mongoDatabase.GetCollection<Bookings>(
            BookingsDatabaseSettings.Value.BookingsCollectionName);
    }

    public async Task<List<Bookings>> GetAsync() =>
        await _bookingsCollection.Find(_ => true).ToListAsync();

    public async Task<Bookings?> GetAsync(string id) =>
        await _bookingsCollection.Find(x => x.BookingId == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Bookings newBooking) =>
        await _bookingsCollection.InsertOneAsync(newBooking);

    public async Task UpdateAsync(string id, Bookings updatedBooking) =>
        await _bookingsCollection.ReplaceOneAsync(x => x.BookingId == id, updatedBooking);

    public async Task RemoveAsync(string id) =>
        await _bookingsCollection.DeleteOneAsync(x => x.BookingId == id);
}