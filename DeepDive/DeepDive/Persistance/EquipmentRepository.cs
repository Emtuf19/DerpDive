using DeepDive.Models;

namespace DeepDive.Persistance
{
    public static class EquipmentRepository
    {
        public static List<BCD> BCDs = new List<BCD>
        {
            new BCD
            {
                Brand = "Scubapro",
                Model = "Navigator Lite BCD",
                Size = "S, M, L",
                Price = 125
            },
            new BCD
            {
                Brand = "Scubapro",
                Model = "BCD Glide",
                Size = "S, M, L",
                Price = 140
            },
            new BCD
            {
                Brand = "Scubapro",
                Model = "BCD Hydros Pro",
                Size = "S, M, L",
                Price = 200
            },
            new BCD
            {
                Brand = "Seac",
                Model = "BCD Modular",
                Size = "S, M, L",
                Price = 145
            }
        };

        public static List<DivingSuits> divingSuits = new List<DivingSuits> {
            new DivingSuits
            {
                Brand = "Scubapro",
                Model = "Definition",
                Size = "XS, S, M, L, XL",
                Type = "Våddragt",
                Gender = "Herre/Dame",
                Price = 100,
                Thickness = 3
            },
            new DivingSuits
            {
                Brand = "Scubapro",
                Model = "Definition",
                Size = "XS, S, M, L, XL",
                Type = "Våddragt",
                Gender = "Herre/Dame",
                Price = 100,
                Thickness = 5
            },
            new DivingSuits
            {
                Brand = "Scubapro",
                Model = "Definition",
                Size = "XS, S, M, L, XL",
                Type = "Våddragt",
                Gender = "Herre/Dame",
                Price = 100,
                Thickness = 7
            },
            new DivingSuits
            {
                Brand = "Waterproof",
                Model = "W5",
                Size = "XS, S, M, L, XL",
                Type = "Våddragt",
                Gender = "Herre/Dame",
                Price = 100,
                Thickness = 3
            },
            new DivingSuits
            {
                Brand = "Fourth Element",
                Model = "Proteus",
                Size = "XS, S, M, L, XL",
                Type = "Våddragt",
                Gender = "Herre/Dame",
                Price = 120,
                Thickness = 5
            },
            new DivingSuits
            {
                Brand = "Scubapro",
                Model = "Exodry 4.0",
                Size = "XS, S, M, L, XL",
                Type = "Tørdragt",
                Gender = "Herre/Dame",
                Price = 300,
                Thickness = 0
            },
            new DivingSuits
            {
                Brand = "Waterproof",
                Model = "D7 Evo",
                Size = "XS, S, M, L, XL",
                Type = "Tørdragt",
                Gender = "Herre/Dame",
                Price = 320,
                Thickness = 0
            },
            new DivingSuits
            {
                Brand = "Santi",
                Model = "E.Lite Plus",
                Size = "XS, S, M, L, XL",
                Type = "Tørdragt",
                Gender = "Herre/Dame",
                Price = 350,
                Thickness = 0
            }
        };


        public static List<Finns> finns = new List<Finns>
        {
            new Finns
            {
                Brand = "Scubapro",
                Model = "Jet Fin",
                Size = "XS, S, M, L, XL",
                Price = 50
            },
            new Finns
            {
                Brand = "Scubapro",
                Model = "GO Travel",
                Size = "XS, S, M, L, XL",
                Price = 50
            },
            new Finns
            {
                Brand = "Scubapro",
                Model = "Seawing Supernova",
                Size = "XS, S, M, L, XL",
                Price = 60
            },
            new Finns
            {
                Brand = "Seac",
                Model = "Propulsion",
                Size = "XS, S, M, L, XL",
                Price = 50
            },
            new Finns
            {
                Brand = "Seac",
                Model = "ALA",
                Size = "XS, S, M, L, XL",
                Price = 50
            },
            new Finns
            {
                Brand = "Fourth Element",
                Model = "Tech",
                Size = "XS, S, M, L, XL",
                Price = 75
            },
            new Finns
            {
                Brand = "Fourth Element",
                Model = "Rec Fin",
                Size = "XS, S, M, L, XL",
                Price = 80
            }

        };
        public static List<Mask_Snorkel> mask_Snorkels = new List<Mask_Snorkel>
        {
            new Mask_Snorkel
            {
                Brand = "Scubapro",
                Model = "Ghost",
                Price = 50
            },
            new Mask_Snorkel
            {
                Brand = "Scubapro",
                Model = "D-Mask",
                Price = 60
            },
            new Mask_Snorkel
            {
                Brand = "Scubapro",
                Model = "Spectra Mini",
                Price = 50
            },
            new Mask_Snorkel
            {
                Brand = "Scubapro",
                Model = "Crystal VU",
                Price = 75
            },
            new Mask_Snorkel
            {
                Brand = "Fourth Element",
                Model = "Scout Kontrast",
                Price = 75
            },
            new Mask_Snorkel
            {
                Brand = "Fourth Element",
                Model = "Scout Enhance",
                Price = 75
            },
            new Mask_Snorkel
            {
                Brand = "Tusa",
                Model = "Element",
                Price = 75
            }

        };
        public static List<RegulatorSet> regulatorSets = new List<RegulatorSet>
        {
            new RegulatorSet
            {
                Brand = "Scubapro",
                FirstStep = "MK25EVO",
                SecondStep = "S600",
                Octopus = "R105",
                Price = 125
            },
            new RegulatorSet
            {
                Brand = "Scubapro",
                FirstStep = "MK17EVO",
                SecondStep = "C370",
                Octopus = "R095",
                Price = 100
            },
            new RegulatorSet
            {
                Brand = "Scubapro",
                FirstStep = "MK25EVO BT",
                SecondStep = "A700 Carbon BT",
                Octopus = "S270",
                Price = 150
            }
        };


        public static List<Tank> tanks = new List<Tank>
        {
            new Tank
            {
                Brand = "Scubapro",
                Price = 150,
                Volumen = 5
            },
            new Tank
            {
                Brand = "Scubapro",
                Price = 160,
                Volumen = 10
            },
            new Tank
            {
                Brand = "Scubapro",
                Price = 170,
                Volumen = 12
            },
            new Tank
            {
                Brand = "Scubapro",
                Price = 180,
                Volumen = 15
            }

        };

        public static List<RegulatorSet> GetAllRegulatorSets()
        {
            return regulatorSets;
        }

        public static List<Tank> GetAllTanks()
        {
            return tanks;
        }

        public static List<Mask_Snorkel> GetAllMask_Snorkels()
        {
            return mask_Snorkels;
        }

        public static List<DivingSuits> GetAllDivingSuits()
        {
            return divingSuits;
        }

        public static List<Finns> GetAllFinns()
        {
            return finns;
        }

        public static List<BCD> GetAllBCDs()
        {
            return BCDs;
        }

        public static BCD? GetById(int id)
        {
            return BCDs.FirstOrDefault(x => x.BCDId == id);
        }

        public static void Add(BCD bcd)
        {
            if (bcd == null) return;

            bcd.BCDId = BCDs.Any() ? BCDs.Max(x => x.BCDId) + 1 : 1;

            BCDs.Add(bcd);
        }

        public static void Delete(int BCDId)
        {
            BCDs.RemoveAll(x => x.BCDId == BCDId);
        }

        public static void Update(int BCDId, BCD bcd)
        {
            var bcdToUpdate = GetById(BCDId);
            if (bcdToUpdate != null)
            {
                bcdToUpdate.Brand = bcd.Brand;
                bcdToUpdate.Model = bcd.Model;
                bcdToUpdate.Size = bcd.Size;
                bcdToUpdate.Price = bcd.Price;
            }
        }


    }
}
