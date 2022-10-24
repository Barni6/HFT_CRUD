using KJWTMR_HTF_2022231.Logic;
using KJWTMR_HTF_2022231.Logic.Interfaces;
using KJWTMR_HTF_2022231.Models;
using KJWTMR_HTF_2022231.Models.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Type = KJWTMR_HTF_2022231.Models.Type;

namespace KJWTMR_HFT_2022231.Test
{
    [TestFixture]
    public class BeerLogicTest
    {
        BeerLogic beerlogic;
        BrandLogic brandlogic;
        TypeLogic typelogic;
        Mock<IRepository<Beer>> mockBeerRepository;
        Mock<IRepository<Brand>> mockBrandRepository;
        Mock<IRepository<Type>> mockTypeRepository;

        [SetUp]
        public void Setup()
        {         
            mockBeerRepository = new Mock<IRepository<Beer>>();
            beerlogic = new BeerLogic(mockBeerRepository.Object);

            mockBrandRepository = new Mock<IRepository<Brand>>();
            brandlogic = new BrandLogic(mockBrandRepository.Object);

            mockTypeRepository = new Mock<IRepository<Type>>();
            typelogic = new TypeLogic(mockTypeRepository.Object);
        }


        #region CreateTests
        [TestCase(1)]
        [TestCase(15)]
        public void CreateBeerTestCorrect(int id)
        {
            var beer = new Beer() { Id = id };

            //Act
            beerlogic.Create(beer);

            //Assert
            mockBeerRepository.Verify(r => r.Create(beer), Times.Once);
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void CreateBeerTestInCorrect(int id)
        {
            var beer = new Beer() { Id = id };
            try
            {
                //Act
                beerlogic.Create(beer);
            }
            catch{ }
                      
            //Assert
            mockBeerRepository.Verify(r => r.Create(beer), Times.Never);
        }

        [TestCase(1)]
        [TestCase(8)]
        public void CreateBrandTestCorrect(int id)
        {
            var brand = new Brand() { Id = id };

            //Act
            brandlogic.Create(brand);

            //Assert
            mockBrandRepository.Verify(r => r.Create(brand), Times.Once);
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void CreateBrandTestInCorrect(int id)
        {
            var brand = new Brand() { Id = id };
            try
            {
                //Act
                brandlogic.Create(brand);
            }
            catch { }

            //Assert
            mockBrandRepository.Verify(r => r.Create(brand), Times.Never);
        }

        [TestCase(1)]
        [TestCase(6)]
        public void CreateTypeTestCorrect(int id)
        {
            var type = new Type() { Id = id };

            //Act
            typelogic.Create(type);

            //Assert
            mockTypeRepository.Verify(r => r.Create(type), Times.Once);
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void CreateTypeTestInCorrect(int id)
        {
            var type = new Type() { Id = id };
            try
            {
                //Act
                typelogic.Create(type);
            }
            catch { }

            //Assert
            mockTypeRepository.Verify(r => r.Create(type), Times.Never);
        }
        #endregion

    }
}
