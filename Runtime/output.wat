(module
  (type (;0;) (func))
  (type (;1;) (func (param i32) (result i32)))
  (func (;0;) (type 0)
    nop)
  (func (;1;) (type 1) (param i32) (result i32)
    local.get 0
    local.get 0
    i32.mul)
  (export "__wasm_call_ctors" (func 0))
  (export "square" (func 1)))
