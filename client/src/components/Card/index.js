import React from "react";

function Card({ cardHeader, cardTitle, cardText, cardButtons, cardFooter }) {
  return (
    <div class="card">
      {cardHeader && <div class="card-header">{cardHeader}</div>}
      <div class="card-body">
        {cardTitle && <h5 class="card-title">{cardTitle}</h5>}
        {cardText && <p class="card-text">{cardText}</p>}
        {cardButtons && { cardButtons }}
      </div>
      {cardFooter && <div class="card-footer">{cardFooter}</div>}
    </div>
  );
}

export default Card;
