TimesTable(7);

decimal productCost = 199M;
WriteLine($"The product will cost ${CalculateTax(productCost, "USA")} in the USA and " +
    $"${CalculateTax(productCost, "ARG")} in Argentina.");