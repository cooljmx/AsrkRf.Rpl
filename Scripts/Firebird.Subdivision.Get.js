var equalData = function (input, output) {
    output.IdSubdivision = input.IdPodrazdelenie;
    output.SubdivisionName = input.Podrazdname;
    output.SubdivisionShortName = input.PodrazdnameSokr;
    output.IdRegion = input.IdRegion;
}

podrazdelenieList.forEach(function (element) {
    equalData(element, cloud);
    if (element.IdParent != 0) {
        cloud.Parent = cloud.CreateParent();
        cloud = cloud.Parent;
    }
});

cloud.Print(test.Id);