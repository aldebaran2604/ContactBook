module com.contactbook.contactbookforms {
    requires javafx.controls;
    requires javafx.fxml;

    opens com.contactbook.contactbookforms to javafx.fxml;
    exports com.contactbook.contactbookforms;
}
