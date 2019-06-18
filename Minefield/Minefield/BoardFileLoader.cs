using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;

namespace Minefield
{
    public class BoardFileLoader
    {
        public async Task<Board> LoadBoardAsync(string jsonFilePath)
        {
            var json = await File.ReadAllTextAsync(jsonFilePath);
            return JsonConvert.DeserializeObject<Board>(json);
        }

        public async Task<IEnumerable<IEnumerable<ITurtleCommand>>> LoadCommandsAsync(string jsonFilePath)
        {
            var json = await File.ReadAllTextAsync(jsonFilePath);
            return  JsonConvert
                .DeserializeObject<List<List<string>>>(json)
                .Select(x => x.Select(y => ConvertCommand(y)));
        }

        private ITurtleCommand ConvertCommand(string value)
        {
            if (string.Equals("r", value, StringComparison.InvariantCultureIgnoreCase)) {
                return new RotateTurtleCommand();
            }

            if (string.Equals("m", value, StringComparison.InvariantCultureIgnoreCase)) {
                return new MoveTurtleCommand();
            }

            throw new FileLoadException("Invalid command found");
        }
    }
}
