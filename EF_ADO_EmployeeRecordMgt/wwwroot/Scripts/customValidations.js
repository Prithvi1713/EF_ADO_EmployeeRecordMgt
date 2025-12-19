function applyExportDateValidation(fromDateSelector, toDateSelector) {

    var today = new Date().toISOString().split('T')[0];

    $(fromDateSelector).attr("max", today);
    $(toDateSelector).attr("max", today);

    $(fromDateSelector).on("change", function () {

        var fromDate = $(this).val();

        if (fromDate) {
            $(toDateSelector).attr("min", fromDate);

            if ($(toDateSelector).val() < fromDate) {
                $(toDateSelector).val('');
            }
        } else {
            $(toDateSelector).removeAttr("min");
        }
    });
}

$(function () {
    const today = new Date().toISOString().split('T')[0];
    $(".export-from-date, .export-to-date").attr("max", today);

    $(".export-from-date").on("change", function () {
        const fromDate = $(this).val();
        const toInput = $(this).closest("form").find(".export-to-date");

        toInput.attr("min", fromDate || "");
        if (toInput.val() < fromDate) toInput.val("");
    });
});
