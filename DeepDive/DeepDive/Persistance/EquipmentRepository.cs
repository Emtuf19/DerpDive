using DeepDive.Models;

namespace DeepDive.Persistance
{
    public static class EquipmentRepository
    {
        public static List<BCD> BCDs = new List<BCD>
        {
            new BCD
            {
                BCDId = 1,
                Brand = "Scubapro",
                Model = "Navigator Lite BCD",
                Size = "S, M, L",
                Price = 125
            },
            new BCD
            {
                BCDId = 2,
                Brand = "Scubapro",
                Model = "BCD Glide",
                Size = "S, M, L",
                Price = 140
            },
            new BCD
            {
                BCDId = 3,
                Brand = "Scubapro",
                Model = "BCD Hydros Pro",
                Size = "S, M, L",
                Price = 200
            },
            new BCD
            {
                BCDId = 4,
                Brand = "Seac",
                Model = "BCD Modular",
                Size = "S, M, L",
                Price = 145
            }
        };

        public static List<DivingSuits> divingSuits = new List<DivingSuits> {
            new DivingSuits
            {
                DivingSuitsId = 1,
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
                DivingSuitsId = 2,
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
                DivingSuitsId = 3,
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
                DivingSuitsId = 4,
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
                DivingSuitsId = 5,
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
                DivingSuitsId = 6,
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
                DivingSuitsId = 7,
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
                DivingSuitsId = 8,
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
                FinnsId = 1,
                Brand = "Scubapro",
                Model = "Jet Fin",
                Size = "XS, S, M, L, XL",
                Price = 50
            },
            new Finns
            {
                FinnsId = 2,
                Brand = "Scubapro",
                Model = "GO Travel",
                Size = "XS, S, M, L, XL",
                Price = 50
            },
            new Finns
            {
                FinnsId = 3,
                Brand = "Scubapro",
                Model = "Seawing Supernova",
                Size = "XS, S, M, L, XL",
                Price = 60
            },
            new Finns
            {
                FinnsId = 4,
                Brand = "Seac",
                Model = "Propulsion",
                Size = "XS, S, M, L, XL",
                Price = 50
            },
            new Finns
            {
                FinnsId = 5,
                Brand = "Seac",
                Model = "ALA",
                Size = "XS, S, M, L, XL",
                Price = 50
            },
            new Finns
            {
                FinnsId = 6,
                Brand = "Fourth Element",
                Model = "Tech",
                Size = "XS, S, M, L, XL",
                Price = 75
            },
            new Finns
            {
                FinnsId = 7,
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

        };
        public static List<RegulatorSet> regulatorSets = new List<RegulatorSet>
        {
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
        };


        public static List<Tank> tanks = new List<Tank>
        {
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

        public static BCD? GetByIdBCD(int id)
        {
            return BCDs.FirstOrDefault(x => x.BCDId == id);
        }

        public static DivingSuits? GetByIdDivingSuits(int id)
        {
            return divingSuits.FirstOrDefault(x => x.DivingSuitsId == id);
        }

        public static Finns? GetByIdFinns(int id)
        {
            return finns.FirstOrDefault(x => x.FinnsId == id);
        }

        public static Mask_Snorkel? GetByIdMask_Snorkel(int id)
        {
            return mask_Snorkels.FirstOrDefault(x => x.Mask_SnorkelId == id);
        }

        public static RegulatorSet? GetByIdRegulatorSet(int id)
        {
            return regulatorSets.FirstOrDefault(x => x.RegulatorSetId == id);
        }

        public static Tank? GetByIdTank(int id)
        {
            return tanks.FirstOrDefault(x => x.TankId == id);
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
            var bcdToUpdate = GetByIdBCD(BCDId);
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
