using CleanArchitectureMvc.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchitectureMvc.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName ="Create Category With Valid State")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should()
                  .NotThrow<CleanArchitectureMvc.Domain.Validation.DomainExceptionValidation>();

        }
        [Fact(DisplayName = "Create Category With Invalid Id")]
        public void CreateCategory_NegativeIdValue_InvalidId()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should()
                  .Throw<CleanArchitectureMvc.Domain.Validation.DomainExceptionValidation>()
                  .WithMessage("Invalid Id Value");

        }
        [Fact(DisplayName = "Create Category With Short Name")]
        public void CreateCategory_With_ShortName()
        {
            Action action = () => new Category(1, "Ca");
            action.Should()
                  .Throw<CleanArchitectureMvc.Domain.Validation.DomainExceptionValidation>()
                  .WithMessage("Invalid name, too short, minimum 3 charecters.");

        }
        [Fact(DisplayName = "Create Category Without Name")]
        public void CreateCategory_Without_Name()
        {
            Action action = () => new Category(1, "");
            action.Should()
                  .Throw<CleanArchitectureMvc.Domain.Validation.DomainExceptionValidation>()
                  .WithMessage("Invalid name. Name is required");

        }
        [Fact(DisplayName = "Create Category With Null")]
        public void CreateCategory_With_Null()
        {
            Action action = () => new Category(1, null);
            action.Should()
                  .Throw<CleanArchitectureMvc.Domain.Validation.DomainExceptionValidation>();
               

        }
    }
}
