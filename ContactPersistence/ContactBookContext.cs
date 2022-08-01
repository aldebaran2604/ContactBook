
using ContactPersistence.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactPersistence;

/// <summary>
/// Class Context to connect with database
/// </summary>
internal class ContactBookContext : DbContext
{
    #region Properties

    /// <summary>
    /// Path where the database is located
    /// </summary>
    private string DbPath { get; }
    
    #endregion

    #region Properties DbSet
    
    /// <summary>
    /// Data set related to the BusinessPosition model
    /// </summary>
    public DbSet<BusinessPosition> BusinessPositions { get; set; }

    /// <summary>
    /// Data set related to the BusinessDepartment model
    /// </summary>
    public DbSet<BusinessDepartment> BusinessDepartments { get; set; }

    /// <summary>
    /// Data set related to the Contact model
    /// </summary>
    public DbSet<Contact> Contacts { get; set; }
   
    #endregion

    #region Constructors

    #pragma warning disable CS8618

    /// <summary>
    /// Default constructor
    /// </summary>
    public ContactBookContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "ContactBook.db");
    }

    #pragma warning restore CS8618

    #endregion

    #region Methods

    /// <summary>
    /// Context configuration
    /// </summary>
    /// <param name="optionsBuilder"></param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source={DbPath}");
    }

    #endregion
}
