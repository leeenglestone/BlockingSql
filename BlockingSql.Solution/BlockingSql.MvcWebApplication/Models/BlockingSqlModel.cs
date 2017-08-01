using System.Collections.Generic;

namespace BlockingSql.MvcWebApplication.Models
{
    public class BlockingSqlModel
    {
        public IEnumerable<BlockingSqlStatementModel> BlockingSqlStatements { get; set; }

        public BlockingSqlModel(IEnumerable<BlockingSqlStatementModel> blockingSqlStatements)
        {
            BlockingSqlStatements = blockingSqlStatements;
        }
    }
}