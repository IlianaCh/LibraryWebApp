<script src="https://code.jquery.com/jquery-3.6.4.min.js"></script>

<script>
    $(document).ready(function () {
        // Initial load or when the page is ready
        filterObjects(""); // Load all objects

        // Handle button click events
        $(".filter-button").on("click", function () {
            var filterValue = $(this).data("filter");
            filterObjects(filterValue);
        });
    });

    function filterObjects(filter) {
        $.ajax({
            url: '@Url.Action("FilterObjects", "YourController")', // Replace "YourController" with your actual controller name
            type: 'GET',
            data: { filter: filter },
            success: function (result) {
                $('#objectTable').html(result);
            },
            error: function (error) {
                console.log(error);
            }
        });
    }
</script>
