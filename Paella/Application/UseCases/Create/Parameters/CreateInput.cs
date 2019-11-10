using System;

namespace Paella.Application.UseCases.Create.Parameters
{
    public class CreateInput
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}