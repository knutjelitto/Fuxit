(module
 (type $i32_=>_i32 (func (param i32) (result i32)))
 (type $none_=>_none (func))
 (type $f64_f64_=>_f64 (func (param f64 f64) (result f64)))
 (global $__stack_pointer (mut i32) (i32.const 66560))
 (global $global$1 i32 (i32.const 1024))
 (global $global$2 i32 (i32.const 1024))
 (global $global$3 i32 (i32.const 1024))
 (global $global$4 i32 (i32.const 66560))
 (global $global$5 i32 (i32.const 0))
 (global $global$6 i32 (i32.const 1))
 (memory $0 16 16)
 (export "memory" (memory $0))
 (export "__wasm_call_ctors" (func $__wasm_call_ctors))
 (export "square" (func $square))
 (export "duple" (func $duple))
 (export "sum" (func $sum))
 (export "__cos" (func $__cos))
 (export "__dso_handle" (global $global$1))
 (export "__data_end" (global $global$2))
 (export "__global_base" (global $global$3))
 (export "__heap_base" (global $global$4))
 (export "__memory_base" (global $global$5))
 (export "__table_base" (global $global$6))
 (func $__wasm_call_ctors
 )
 (func $square (param $0 i32) (result i32)
  (i32.mul
   (local.get $0)
   (local.get $0)
  )
 )
 (func $duple (param $0 i32) (result i32)
  (i32.shl
   (local.get $0)
   (i32.const 1)
  )
 )
 (func $sum (param $0 i32) (result i32)
  (i32.shl
   (local.get $0)
   (i32.const 1)
  )
 )
 (func $__cos (param $0 f64) (param $1 f64) (result f64)
  (f64.add
   (f64.sub
    (f64.const 1)
    (f64.mul
     (local.get $1)
     (local.get $0)
    )
   )
   (f64.mul
    (f64.add
     (f64.add
      (f64.mul
       (f64.mul
        (local.tee $1
         (f64.mul
          (local.tee $0
           (f64.mul
            (local.get $0)
            (local.get $0)
           )
          )
          (local.get $0)
         )
        )
        (local.get $1)
       )
       (f64.add
        (f64.mul
         (f64.add
          (f64.mul
           (local.get $0)
           (f64.const -1.1359647557788195e-11)
          )
          (f64.const 2.087572321298175e-09)
         )
         (local.get $0)
        )
        (f64.const -2.7557314351390663e-07)
       )
      )
      (f64.const -0.5)
     )
     (f64.mul
      (f64.add
       (f64.mul
        (f64.add
         (f64.mul
          (local.get $0)
          (f64.const 2.480158728947673e-05)
         )
         (f64.const -0.001388888888887411)
        )
        (local.get $0)
       )
       (f64.const 0.0416666666666666)
      )
      (local.get $0)
     )
    )
    (local.get $0)
   )
  )
 )
 ;; custom section "producers", size 28
)

