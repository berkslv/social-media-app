import React from 'react'

function Container({ children, className, style }) {
  return (
    <div className={`container py-3 ${className}`} style={style}>
        {children}
    </div>
  )
}

export default Container