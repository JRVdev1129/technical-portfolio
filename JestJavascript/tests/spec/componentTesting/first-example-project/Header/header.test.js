import { cleanup, fireEvent, render, screen } from "@testing-library/react";
import Header from "../../../../../react-example-project/src/components/Header/Header.js";

// Note: running cleanup afterEach is done automatically for you in @testing-library/react@9.0.0 or higher
// unmount and cleanup DOM after the test is finished.
afterEach(cleanup);

it("CheckboxWithLabel changes the text after click", () => {
  render(<Header title="header" />);
  const headerElement = screen.getByText("header");

  expect(headerElement).toBeInTheDocument();

  // fireEvent.click(getByLabelText(/off/i));

  // expect(queryByLabelText(/on/i)).toBeTruthy();
});
