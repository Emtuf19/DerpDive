using DeepDive.Models;
using Microsoft.EntityFrameworkCore;
using DeepDive.Enums;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DeepDive.Data
{
    public class EquipmentContext : DbContext
    {

        public EquipmentContext(DbContextOptions<EquipmentContext> options) : base(options)
        {
        }

        public DbSet<BCD> BCDs { get; set; }
        public DbSet<DivingSuits> DivingSuits { get; set; }
        public DbSet<Finns> Finns { get; set; }
        public DbSet<Mask_Snorkel> Mask_Snorkels { get; set; }
        public DbSet<RegulatorSet> RegulatorSets { get; set; }
        public DbSet<Tank> Tanks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var sizeComparer = new ValueComparer<List<EquipmentSize>>(
                (a, b) => a.SequenceEqual(b),
                a => a.Aggregate(0, (hash, value) => HashCode.Combine(hash, value)),
                a => a.ToList()
            );

            var genderComparer = new ValueComparer<List<EquipmentGender>>(
                (a, b) => a.SequenceEqual(b),
                a => a.Aggregate(0, (hash, value) => HashCode.Combine(hash, value)),
                a => a.ToList()
            );

            modelBuilder.Entity<BCD>()
                .Property(b => b.Size)
                .HasConversion(
                    size => string.Join(',', size),
                    size => size.Split(',', StringSplitOptions.RemoveEmptyEntries)
                        .Select(size => Enum.Parse<EquipmentSize>(size))
                        .ToList()
                )
                .Metadata.SetValueComparer(sizeComparer);

            modelBuilder.Entity<DivingSuits>()
                .Property(b => b.Size)
                .HasConversion(
                    size => string.Join(',', size),
                    size => size.Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(size => Enum.Parse<EquipmentSize>(size)).ToList()
                ).Metadata.SetValueComparer(sizeComparer);

            modelBuilder.Entity<DivingSuits>()
                .Property(b => b.Gender)
                .HasConversion(
                    gender => string.Join(',', gender),
                    gender => gender.Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(gender => Enum.Parse<EquipmentGender>(gender)).ToList()
                ).Metadata.SetValueComparer(genderComparer);

            modelBuilder.Entity<Finns>()
                .Property(f => f.Size)
                .HasConversion(
                    size => string.Join(',', size),
                    size => size.Split(',', StringSplitOptions.RemoveEmptyEntries)
                        .Select(size => Enum.Parse<EquipmentSize>(size))
                        .ToList()
                )
                .Metadata.SetValueComparer(sizeComparer);

            modelBuilder.Entity<BCD>().HasData(
                new BCD
                {
                    BCDId = 1,
                    Brand = "Scubapro",
                    Model = "Navigator Lite BCD",
                    Size = new List<EquipmentSize>
                    {
                        EquipmentSize.S,
                        EquipmentSize.M,
                        EquipmentSize.L
                    },
                    Price = 125
                },
                new BCD
                {
                    BCDId = 2,
                    Brand = "Scubapro",
                    Model = "BCD Glide",
                    Size = new List<EquipmentSize>
                    {
                        EquipmentSize.S,
                        EquipmentSize.M,
                        EquipmentSize.L
                    },
                    Price = 140
                },
                new BCD
                {
                    BCDId = 3,
                    Brand = "Scubapro",
                    Model = "BCD Hydros Pro",
                    Size = new List<EquipmentSize>
                    {
                        EquipmentSize.S,
                        EquipmentSize.M,
                        EquipmentSize.L
                    },
                    Price = 200
                },
                new BCD
                {
                    BCDId = 4,
                    Brand = "Seac",
                    Model = "BCD Modular",
                    Size = new List<EquipmentSize>
                    {
                        EquipmentSize.S,
                        EquipmentSize.M,
                        EquipmentSize.L
                    },
                    Price = 145
                }
            );
            modelBuilder.Entity<DivingSuits>().HasData(
                new DivingSuits
                {
                    DivingSuitsId = 1,
                    Brand = "Scubapro",
                    Model = "Definition",

                    Size = new List<EquipmentSize>
                    {
                        EquipmentSize.XS,
                        EquipmentSize.S,
                        EquipmentSize.M,
                        EquipmentSize.L,
                        EquipmentSize.XL
                    },

                    Type = "Våddragt",

                    Gender = new List<EquipmentGender>
                    {
                        EquipmentGender.Herre,
                        EquipmentGender.Dame
                    },

                    Price = 100,
                    Thickness = 3
                },
                new DivingSuits
                {
                    DivingSuitsId = 2,
                    Brand = "Scubapro",
                    Model = "Definition",
                    Size = new List<EquipmentSize>
                    {
                        EquipmentSize.XS,
                        EquipmentSize.S,
                        EquipmentSize.M,
                        EquipmentSize.L,
                        EquipmentSize.XL
                    },
                    Type = "Våddragt",
                    Gender = new List<EquipmentGender>
                    {
                        EquipmentGender.Herre,
                        EquipmentGender.Dame
                    },
                    Price = 100,
                    Thickness = 5
                },
                new DivingSuits
                {
                    DivingSuitsId = 3,
                    Brand = "Scubapro",
                    Model = "Definition",
                    Size = new List<EquipmentSize>
                    {
                        EquipmentSize.XS,
                        EquipmentSize.S,
                        EquipmentSize.M,
                        EquipmentSize.L,
                        EquipmentSize.XL
                    },
                    Type = "Våddragt",
                    Gender = new List<EquipmentGender>
                    {
                        EquipmentGender.Herre,
                        EquipmentGender.Dame
                    },
                    Price = 100,
                    Thickness = 7
                },
                new DivingSuits
                {
                    DivingSuitsId = 4,
                    Brand = "Waterproof",
                    Model = "W5",
                    Size = new List<EquipmentSize>
                    {
                        EquipmentSize.XS,
                        EquipmentSize.S,
                        EquipmentSize.M,
                        EquipmentSize.L,
                        EquipmentSize.XL
                    },
                    Type = "Våddragt",
                    Gender = new List<EquipmentGender>
                    {
                        EquipmentGender.Herre,
                        EquipmentGender.Dame
                    },
                    Price = 100,
                    Thickness = 3
                },
                new DivingSuits
                {
                    DivingSuitsId = 5,
                    Brand = "Fourth Element",
                    Model = "Proteus",
                    Size = new List<EquipmentSize>
                    {
                        EquipmentSize.XS,
                        EquipmentSize.S,
                        EquipmentSize.M,
                        EquipmentSize.L,
                        EquipmentSize.XL
                    },
                    Type = "Våddragt",
                    Gender = new List<EquipmentGender>
                    {
                        EquipmentGender.Herre,
                        EquipmentGender.Dame
                    },
                    Price = 120,
                    Thickness = 5
                },
                new DivingSuits
                {
                    DivingSuitsId = 6,
                    Brand = "Scubapro",
                    Model = "Exodry 4.0",
                    Size = new List<EquipmentSize>
                    {
                        EquipmentSize.XS,
                        EquipmentSize.S,
                        EquipmentSize.M,
                        EquipmentSize.L,
                        EquipmentSize.XL
                    },
                    Type = "Tørdragt",
                    Gender = new List<EquipmentGender>
                    {
                        EquipmentGender.Herre,
                        EquipmentGender.Dame
                    },
                    Price = 300,
                    Thickness = 0
                },
                new DivingSuits
                {
                    DivingSuitsId = 7,
                    Brand = "Waterproof",
                    Model = "D7 Evo",
                    Size = new List<EquipmentSize>
                    {
                        EquipmentSize.XS,
                        EquipmentSize.S,
                        EquipmentSize.M,
                        EquipmentSize.L,
                        EquipmentSize.XL
                    },
                    Type = "Tørdragt",
                    Gender = new List<EquipmentGender>
                    {
                        EquipmentGender.Herre,
                        EquipmentGender.Dame
                    },
                    Price = 320,
                    Thickness = 0
                },
                new DivingSuits
                {
                    DivingSuitsId = 8,
                    Brand = "Santi",
                    Model = "E.Lite Plus",
                    Size = new List<EquipmentSize>
                    {
                        EquipmentSize.XS,
                        EquipmentSize.S,
                        EquipmentSize.M,
                        EquipmentSize.L,
                        EquipmentSize.XL
                    },
                    Type = "Tørdragt",
                    Gender = new List<EquipmentGender>
                    {
                        EquipmentGender.Herre,
                        EquipmentGender.Dame
                    },
                    Price = 350,
                    Thickness = 0
                }
            );
            modelBuilder.Entity<Finns>().HasData(
                new Finns
                {
                    FinnsId = 1,
                    Brand = "Scubapro",
                    Model = "Jet Fin",
                    Size = new List<EquipmentSize>
                    {
                        EquipmentSize.XS,
                        EquipmentSize.S,
                        EquipmentSize.M,
                        EquipmentSize.L,
                        EquipmentSize.XL
                    },
                    Price = 50
                },
                new Finns
                {
                    FinnsId = 2,
                    Brand = "Scubapro",
                    Model = "GO Travel",
                    Size = new List<EquipmentSize>
                    {
                        EquipmentSize.XS,
                        EquipmentSize.S,
                        EquipmentSize.M,
                        EquipmentSize.L,
                        EquipmentSize.XL
                    },
                    Price = 50
                },
                new Finns
                {
                    FinnsId = 3,
                    Brand = "Scubapro",
                    Model = "Seawing Supernova",
                    Size = new List<EquipmentSize>
                    {
                        EquipmentSize.XS,
                        EquipmentSize.S,
                        EquipmentSize.M,
                        EquipmentSize.L,
                        EquipmentSize.XL
                    },
                    Price = 60
                },
                new Finns
                {
                    FinnsId = 4,
                    Brand = "Seac",
                    Model = "Propulsion",
                    Size = new List<EquipmentSize>
                    {
                        EquipmentSize.XS,
                        EquipmentSize.S,
                        EquipmentSize.M,
                        EquipmentSize.L,
                        EquipmentSize.XL
                    },
                    Price = 50
                },
                new Finns
                {
                    FinnsId = 5,
                    Brand = "Seac",
                    Model = "ALA",
                    Size = new List<EquipmentSize>
                    {
                        EquipmentSize.XS,
                        EquipmentSize.S,
                        EquipmentSize.M,
                        EquipmentSize.L,
                        EquipmentSize.XL
                    },
                    Price = 50
                },
                new Finns
                {
                    FinnsId = 6,
                    Brand = "Fourth Element",
                    Model = "Tech",
                    Size = new List<EquipmentSize>
                    {
                        EquipmentSize.XS,
                        EquipmentSize.S,
                        EquipmentSize.M,
                        EquipmentSize.L,
                        EquipmentSize.XL
                    },
                    Price = 75
                },
                new Finns
                {
                    FinnsId = 7,
                    Brand = "Fourth Element",
                    Model = "Rec Fin",
                    Size = new List<EquipmentSize>
                    {
                        EquipmentSize.XS,
                        EquipmentSize.S,
                        EquipmentSize.M,
                        EquipmentSize.L,
                        EquipmentSize.XL
                    },
                    Price = 80
                }
            );
            modelBuilder.Entity<Mask_Snorkel>().HasData(
                new Mask_Snorkel
                {
                    Mask_SnorkelId = 1,
                    Brand = "Scubapro",
                    Model = "Ghost",
                    Price = 50
                },
                new Mask_Snorkel
                {
                    Mask_SnorkelId = 2,
                    Brand = "Scubapro",
                    Model = "D-Mask",
                    Price = 60
                },
                new Mask_Snorkel
                {
                    Mask_SnorkelId = 3,
                    Brand = "Scubapro",
                    Model = "Spectra Mini",
                    Price = 50
                },
                new Mask_Snorkel
                {
                    Mask_SnorkelId = 4,
                    Brand = "Scubapro",
                    Model = "Crystal VU",
                    Price = 75
                },
                new Mask_Snorkel
                {
                    Mask_SnorkelId = 5,
                    Brand = "Fourth Element",
                    Model = "Scout Kontrast",
                    Price = 75
                },
                new Mask_Snorkel
                {
                    Mask_SnorkelId = 6,
                    Brand = "Fourth Element",
                    Model = "Scout Enhance",
                    Price = 75
                },
                new Mask_Snorkel
                {
                    Mask_SnorkelId = 7,
                    Brand = "Tusa",
                    Model = "Element",
                    Price = 75
                }
            );
            modelBuilder.Entity<RegulatorSet>().HasData(
                new RegulatorSet
                {
                    RegulatorSetId = 1,
                    Brand = "Scubapro",
                    FirstStep = "MK25EVO",
                    SecondStep = "S600",
                    Octopus = "R105",
                    Price = 125
                },
                new RegulatorSet
                {
                    RegulatorSetId = 2,
                    Brand = "Scubapro",
                    FirstStep = "MK17EVO",
                    SecondStep = "C370",
                    Octopus = "R095",
                    Price = 100
                },
                new RegulatorSet
                {
                    RegulatorSetId = 3,
                    Brand = "Scubapro",
                    FirstStep = "MK25EVO BT",
                    SecondStep = "A700 Carbon BT",
                    Octopus = "S270",
                    Price = 150
                }
            );
            modelBuilder.Entity<Tank>().HasData(
                new Tank
                {
                    TankId = 1,
                    Brand = "Scubapro",
                    Price = 150,
                    Volumen = 5
                },
                new Tank
                {
                    TankId = 2,
                    Brand = "Scubapro",
                    Price = 160,
                    Volumen = 10
                },
                new Tank
                {
                    TankId = 3,
                    Brand = "Scubapro",
                    Price = 170,
                    Volumen = 12
                },
                new Tank
                {
                    TankId = 4,
                    Brand = "Scubapro",
                    Price = 180,
                    Volumen = 15
                }
            );

        }
    }
}
