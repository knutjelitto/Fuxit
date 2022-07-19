(module
 (type $f64_=>_f64 (func (param f64) (result f64)))
 (type $f64_f64_=>_f64 (func (param f64 f64) (result f64)))
 (type $f64_i32_=>_i32 (func (param f64 i32) (result i32)))
 (type $f64_f64_i32_=>_f64 (func (param f64 f64 i32) (result f64)))
 (type $none_=>_none (func))
 (type $i32_i32_=>_i32 (func (param i32 i32) (result i32)))
 (type $f64_i32_=>_f64 (func (param f64 i32) (result f64)))
 (import "env" "core_math___cos" (func $core_math___cos (param f64 f64) (result f64)))
 (import "env" "core_math___rem_pio2" (func $core_math___rem_pio2 (param f64 i32) (result i32)))
 (import "env" "core_math___sin" (func $core_math___sin (param f64 f64 i32) (result f64)))
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
 (export "adder" (func $adder))
 (export "core_math_scalbn" (func $core_math_scalbn))
 (export "core_math_cos" (func $core_math_cos))
 (export "core_math_sin" (func $core_math_sin))
 (export "__dso_handle" (global $global$1))
 (export "__data_end" (global $global$2))
 (export "__global_base" (global $global$3))
 (export "__heap_base" (global $global$4))
 (export "__memory_base" (global $global$5))
 (export "__table_base" (global $global$6))
 (func $__wasm_call_ctors
 )
 (func $adder (param $0 i32) (param $1 i32) (result i32)
  (i32.add
   (local.get $1)
   (local.get $0)
  )
 )
 (func $core_math_scalbn (param $0 f64) (param $1 i32) (result f64)
  (block $label$1
   (block $label$2
    (br_if $label$2
     (i32.lt_s
      (local.get $1)
      (i32.const 1024)
     )
    )
    (block $label$3
     (br_if $label$3
      (i32.ge_u
       (local.get $1)
       (i32.const 2047)
      )
     )
     (local.set $1
      (i32.add
       (local.get $1)
       (i32.const -1023)
      )
     )
     (local.set $0
      (f64.mul
       (local.get $0)
       (f64.const 8988465674311579538646525e283)
      )
     )
     (br $label$1)
    )
    (local.set $1
     (i32.add
      (select
       (local.get $1)
       (i32.const 3069)
       (i32.lt_u
        (local.get $1)
        (i32.const 3069)
       )
      )
      (i32.const -2046)
     )
    )
    (br $label$1)
   )
   (br_if $label$1
    (i32.gt_s
     (local.get $1)
     (i32.const -1023)
    )
   )
   (block $label$4
    (br_if $label$4
     (i32.le_u
      (local.get $1)
      (i32.const -1992)
     )
    )
    (local.set $1
     (i32.add
      (local.get $1)
      (i32.const 969)
     )
    )
    (local.set $0
     (f64.mul
      (local.get $0)
      (f64.const 2.004168360008973e-292)
     )
    )
    (br $label$1)
   )
   (local.set $1
    (i32.add
     (select
      (local.get $1)
      (i32.const -2960)
      (i32.gt_u
       (local.get $1)
       (i32.const -2960)
      )
     )
     (i32.const 1938)
    )
   )
   (local.set $0
    (f64.const 0)
   )
  )
  (f64.mul
   (local.get $0)
   (f64.reinterpret_i64
    (i64.shl
     (i64.extend_i32_u
      (i32.add
       (local.get $1)
       (i32.const 1023)
      )
     )
     (i64.const 52)
    )
   )
  )
 )
 (func $core_math_cos (param $0 f64) (result f64)
  (local $1 i32)
  (local $2 i32)
  (local $3 f64)
  (global.set $__stack_pointer
   (local.tee $1
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 16)
    )
   )
  )
  (block $label$1
   (block $label$2
    (br_if $label$2
     (i32.gt_u
      (local.tee $2
       (i32.and
        (i32.wrap_i64
         (i64.shr_u
          (i64.reinterpret_f64
           (local.get $0)
          )
          (i64.const 32)
         )
        )
        (i32.const 2147483647)
       )
      )
      (i32.const 1072243195)
     )
    )
    (block $label$3
     (br_if $label$3
      (i32.gt_u
       (local.get $2)
       (i32.const 1044816029)
      )
     )
     (f64.store
      (local.get $1)
      (f64.add
       (local.get $0)
       (f64.const 1329227995784915872903807e12)
      )
     )
     (local.set $3
      (f64.const 1)
     )
     (br $label$1)
    )
    (local.set $3
     (call $core_math___cos
      (local.get $0)
      (f64.const 0)
     )
    )
    (br $label$1)
   )
   (local.set $3
    (f64.const 0)
   )
   (br_if $label$1
    (i32.gt_u
     (local.get $2)
     (i32.const 2146435071)
    )
   )
   (block $label$4
    (block $label$5
     (block $label$6
      (block $label$7
       (br_table $label$7 $label$6 $label$5 $label$4
        (i32.and
         (call $core_math___rem_pio2
          (local.get $0)
          (local.get $1)
         )
         (i32.const 3)
        )
       )
      )
      (local.set $3
       (call $core_math___cos
        (f64.load
         (local.get $1)
        )
        (f64.load offset=8
         (local.get $1)
        )
       )
      )
      (br $label$1)
     )
     (local.set $3
      (f64.neg
       (call $core_math___sin
        (f64.load
         (local.get $1)
        )
        (f64.load offset=8
         (local.get $1)
        )
        (i32.const 1)
       )
      )
     )
     (br $label$1)
    )
    (local.set $3
     (f64.neg
      (call $core_math___cos
       (f64.load
        (local.get $1)
       )
       (f64.load offset=8
        (local.get $1)
       )
      )
     )
    )
    (br $label$1)
   )
   (local.set $3
    (call $core_math___sin
     (f64.load
      (local.get $1)
     )
     (f64.load offset=8
      (local.get $1)
     )
     (i32.const 1)
    )
   )
  )
  (global.set $__stack_pointer
   (i32.add
    (local.get $1)
    (i32.const 16)
   )
  )
  (local.get $3)
 )
 (func $core_math_sin (param $0 f64) (result f64)
  (local $1 i32)
  (local $2 i32)
  (local $3 f64)
  (global.set $__stack_pointer
   (local.tee $1
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 16)
    )
   )
  )
  (block $label$1
   (block $label$2
    (br_if $label$2
     (i32.gt_u
      (local.tee $2
       (i32.and
        (i32.wrap_i64
         (i64.shr_u
          (i64.reinterpret_f64
           (local.get $0)
          )
          (i64.const 32)
         )
        )
        (i32.const 2147483647)
       )
      )
      (i32.const 1072243195)
     )
    )
    (block $label$3
     (br_if $label$3
      (i32.gt_u
       (local.get $2)
       (i32.const 1045430271)
      )
     )
     (f64.store
      (local.get $1)
      (select
       (f64.mul
        (local.get $0)
        (f64.const 7.52316384526264e-37)
       )
       (f64.add
        (local.get $0)
        (f64.const 1329227995784915872903807e12)
       )
       (i32.lt_u
        (local.get $2)
        (i32.const 1048576)
       )
      )
     )
     (local.set $3
      (local.get $0)
     )
     (br $label$1)
    )
    (local.set $3
     (call $core_math___sin
      (local.get $0)
      (f64.const 0)
      (i32.const 0)
     )
    )
    (br $label$1)
   )
   (local.set $3
    (f64.const 0)
   )
   (br_if $label$1
    (i32.gt_u
     (local.get $2)
     (i32.const 2146435071)
    )
   )
   (block $label$4
    (block $label$5
     (block $label$6
      (block $label$7
       (br_table $label$7 $label$6 $label$5 $label$4
        (i32.and
         (call $core_math___rem_pio2
          (local.get $0)
          (local.get $1)
         )
         (i32.const 3)
        )
       )
      )
      (local.set $3
       (call $core_math___sin
        (f64.load
         (local.get $1)
        )
        (f64.load offset=8
         (local.get $1)
        )
        (i32.const 1)
       )
      )
      (br $label$1)
     )
     (local.set $3
      (call $core_math___cos
       (f64.load
        (local.get $1)
       )
       (f64.load offset=8
        (local.get $1)
       )
      )
     )
     (br $label$1)
    )
    (local.set $3
     (f64.neg
      (call $core_math___sin
       (f64.load
        (local.get $1)
       )
       (f64.load offset=8
        (local.get $1)
       )
       (i32.const 1)
      )
     )
    )
    (br $label$1)
   )
   (local.set $3
    (f64.neg
     (call $core_math___cos
      (f64.load
       (local.get $1)
      )
      (f64.load offset=8
       (local.get $1)
      )
     )
    )
   )
  )
  (global.set $__stack_pointer
   (i32.add
    (local.get $1)
    (i32.const 16)
   )
  )
  (local.get $3)
 )
 ;; custom section "producers", size 28
)

