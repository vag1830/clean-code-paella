using System;

namespace Paella.Application.UseCases.Update.Parameters
{
    public class UpdateInput
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}