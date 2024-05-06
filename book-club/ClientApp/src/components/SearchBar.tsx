import { ChangeEventHandler, MouseEventHandler } from "react";

export interface SearchBarProps {
  handleInputChange: ChangeEventHandler;
  handleOptionSelect: Function;
  ListOptions: string[];
  placeHolder?: string;
  DebounceTime?: number;
}

export function SearchBar(props: SearchBarProps) {
  return (
    <div>
      <input
        type="text"
        placeholder={props.placeHolder ?? "Placeholder Not Supplied"}
        onChange={props.handleInputChange}
      ></input>
      <ul>
        {props.ListOptions.map((x, idx) => (
          <li key={idx} onClick={() => props.handleOptionSelect(idx)}>
            {x}
          </li>
        ))}
      </ul>
    </div>
  );
}
