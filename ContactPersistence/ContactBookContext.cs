
using ContactPersistence.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactPersistence;

/// <summary>
/// Class Context to connect with database
/// </summary>
internal class ContactBookContext : DbContext
{
    #region Properties
    private string DbPath { get; }
    #endregion

    #region Properties DbSet
    public DbSet<BusinessPosition>? BusinessPositions { get; set; }
    public DbSet<BusinessDepartment>? BusinessDepartments { get; set; }
    public DbSet<Contact>? Contacts { get; set; }
    #endregion

    #region Constructors
    public ContactBookContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "ContactBook.db");
    }
    #endregion

    #region Methods
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source={DbPath}");
    }
    #endregion
}
