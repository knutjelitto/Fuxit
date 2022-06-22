(module
 (type $i32_=>_i32 (func (param i32) (result i32)))
 (type $i32_i32_=>_none (func (param i32 i32)))
 (type $i32_i32_i32_=>_i32 (func (param i32 i32 i32) (result i32)))
 (type $i32_=>_none (func (param i32)))
 (type $i32_i32_=>_i32 (func (param i32 i32) (result i32)))
 (type $i32_i32_i32_=>_none (func (param i32 i32 i32)))
 (type $none_=>_none (func))
 (type $i32_i32_i32_i32_=>_i32 (func (param i32 i32 i32 i32) (result i32)))
 (type $f64_=>_i32 (func (param f64) (result i32)))
 (type $none_=>_i32 (func (result i32)))
 (type $i32_i32_i32_i32_i32_=>_i32 (func (param i32 i32 i32 i32 i32) (result i32)))
 (type $i32_i32_i32_i32_=>_none (func (param i32 i32 i32 i32)))
 (type $f64_f64_=>_i32 (func (param f64 f64) (result i32)))
 (type $i32_i32_=>_f64 (func (param i32 i32) (result f64)))
 (type $i32_i32_i32_i32_f64_i32_=>_i32 (func (param i32 i32 i32 i32 f64 i32) (result i32)))
 (type $i32_i32_i32_i32_i32_i32_i64_=>_none (func (param i32 i32 i32 i32 i32 i32 i64)))
 (type $i32_i32_i32_i32_i32_i64_i64_=>_none (func (param i32 i32 i32 i32 i32 i64 i64)))
 (type $i32_i32_i32_i32_i32_=>_none (func (param i32 i32 i32 i32 i32)))
 (type $i32_i32_=>_i64 (func (param i32 i32) (result i64)))
 (type $i32_i32_i32_i32_i32_i32_i32_i32_=>_none (func (param i32 i32 i32 i32 i32 i32 i32 i32)))
 (type $i32_i32_i32_i32_i32_i32_i32_i32_i32_=>_none (func (param i32 i32 i32 i32 i32 i32 i32 i32 i32)))
 (import "env" "sweepJsRefs" (func $sweepJsRefs (param i32)))
 (import "env" "abort" (func $abort))
 (import "env" "pow" (func $pow (param f64 f64) (result i32)))
 (import "env" "round" (func $round (param f64) (result i32)))
 (import "env" "floor" (func $floor (param f64) (result i32)))
 (import "env" "ceil" (func $ceil (param f64) (result i32)))
 (import "env" "log" (func $log (param f64) (result i32)))
 (import "env" "applyJsRef" (func $applyJsRef (param i32 i32 i32) (result i32)))
 (import "env" "jsStepper" (func $jsStepper (param i32)))
 (import "env" "exit" (func $exit (param i32)))
 (import "env" "write" (func $write (param i32 i32 i32) (result i32)))
 (import "env" "Wrapper_setupIncomingPort" (func $Wrapper_setupIncomingPort (param i32) (result i32)))
 (import "env" "Wrapper_setupOutgoingPort" (func $Wrapper_setupOutgoingPort (result i32)))
 (import "env" "Json_runHelp" (func $Json_runHelp (param i32 i32) (result i32)))
 (import "env" "Wrapper_sleep" (func $Wrapper_sleep (param f64) (result i32)))
 (import "env" "parseFloat" (func $parseFloat (param i32 i32) (result f64)))
 (import "env" "isnan" (func $isnan (param f64) (result i32)))
 (import "env" "jsRefToWasmRecord" (func $jsRefToWasmRecord (param i32) (result i32)))
 (import "env" "Debug_evaluator_name" (func $Debug_evaluator_name (param i32) (result i32)))
 (import "env" "putchar" (func $putchar (param i32) (result i32)))
 (import "env" "eval_Test_runThunk" (func $eval_Test_runThunk (param i32) (result i32)))
 (import "env" "eval_Json_succeed" (func $eval_Json_succeed (param i32) (result i32)))
 (import "env" "eval_Json_fail" (func $eval_Json_fail (param i32) (result i32)))
 (import "env" "eval_Json_decodeList" (func $eval_Json_decodeList (param i32) (result i32)))
 (import "env" "eval_Json_decodeArray" (func $eval_Json_decodeArray (param i32) (result i32)))
 (import "env" "eval_Json_decodeNull" (func $eval_Json_decodeNull (param i32) (result i32)))
 (import "env" "eval_Json_decodeField" (func $eval_Json_decodeField (param i32) (result i32)))
 (import "env" "eval_Json_decodeIndex" (func $eval_Json_decodeIndex (param i32) (result i32)))
 (import "env" "eval_Json_decodeKeyValuePairs" (func $eval_Json_decodeKeyValuePairs (param i32) (result i32)))
 (import "env" "eval_Json_andThen" (func $eval_Json_andThen (param i32) (result i32)))
 (import "env" "eval_Json_oneOf" (func $eval_Json_oneOf (param i32) (result i32)))
 (import "env" "eval_Json_mapMany" (func $eval_Json_mapMany (param i32) (result i32)))
 (import "env" "eval_Json_array_get" (func $eval_Json_array_get (param i32) (result i32)))
 (import "env" "eval_runOnString" (func $eval_runOnString (param i32) (result i32)))
 (import "env" "eval_Json_run" (func $eval_Json_run (param i32) (result i32)))
 (import "env" "eval_Json_wrap" (func $eval_Json_wrap (param i32) (result i32)))
 (import "env" "eval_Json_unwrap" (func $eval_Json_unwrap (param i32) (result i32)))
 (import "env" "eval_Json_emptyArray" (func $eval_Json_emptyArray (param i32) (result i32)))
 (import "env" "eval_Json_emptyObject" (func $eval_Json_emptyObject (param i32) (result i32)))
 (import "env" "eval_Json_addField" (func $eval_Json_addField (param i32) (result i32)))
 (import "env" "eval_Json_addEntry" (func $eval_Json_addEntry (param i32) (result i32)))
 (import "env" "eval_Json_encode" (func $eval_Json_encode (param i32) (result i32)))
 (import "env" "eval_wrapInit" (func $eval_wrapInit (param i32) (result i32)))
 (import "env" "eval_wrapView" (func $eval_wrapView (param i32) (result i32)))
 (import "env" "eval_intercept" (func $eval_intercept (param i32) (result i32)))
 (import "env" "brk" (func $brk (param i32) (result i32)))
 (import "env" "perror" (func $perror (param i32)))
 (import "env" "sbrk" (func $sbrk (param i32) (result i32)))
 (import "env" "markJsRef" (func $markJsRef (param i32)))
 (import "env" "setTempRet0" (func $setTempRet0 (param i32)))
 (global $__stack_pointer (mut i32) (i32.const 125536))
 (global $global$1 i32 (i32.const 8744))
 (global $global$2 i32 (i32.const 49760))
 (global $global$3 i32 (i32.const 8800))
 (global $global$4 i32 (i32.const 8532))
 (global $global$5 i32 (i32.const 8540))
 (global $global$6 i32 (i32.const 7844))
 (global $global$7 i32 (i32.const 8512))
 (global $global$8 i32 (i32.const 8708))
 (global $global$9 i32 (i32.const 8704))
 (global $global$10 i32 (i32.const 8712))
 (global $global$11 i32 (i32.const 8716))
 (global $global$12 i32 (i32.const 8080))
 (global $global$13 i32 (i32.const 8732))
 (global $global$14 i32 (i32.const 8720))
 (global $global$15 i32 (i32.const 8724))
 (global $global$16 i32 (i32.const 8728))
 (global $global$17 i32 (i32.const 8112))
 (global $global$18 i32 (i32.const 8736))
 (global $global$19 i32 (i32.const 8016))
 (global $global$20 i32 (i32.const 8568))
 (global $global$21 i32 (i32.const 8088))
 (global $global$22 i32 (i32.const 8100))
 (global $global$23 i32 (i32.const 8256))
 (global $global$24 i32 (i32.const 8740))
 (global $global$25 i32 (i32.const 8548))
 (global $global$26 i32 (i32.const 8552))
 (global $global$27 i32 (i32.const 8524))
 (global $global$28 i32 (i32.const 8688))
 (global $global$29 i32 (i32.const 7476))
 (global $global$30 i32 (i32.const 7488))
 (global $global$31 i32 (i32.const 7500))
 (global $global$32 i32 (i32.const 7512))
 (global $global$33 i32 (i32.const 7524))
 (global $global$34 i32 (i32.const 7536))
 (global $global$35 i32 (i32.const 7548))
 (global $global$36 i32 (i32.const 7560))
 (global $global$37 i32 (i32.const 7572))
 (global $global$38 i32 (i32.const 7584))
 (global $global$39 i32 (i32.const 7596))
 (global $global$40 i32 (i32.const 7608))
 (global $global$41 i32 (i32.const 7620))
 (global $global$42 i32 (i32.const 7632))
 (global $global$43 i32 (i32.const 7644))
 (global $global$44 i32 (i32.const 7656))
 (global $global$45 i32 (i32.const 7668))
 (global $global$46 i32 (i32.const 7680))
 (global $global$47 i32 (i32.const 7692))
 (global $global$48 i32 (i32.const 7704))
 (global $global$49 i32 (i32.const 7716))
 (global $global$50 i32 (i32.const 7728))
 (global $global$51 i32 (i32.const 7740))
 (global $global$52 i32 (i32.const 7752))
 (global $global$53 i32 (i32.const 7764))
 (global $global$54 i32 (i32.const 7776))
 (global $global$55 i32 (i32.const 7788))
 (global $global$56 i32 (i32.const 7800))
 (global $global$57 i32 (i32.const 7808))
 (global $global$58 i32 (i32.const 7820))
 (global $global$59 i32 (i32.const 7832))
 (global $global$60 i32 (i32.const 7848))
 (global $global$61 i32 (i32.const 7860))
 (global $global$62 i32 (i32.const 7872))
 (global $global$63 i32 (i32.const 7884))
 (global $global$64 i32 (i32.const 7896))
 (global $global$65 i32 (i32.const 7908))
 (global $global$66 i32 (i32.const 7920))
 (global $global$67 i32 (i32.const 7932))
 (global $global$68 i32 (i32.const 7944))
 (global $global$69 i32 (i32.const 7956))
 (global $global$70 i32 (i32.const 7968))
 (global $global$71 i32 (i32.const 7980))
 (global $global$72 i32 (i32.const 7992))
 (global $global$73 i32 (i32.const 8004))
 (global $global$74 i32 (i32.const 8020))
 (global $global$75 i32 (i32.const 8032))
 (global $global$76 i32 (i32.const 8044))
 (global $global$77 i32 (i32.const 8056))
 (global $global$78 i32 (i32.const 8068))
 (global $global$79 i32 (i32.const 8124))
 (global $global$80 i32 (i32.const 8136))
 (global $global$81 i32 (i32.const 8148))
 (global $global$82 i32 (i32.const 8160))
 (global $global$83 i32 (i32.const 8172))
 (global $global$84 i32 (i32.const 8184))
 (global $global$85 i32 (i32.const 8196))
 (global $global$86 i32 (i32.const 8208))
 (global $global$87 i32 (i32.const 8220))
 (global $global$88 i32 (i32.const 8232))
 (global $global$89 i32 (i32.const 8244))
 (global $global$90 i32 (i32.const 8272))
 (global $global$91 i32 (i32.const 8296))
 (global $global$92 i32 (i32.const 8308))
 (global $global$93 i32 (i32.const 8320))
 (global $global$94 i32 (i32.const 8332))
 (global $global$95 i32 (i32.const 8344))
 (global $global$96 i32 (i32.const 8356))
 (global $global$97 i32 (i32.const 8368))
 (global $global$98 i32 (i32.const 8380))
 (global $global$99 i32 (i32.const 8392))
 (global $global$100 i32 (i32.const 8404))
 (global $global$101 i32 (i32.const 8416))
 (global $global$102 i32 (i32.const 8428))
 (global $global$103 i32 (i32.const 8440))
 (global $global$104 i32 (i32.const 8452))
 (global $global$105 i32 (i32.const 8464))
 (global $global$106 i32 (i32.const 8476))
 (global $global$107 i32 (i32.const 8488))
 (global $global$108 i32 (i32.const 8500))
 (global $global$109 i32 (i32.const 8556))
 (global $global$110 i32 (i32.const 8580))
 (global $global$111 i32 (i32.const 8592))
 (global $global$112 i32 (i32.const 8604))
 (global $global$113 i32 (i32.const 8616))
 (global $global$114 i32 (i32.const 8628))
 (global $global$115 i32 (i32.const 8640))
 (global $global$116 i32 (i32.const 8652))
 (global $global$117 i32 (i32.const 8664))
 (global $global$118 i32 (i32.const 8676))
 (global $global$119 i32 (i32.const 1024))
 (global $global$120 i32 (i32.const 60000))
 (global $global$121 i32 (i32.const 1024))
 (global $global$122 i32 (i32.const 125536))
 (global $global$123 i32 (i32.const 0))
 (global $global$124 i32 (i32.const 1))
 (memory $0 16 16)
 (data $.rodata (i32.const 1024) "0123456789abcdefxp\00\00\00\00\00\00\00\00\00\00\00\00\00\000123456789ABCDEFXP\00identity\00Json_addEntry\00Json_mapMany\00Utils_apply\00Json_emptyArray\00Json_decodeArray\00List_sortBy\00Bitwise_shiftRightBy\00Bitwise_shiftLeftBy\00remainderBy\00Bitwise_shiftRightZfBy\00eval_modBy\00sm->index\00state->stack_map.index\00Json_decodeIndex\00Char 0x%x\00pow\00wrapView\00idiv\00fdiv\00JsArray_initializeFromList\00Json_decodeList\00Failed to decode message from port\00intercept\00GC_init_root\00not\00count\00Bitwise_complement\00String_toInt\00result\00Unit\00wrapInit\00String_split\00String_trimRight\00gt\00String_trimLeft\00Json_array_get\00JsArray_unsafeSet\00JsArray_unsafeGet\00Json_emptyObject\00compact\00String_toFloat\00modulus\00Platform_gatherEffects\00Utils_access\00Json_decodeKeyValuePairs\00applyTaggers\00String_uncons\00List_cons\00String_contains\00sendToApp_revArgs\00String_indexes\00mark_words\00%.1f %s\00%\'.0f %s\00Bitwise_xor\00cursor\00Scheduler_onError\00floor\00GC_collect_major\00Bitwise_or\00String_fromNumber\00JsArray_foldr\00String_foldr\00eq\00Platform_sendToApp\00manager_loop\00Json_unwrap\00Json_wrap\00JsArray_map\00Platform_map\00print_stack_map\00JsArray_indexedMap\00%8p\00Cons head: %p tail: %p\00Tuple3 a: %p b: %p c: %p\00Tuple2 a: %p b: %p\00Debug_todo\00Scheduler_spawn\00Scheduler_rawSpawn\00Json_run\00JsArray_singleton\00eval_String_join\00written\00Scheduler_andThen\00Json_andThen\00String_trim\00mul\00null\00Json_decodeNull\00Scheduler_kill\00String_all\00Scheduler_fail\00Json_fail\00Nil\00JsArray_foldl\00Utils_access_eval\00notEqual\00task\00Task\00brk\00Test_runThunk\00callback\00String_startsWith\00String_endsWith\00JsArray_length\00String_length\00JsArray_push\00Platform_batch\00Debug_log\00Debug_toString\00runOnString\00ceiling\00Scheduler_binding\00v->header.tag\00record->header.tag\00c->header.tag\00flag\00%.16g\00safe_vprintf\00Inf\00Platform_sendToSelf\00Platform_leaf\00Json_oneOf\00Float %f\00home >= 0 && home < Platform_managers_size\00p + size\00JsArray_initialize\00Scheduler_receive\00manager_loop_receive\00True\00next_value\00GC_stack_push_value\00negate\00false\00False\00v->header.tag == Tag_Closure\00c->header.tag == Tag_Closure\00compare\00home\00GC_stack_pop_frame\00Multiple ports with the same name\00le\00ge\00Json_encode\00toCode\00JsArray_slice\00String_slice\00mark_trace\00Tag_Record\00round\00Scheduler_send\00List_append\00Utils_append\00String_append\00Scheduler_rawSend\00p + size <= heap->end\00next_value < heap->end\00Bitwise_and\00%lld\00Json_decodeField\00Json_addField\00%ld\00Scheduler_succeed\00Json_succeed\00add\00Int %d\00JsRef %d\00Process id %d, stack size %d, mailbox size %d\00func\00src/kernel/core/./gc/compact.c\00src/kernel/core/utils.c\00src/kernel/core/basics.c\00src/kernel/core/platform.c\00src/kernel/core/./gc/mark.c\00src/kernel/core/./gc/stack.c\00src/kernel/core/debug/./log.c\00src/kernel/core/string.c\00src/kernel/core/gc/gc.c\00src/kernel/core/debug/./debug-c.c\00sub\00Platform_sendToApp_lambda\00Scheduler_step_lambda\00Scheduler_spawn_lambda\00Scheduler_kill_lambda\00Scheduler_send_lambda\00stack_flags[frame]\00stack_values[frame + 1]\00_kMGT\00_KMGT\00ON_ERROR\00JsArray_appendN\00NaN\00AND_THEN\00NULL\00FAIL\00BINDING\00sm->index < GC_STACK_MAP_SIZE\00RECEIVE\00SUCCEED\00kB\00MB\00<JSON Array>\00<JavaScript>\00<JSON Object>\00<Process>\00<unknown ctor>\00<fieldgroup>\00<unknown>\00<function>\00<Task>\00result->words16 + len16\00List_map2\00modulus != 0\00...\00(corrupt data? %08zx)\00(?)\00()\00Record (\00 \'%c\'\00\'F\'\00String \"%s\"\00%2d | %c | %8p | \00| %8p | %08zx |  %c   |%5d | \00Custom %s \00Fieldgroup \00%p \00Custom ctor: %d \00%s = \00%d = \00Closure (%s) n_values: %d max_values: %d values: \00) values: \00To run a WebAssembly app, you need to pass your program configuration record through WebAssembly.intercept before constructing the Program. For example:\n\n    Browser.application <|\n        WebAssembly.intercept\n            { init = init\n            , onUrlChange = onUrlChange\n            , onUrlRequest = onUrlRequest\n            , subscriptions = subscriptions\n            , update = update\n            , view = view\n            }\n\00%2d | %c | %8p |\n\00| %8p | %08zx |  %c   |      |\n\00{\n\00%s @ offset 0x%zx\n\00   %s = 0x%llx\n\00%8d stack_index\n\00Char 0x%8x\n\00%p start\n\00mark stack overflowed! Get more memory to grow it\n\00%s Wrapper args\n\00%4zd | %8p %s\n\00Task %s\n\00Closure %s\n\00   Expected    %s\n\00Global initializer\n\00FieldGroup\n\00Failed to find field %d in record access at %p\n\00Failed to find field %d in record update at %p\n\00Marking %p - %p, past heap end at %p\n\00process cache miss for Process id %d @ %p\n\00(out of bounds) %p\n\00Json.null\n\00Float %f\n\00True\n\00| Address  |   Hex    | Mark | Size | Value\n\00False\n\00\nASSERT failed in \'%s\' at %s:%d\n\00\nASSERT_EQUAL failed in \'%s\' at %s:%d\n\00\nASSERT_SANITY(%s) failed in \'%s\' at %s:%d\n\00%s @ %s:%d\n\00External JS object #%d\n\00Int %d\n\00ERROR in Platform_gatherEffects, unknown effect constructor %d\n\00JsRef %d\n\00Process id %d, stack size %d, mailbox size %d\n\00CORRUPTED!! tag %x size %d\n\00[]\n\00[\n\00NULL\n\00\nStack map:\n\00...etc...\n\00-----------------\n\00| -------- | -------- | ---- | ---- | -----\n\00(JSON Array)\n\00(JSON Object)\n\00| %8p | %08zx |      |%5zd | (zeros)\n\00Bitmap at %s:%d (%s)\n\00%p end             (%zd kB app heap)\n\00%p system_end      (%zd kB total heap)\n\00  %s (%p)\n\00%p next_alloc      (%zd kB used)\n\00%p roots (%d)\n\00Custom (ctor %d)\n\00%p gc_temp (%zd x %db)\n\00%p bitmap (%zd x %db)\n\00%p end_of_old_gen  (%zd kB)\n\00()\n\00(\n\00String \"%s\"\n\00   But found   %s == 0x%llx\n\n\00\00\00\0000010203040506070809101112131415161718192021222324252627282930313233343536373839404142434445464748495051525354555657585960616263646566676869707172737475767778798081828384858687888990919293949596979899\00\00\00\00\04\00\00\10\00\00\00\00\00\00\00\00\00\00\00\00\01\00\00\00\00\00\00\00\n\00\00\00\00\00\00\00d\00\00\00\00\00\00\00\e8\03\00\00\00\00\00\00\10\'\00\00\00\00\00\00\a0\86\01\00\00\00\00\00@B\0f\00\00\00\00\00\80\96\98\00\00\00\00\00\00\e1\f5\05\00\00\00\00\00\ca\9a;\00\00\00\00\00\e4\0bT\02\00\00\00\00\e8vH\17\00\00\00\00\10\a5\d4\e8\00\00\00\00\a0rN\18\t\00\00\00@z\10\f3Z\00\00\00\80\c6\a4~\8d\03\00\00\00\c1o\f2\86#\00\00\00\8a]xEc\01\00\00d\a7\b3\b6\e0\0d\00\00\e8\89\04#\c7\8a\00\00\00\00\00\00\f0?\00\00\00\00\00\00$@\00\00\00\00\00\00Y@\00\00\00\00\00@\8f@\00\00\00\00\00\88\c3@\00\00\00\00\00j\f8@\00\00\00\00\80\84.A\00\00\00\00\d0\12cA\00\00\00\00\84\d7\97A\00\00\00\00e\cd\cdA\00\00\00 _\a0\02B\00\00\00\e8vH7B\00\00\00\a2\94\1amB\00\00@\e5\9c0\a2B\00\00\90\1e\c4\bc\d6B\00\004&\f5k\0cC\00\80\e07y\c3AC\00\a0\d8\85W4vC\00\c8Ngm\c1\abC\00=\91`\e4X\e1C@\8c\b5x\1d\af\15DP\ef\e2\d6\e4\1aKD\92\d5M\06\cf\f0\80D\00\00\00\00\00\00\00\00\9a\99\99\99\99\99\b9?{\14\aeG\e1z\84?\fc\a9\f1\d2MbP?-C\1c\eb\e26\1a?\f1h\e3\88\b5\f8\e4>\8d\ed\b5\a0\f7\c6\b0>H\af\bc\9a\f2\d7z>:\8c0\e2\8eyE>\95\d6&\e8\0b.\11>\bb\bd\d7\d9\df|\db=\95dy\e1\7f\fd\a5=\11\ea-\81\99\97q=\82vIh\c2%<=\9b+\a1\86\9b\84\06=\16V\e7\9e\af\03\d2<\bc\89\d8\97\b2\d2\9c<\97\d4FF\f5\0eg<\acC\d2\d1]r2<\ac\d2\b6O\c9\83\fd;#B\92\0c\a1\9c\c7;O\9b\0e\n\b4\e3\92;\e6^\17\10 9^;\9a\99\99\99\99\99Y\bc\b8\1e\85\ebQ\b8\0e\bc\fa~j\bct\93\d8\bb\fee\f7\e4a\a1\b6\bbd\1e\f9\83\81\e7\8e\bb,\9c\a4\f9cZK;#\b0\83\94\e9\e1\15;\94L-\df#0\d0\ba;\b8\ab\bftF\b3\ba,\8d\dfeT\nr\ba\aa(M{\bc\f7G:\86\e8\f6\f0\'\7f\f99\95\df\a0\a5y\cd\ce\b9\e7=\83\t\t\a7N9\a0\f5G\16\837y\b9\99\87\e6\eb\c2\b4%9)0\n\08\b2\b7\0d\b9\ee\8cn\06(\c6\d7\b8\07=\9e\1e\b3R\8a86\e5\d8\a5GTg8^\b7\e0\b7\9fv?8i\a7\cb\d9fu\fa\b7Q\b2\12@\b3-(;aU,$\ceDb6\04\03\f3dc\9b\9b1\b7\1c\f7\b3\f7\db\d4,0>\08\e7\87\85\0f(#\c1pF*\d1G#]X\fcA\e3\fe\81\1e\d2 \c3]\bb1\bb\19\bd\a1q\ca\"\8c\f4\14\db\98\91\83\e4\0c/\10\a8dPr\03vg\0b\00\10\b2\f5\03\ba\a1\06/0\b7\b3\a7\c9\da\01\00\00\00\00\00\00\00\00y\e0)\b8\ad;\c17d\9f=\8d\a9F\ee\b2e+\8a!\c7\'2.\e9\01\aa\99i\d9Q)b9\fc\9e\"\c2\ac\a4z@c\"J\d0\ec\9fW\a1\87\f1\80;\12\9b\12\d9N\91\"N\\\96\82/\f4\cd\96\c2\9b\11\e1o\e1\f4\e7\f9\c9\8c*\90\a8r\n\eb\n\88\084\c1\12\8e\"N\83Y\12\fa\00\00\00\00\00\00\00\00\00\00\00\00\00\f6J\e1\c7\02-\b5D\c63T\ec\a5\06|Id\9f\e4\ab\c8\8bBN$N(\bf\a3\8b\08S\8c\b1\c2\f5)>\d0W|\dbA\bbH\7f\95\\\f4\fb\cb.\89s\\a=\0b\8f\f8\d6\d3\"f\n\8d\858\01\eb\e8j=\12$qE}\b0o\18ztU\ce\d2ut\823t\7f\13\e2<y\b0\f7\999\fd\1c\03~\00\00\00\00\00\00\00\00\00\00\00\00\00\00`A@\eb\0d\c8B\b5\ebE\n\b6\aa\b9\80;\e8\cal\16z\d1\".\a3\cf\0e\18.\90\066R\d4\87.F\82\b7o)\d9\11\d0\0b,\95X\f3\ddlK\a3v\13\8c\a7\e2\df:$\fciu\81\e7\a6\aa\97\a8e\93]\ec\a0#a%\0c\05\19q\a6\c7l\d7\99\17\db\f58\1aW9\fe\13\a2\fa\00\00\00\00\00\00\00\008\0f\00\00\05\0f\00\00\n\0f\00\00\f7\0e\00\00\da\0e\00\000\0f\00\00")
 (data $.data (i32.const 7472) ".,\00\00\03\00\00\a0\00\00\01\00\0f\00\00\00\03\00\00\a0\00\00\02\00\10\00\00\00\03\00\00\a0\00\00\02\00\11\00\00\00\03\00\00\a0\00\00\02\00\12\00\00\00\03\00\00\a0\00\00\02\00\13\00\00\00\03\00\00\a0\00\00\02\00\14\00\00\00\03\00\00\a0\00\00\02\00\15\00\00\00\03\00\00\a0\00\00\01\00\16\00\00\00\03\00\00\a0\00\00\01\00\17\00\00\00\03\00\00\a0\00\00\01\00\18\00\00\00\03\00\00\a0\00\00\01\00\19\00\00\00\03\00\00\a0\00\00\01\00\1a\00\00\00\03\00\00\a0\00\00\02\00\1b\00\00\00\03\00\00\a0\00\00\02\00\1c\00\00\00\03\00\00\a0\00\00\02\00\1d\00\00\00\03\00\00\a0\00\00\02\00\1e\00\00\00\03\00\00\a0\00\00\02\00\1f\00\00\00\03\00\00\a0\00\00\01\00 \00\00\00\03\00\00\a0\00\00\01\00!\00\00\00\03\00\00\a0\00\00\02\00\"\00\00\00\03\00\00\a0\00\00\02\00#\00\00\00\03\00\00\a0\00\00\02\00$\00\00\00\03\00\00\a0\00\00\01\00%\00\00\00\03\00\00\a0\00\00\02\00&\00\00\00\03\00\00\a0\00\00\02\00\'\00\00\00\03\00\00\a0\00\00\02\00(\00\00\00\03\00\00\a0\00\00\01\00)\00\00\00\02\00\00p\03\00\e2\04\03\00\00\a0\00\00\01\00-\00\00\00\03\00\00\a0\00\00\01\00.\00\00\00\03\00\00\a0\00\00\03\00/\00\00\00@!\00\00\03\00\00\a0\00\00\02\000\00\00\00\03\00\00\a0\00\00\02\001\00\00\00\03\00\00\a0\00\00\03\002\00\00\00\03\00\00\a0\00\00\02\003\00\00\00\03\00\00\a0\00\00\03\004\00\00\00\03\00\00\a0\00\00\03\005\00\00\00\03\00\00\a0\00\00\03\006\00\00\00\03\00\00\a0\00\00\03\007\00\00\00\03\00\00\a0\00\00\03\008\00\00\00\03\00\00\a0\00\00\03\009\00\00\00\03\00\00\a0\00\00\02\00:\00\00\00\03\00\00\a0\00\00\02\00;\00\00\00\03\00\00\a0\00\00\03\00<\00\00\00\03\00\00\a0\00\00\02\00=\00\00\00L!\00\00\03\00\00\a0\00\00\02\00>\00\00\00\03\00\00\a0\00\00\02\00?\00\00\00\03\00\00\a0\00\00\02\00\0c\00\00\00\03\00\00\a0\00\00\01\00@\00\00\00\03\00\00\a0\00\00\02\00A\00\00\00@!\00\00@!\00\00\03\00\00\a0\00\00\02\00\81\00\00\00\03\00\00\a0\00\00\03\00\82\00\00\00\03\00\00\a0\00\00\01\00\83\00\00\00\03\00\00\a0\00\00\01\00B\00\00\00\03\00\00\a0\00\00\01\00C\00\00\00\03\00\00\a0\00\00\01\00D\00\00\00\03\00\00\a0\00\00\02\00E\00\00\00\03\00\00\a0\00\00\02\00F\00\00\00\03\00\00\a0\00\00\01\00G\00\00\00\03\00\00\a0\00\00\01\00H\00\00\00\03\00\00\a0\00\00\01\00I\00\00\00\03\00\00\a0\00\00\02\00J\00\00\00\03\00\00\a0\00\00\02\00K\00\00\00\03\00\00\a0\00\00\01\00L\00\00\00@!\00\00@!\00\00\00\00\00\00\00\00\00\008\0f\00\00\05\0f\00\00\n\0f\00\00\f7\0e\00\00\da\0e\00\000\0f\00\00\03\00\00\a0\00\00\01\00M\00\00\00\03\00\00\a0\00\00\02\00N\00\00\00\03\00\00\a0\00\00\01\00O\00\00\00\03\00\00\a0\00\00\03\00P\00\00\00\03\00\00\a0\00\00\02\00Q\00\00\00\03\00\00\a0\00\00\02\00R\00\00\00\03\00\00\a0\00\00\03\00S\00\00\00\03\00\00\a0\00\00\01\00T\00\00\00\03\00\00\a0\00\00\01\00U\00\00\00\03\00\00\a0\00\00\01\00V\00\00\00\03\00\00\a0\00\00\02\00W\00\00\00\03\00\00\a0\00\00\02\00X\00\00\00\03\00\00\a0\00\00\02\00Y\00\00\00\03\00\00\a0\00\00\02\00Z\00\00\00\03\00\00\a0\00\00\02\00[\00\00\00\03\00\00\a0\00\00\01\00\\\00\00\00\03\00\00\a0\00\00\01\00]\00\00\00\03\00\00\a0\00\00\01\00^\00\00\00\03\00\00@\00\00\00\00\00\00\00\00\02\00\00p\00\00\00\00\02\00\00p\01\00\00\00\02\00\00p\00\00\00\00T!\00\00\\!\00\00\03\00\00\a0\00\00\02\00`\00\00\00\03\00\00\a0\00\00\02\00a\00\00\00\03\00\00\a0\00\00\02\00b\00\00\00\03\00\00\a0\00\00\02\00c\00\00\00\03\00\00\a0\00\00\02\00d\00\00\00\03\00\00\a0\00\00\02\00e\00\00\00\03\00\00\a0\00\00\02\00f\00\00\00\03\00\00\a0\00\00\02\00g\00\00\00\03\00\00\a0\00\00\01\00*\00\00\00\03\00\00\a0\00\00\02\00+\00\00\00\03\00\00\a0\00\00\01\00,\00\00\00\03\00\00@@ \00\00@!\00\00")
 (table $0 132 132 funcref)
 (elem (i32.const 1) $stbsp__count_clamp_callback $stbsp__clamp_callback $eval_sendToApp_revArgs $eval_Platform_incomingPortOnEffects $eval_Platform_outgoingPortOnEffects $eval_manager_loop $eval_manager_loop_receive $eval_Scheduler_step_lambda $eval_Platform_sendToApp_lambda $eval_Scheduler_send_lambda $eval_applyTaggers $eval_Platform_leaf $eval_Scheduler_spawn_lambda $eval_Scheduler_kill_lambda $eval_negate $eval_add $eval_sub $eval_mul $eval_fdiv $eval_idiv $eval_pow $eval_toFloat $eval_round $eval_floor $eval_ceiling $eval_not $eval_and $eval_or $eval_xor $eval_remainderBy $eval_modBy $eval_log $eval_identity $eval_Bitwise_and $eval_Bitwise_or $eval_Bitwise_xor $eval_Bitwise_complement $eval_Bitwise_shiftLeftBy $eval_Bitwise_shiftRightBy $eval_Bitwise_shiftRightZfBy $eval_toCode $eval_Debug_toString $eval_Debug_log $eval_Debug_todo $eval_JsArray_singleton $eval_JsArray_length $eval_JsArray_initialize $eval_JsArray_initializeFromList $eval_JsArray_unsafeGet $eval_JsArray_unsafeSet $eval_JsArray_push $eval_JsArray_foldl $eval_JsArray_foldr $eval_JsArray_map $eval_JsArray_indexedMap $eval_JsArray_slice $eval_JsArray_appendN $eval_List_cons $eval_List_append $eval_List_map2 $eval_List_sortBy $eval_Platform_sendToApp $eval_Platform_sendToSelf $eval_Platform_batch $eval_Platform_map $eval_Scheduler_succeed $eval_Scheduler_fail $eval_Scheduler_binding $eval_Scheduler_andThen $eval_Scheduler_onError $eval_Scheduler_receive $eval_Scheduler_rawSpawn $eval_Scheduler_spawn $eval_Scheduler_rawSend $eval_Scheduler_send $eval_Scheduler_kill $eval_String_uncons $eval_String_append $eval_String_length $eval_String_foldr $eval_String_split $eval_String_join $eval_String_slice $eval_String_trim $eval_String_trimLeft $eval_String_trimRight $eval_String_all $eval_String_contains $eval_String_startsWith $eval_String_endsWith $eval_String_indexes $String_fromNumber_eval $eval_String_toInt $eval_String_toFloat $Utils_access_eval $eval_Utils_append $eq_eval $eval_notEqual $compare_eval $lt_eval $le_eval $gt_eval $ge_eval $eval_Test_runThunk $eval_Json_succeed $eval_Json_fail $eval_Json_decodeList $eval_Json_decodeArray $eval_Json_decodeNull $eval_Json_decodeField $eval_Json_decodeIndex $eval_Json_decodeKeyValuePairs $eval_Json_andThen $eval_Json_oneOf $eval_Json_mapMany $eval_Json_array_get $eval_runOnString $eval_Json_run $eval_Json_wrap $eval_Json_unwrap $eval_Json_emptyArray $eval_Json_emptyObject $eval_Json_addField $eval_Json_addEntry $eval_Json_encode $eval_wrapInit $eval_wrapView $eval_intercept $eval_Platform_outgoingPortMap $eval_Platform_incomingPortMap $eval_Process_sleep)
 (export "memory" (memory $0))
 (export "__wasm_call_ctors" (func $__wasm_call_ctors))
 (export "square" (func $square))
 (export "sum" (func $sum))
 (export "stbsp_set_separators" (func $stbsp_set_separators))
 (export "stbsp_vsprintfcb" (func $stbsp_vsprintfcb))
 (export "stbsp_sprintf" (func $stbsp_sprintf))
 (export "stbsp_vsnprintf" (func $stbsp_vsnprintf))
 (export "stbsp_snprintf" (func $stbsp_snprintf))
 (export "stbsp_vsprintf" (func $stbsp_vsprintf))
 (export "eval_negate" (func $eval_negate))
 (export "GC_allocate" (func $GC_allocate))
 (export "gc_state" (global $global$1))
 (export "bitmap_find_space" (func $bitmap_find_space))
 (export "mark" (func $mark))
 (export "grow_heap" (func $grow_heap))
 (export "stack_flags" (global $global$2))
 (export "stack_values" (global $global$3))
 (export "safe_printf" (func $safe_printf))
 (export "eval_add" (func $eval_add))
 (export "eval_sub" (func $eval_sub))
 (export "eval_mul" (func $eval_mul))
 (export "eval_fdiv" (func $eval_fdiv))
 (export "eval_idiv" (func $eval_idiv))
 (export "newElmInt" (func $newElmInt))
 (export "eval_toFloat" (func $eval_toFloat))
 (export "newElmFloat" (func $newElmFloat))
 (export "eval_round" (func $eval_round))
 (export "eval_floor" (func $eval_floor))
 (export "eval_ceiling" (func $eval_ceiling))
 (export "eval_not" (func $eval_not))
 (export "True" (global $global$4))
 (export "False" (global $global$5))
 (export "eval_and" (func $eval_and))
 (export "eval_or" (func $eval_or))
 (export "eval_xor" (func $eval_xor))
 (export "eval_remainderBy" (func $eval_remainderBy))
 (export "eval_modBy" (func $eval_modBy))
 (export "Debug_assert" (func $legalstub$Debug_assert))
 (export "eval_log" (func $eval_log))
 (export "eval_identity" (func $eval_identity))
 (export "eval_Bitwise_and" (func $eval_Bitwise_and))
 (export "eval_Bitwise_or" (func $eval_Bitwise_or))
 (export "eval_Bitwise_xor" (func $eval_Bitwise_xor))
 (export "eval_Bitwise_complement" (func $eval_Bitwise_complement))
 (export "eval_Bitwise_shiftLeftBy" (func $eval_Bitwise_shiftLeftBy))
 (export "eval_Bitwise_shiftRightBy" (func $eval_Bitwise_shiftRightBy))
 (export "eval_Bitwise_shiftRightZfBy" (func $eval_Bitwise_shiftRightZfBy))
 (export "eval_toCode" (func $eval_toCode))
 (export "newDynamicArray" (func $newDynamicArray))
 (export "DynamicArray_push" (func $DynamicArray_push))
 (export "custom_params" (func $custom_params))
 (export "DynamicArray_remove_ordered" (func $DynamicArray_remove_ordered))
 (export "DynamicArray_remove_unordered" (func $DynamicArray_remove_unordered))
 (export "eval_JsArray_singleton" (func $eval_JsArray_singleton))
 (export "newCustom" (func $newCustom))
 (export "eval_JsArray_length" (func $eval_JsArray_length))
 (export "eval_JsArray_initialize" (func $eval_JsArray_initialize))
 (export "Utils_apply" (func $Utils_apply))
 (export "GC_stack_pop_frame" (func $GC_stack_pop_frame))
 (export "eval_JsArray_initializeFromList" (func $eval_JsArray_initializeFromList))
 (export "pNil" (global $global$6))
 (export "newTuple2" (func $newTuple2))
 (export "eval_JsArray_unsafeGet" (func $eval_JsArray_unsafeGet))
 (export "eval_JsArray_unsafeSet" (func $eval_JsArray_unsafeSet))
 (export "Utils_clone" (func $Utils_clone))
 (export "eval_JsArray_push" (func $eval_JsArray_push))
 (export "GC_memcpy" (func $GC_memcpy))
 (export "eval_JsArray_foldl" (func $eval_JsArray_foldl))
 (export "eval_JsArray_foldr" (func $eval_JsArray_foldr))
 (export "eval_JsArray_map" (func $eval_JsArray_map))
 (export "eval_JsArray_indexedMap" (func $eval_JsArray_indexedMap))
 (export "eval_JsArray_slice" (func $eval_JsArray_slice))
 (export "eval_JsArray_appendN" (func $eval_JsArray_appendN))
 (export "List_create" (func $List_create))
 (export "Nil" (global $global$7))
 (export "eval_List_cons" (func $eval_List_cons))
 (export "newCons" (func $newCons))
 (export "eval_List_append" (func $eval_List_append))
 (export "eval_List_map2" (func $eval_List_map2))
 (export "eval_List_sortBy" (func $eval_List_sortBy))
 (export "Platform_initOnIntercept" (func $Platform_initOnIntercept))
 (export "Platform_subscriptions" (global $global$8))
 (export "Platform_update" (global $global$9))
 (export "Platform_model" (global $global$10))
 (export "GC_register_root" (func $GC_register_root))
 (export "eval_sendToApp_revArgs" (func $eval_sendToApp_revArgs))
 (export "Platform_managerProcs" (global $global$11))
 (export "Platform_enqueueEffects" (func $Platform_enqueueEffects))
 (export "Platform_effectsQueue" (global $global$12))
 (export "Platform_effectsActive" (global $global$13))
 (export "Platform_dispatchEffects" (func $Platform_dispatchEffects))
 (export "Platform_initializeEffects" (func $Platform_initializeEffects))
 (export "Platform_process_cache" (global $global$14))
 (export "Platform_setupEffects" (func $Platform_setupEffects))
 (export "Platform_initCmd" (global $global$15))
 (export "newClosure" (func $newClosure))
 (export "Platform_managerConfigs" (global $global$16))
 (export "eval_Platform_incomingPortOnEffects" (func $eval_Platform_incomingPortOnEffects))
 (export "Process_sleep" (global $global$17))
 (export "eval_Platform_outgoingPortOnEffects" (func $eval_Platform_outgoingPortOnEffects))
 (export "eval_manager_loop" (func $eval_manager_loop))
 (export "eval_Scheduler_rawSpawn" (func $eval_Scheduler_rawSpawn))
 (export "Platform_setupIncomingPort" (func $Platform_setupIncomingPort))
 (export "Platform_setupOutgoingPort" (func $Platform_setupOutgoingPort))
 (export "Platform_instantiateManager" (func $Platform_instantiateManager))
 (export "Platform_createManager" (func $Platform_createManager))
 (export "eval_manager_loop_receive" (func $eval_manager_loop_receive))
 (export "eval_Scheduler_receive" (func $eval_Scheduler_receive))
 (export "eval_Scheduler_andThen" (func $eval_Scheduler_andThen))
 (export "Scheduler_guid" (global $global$18))
 (export "eval_Platform_sendToApp_lambda" (func $eval_Platform_sendToApp_lambda))
 (export "pUnit" (global $global$19))
 (export "eval_Scheduler_succeed" (func $eval_Scheduler_succeed))
 (export "eval_Platform_sendToApp" (func $eval_Platform_sendToApp))
 (export "eval_Scheduler_binding" (func $eval_Scheduler_binding))
 (export "eval_Platform_sendToSelf" (func $eval_Platform_sendToSelf))
 (export "eval_Scheduler_send_lambda" (func $eval_Scheduler_send_lambda))
 (export "eval_Scheduler_send" (func $eval_Scheduler_send))
 (export "eval_Platform_leaf" (func $eval_Platform_leaf))
 (export "eval_Platform_batch" (func $eval_Platform_batch))
 (export "eval_Platform_map" (func $eval_Platform_map))
 (export "Queue_push" (func $Queue_push))
 (export "newTuple3" (func $newTuple3))
 (export "Queue_shift" (func $Queue_shift))
 (export "Platform_gatherEffects" (func $Platform_gatherEffects))
 (export "eval_applyTaggers" (func $eval_applyTaggers))
 (export "log_error" (func $log_error))
 (export "eval_Scheduler_rawSend" (func $eval_Scheduler_rawSend))
 (export "Platform_toEffect" (func $Platform_toEffect))
 (export "Platform_insert" (func $Platform_insert))
 (export "safe_vprintf" (func $safe_vprintf))
 (export "Platform_checkPortName" (func $Platform_checkPortName))
 (export "Utils_equal" (global $global$20))
 (export "eval_Platform_outgoingPortMap" (func $eval_Platform_outgoingPortMap))
 (export "Platform_outgoingPort" (func $Platform_outgoingPort))
 (export "Platform_outgoingPortMap" (global $global$21))
 (export "eval_Platform_incomingPortMap" (func $eval_Platform_incomingPortMap))
 (export "Platform_sendToIncomingPort" (func $Platform_sendToIncomingPort))
 (export "Platform_incomingPort" (func $Platform_incomingPort))
 (export "Platform_incomingPortMap" (global $global$22))
 (export "newJsRef" (func $newJsRef))
 (export "eval_Process_sleep" (func $eval_Process_sleep))
 (export "newTask" (func $newTask))
 (export "eval_Scheduler_fail" (func $eval_Scheduler_fail))
 (export "eval_Scheduler_onError" (func $eval_Scheduler_onError))
 (export "Scheduler_queue" (global $global$23))
 (export "Scheduler_working" (global $global$24))
 (export "eval_Scheduler_step_lambda" (func $eval_Scheduler_step_lambda))
 (export "eval_Scheduler_spawn_lambda" (func $eval_Scheduler_spawn_lambda))
 (export "eval_Scheduler_spawn" (func $eval_Scheduler_spawn))
 (export "eval_Scheduler_kill_lambda" (func $eval_Scheduler_kill_lambda))
 (export "eval_Scheduler_kill" (func $eval_Scheduler_kill))
 (export "code_units" (func $code_units))
 (export "String_copy" (func $String_copy))
 (export "find_reverse" (func $find_reverse))
 (export "find_forward" (func $find_forward))
 (export "eval_String_uncons" (func $eval_String_uncons))
 (export "newElmChar" (func $newElmChar))
 (export "newElmString" (func $newElmString))
 (export "eval_String_append" (func $eval_String_append))
 (export "eval_String_length" (func $eval_String_length))
 (export "eval_String_foldr" (func $eval_String_foldr))
 (export "eval_String_split" (func $eval_String_split))
 (export "eval_String_join" (func $eval_String_join))
 (export "Debug_assert_equal" (func $legalstub$Debug_assert_equal))
 (export "eval_String_slice" (func $eval_String_slice))
 (export "is_whitespace" (func $is_whitespace))
 (export "eval_String_trim" (func $eval_String_trim))
 (export "eval_String_trimLeft" (func $eval_String_trimLeft))
 (export "eval_String_trimRight" (func $eval_String_trimRight))
 (export "eval_String_all" (func $eval_String_all))
 (export "eval_String_contains" (func $eval_String_contains))
 (export "eval_String_startsWith" (func $eval_String_startsWith))
 (export "eval_String_endsWith" (func $eval_String_endsWith))
 (export "eval_String_indexes" (func $eval_String_indexes))
 (export "String_fromNumber_eval" (func $String_fromNumber_eval))
 (export "eval_String_toInt" (func $eval_String_toInt))
 (export "eval_String_toFloat" (func $eval_String_toFloat))
 (export "Debug_is_target_in_range" (func $Debug_is_target_in_range))
 (export "Debug_pretty" (func $Debug_pretty))
 (export "newRecord" (func $newRecord))
 (export "Utils_destruct_index" (func $Utils_destruct_index))
 (export "Utils_access_eval" (func $Utils_access_eval))
 (export "Utils_update" (func $Utils_update))
 (export "eval_Utils_append" (func $eval_Utils_append))
 (export "GC_stack_push_frame" (func $GC_stack_push_frame))
 (export "Debug_assert_sanity" (func $Debug_assert_sanity))
 (export "eq_eval" (func $eq_eval))
 (export "eval_notEqual" (func $eval_notEqual))
 (export "compare_eval" (func $compare_eval))
 (export "lt_eval" (func $lt_eval))
 (export "le_eval" (func $le_eval))
 (export "gt_eval" (func $gt_eval))
 (export "ge_eval" (func $ge_eval))
 (export "Debug_pause" (func $Debug_pause))
 (export "log_debug" (func $log_debug))
 (export "print_heap_range" (func $print_heap_range))
 (export "sanity_check" (func $sanity_check))
 (export "print_value" (func $print_value))
 (export "Debug_print_offset" (func $Debug_print_offset))
 (export "Debug_is_target_addr" (func $Debug_is_target_addr))
 (export "is_marked" (func $is_marked))
 (export "ptr_to_bitmap_iter" (func $ptr_to_bitmap_iter))
 (export "pTrue" (global $global$25))
 (export "pFalse" (global $global$26))
 (export "print_value_line" (func $print_value_line))
 (export "print_value_full" (func $print_value_full))
 (export "print_heap" (func $print_heap))
 (export "print_bitmap" (func $print_bitmap))
 (export "print_stack_map" (func $print_stack_map))
 (export "print_state" (func $print_state))
 (export "format_ptr_diff_size" (func $format_ptr_diff_size))
 (export "format_mem_size" (func $format_mem_size))
 (export "print_ptr_diff_size" (func $print_ptr_diff_size))
 (export "print_mem_size" (func $print_mem_size))
 (export "pretty_print_child" (func $pretty_print_child))
 (export "Unit" (global $global$27))
 (export "Debug_pretty_with_location" (func $Debug_pretty_with_location))
 (export "Debug_toStringHelp" (func $Debug_toStringHelp))
 (export "StringBuilder_copyAscii" (func $StringBuilder_copyAscii))
 (export "StringBuilder_ensureSpace" (func $StringBuilder_ensureSpace))
 (export "StringBuilder_writeChar" (func $StringBuilder_writeChar))
 (export "eval_Debug_toString" (func $eval_Debug_toString))
 (export "StringBuilder_toString" (func $StringBuilder_toString))
 (export "StringBuilder_init" (func $StringBuilder_init))
 (export "eval_Debug_log" (func $eval_Debug_log))
 (export "eval_Debug_todo" (func $eval_Debug_todo))
 (export "Debug_evaluator_name_core" (func $Debug_evaluator_name_core))
 (export "GC_stack_push_value" (func $GC_stack_push_value))
 (export "bitmap_reset" (func $bitmap_reset))
 (export "bitmap_dead_between" (func $bitmap_dead_between))
 (export "make_bitmask" (func $legalstub$make_bitmask))
 (export "bitmap_iter_to_ptr" (func $bitmap_iter_to_ptr))
 (export "bitmap_find" (func $bitmap_find))
 (export "calc_offsets" (func $calc_offsets))
 (export "forwarding_address" (func $forwarding_address))
 (export "compact" (func $compact))
 (export "child_count" (func $child_count))
 (export "resize_system_memory" (func $resize_system_memory))
 (export "set_heap_layout" (func $set_heap_layout))
 (export "init_heap" (func $init_heap))
 (export "move_metadata_after_resize" (func $move_metadata_after_resize))
 (export "next_heap_size_bytes" (func $next_heap_size_bytes))
 (export "mark_words" (func $mark_words))
 (export "stack_reset" (func $stack_reset))
 (export "GC_stack_pop_value" (func $GC_stack_pop_value))
 (export "GC_stack_tailcall" (func $GC_stack_tailcall))
 (export "reset_state" (func $reset_state))
 (export "coreRoots" (global $global$28))
 (export "GC_init" (func $GC_init))
 (export "GC_collect_minor" (func $GC_collect_minor))
 (export "GC_collect_major" (func $GC_collect_major))
 (export "GC_execute" (func $GC_execute))
 (export "GC_init_root" (func $GC_init_root))
 (export "StringBuilder_startSection" (func $StringBuilder_startSection))
 (export "StringBuilder_finishSection" (func $StringBuilder_finishSection))
 (export "StringBuilder_writeIndent" (func $StringBuilder_writeIndent))
 (export "Basics_negate" (global $global$29))
 (export "Basics_add" (global $global$30))
 (export "Basics_sub" (global $global$31))
 (export "Basics_mul" (global $global$32))
 (export "Basics_fdiv" (global $global$33))
 (export "Basics_idiv" (global $global$34))
 (export "Basics_pow" (global $global$35))
 (export "Basics_toFloat" (global $global$36))
 (export "Basics_round" (global $global$37))
 (export "Basics_floor" (global $global$38))
 (export "Basics_ceiling" (global $global$39))
 (export "Basics_not" (global $global$40))
 (export "Basics_and" (global $global$41))
 (export "Basics_or" (global $global$42))
 (export "Basics_xor" (global $global$43))
 (export "Basics_remainderBy" (global $global$44))
 (export "Basics_modBy" (global $global$45))
 (export "Basics_log" (global $global$46))
 (export "Basics_identity" (global $global$47))
 (export "Bitwise_and" (global $global$48))
 (export "Bitwise_or" (global $global$49))
 (export "Bitwise_xor" (global $global$50))
 (export "Bitwise_complement" (global $global$51))
 (export "Bitwise_shiftLeftBy" (global $global$52))
 (export "Bitwise_shiftRightBy" (global $global$53))
 (export "Bitwise_shiftRightZfBy" (global $global$54))
 (export "Char_toCode" (global $global$55))
 (export "JsArray_empty" (global $global$56))
 (export "JsArray_singleton" (global $global$57))
 (export "JsArray_length" (global $global$58))
 (export "JsArray_initialize" (global $global$59))
 (export "JsArray_initializeFromList" (global $global$60))
 (export "JsArray_unsafeGet" (global $global$61))
 (export "JsArray_unsafeSet" (global $global$62))
 (export "JsArray_push" (global $global$63))
 (export "JsArray_foldl" (global $global$64))
 (export "JsArray_foldr" (global $global$65))
 (export "JsArray_map" (global $global$66))
 (export "JsArray_indexedMap" (global $global$67))
 (export "JsArray_slice" (global $global$68))
 (export "JsArray_appendN" (global $global$69))
 (export "List_cons" (global $global$70))
 (export "List_append" (global $global$71))
 (export "List_map2" (global $global$72))
 (export "List_sortBy" (global $global$73))
 (export "Platform_sendToApp" (global $global$74))
 (export "Platform_sendToSelf" (global $global$75))
 (export "Platform_leaf" (global $global$76))
 (export "Platform_batch" (global $global$77))
 (export "Platform_map" (global $global$78))
 (export "Scheduler_succeed" (global $global$79))
 (export "Scheduler_fail" (global $global$80))
 (export "Scheduler_binding" (global $global$81))
 (export "Scheduler_andThen" (global $global$82))
 (export "Scheduler_onError" (global $global$83))
 (export "Scheduler_receive" (global $global$84))
 (export "Scheduler_rawSpawn" (global $global$85))
 (export "Scheduler_spawn" (global $global$86))
 (export "Scheduler_rawSend" (global $global$87))
 (export "Scheduler_send" (global $global$88))
 (export "Scheduler_kill" (global $global$89))
 (export "tag_names" (global $global$90))
 (export "String_uncons" (global $global$91))
 (export "String_append" (global $global$92))
 (export "String_length" (global $global$93))
 (export "String_foldr" (global $global$94))
 (export "String_split" (global $global$95))
 (export "String_join" (global $global$96))
 (export "String_slice" (global $global$97))
 (export "String_trim" (global $global$98))
 (export "String_trimLeft" (global $global$99))
 (export "String_trimRight" (global $global$100))
 (export "String_all" (global $global$101))
 (export "String_contains" (global $global$102))
 (export "String_startsWith" (global $global$103))
 (export "String_endsWith" (global $global$104))
 (export "String_indexes" (global $global$105))
 (export "String_fromNumber" (global $global$106))
 (export "String_toInt" (global $global$107))
 (export "String_toFloat" (global $global$108))
 (export "Utils_append" (global $global$109))
 (export "Utils_notEqual" (global $global$110))
 (export "Utils_compare" (global $global$111))
 (export "Utils_lt" (global $global$112))
 (export "Utils_le" (global $global$113))
 (export "Utils_gt" (global $global$114))
 (export "Utils_ge" (global $global$115))
 (export "Debug_toString" (global $global$116))
 (export "Debug_log" (global $global$117))
 (export "Debug_todo" (global $global$118))
 (export "__indirect_function_table" (table $0))
 (export "__dso_handle" (global $global$119))
 (export "__data_end" (global $global$120))
 (export "__global_base" (global $global$121))
 (export "__heap_base" (global $global$122))
 (export "__memory_base" (global $global$123))
 (export "__table_base" (global $global$124))
 (func $__wasm_call_ctors
 )
 (func $square (param $0 i32) (result i32)
  (i32.mul
   (local.get $0)
   (local.get $0)
  )
 )
 (func $sum (param $0 i32) (result i32)
  (i32.shl
   (local.get $0)
   (i32.const 1)
  )
 )
 (func $stbsp_set_separators (param $0 i32) (param $1 i32)
  (i32.store8 offset=7473
   (i32.const 0)
   (local.get $0)
  )
  (i32.store8 offset=7472
   (i32.const 0)
   (local.get $1)
  )
 )
 (func $stbsp_vsprintfcb (param $0 i32) (param $1 i32) (param $2 i32) (param $3 i32) (param $4 i32) (result i32)
  (local $5 i32)
  (local $6 i32)
  (local $7 i32)
  (local $8 i32)
  (local $9 i32)
  (local $10 i32)
  (local $11 i32)
  (local $12 i32)
  (local $13 i32)
  (local $14 i32)
  (local $15 i32)
  (local $16 i32)
  (local $17 i32)
  (local $18 i32)
  (local $19 i32)
  (local $20 i32)
  (local $21 i32)
  (local $22 i32)
  (local $23 i32)
  (local $24 i32)
  (local $25 i32)
  (local $26 i32)
  (local $27 i32)
  (local $28 i32)
  (local $29 i64)
  (local $30 i64)
  (local $31 f64)
  (local $32 f64)
  (local $33 f64)
  (global.set $__stack_pointer
   (local.tee $5
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 544)
    )
   )
  )
  (local.set $6
   (i32.sub
    (i32.const 50331585)
    (i32.add
     (local.get $5)
     (i32.const 32)
    )
   )
  )
  (local.set $7
   (i32.add
    (i32.add
     (local.get $5)
     (i32.const 32)
    )
    (i32.const 511)
   )
  )
  (local.set $8
   (i32.add
    (i32.add
     (local.get $5)
     (i32.const 16)
    )
    (i32.const 1)
   )
  )
  (local.set $9
   (i32.add
    (i32.add
     (local.get $5)
     (i32.const 32)
    )
    (i32.const 66)
   )
  )
  (local.set $10
   (i32.add
    (i32.add
     (local.get $5)
     (i32.const 32)
    )
    (i32.const 65)
   )
  )
  (local.set $11
   (i32.add
    (i32.add
     (local.get $5)
     (i32.const 32)
    )
    (i32.const 64)
   )
  )
  (local.set $12
   (i32.add
    (i32.add
     (local.get $5)
     (i32.const 24)
    )
    (i32.const 1)
   )
  )
  (local.set $13
   (i32.add
    (i32.add
     (local.get $5)
     (i32.const 32)
    )
    (i32.const 512)
   )
  )
  (local.set $14
   (i32.const 0)
  )
  (local.set $15
   (local.get $2)
  )
  (block $label$1
   (block $label$2
    (loop $label$3
     (block $label$4
      (block $label$5
       (block $label$6
        (block $label$7
         (br_if $label$7
          (i32.eqz
           (i32.and
            (local.get $3)
            (i32.const 3)
           )
          )
         )
         (local.set $16
          (i32.load8_u
           (local.get $3)
          )
         )
         (br $label$6)
        )
        (br_if $label$6
         (i32.and
          (i32.add
           (i32.xor
            (local.tee $16
             (i32.load
              (local.get $3)
             )
            )
            (i32.const 623191333)
           )
           (i32.const -16843009)
          )
          (local.tee $17
           (i32.and
            (i32.xor
             (local.get $16)
             (i32.const -1)
            )
            (i32.const -2139062144)
           )
          )
         )
        )
        (block $label$8
         (br_if $label$8
          (i32.eqz
           (local.get $0)
          )
         )
         (local.set $18
          (i32.add
           (i32.sub
            (local.get $15)
            (local.get $2)
           )
           (i32.const 512)
          )
         )
         (loop $label$9
          (br_if $label$4
           (i32.and
            (local.get $17)
            (i32.add
             (local.get $16)
             (i32.const -16843009)
            )
           )
          )
          (br_if $label$6
           (i32.lt_s
            (local.get $18)
            (i32.const 4)
           )
          )
          (i32.store
           (local.get $2)
           (local.get $16)
          )
          (local.set $18
           (i32.add
            (local.get $18)
            (i32.const -4)
           )
          )
          (local.set $2
           (i32.add
            (local.get $2)
            (i32.const 4)
           )
          )
          (br_if $label$9
           (i32.eqz
            (i32.and
             (i32.add
              (i32.xor
               (local.tee $16
                (i32.load
                 (local.tee $3
                  (i32.add
                   (local.get $3)
                   (i32.const 4)
                  )
                 )
                )
               )
               (i32.const 623191333)
              )
              (i32.const -16843009)
             )
             (local.tee $17
              (i32.and
               (i32.xor
                (local.get $16)
                (i32.const -1)
               )
               (i32.const -2139062144)
              )
             )
            )
           )
          )
          (br $label$6)
         )
        )
        (br_if $label$4
         (i32.and
          (local.get $17)
          (i32.add
           (local.get $16)
           (i32.const -16843009)
          )
         )
        )
        (local.set $3
         (i32.add
          (local.get $3)
          (i32.const 4)
         )
        )
        (block $label$10
         (loop $label$11
          (i32.store
           (local.get $2)
           (local.get $16)
          )
          (br_if $label$10
           (i32.and
            (i32.add
             (i32.xor
              (local.tee $16
               (i32.load
                (local.get $3)
               )
              )
              (i32.const 623191333)
             )
             (i32.const -16843009)
            )
            (local.tee $18
             (i32.and
              (i32.xor
               (local.get $16)
               (i32.const -1)
              )
              (i32.const -2139062144)
             )
            )
           )
          )
          (local.set $2
           (i32.add
            (local.get $2)
            (i32.const 4)
           )
          )
          (local.set $3
           (i32.add
            (local.get $3)
            (i32.const 4)
           )
          )
          (br_if $label$5
           (i32.and
            (local.get $18)
            (i32.add
             (local.get $16)
             (i32.const -16843009)
            )
           )
          )
          (br $label$11)
         )
        )
        (local.set $2
         (i32.add
          (local.get $2)
          (i32.const 4)
         )
        )
       )
       (br_if $label$4
        (i32.ne
         (i32.and
          (local.get $16)
          (i32.const 255)
         )
         (i32.const 37)
        )
       )
       (local.set $16
        (i32.add
         (local.get $3)
         (i32.const 2)
        )
       )
       (local.set $17
        (i32.const 0)
       )
       (loop $label$12
        (local.set $3
         (i32.const 2)
        )
        (block $label$13
         (block $label$14
          (block $label$15
           (block $label$16
            (block $label$17
             (block $label$18
              (block $label$19
               (block $label$20
                (block $label$21
                 (block $label$22
                  (br_table $label$21 $label$15 $label$15 $label$20 $label$18 $label$15 $label$15 $label$19 $label$15 $label$15 $label$15 $label$13 $label$15 $label$22 $label$15 $label$15 $label$16 $label$15 $label$15 $label$15 $label$15 $label$15 $label$15 $label$15 $label$15 $label$15 $label$15 $label$15 $label$15 $label$15 $label$15 $label$15 $label$15 $label$15 $label$15 $label$15 $label$15 $label$15 $label$15 $label$15 $label$15 $label$15 $label$15 $label$15 $label$15 $label$15 $label$15 $label$15 $label$15 $label$15 $label$15 $label$15 $label$15 $label$15 $label$15 $label$15 $label$15 $label$15 $label$15 $label$15 $label$15 $label$15 $label$15 $label$17 $label$15
                   (i32.add
                    (local.tee $18
                     (i32.load8_s
                      (local.tee $19
                       (i32.add
                        (local.get $16)
                        (i32.const -1)
                       )
                      )
                     )
                    )
                    (i32.const -32)
                   )
                  )
                 )
                 (local.set $3
                  (i32.const 1)
                 )
                 (br $label$13)
                )
                (local.set $3
                 (i32.const 4)
                )
                (br $label$13)
               )
               (local.set $3
                (i32.const 8)
               )
               (br $label$13)
              )
              (local.set $3
               (i32.const 64)
              )
              (br $label$13)
             )
             (local.set $3
              (i32.const 256)
             )
             (br_if $label$13
              (i32.eqz
               (i32.and
                (local.get $17)
                (i32.const 256)
               )
              )
             )
             (local.set $3
              (select
               (i32.const 4096)
               (i32.const 2048)
               (i32.and
                (local.get $17)
                (i32.const 2048)
               )
              )
             )
             (br $label$13)
            )
            (local.set $3
             (i32.const 1024)
            )
            (br $label$13)
           )
           (local.set $17
            (i32.or
             (local.get $17)
             (i32.const 16)
            )
           )
           (local.set $18
            (i32.load8_u
             (local.get $16)
            )
           )
           (br $label$14)
          )
          (local.set $16
           (local.get $19)
          )
         )
         (block $label$23
          (block $label$24
           (br_if $label$24
            (i32.eq
             (i32.and
              (local.get $18)
              (i32.const 255)
             )
             (i32.const 42)
            )
           )
           (local.set $20
            (i32.const 0)
           )
           (block $label$25
            (br_if $label$25
             (i32.gt_u
              (i32.and
               (i32.add
                (local.get $18)
                (i32.const -48)
               )
               (i32.const 255)
              )
              (i32.const 9)
             )
            )
            (local.set $20
             (i32.const 0)
            )
            (loop $label$26
             (local.set $20
              (i32.add
               (i32.add
                (i32.mul
                 (local.get $20)
                 (i32.const 10)
                )
                (i32.and
                 (local.get $18)
                 (i32.const 255)
                )
               )
               (i32.const -48)
              )
             )
             (br_if $label$26
              (i32.lt_u
               (i32.and
                (i32.add
                 (local.tee $18
                  (i32.load8_u
                   (local.tee $16
                    (i32.add
                     (local.get $16)
                     (i32.const 1)
                    )
                   )
                  )
                 )
                 (i32.const -48)
                )
                (i32.const 255)
               )
               (i32.const 10)
              )
             )
            )
           )
           (local.set $3
            (local.get $16)
           )
           (local.set $21
            (local.get $4)
           )
           (br $label$23)
          )
          (local.set $3
           (i32.add
            (local.get $16)
            (i32.const 1)
           )
          )
          (local.set $21
           (i32.add
            (local.get $4)
            (i32.const 4)
           )
          )
          (local.set $18
           (i32.load8_u offset=1
            (local.get $16)
           )
          )
          (local.set $20
           (i32.load
            (local.get $4)
           )
          )
         )
         (local.set $22
          (i32.const -1)
         )
         (block $label$27
          (block $label$28
           (block $label$29
            (block $label$30
             (br_if $label$30
              (i32.eq
               (i32.and
                (local.get $18)
                (i32.const 255)
               )
               (i32.const 46)
              )
             )
             (local.set $16
              (local.get $3)
             )
             (br $label$29)
            )
            (br_if $label$28
             (i32.eq
              (local.tee $18
               (i32.load8_u offset=1
                (local.get $3)
               )
              )
              (i32.const 42)
             )
            )
            (local.set $16
             (i32.add
              (local.get $3)
              (i32.const 1)
             )
            )
            (local.set $22
             (i32.const 0)
            )
            (br_if $label$29
             (i32.gt_u
              (i32.and
               (i32.add
                (local.get $18)
                (i32.const -48)
               )
               (i32.const 255)
              )
              (i32.const 9)
             )
            )
            (local.set $22
             (i32.const 0)
            )
            (loop $label$31
             (local.set $22
              (i32.add
               (i32.add
                (i32.mul
                 (local.get $22)
                 (i32.const 10)
                )
                (i32.and
                 (local.get $18)
                 (i32.const 255)
                )
               )
               (i32.const -48)
              )
             )
             (br_if $label$31
              (i32.lt_u
               (i32.and
                (i32.add
                 (local.tee $18
                  (i32.load8_u
                   (local.tee $16
                    (i32.add
                     (local.get $16)
                     (i32.const 1)
                    )
                   )
                  )
                 )
                 (i32.const -48)
                )
                (i32.const 255)
               )
               (i32.const 10)
              )
             )
            )
           )
           (local.set $19
            (local.get $21)
           )
           (br $label$27)
          )
          (local.set $16
           (i32.add
            (local.get $3)
            (i32.const 2)
           )
          )
          (local.set $19
           (i32.add
            (local.get $21)
            (i32.const 4)
           )
          )
          (local.set $18
           (i32.load8_u offset=2
            (local.get $3)
           )
          )
          (local.set $22
           (i32.load
            (local.get $21)
           )
          )
         )
         (local.set $23
          (local.get $16)
         )
         (block $label$32
          (block $label$33
           (block $label$34
            (block $label$35
             (block $label$36
              (br_table $label$33 $label$32 $label$32 $label$32 $label$32 $label$32 $label$32 $label$32 $label$32 $label$32 $label$32 $label$32 $label$32 $label$32 $label$32 $label$32 $label$32 $label$32 $label$32 $label$32 $label$32 $label$32 $label$32 $label$32 $label$32 $label$32 $label$32 $label$32 $label$32 $label$32 $label$32 $label$36 $label$32 $label$34 $label$32 $label$35 $label$32 $label$32 $label$32 $label$32 $label$32 $label$32 $label$32 $label$34 $label$32 $label$32 $label$32 $label$32 $label$32 $label$34 $label$32
               (i32.add
                (i32.shr_s
                 (i32.shl
                  (local.get $18)
                  (i32.const 24)
                 )
                 (i32.const 24)
                )
                (i32.const -73)
               )
              )
             )
             (local.set $23
              (select
               (i32.add
                (local.get $16)
                (i32.const 2)
               )
               (i32.add
                (local.get $16)
                (i32.const 1)
               )
               (i32.eq
                (i32.load8_u offset=1
                 (local.get $16)
                )
                (i32.const 104)
               )
              )
             )
             (local.set $17
              (i32.or
               (local.get $17)
               (i32.const 512)
              )
             )
             (br $label$32)
            )
            (block $label$37
             (br_if $label$37
              (i32.eq
               (i32.load8_u offset=1
                (local.get $16)
               )
               (i32.const 108)
              )
             )
             (local.set $23
              (i32.add
               (local.get $16)
               (i32.const 1)
              )
             )
             (br $label$32)
            )
            (local.set $23
             (i32.add
              (local.get $16)
              (i32.const 2)
             )
            )
            (local.set $17
             (i32.or
              (local.get $17)
              (i32.const 32)
             )
            )
            (br $label$32)
           )
           (local.set $23
            (i32.add
             (local.get $16)
             (i32.const 1)
            )
           )
           (br $label$32)
          )
          (local.set $23
           (i32.add
            (local.get $16)
            (i32.const 1)
           )
          )
          (block $label$38
           (block $label$39
            (br_table $label$38 $label$32 $label$32 $label$39 $label$32
             (i32.add
              (i32.load8_u offset=1
               (local.get $16)
              )
              (i32.const -51)
             )
            )
           )
           (br_if $label$32
            (i32.ne
             (i32.load8_u offset=2
              (local.get $16)
             )
             (i32.const 52)
            )
           )
           (local.set $23
            (i32.add
             (local.get $16)
             (i32.const 3)
            )
           )
           (local.set $17
            (i32.or
             (local.get $17)
             (i32.const 32)
            )
           )
           (br $label$32)
          )
          (local.set $23
           (select
            (i32.add
             (local.get $16)
             (i32.const 3)
            )
            (local.get $23)
            (i32.eq
             (i32.load8_u offset=2
              (local.get $16)
             )
             (i32.const 50)
            )
           )
          )
         )
         (block $label$40
          (block $label$41
           (block $label$42
            (block $label$43
             (block $label$44
              (block $label$45
               (block $label$46
                (block $label$47
                 (block $label$48
                  (block $label$49
                   (block $label$50
                    (block $label$51
                     (block $label$52
                      (block $label$53
                       (block $label$54
                        (block $label$55
                         (block $label$56
                          (block $label$57
                           (block $label$58
                            (block $label$59
                             (block $label$60
                              (block $label$61
                               (br_table $label$44 $label$54 $label$59 $label$59 $label$49 $label$59 $label$48 $label$59 $label$59 $label$59 $label$59 $label$59 $label$59 $label$59 $label$59 $label$59 $label$59 $label$59 $label$59 $label$59 $label$59 $label$59 $label$59 $label$56 $label$59 $label$59 $label$59 $label$59 $label$59 $label$59 $label$59 $label$59 $label$44 $label$54 $label$43 $label$58 $label$49 $label$52 $label$48 $label$59 $label$58 $label$59 $label$59 $label$59 $label$59 $label$60 $label$55 $label$57 $label$59 $label$59 $label$61 $label$59 $label$58 $label$59 $label$59 $label$56 $label$59
                                (i32.add
                                 (local.tee $21
                                  (i32.load8_s
                                   (local.get $23)
                                  )
                                 )
                                 (i32.const -65)
                                )
                               )
                              )
                              (local.set $4
                               (i32.add
                                (local.get $19)
                                (i32.const 4)
                               )
                              )
                              (local.set $18
                               (local.tee $16
                                (select
                                 (local.tee $16
                                  (i32.load
                                   (local.get $19)
                                  )
                                 )
                                 (i32.const 2274)
                                 (local.get $16)
                                )
                               )
                              )
                              (block $label$62
                               (loop $label$63
                                (i32.store offset=4
                                 (local.get $5)
                                 (local.get $18)
                                )
                                (block $label$64
                                 (block $label$65
                                  (br_if $label$65
                                   (i32.and
                                    (local.get $18)
                                    (i32.const 3)
                                   )
                                  )
                                  (block $label$66
                                   (block $label$67
                                    (br_if $label$67
                                     (i32.ge_s
                                      (local.get $22)
                                      (i32.const 0)
                                     )
                                    )
                                    (local.set $19
                                     (i32.const -1)
                                    )
                                    (br $label$66)
                                   )
                                   (br_if $label$62
                                    (i32.le_u
                                     (local.get $22)
                                     (local.tee $3
                                      (i32.sub
                                       (local.get $18)
                                       (local.get $16)
                                      )
                                     )
                                    )
                                   )
                                   (br_if $label$65
                                    (i32.lt_u
                                     (local.tee $3
                                      (i32.sub
                                       (local.get $22)
                                       (local.get $3)
                                      )
                                     )
                                     (i32.const 4)
                                    )
                                   )
                                   (local.set $19
                                    (i32.shr_u
                                     (local.get $3)
                                     (i32.const 2)
                                    )
                                   )
                                  )
                                  (local.set $3
                                   (local.get $18)
                                  )
                                  (loop $label$68
                                   (br_if $label$64
                                    (i32.and
                                     (i32.and
                                      (i32.xor
                                       (local.tee $18
                                        (i32.load
                                         (local.get $3)
                                        )
                                       )
                                       (i32.const -1)
                                      )
                                      (i32.add
                                       (local.get $18)
                                       (i32.const -16843009)
                                      )
                                     )
                                     (i32.const -2139062144)
                                    )
                                   )
                                   (i32.store offset=4
                                    (local.get $5)
                                    (local.tee $3
                                     (i32.add
                                      (local.get $3)
                                      (i32.const 4)
                                     )
                                    )
                                   )
                                   (br_if $label$64
                                    (i32.eqz
                                     (local.tee $19
                                      (i32.add
                                       (local.get $19)
                                       (i32.const -1)
                                      )
                                     )
                                    )
                                   )
                                   (br $label$68)
                                  )
                                 )
                                 (local.set $3
                                  (local.get $18)
                                 )
                                )
                                (local.set $18
                                 (i32.add
                                  (local.get $3)
                                  (i32.const 1)
                                 )
                                )
                                (br_if $label$63
                                 (i32.load8_u
                                  (local.get $3)
                                 )
                                )
                               )
                               (local.set $3
                                (i32.sub
                                 (local.get $3)
                                 (local.get $16)
                                )
                               )
                              )
                              (local.set $24
                               (i32.const 0)
                              )
                              (i32.store8 offset=24
                               (local.get $5)
                               (i32.const 0)
                              )
                              (i32.store8 offset=16
                               (local.get $5)
                               (i32.const 0)
                              )
                              (i32.store offset=8
                               (local.get $5)
                               (i32.const 0)
                              )
                              (i32.store offset=12
                               (local.get $5)
                               (select
                                (local.get $22)
                                (local.get $3)
                                (i32.gt_u
                                 (local.get $3)
                                 (local.get $22)
                                )
                               )
                              )
                              (br $label$42)
                             )
                             (i32.store
                              (i32.load
                               (local.get $19)
                              )
                              (i32.add
                               (i32.sub
                                (local.get $14)
                                (local.get $15)
                               )
                               (local.get $2)
                              )
                             )
                             (local.set $4
                              (i32.add
                               (local.get $19)
                               (i32.const 4)
                              )
                             )
                             (br $label$40)
                            )
                            (i32.store offset=12
                             (local.get $5)
                             (i32.const 1)
                            )
                            (i32.store8 offset=543
                             (local.get $5)
                             (local.get $21)
                            )
                            (local.set $24
                             (i32.const 0)
                            )
                            (i32.store8 offset=24
                             (local.get $5)
                             (i32.const 0)
                            )
                            (i32.store8 offset=16
                             (local.get $5)
                             (i32.const 0)
                            )
                            (i32.store offset=8
                             (local.get $5)
                             (i32.const 0)
                            )
                            (local.set $16
                             (local.get $7)
                            )
                            (local.set $17
                             (i32.const 0)
                            )
                            (local.set $25
                             (i32.const 0)
                            )
                            (local.set $22
                             (i32.const 0)
                            )
                            (local.set $20
                             (i32.const 0)
                            )
                            (local.set $4
                             (local.get $19)
                            )
                            (br $label$41)
                           )
                           (block $label$69
                            (block $label$70
                             (br_if $label$70
                              (i32.eqz
                               (i32.and
                                (local.get $17)
                                (i32.const 32)
                               )
                              )
                             )
                             (local.set $4
                              (i32.add
                               (local.tee $16
                                (i32.and
                                 (i32.add
                                  (local.get $19)
                                  (i32.const 7)
                                 )
                                 (i32.const -8)
                                )
                               )
                               (i32.const 8)
                              )
                             )
                             (local.set $29
                              (i64.load
                               (local.get $16)
                              )
                             )
                             (br_if $label$69
                              (i32.eq
                               (local.get $21)
                               (i32.const 117)
                              )
                             )
                             (br_if $label$69
                              (i64.gt_s
                               (local.get $29)
                               (i64.const -1)
                              )
                             )
                             (local.set $17
                              (i32.or
                               (local.get $17)
                               (i32.const 128)
                              )
                             )
                             (local.set $29
                              (i64.sub
                               (i64.const 0)
                               (local.get $29)
                              )
                             )
                             (br $label$69)
                            )
                            (local.set $4
                             (i32.add
                              (local.get $19)
                              (i32.const 4)
                             )
                            )
                            (local.set $29
                             (i64.extend_i32_u
                              (local.tee $16
                               (i32.load
                                (local.get $19)
                               )
                              )
                             )
                            )
                            (br_if $label$69
                             (i32.eq
                              (local.get $21)
                              (i32.const 117)
                             )
                            )
                            (br_if $label$69
                             (i32.gt_s
                              (local.get $16)
                              (i32.const -1)
                             )
                            )
                            (local.set $17
                             (i32.or
                              (local.get $17)
                              (i32.const 128)
                             )
                            )
                            (local.set $29
                             (i64.extend_i32_u
                              (i32.sub
                               (i32.const 0)
                               (local.get $16)
                              )
                             )
                            )
                           )
                           (block $label$71
                            (br_if $label$71
                             (i32.eqz
                              (i32.and
                               (local.get $17)
                               (i32.const 256)
                              )
                             )
                            )
                            (local.set $22
                             (select
                              (i32.const 0)
                              (select
                               (i32.const 1)
                               (local.get $22)
                               (i32.eq
                                (local.get $22)
                                (i32.const -1)
                               )
                              )
                              (i64.lt_u
                               (local.get $29)
                               (i64.const 1024)
                              )
                             )
                            )
                            (local.set $31
                             (f64.convert_i64_s
                              (local.get $29)
                             )
                            )
                            (br $label$51)
                           )
                           (i32.store offset=12
                            (local.get $5)
                            (i32.const 0)
                           )
                           (local.set $24
                            (i32.and
                             (local.get $17)
                             (i32.const 64)
                            )
                           )
                           (local.set $18
                            (local.get $13)
                           )
                           (loop $label$72
                            (local.set $30
                             (i64.const 0)
                            )
                            (block $label$73
                             (br_if $label$73
                              (i64.lt_u
                               (local.get $29)
                               (i64.const 100000000)
                              )
                             )
                             (local.set $29
                              (i64.sub
                               (local.get $29)
                               (i64.mul
                                (local.tee $30
                                 (i64.div_u
                                  (local.get $29)
                                  (i64.const 100000000)
                                 )
                                )
                                (i64.const 100000000)
                               )
                              )
                             )
                            )
                            (local.set $21
                             (i32.add
                              (local.get $18)
                              (i32.const -8)
                             )
                            )
                            (local.set $16
                             (i32.wrap_i64
                              (local.get $29)
                             )
                            )
                            (block $label$74
                             (block $label$75
                              (br_if $label$75
                               (local.get $24)
                              )
                              (loop $label$76
                               (i32.store16
                                (local.tee $18
                                 (i32.add
                                  (local.get $18)
                                  (i32.const -2)
                                 )
                                )
                                (i32.load16_u
                                 (i32.add
                                  (i32.shl
                                   (i32.sub
                                    (local.get $16)
                                    (i32.mul
                                     (local.tee $3
                                      (i32.div_u
                                       (local.get $16)
                                       (i32.const 100)
                                      )
                                     )
                                     (i32.const 100)
                                    )
                                   )
                                   (i32.const 1)
                                  )
                                  (i32.const 6068)
                                 )
                                )
                               )
                               (local.set $19
                                (i32.lt_u
                                 (local.get $16)
                                 (i32.const 100)
                                )
                               )
                               (local.set $16
                                (local.get $3)
                               )
                               (br_if $label$76
                                (i32.eqz
                                 (local.get $19)
                                )
                               )
                              )
                              (local.set $3
                               (local.get $18)
                              )
                              (br $label$74)
                             )
                             (block $label$77
                              (br_if $label$77
                               (local.get $16)
                              )
                              (local.set $3
                               (local.get $18)
                              )
                              (br $label$74)
                             )
                             (local.set $3
                              (local.get $18)
                             )
                             (loop $label$78
                              (i32.store offset=12
                               (local.get $5)
                               (i32.add
                                (local.tee $18
                                 (i32.load offset=12
                                  (local.get $5)
                                 )
                                )
                                (i32.const 1)
                               )
                              )
                              (block $label$79
                               (block $label$80
                                (br_if $label$80
                                 (i32.ne
                                  (local.get $18)
                                  (i32.const 3)
                                 )
                                )
                                (i32.store offset=12
                                 (local.get $5)
                                 (i32.const 0)
                                )
                                (i32.store8
                                 (local.tee $3
                                  (i32.add
                                   (local.get $3)
                                   (i32.const -1)
                                  )
                                 )
                                 (i32.load8_u offset=7473
                                  (i32.const 0)
                                 )
                                )
                                (local.set $21
                                 (i32.add
                                  (local.get $21)
                                  (i32.const -1)
                                 )
                                )
                                (br $label$79)
                               )
                               (i32.store8
                                (local.tee $3
                                 (i32.add
                                  (local.get $3)
                                  (i32.const -1)
                                 )
                                )
                                (i32.or
                                 (i32.sub
                                  (local.get $16)
                                  (i32.mul
                                   (local.tee $18
                                    (i32.div_u
                                     (local.get $16)
                                     (i32.const 10)
                                    )
                                   )
                                   (i32.const 10)
                                  )
                                 )
                                 (i32.const 48)
                                )
                               )
                               (local.set $16
                                (local.get $18)
                               )
                              )
                              (br_if $label$78
                               (local.get $16)
                              )
                             )
                            )
                            (block $label$81
                             (block $label$82
                              (br_if $label$82
                               (i64.eqz
                                (local.get $30)
                               )
                              )
                              (local.set $29
                               (local.get $30)
                              )
                              (local.set $18
                               (local.get $21)
                              )
                              (br_if $label$72
                               (i32.eq
                                (local.get $3)
                                (local.get $21)
                               )
                              )
                              (br_if $label$81
                               (i32.eqz
                                (local.get $24)
                               )
                              )
                              (local.set $18
                               (local.get $21)
                              )
                              (loop $label$83
                               (i32.store offset=12
                                (local.get $5)
                                (i32.add
                                 (local.tee $16
                                  (i32.load offset=12
                                   (local.get $5)
                                  )
                                 )
                                 (i32.const 1)
                                )
                               )
                               (block $label$84
                                (block $label$85
                                 (br_if $label$85
                                  (i32.ne
                                   (local.get $16)
                                   (i32.const 3)
                                  )
                                 )
                                 (i32.store offset=12
                                  (local.get $5)
                                  (i32.const 0)
                                 )
                                 (i32.store8
                                  (local.tee $3
                                   (i32.add
                                    (local.get $3)
                                    (i32.const -1)
                                   )
                                  )
                                  (i32.load8_u offset=7473
                                   (i32.const 0)
                                  )
                                 )
                                 (local.set $18
                                  (i32.add
                                   (local.get $18)
                                   (i32.const -1)
                                  )
                                 )
                                 (br $label$84)
                                )
                                (i32.store8
                                 (local.tee $3
                                  (i32.add
                                   (local.get $3)
                                   (i32.const -1)
                                  )
                                 )
                                 (i32.const 48)
                                )
                               )
                               (br_if $label$83
                                (i32.ne
                                 (local.get $3)
                                 (local.get $18)
                                )
                               )
                              )
                              (local.set $29
                               (local.get $30)
                              )
                              (br $label$72)
                             )
                             (local.set $16
                              (i32.load8_u
                               (local.get $3)
                              )
                             )
                             (i32.store8 offset=24
                              (local.get $5)
                              (i32.const 0)
                             )
                             (i32.store8 offset=16
                              (local.get $5)
                              (i32.const 0)
                             )
                             (local.set $16
                              (i32.add
                               (local.get $3)
                               (i32.and
                                (i32.eq
                                 (local.get $16)
                                 (i32.const 48)
                                )
                                (i32.ne
                                 (local.get $3)
                                 (local.get $13)
                                )
                               )
                              )
                             )
                             (local.set $3
                              (i32.const 45)
                             )
                             (block $label$86
                              (block $label$87
                               (br_if $label$87
                                (i32.and
                                 (local.get $17)
                                 (i32.const 128)
                                )
                               )
                               (local.set $3
                                (i32.const 32)
                               )
                               (br_if $label$87
                                (i32.and
                                 (local.get $17)
                                 (i32.const 4)
                                )
                               )
                               (local.set $3
                                (i32.const 43)
                               )
                               (br_if $label$86
                                (i32.eqz
                                 (i32.and
                                  (local.get $17)
                                  (i32.const 2)
                                 )
                                )
                               )
                              )
                              (i32.store8 offset=25
                               (local.get $5)
                               (local.get $3)
                              )
                              (i32.store8 offset=24
                               (local.get $5)
                               (i32.const 1)
                              )
                             )
                             (i32.store offset=12
                              (local.get $5)
                              (local.tee $3
                               (i32.sub
                                (local.get $13)
                                (local.get $16)
                               )
                              )
                             )
                             (block $label$88
                              (br_if $label$88
                               (local.get $3)
                              )
                              (i32.store8
                               (local.tee $16
                                (i32.add
                                 (local.get $16)
                                 (i32.const -1)
                                )
                               )
                               (i32.const 48)
                              )
                              (local.set $3
                               (i32.const 1)
                              )
                              (i32.store offset=12
                               (local.get $5)
                               (i32.const 1)
                              )
                             )
                             (local.set $25
                              (i32.const 0)
                             )
                             (local.set $22
                              (select
                               (local.get $22)
                               (i32.const 0)
                               (i32.gt_s
                                (local.get $22)
                                (i32.const 0)
                               )
                              )
                             )
                             (local.set $24
                              (i32.add
                               (local.get $3)
                               (i32.const 50331648)
                              )
                             )
                             (br $label$41)
                            )
                            (local.set $19
                             (i32.add
                              (i32.xor
                               (local.get $21)
                               (i32.const -1)
                              )
                              (local.get $3)
                             )
                            )
                            (block $label$89
                             (br_if $label$89
                              (i32.eqz
                               (local.tee $16
                                (i32.and
                                 (i32.sub
                                  (local.get $3)
                                  (local.get $21)
                                 )
                                 (i32.const 7)
                                )
                               )
                              )
                             )
                             (loop $label$90
                              (i32.store8
                               (local.tee $3
                                (i32.add
                                 (local.get $3)
                                 (i32.const -1)
                                )
                               )
                               (i32.const 48)
                              )
                              (br_if $label$90
                               (local.tee $16
                                (i32.add
                                 (local.get $16)
                                 (i32.const -1)
                                )
                               )
                              )
                             )
                            )
                            (local.set $29
                             (local.get $30)
                            )
                            (local.set $18
                             (local.get $21)
                            )
                            (br_if $label$72
                             (i32.lt_u
                              (local.get $19)
                              (i32.const 7)
                             )
                            )
                            (loop $label$91
                             (i64.store align=1
                              (local.tee $3
                               (i32.add
                                (local.get $3)
                                (i32.const -8)
                               )
                              )
                              (i64.const 3472328296227680304)
                             )
                             (br_if $label$91
                              (i32.ne
                               (local.get $3)
                               (local.get $21)
                              )
                             )
                            )
                            (local.set $29
                             (local.get $30)
                            )
                            (local.set $18
                             (local.get $21)
                            )
                            (br $label$72)
                           )
                          )
                          (local.set $17
                           (i32.and
                            (local.get $17)
                            (i32.const -17)
                           )
                          )
                          (local.set $22
                           (i32.const 8)
                          )
                         )
                         (i32.store8 offset=24
                          (local.get $5)
                          (i32.const 0)
                         )
                         (local.set $3
                          (i32.const 1088)
                         )
                         (i32.store offset=12
                          (local.get $5)
                          (i32.const 1088)
                         )
                         (local.set $21
                          (select
                           (i32.const 1056)
                           (i32.const 1024)
                           (local.tee $16
                            (i32.eq
                             (local.get $21)
                             (i32.const 88)
                            )
                           )
                          )
                         )
                         (br_if $label$53
                          (i32.eqz
                           (i32.and
                            (local.get $17)
                            (i32.const 8)
                           )
                          )
                         )
                         (i32.store16 offset=24 align=1
                          (local.get $5)
                          (i32.const 12290)
                         )
                         (i32.store8 offset=26
                          (local.get $5)
                          (select
                           (i32.const 88)
                           (i32.const 120)
                           (local.get $16)
                          )
                         )
                         (br $label$53)
                        )
                        (i32.store8 offset=24
                         (local.get $5)
                         (i32.const 0)
                        )
                        (block $label$92
                         (br_if $label$92
                          (i32.eqz
                           (i32.and
                            (local.get $17)
                            (i32.const 8)
                           )
                          )
                         )
                         (i32.store16 offset=24 align=1
                          (local.get $5)
                          (i32.const 12289)
                         )
                        )
                        (local.set $3
                         (i32.const 816)
                        )
                        (i32.store offset=12
                         (local.get $5)
                         (i32.const 816)
                        )
                        (local.set $21
                         (i32.const 1056)
                        )
                        (br $label$53)
                       )
                       (i32.store8 offset=24
                        (local.get $5)
                        (i32.const 0)
                       )
                       (local.set $16
                        (i32.eq
                         (local.get $21)
                         (i32.const 66)
                        )
                       )
                       (block $label$93
                        (br_if $label$93
                         (i32.eqz
                          (i32.and
                           (local.get $17)
                           (i32.const 8)
                          )
                         )
                        )
                        (i32.store16 offset=24 align=1
                         (local.get $5)
                         (i32.const 12290)
                        )
                        (i32.store8 offset=26
                         (local.get $5)
                         (select
                          (i32.const 66)
                          (i32.const 98)
                          (local.get $16)
                         )
                        )
                       )
                       (local.set $21
                        (select
                         (i32.const 1056)
                         (i32.const 1024)
                         (local.get $16)
                        )
                       )
                       (local.set $3
                        (i32.const 384)
                       )
                       (i32.store offset=12
                        (local.get $5)
                        (i32.const 384)
                       )
                      )
                      (block $label$94
                       (block $label$95
                        (br_if $label$95
                         (i32.eqz
                          (i32.and
                           (local.get $17)
                           (i32.const 32)
                          )
                         )
                        )
                        (local.set $4
                         (i32.add
                          (local.tee $16
                           (i32.and
                            (i32.add
                             (local.get $19)
                             (i32.const 7)
                            )
                            (i32.const -8)
                           )
                          )
                          (i32.const 8)
                         )
                        )
                        (local.set $29
                         (i64.load
                          (local.get $16)
                         )
                        )
                        (br $label$94)
                       )
                       (local.set $4
                        (i32.add
                         (local.get $19)
                         (i32.const 4)
                        )
                       )
                       (local.set $29
                        (i64.load32_u
                         (local.get $19)
                        )
                       )
                      )
                      (i32.store8 offset=16
                       (local.get $5)
                       (i32.const 0)
                      )
                      (i32.store offset=8
                       (local.get $5)
                       (i32.const 0)
                      )
                      (block $label$96
                       (br_if $label$96
                        (i64.ne
                         (local.get $29)
                         (i64.const 0)
                        )
                       )
                       (i32.store8 offset=24
                        (local.get $5)
                        (i32.const 0)
                       )
                       (br_if $label$96
                        (local.get $22)
                       )
                       (local.set $24
                        (i32.const 0)
                       )
                       (i32.store offset=12
                        (local.get $5)
                        (i32.const 0)
                       )
                       (local.set $16
                        (local.get $13)
                       )
                       (br $label$42)
                      )
                      (local.set $24
                       (i32.and
                        (local.get $17)
                        (i32.const 64)
                       )
                      )
                      (local.set $16
                       (local.get $13)
                      )
                      (block $label$97
                       (loop $label$98
                        (i32.store8
                         (local.tee $16
                          (i32.add
                           (local.tee $19
                            (local.get $16)
                           )
                           (i32.const -1)
                          )
                         )
                         (i32.load8_u
                          (i32.add
                           (local.get $21)
                           (i32.and
                            (i32.xor
                             (i32.shl
                              (i32.const -1)
                              (i32.shr_u
                               (local.get $3)
                               (i32.const 8)
                              )
                             )
                             (i32.const -1)
                            )
                            (i32.wrap_i64
                             (local.get $29)
                            )
                           )
                          )
                         )
                        )
                        (local.set $18
                         (i32.sub
                          (local.get $13)
                          (local.get $16)
                         )
                        )
                        (block $label$99
                         (br_if $label$99
                          (i64.ne
                           (local.tee $29
                            (i64.shr_u
                             (local.get $29)
                             (i64.extend_i32_u
                              (i32.shr_u
                               (local.tee $3
                                (i32.load offset=12
                                 (local.get $5)
                                )
                               )
                               (i32.const 8)
                              )
                             )
                            )
                           )
                           (i64.const 0)
                          )
                         )
                         (br_if $label$97
                          (i32.ge_s
                           (local.get $18)
                           (local.get $22)
                          )
                         )
                        )
                        (br_if $label$98
                         (i32.eqz
                          (local.get $24)
                         )
                        )
                        (i32.store offset=12
                         (local.get $5)
                         (local.tee $3
                          (i32.add
                           (local.get $3)
                           (i32.const 1)
                          )
                         )
                        )
                        (br_if $label$98
                         (i32.and
                          (i32.xor
                           (i32.shr_u
                            (local.get $3)
                            (i32.const 4)
                           )
                           (local.get $3)
                          )
                          (i32.const 15)
                         )
                        )
                        (i32.store8
                         (local.tee $16
                          (i32.add
                           (local.get $19)
                           (i32.const -2)
                          )
                         )
                         (i32.load8_u offset=7473
                          (i32.const 0)
                         )
                        )
                        (i32.store offset=12
                         (local.get $5)
                         (local.tee $3
                          (i32.and
                           (local.get $3)
                           (i32.const -16)
                          )
                         )
                        )
                        (br $label$98)
                       )
                      )
                      (i32.store offset=12
                       (local.get $5)
                       (local.get $18)
                      )
                      (local.set $24
                       (i32.add
                        (i32.and
                         (i32.shl
                          (local.get $3)
                          (i32.const 20)
                         )
                         (i32.const 251658240)
                        )
                        (local.get $18)
                       )
                      )
                      (local.set $25
                       (i32.const 0)
                      )
                      (br $label$41)
                     )
                     (local.set $4
                      (i32.add
                       (local.tee $16
                        (i32.and
                         (i32.add
                          (local.get $19)
                          (i32.const 7)
                         )
                         (i32.const -8)
                        )
                       )
                       (i32.const 8)
                      )
                     )
                     (local.set $31
                      (f64.load
                       (local.get $16)
                      )
                     )
                     (br_if $label$50
                      (i32.eqz
                       (i32.and
                        (local.get $17)
                        (i32.const 256)
                       )
                      )
                     )
                    )
                    (br_if $label$50
                     (i32.gt_u
                      (local.get $17)
                      (i32.const 67108863)
                     )
                    )
                    (local.set $33
                     (f64.neg
                      (local.tee $32
                       (select
                        (f64.const 1024)
                        (f64.const 1e3)
                        (i32.and
                         (local.get $17)
                         (i32.const 2048)
                        )
                       )
                      )
                     )
                    )
                    (block $label$100
                     (br_if $label$100
                      (f64.ge
                       (local.get $31)
                       (local.get $32)
                      )
                     )
                     (br_if $label$50
                      (f64.gt
                       (local.get $31)
                       (local.get $33)
                      )
                     )
                    )
                    (local.set $16
                     (i32.add
                      (local.get $17)
                      (i32.const 16777216)
                     )
                    )
                    (local.set $31
                     (f64.div
                      (local.get $31)
                      (local.get $32)
                     )
                    )
                    (block $label$101
                     (br_if $label$101
                      (i32.le_u
                       (local.get $17)
                       (i32.const 50331647)
                      )
                     )
                     (local.set $17
                      (local.get $16)
                     )
                     (br $label$50)
                    )
                    (block $label$102
                     (br_if $label$102
                      (f64.ge
                       (local.get $31)
                       (local.get $32)
                      )
                     )
                     (br_if $label$102
                      (i32.eqz
                       (f64.gt
                        (local.get $31)
                        (local.get $33)
                       )
                      )
                     )
                     (local.set $17
                      (local.get $16)
                     )
                     (br $label$50)
                    )
                    (local.set $16
                     (i32.add
                      (local.get $17)
                      (i32.const 33554432)
                     )
                    )
                    (local.set $31
                     (f64.div
                      (local.get $31)
                      (local.get $32)
                     )
                    )
                    (block $label$103
                     (br_if $label$103
                      (i32.le_u
                       (local.get $17)
                       (i32.const 33554431)
                      )
                     )
                     (local.set $17
                      (local.get $16)
                     )
                     (br $label$50)
                    )
                    (block $label$104
                     (br_if $label$104
                      (f64.ge
                       (local.get $31)
                       (local.get $32)
                      )
                     )
                     (br_if $label$104
                      (i32.eqz
                       (f64.gt
                        (local.get $31)
                        (local.get $33)
                       )
                      )
                     )
                     (local.set $17
                      (local.get $16)
                     )
                     (br $label$50)
                    )
                    (local.set $16
                     (i32.add
                      (local.get $17)
                      (i32.const 50331648)
                     )
                    )
                    (local.set $31
                     (f64.div
                      (local.get $31)
                      (local.get $32)
                     )
                    )
                    (block $label$105
                     (br_if $label$105
                      (i32.le_u
                       (local.get $17)
                       (i32.const 16777215)
                      )
                     )
                     (local.set $17
                      (local.get $16)
                     )
                     (br $label$50)
                    )
                    (block $label$106
                     (br_if $label$106
                      (f64.ge
                       (local.get $31)
                       (local.get $32)
                      )
                     )
                     (br_if $label$106
                      (i32.eqz
                       (f64.gt
                        (local.get $31)
                        (local.get $33)
                       )
                      )
                     )
                     (local.set $17
                      (local.get $16)
                     )
                     (br $label$50)
                    )
                    (local.set $17
                     (i32.add
                      (local.get $17)
                      (i32.const 67108864)
                     )
                    )
                    (local.set $31
                     (f64.div
                      (local.get $31)
                      (local.get $32)
                     )
                    )
                   )
                   (local.set $17
                    (select
                     (i32.or
                      (local.get $17)
                      (i32.const 128)
                     )
                     (local.get $17)
                     (call $stbsp__real_to_str
                      (i32.add
                       (local.get $5)
                       (i32.const 4)
                      )
                      (i32.add
                       (local.get $5)
                       (i32.const 12)
                      )
                      (i32.add
                       (local.get $5)
                       (i32.const 32)
                      )
                      (i32.add
                       (local.get $5)
                       (i32.const 8)
                      )
                      (local.get $31)
                      (local.tee $25
                       (select
                        (i32.const 6)
                        (local.get $22)
                        (i32.eq
                         (local.get $22)
                         (i32.const -1)
                        )
                       )
                      )
                     )
                    )
                   )
                   (br $label$46)
                  )
                  (local.set $17
                   (select
                    (i32.or
                     (local.get $17)
                     (i32.const 128)
                    )
                    (local.get $17)
                    (call $stbsp__real_to_str
                     (i32.add
                      (local.get $5)
                      (i32.const 4)
                     )
                     (i32.add
                      (local.get $5)
                      (i32.const 12)
                     )
                     (i32.add
                      (local.get $5)
                      (i32.const 32)
                     )
                     (i32.add
                      (local.get $5)
                      (i32.const 8)
                     )
                     (f64.load
                      (local.tee $16
                       (i32.and
                        (i32.add
                         (local.get $19)
                         (i32.const 7)
                        )
                        (i32.const -8)
                       )
                      )
                     )
                     (i32.or
                      (local.tee $22
                       (select
                        (i32.const 6)
                        (local.get $22)
                        (i32.eq
                         (local.get $22)
                         (i32.const -1)
                        )
                       )
                      )
                      (i32.const -2147483648)
                     )
                    )
                   )
                  )
                  (local.set $26
                   (select
                    (i32.const 1056)
                    (i32.const 1024)
                    (i32.eq
                     (local.get $21)
                     (i32.const 69)
                    )
                   )
                  )
                  (local.set $4
                   (i32.add
                    (local.get $16)
                    (i32.const 8)
                   )
                  )
                  (br $label$47)
                 )
                 (local.set $31
                  (f64.load
                   (local.tee $27
                    (i32.and
                     (i32.add
                      (local.get $19)
                      (i32.const 7)
                     )
                     (i32.const -8)
                    )
                   )
                  )
                 )
                 (local.set $28
                  (i32.const 6)
                 )
                 (block $label$107
                  (block $label$108
                   (block $label$109
                    (br_table $label$107 $label$109 $label$108
                     (i32.add
                      (local.get $22)
                      (i32.const 1)
                     )
                    )
                   )
                   (local.set $28
                    (i32.const 1)
                   )
                   (br $label$107)
                  )
                  (local.set $28
                   (local.get $22)
                  )
                 )
                 (local.set $22
                  (call $stbsp__real_to_str
                   (i32.add
                    (local.get $5)
                    (i32.const 4)
                   )
                   (i32.add
                    (local.get $5)
                    (i32.const 12)
                   )
                   (i32.add
                    (local.get $5)
                    (i32.const 32)
                   )
                   (i32.add
                    (local.get $5)
                    (i32.const 8)
                   )
                   (local.get $31)
                   (i32.or
                    (i32.add
                     (local.get $28)
                     (i32.const -1)
                    )
                    (i32.const -2147483648)
                   )
                  )
                 )
                 (block $label$110
                  (br_if $label$110
                   (i32.le_u
                    (local.tee $16
                     (i32.load offset=12
                      (local.get $5)
                     )
                    )
                    (local.get $28)
                   )
                  )
                  (i32.store offset=12
                   (local.get $5)
                   (local.get $28)
                  )
                  (local.set $16
                   (local.get $28)
                  )
                 )
                 (local.set $26
                  (i32.or
                   (local.get $17)
                   (i32.const 128)
                  )
                 )
                 (local.set $24
                  (i32.const 1)
                 )
                 (block $label$111
                  (block $label$112
                   (br_if $label$112
                    (i32.ge_u
                     (local.get $16)
                     (i32.const 2)
                    )
                   )
                   (local.set $18
                    (local.get $28)
                   )
                   (br $label$111)
                  )
                  (local.set $25
                   (i32.add
                    (i32.load offset=4
                     (local.get $5)
                    )
                    (i32.const -1)
                   )
                  )
                  (local.set $3
                   (local.get $28)
                  )
                  (loop $label$113
                   (block $label$114
                    (br_if $label$114
                     (i32.eq
                      (i32.load8_u
                       (i32.add
                        (local.get $25)
                        (local.get $16)
                       )
                      )
                      (i32.const 48)
                     )
                    )
                    (local.set $18
                     (local.get $3)
                    )
                    (local.set $24
                     (i32.const 1)
                    )
                    (br $label$111)
                   )
                   (local.set $24
                    (i32.ne
                     (local.get $3)
                     (i32.const 1)
                    )
                   )
                   (local.set $18
                    (i32.add
                     (local.get $3)
                     (i32.const -1)
                    )
                   )
                   (i32.store offset=12
                    (local.get $5)
                    (local.tee $16
                     (i32.add
                      (local.get $16)
                      (i32.const -1)
                     )
                    )
                   )
                   (br_if $label$111
                    (i32.lt_u
                     (local.get $16)
                     (i32.const 2)
                    )
                   )
                   (local.set $19
                    (i32.ne
                     (local.get $3)
                     (i32.const 1)
                    )
                   )
                   (local.set $3
                    (local.get $18)
                   )
                   (br_if $label$113
                    (local.get $19)
                   )
                  )
                 )
                 (local.set $4
                  (i32.add
                   (local.get $27)
                   (i32.const 8)
                  )
                 )
                 (local.set $17
                  (select
                   (local.get $26)
                   (local.get $17)
                   (local.get $22)
                  )
                 )
                 (block $label$115
                  (block $label$116
                   (br_if $label$116
                    (i32.lt_s
                     (local.tee $3
                      (i32.load offset=8
                       (local.get $5)
                      )
                     )
                     (i32.const -3)
                    )
                   )
                   (br_if $label$115
                    (i32.le_s
                     (local.get $3)
                     (local.get $28)
                    )
                   )
                  )
                  (local.set $26
                   (select
                    (i32.const 1056)
                    (i32.const 1024)
                    (i32.eq
                     (local.get $21)
                     (i32.const 71)
                    )
                   )
                  )
                  (block $label$117
                   (br_if $label$117
                    (i32.le_s
                     (local.get $18)
                     (local.get $16)
                    )
                   )
                   (local.set $22
                    (i32.add
                     (local.get $16)
                     (i32.const -1)
                    )
                   )
                   (br $label$47)
                  )
                  (local.set $22
                   (select
                    (i32.add
                     (local.get $18)
                     (i32.const -1)
                    )
                    (i32.const 0)
                    (local.get $24)
                   )
                  )
                  (br $label$47)
                 )
                 (block $label$118
                  (br_if $label$118
                   (i32.lt_s
                    (local.get $3)
                    (i32.const 1)
                   )
                  )
                  (local.set $25
                   (select
                    (i32.sub
                     (local.get $16)
                     (local.get $3)
                    )
                    (i32.const 0)
                    (i32.gt_s
                     (local.get $16)
                     (local.get $3)
                    )
                   )
                  )
                  (br $label$46)
                 )
                 (local.set $25
                  (i32.sub
                   (select
                    (local.get $16)
                    (local.get $18)
                    (i32.gt_s
                     (local.get $18)
                     (local.get $16)
                    )
                   )
                   (local.get $3)
                  )
                 )
                 (br $label$46)
                )
                (i32.store8 offset=24
                 (local.get $5)
                 (i32.const 0)
                )
                (i32.store8 offset=16
                 (local.get $5)
                 (i32.const 0)
                )
                (local.set $16
                 (i32.const 45)
                )
                (block $label$119
                 (block $label$120
                  (br_if $label$120
                   (i32.and
                    (local.get $17)
                    (i32.const 128)
                   )
                  )
                  (local.set $16
                   (i32.const 32)
                  )
                  (br_if $label$120
                   (i32.and
                    (local.get $17)
                    (i32.const 4)
                   )
                  )
                  (local.set $16
                   (i32.const 43)
                  )
                  (br_if $label$119
                   (i32.eqz
                    (i32.and
                     (local.get $17)
                     (i32.const 2)
                    )
                   )
                  )
                 )
                 (i32.store8 offset=25
                  (local.get $5)
                  (local.get $16)
                 )
                 (i32.store8 offset=24
                  (local.get $5)
                  (i32.const 1)
                 )
                )
                (local.set $24
                 (i32.const 0)
                )
                (local.set $16
                 (i32.load offset=4
                  (local.get $5)
                 )
                )
                (br_if $label$42
                 (i32.eq
                  (local.tee $27
                   (i32.load offset=8
                    (local.get $5)
                   )
                  )
                  (i32.const 28672)
                 )
                )
                (i32.store8 offset=96
                 (local.get $5)
                 (i32.load8_u
                  (local.get $16)
                 )
                )
                (local.set $3
                 (local.get $10)
                )
                (block $label$121
                 (br_if $label$121
                  (i32.eqz
                   (local.get $22)
                  )
                 )
                 (i32.store8 offset=97
                  (local.get $5)
                  (i32.load8_u offset=7472
                   (i32.const 0)
                  )
                 )
                 (local.set $3
                  (local.get $9)
                 )
                )
                (block $label$122
                 (br_if $label$122
                  (i32.le_u
                   (i32.add
                    (local.tee $28
                     (i32.load offset=12
                      (local.get $5)
                     )
                    )
                    (i32.const -1)
                   )
                   (local.get $22)
                  )
                 )
                 (i32.store offset=12
                  (local.get $5)
                  (local.tee $28
                   (i32.add
                    (local.get $22)
                    (i32.const 1)
                   )
                  )
                 )
                )
                (block $label$123
                 (br_if $label$123
                  (i32.lt_u
                   (local.get $28)
                   (i32.const 2)
                  )
                 )
                 (local.set $24
                  (i32.and
                   (local.tee $18
                    (i32.add
                     (local.get $28)
                     (i32.const -1)
                    )
                   )
                   (i32.const 3)
                  )
                 )
                 (local.set $19
                  (i32.const 1)
                 )
                 (block $label$124
                  (br_if $label$124
                   (i32.lt_u
                    (i32.add
                     (local.get $28)
                     (i32.const -2)
                    )
                    (i32.const 3)
                   )
                  )
                  (local.set $25
                   (i32.and
                    (local.get $18)
                    (i32.const -4)
                   )
                  )
                  (local.set $18
                   (i32.const 0)
                  )
                  (loop $label$125
                   (i32.store8
                    (local.tee $19
                     (i32.add
                      (local.get $3)
                      (local.get $18)
                     )
                    )
                    (i32.load8_u
                     (i32.add
                      (local.tee $21
                       (i32.add
                        (local.get $16)
                        (local.get $18)
                       )
                      )
                      (i32.const 1)
                     )
                    )
                   )
                   (i32.store8
                    (i32.add
                     (local.get $19)
                     (i32.const 1)
                    )
                    (i32.load8_u
                     (i32.add
                      (local.get $21)
                      (i32.const 2)
                     )
                    )
                   )
                   (i32.store8
                    (i32.add
                     (local.get $19)
                     (i32.const 2)
                    )
                    (i32.load8_u
                     (i32.add
                      (local.get $21)
                      (i32.const 3)
                     )
                    )
                   )
                   (i32.store8
                    (i32.add
                     (local.get $19)
                     (i32.const 3)
                    )
                    (i32.load8_u
                     (i32.add
                      (local.get $21)
                      (i32.const 4)
                     )
                    )
                   )
                   (br_if $label$125
                    (i32.ne
                     (local.get $25)
                     (local.tee $18
                      (i32.add
                       (local.get $18)
                       (i32.const 4)
                      )
                     )
                    )
                   )
                  )
                  (local.set $19
                   (i32.add
                    (local.get $18)
                    (i32.const 1)
                   )
                  )
                  (local.set $3
                   (i32.add
                    (local.get $3)
                    (local.get $18)
                   )
                  )
                 )
                 (br_if $label$123
                  (i32.eqz
                   (local.get $24)
                  )
                 )
                 (local.set $16
                  (i32.add
                   (local.get $16)
                   (local.get $19)
                  )
                 )
                 (loop $label$126
                  (i32.store8
                   (local.get $3)
                   (i32.load8_u
                    (local.get $16)
                   )
                  )
                  (local.set $16
                   (i32.add
                    (local.get $16)
                    (i32.const 1)
                   )
                  )
                  (local.set $3
                   (i32.add
                    (local.get $3)
                    (i32.const 1)
                   )
                  )
                  (br_if $label$126
                   (local.tee $24
                    (i32.add
                     (local.get $24)
                     (i32.const -1)
                    )
                   )
                  )
                 )
                )
                (i32.store8 offset=17
                 (local.get $5)
                 (i32.load8_u offset=14
                  (local.get $26)
                 )
                )
                (block $label$127
                 (block $label$128
                  (br_if $label$128
                   (i32.gt_s
                    (local.get $27)
                    (i32.const 0)
                   )
                  )
                  (i32.store8 offset=18
                   (local.get $5)
                   (i32.const 45)
                  )
                  (local.set $16
                   (i32.sub
                    (i32.const 1)
                    (local.get $27)
                   )
                  )
                  (br $label$127)
                 )
                 (i32.store8 offset=18
                  (local.get $5)
                  (i32.const 43)
                 )
                 (local.set $16
                  (i32.add
                   (local.get $27)
                   (i32.const -1)
                  )
                 )
                )
                (local.set $21
                 (i32.sub
                  (local.get $22)
                  (local.get $28)
                 )
                )
                (i32.store8
                 (i32.add
                  (i32.add
                   (local.get $5)
                   (i32.const 16)
                  )
                  (local.tee $24
                   (i32.add
                    (local.tee $18
                     (select
                      (i32.const 5)
                      (i32.const 4)
                      (i32.gt_s
                       (local.get $16)
                       (i32.const 99)
                      )
                     )
                    )
                    (i32.const -1)
                   )
                  )
                 )
                 (i32.add
                  (i32.rem_s
                   (local.tee $19
                    (i32.div_s
                     (local.get $16)
                     (i32.const 10)
                    )
                   )
                   (i32.const 10)
                  )
                  (i32.const 48)
                 )
                )
                (i32.store8
                 (i32.add
                  (i32.add
                   (local.get $5)
                   (i32.const 16)
                  )
                  (local.get $18)
                 )
                 (i32.add
                  (i32.sub
                   (local.get $16)
                   (i32.mul
                    (local.get $19)
                    (i32.const 10)
                   )
                  )
                  (i32.const 48)
                 )
                )
                (i32.store8 offset=16
                 (local.get $5)
                 (local.get $18)
                )
                (block $label$129
                 (br_if $label$129
                  (i32.lt_u
                   (local.get $24)
                   (i32.const 4)
                  )
                 )
                 (i32.store8
                  (i32.add
                   (i32.add
                    (local.get $18)
                    (i32.add
                     (local.get $5)
                     (i32.const 16)
                    )
                   )
                   (i32.const -2)
                  )
                  (i32.add
                   (i32.rem_s
                    (local.tee $19
                     (i32.div_s
                      (local.get $16)
                      (i32.const 100)
                     )
                    )
                    (i32.const 10)
                   )
                   (i32.const 48)
                  )
                 )
                )
                (local.set $25
                 (i32.add
                  (local.get $21)
                  (i32.const 1)
                 )
                )
                (i32.store offset=8
                 (local.get $5)
                 (local.get $19)
                )
                (local.set $24
                 (i32.const 50331649)
                )
                (br $label$45)
               )
               (i32.store8 offset=24
                (local.get $5)
                (i32.const 0)
               )
               (i32.store8 offset=16
                (local.get $5)
                (i32.const 0)
               )
               (local.set $16
                (i32.const 45)
               )
               (block $label$130
                (block $label$131
                 (br_if $label$131
                  (i32.and
                   (local.get $17)
                   (i32.const 128)
                  )
                 )
                 (local.set $16
                  (i32.const 32)
                 )
                 (br_if $label$131
                  (i32.and
                   (local.get $17)
                   (i32.const 4)
                  )
                 )
                 (local.set $16
                  (i32.const 43)
                 )
                 (br_if $label$130
                  (i32.eqz
                   (i32.and
                    (local.get $17)
                    (i32.const 2)
                   )
                  )
                 )
                )
                (i32.store8 offset=25
                 (local.get $5)
                 (local.get $16)
                )
                (i32.store8 offset=24
                 (local.get $5)
                 (i32.const 1)
                )
               )
               (block $label$132
                (br_if $label$132
                 (i32.ne
                  (local.tee $3
                   (i32.load offset=8
                    (local.get $5)
                   )
                  )
                  (i32.const 28672)
                 )
                )
                (local.set $24
                 (i32.const 0)
                )
                (local.set $16
                 (i32.load offset=4
                  (local.get $5)
                 )
                )
                (br $label$42)
               )
               (block $label$133
                (block $label$134
                 (block $label$135
                  (br_if $label$135
                   (i32.gt_s
                    (local.get $3)
                    (i32.const 0)
                   )
                  )
                  (i32.store8 offset=96
                   (local.get $5)
                   (i32.const 48)
                  )
                  (local.set $18
                   (local.get $10)
                  )
                  (block $label$136
                   (br_if $label$136
                    (i32.eqz
                     (local.get $25)
                    )
                   )
                   (i32.store8 offset=97
                    (local.get $5)
                    (i32.load8_u offset=7472
                     (i32.const 0)
                    )
                   )
                   (local.set $18
                    (local.get $9)
                   )
                  )
                  (block $label$137
                   (block $label$138
                    (br_if $label$138
                     (i32.eqz
                      (local.tee $24
                       (select
                        (local.get $25)
                        (local.tee $16
                         (i32.sub
                          (i32.const 0)
                          (local.get $3)
                         )
                        )
                        (i32.lt_s
                         (local.get $25)
                         (local.get $16)
                        )
                       )
                      )
                     )
                    )
                    (br_if $label$137
                     (i32.and
                      (local.get $18)
                      (i32.const 3)
                     )
                    )
                   )
                   (local.set $16
                    (local.get $24)
                   )
                   (local.set $3
                    (local.get $18)
                   )
                   (br $label$134)
                  )
                  (i32.store8
                   (local.get $18)
                   (i32.const 48)
                  )
                  (local.set $3
                   (i32.add
                    (local.get $18)
                    (i32.const 1)
                   )
                  )
                  (br_if $label$134
                   (i32.eqz
                    (local.tee $16
                     (i32.add
                      (local.get $24)
                      (i32.const -1)
                     )
                    )
                   )
                  )
                  (br_if $label$134
                   (i32.eqz
                    (i32.and
                     (local.get $3)
                     (i32.const 3)
                    )
                   )
                  )
                  (i32.store8 offset=1
                   (local.get $18)
                   (i32.const 48)
                  )
                  (local.set $3
                   (i32.add
                    (local.get $18)
                    (i32.const 2)
                   )
                  )
                  (br_if $label$134
                   (i32.eqz
                    (local.tee $16
                     (i32.add
                      (local.get $24)
                      (i32.const -2)
                     )
                    )
                   )
                  )
                  (br_if $label$134
                   (i32.eqz
                    (i32.and
                     (local.get $3)
                     (i32.const 3)
                    )
                   )
                  )
                  (i32.store8 offset=2
                   (local.get $18)
                   (i32.const 48)
                  )
                  (local.set $3
                   (i32.add
                    (local.get $18)
                    (i32.const 3)
                   )
                  )
                  (br_if $label$134
                   (i32.eqz
                    (local.tee $16
                     (i32.add
                      (local.get $24)
                      (i32.const -3)
                     )
                    )
                   )
                  )
                  (br_if $label$134
                   (i32.eqz
                    (i32.and
                     (local.get $3)
                     (i32.const 3)
                    )
                   )
                  )
                  (i32.store8 offset=3
                   (local.get $18)
                   (i32.const 48)
                  )
                  (local.set $16
                   (i32.add
                    (local.get $24)
                    (i32.const -4)
                   )
                  )
                  (local.set $3
                   (i32.add
                    (local.get $18)
                    (i32.const 4)
                   )
                  )
                  (br $label$134)
                 )
                 (local.set $16
                  (i32.const 0)
                 )
                 (block $label$139
                  (br_if $label$139
                   (i32.eqz
                    (local.tee $19
                     (i32.and
                      (local.get $17)
                      (i32.const 64)
                     )
                    )
                   )
                  )
                  (local.set $16
                   (i32.rem_u
                    (i32.sub
                     (i32.const 600)
                     (local.get $3)
                    )
                    (i32.const 3)
                   )
                  )
                 )
                 (block $label$140
                  (block $label$141
                   (block $label$142
                    (block $label$143
                     (block $label$144
                      (block $label$145
                       (br_if $label$145
                        (i32.lt_u
                         (local.get $3)
                         (i32.load offset=12
                          (local.get $5)
                         )
                        )
                       )
                       (local.set $24
                        (i32.const 0)
                       )
                       (local.set $21
                        (local.get $11)
                       )
                       (local.set $3
                        (i32.const 0)
                       )
                       (br $label$144)
                      )
                      (local.set $21
                       (i32.const 0)
                      )
                      (local.set $3
                       (local.get $11)
                      )
                      (br $label$143)
                     )
                     (loop $label$146
                      (local.set $18
                       (i32.add
                        (local.get $21)
                        (local.get $3)
                       )
                      )
                      (block $label$147
                       (br_if $label$147
                        (i32.eqz
                         (local.get $19)
                        )
                       )
                       (br_if $label$147
                        (i32.ne
                         (local.tee $16
                          (i32.add
                           (local.get $16)
                           (i32.const 1)
                          )
                         )
                         (i32.const 4)
                        )
                       )
                       (local.set $16
                        (i32.const 0)
                       )
                       (i32.store8
                        (local.get $18)
                        (i32.load8_u offset=7473
                         (i32.const 0)
                        )
                       )
                       (local.set $3
                        (i32.add
                         (local.get $3)
                         (i32.const 1)
                        )
                       )
                       (br $label$146)
                      )
                      (i32.store8
                       (local.get $18)
                       (i32.load8_u
                        (i32.add
                         (i32.load offset=4
                          (local.get $5)
                         )
                         (local.get $24)
                        )
                       )
                      )
                      (local.set $21
                       (i32.add
                        (local.get $18)
                        (i32.const 1)
                       )
                      )
                      (block $label$148
                       (br_if $label$148
                        (i32.ge_u
                         (local.tee $24
                          (i32.add
                           (local.get $24)
                           (i32.const 1)
                          )
                         )
                         (i32.load offset=12
                          (local.get $5)
                         )
                        )
                       )
                       (local.set $3
                        (i32.const 0)
                       )
                       (br $label$146)
                      )
                     )
                     (local.set $3
                      (i32.add
                       (local.get $18)
                       (i32.const 1)
                      )
                     )
                     (br_if $label$140
                      (i32.le_u
                       (local.tee $21
                        (i32.load offset=8
                         (local.get $5)
                        )
                       )
                       (local.get $24)
                      )
                     )
                     (local.set $21
                      (i32.sub
                       (local.get $21)
                       (local.get $24)
                      )
                     )
                     (br_if $label$141
                      (local.get $19)
                     )
                     (br_if $label$142
                      (i32.eqz
                       (local.get $21)
                      )
                     )
                     (br_if $label$142
                      (i32.eqz
                       (i32.and
                        (i32.add
                         (local.get $18)
                         (i32.const 1)
                        )
                        (i32.const 3)
                       )
                      )
                     )
                     (i32.store8
                      (local.get $3)
                      (i32.const 48)
                     )
                     (local.set $3
                      (i32.add
                       (local.get $18)
                       (i32.const 2)
                      )
                     )
                     (block $label$149
                      (br_if $label$149
                       (local.tee $24
                        (i32.add
                         (local.get $21)
                         (i32.const -1)
                        )
                       )
                      )
                      (local.set $21
                       (local.get $24)
                      )
                      (br $label$142)
                     )
                     (block $label$150
                      (br_if $label$150
                       (i32.and
                        (local.get $3)
                        (i32.const 3)
                       )
                      )
                      (local.set $21
                       (local.get $24)
                      )
                      (br $label$142)
                     )
                     (i32.store8
                      (local.get $3)
                      (i32.const 48)
                     )
                     (local.set $3
                      (i32.add
                       (local.get $18)
                       (i32.const 3)
                      )
                     )
                     (block $label$151
                      (br_if $label$151
                       (local.tee $24
                        (i32.add
                         (local.get $21)
                         (i32.const -2)
                        )
                       )
                      )
                      (local.set $21
                       (local.get $24)
                      )
                      (br $label$142)
                     )
                     (block $label$152
                      (br_if $label$152
                       (i32.and
                        (local.get $3)
                        (i32.const 3)
                       )
                      )
                      (local.set $21
                       (local.get $24)
                      )
                      (br $label$142)
                     )
                     (i32.store8
                      (local.get $3)
                      (i32.const 48)
                     )
                     (local.set $3
                      (i32.add
                       (local.get $18)
                       (i32.const 4)
                      )
                     )
                     (block $label$153
                      (br_if $label$153
                       (local.tee $24
                        (i32.add
                         (local.get $21)
                         (i32.const -3)
                        )
                       )
                      )
                      (local.set $21
                       (local.get $24)
                      )
                      (br $label$142)
                     )
                     (block $label$154
                      (br_if $label$154
                       (i32.and
                        (local.get $3)
                        (i32.const 3)
                       )
                      )
                      (local.set $21
                       (local.get $24)
                      )
                      (br $label$142)
                     )
                     (i32.store8
                      (local.get $3)
                      (i32.const 48)
                     )
                     (local.set $21
                      (i32.add
                       (local.get $21)
                       (i32.const -4)
                      )
                     )
                     (local.set $3
                      (i32.add
                       (local.get $18)
                       (i32.const 5)
                      )
                     )
                     (br $label$142)
                    )
                    (loop $label$155
                     (local.set $24
                      (i32.add
                       (local.get $6)
                       (local.get $3)
                      )
                     )
                     (local.set $3
                      (i32.add
                       (local.get $3)
                       (i32.const 1)
                      )
                     )
                     (block $label$156
                      (loop $label$157
                       (local.set $18
                        (i32.add
                         (local.get $3)
                         (i32.const -1)
                        )
                       )
                       (br_if $label$156
                        (i32.eqz
                         (local.get $19)
                        )
                       )
                       (br_if $label$156
                        (i32.ne
                         (local.tee $16
                          (i32.add
                           (local.get $16)
                           (i32.const 1)
                          )
                         )
                         (i32.const 4)
                        )
                       )
                       (local.set $16
                        (i32.const 0)
                       )
                       (i32.store8
                        (local.get $18)
                        (i32.load8_u offset=7473
                         (i32.const 0)
                        )
                       )
                       (local.set $24
                        (i32.add
                         (local.get $24)
                         (i32.const 1)
                        )
                       )
                       (local.set $3
                        (i32.add
                         (local.get $3)
                         (i32.const 1)
                        )
                       )
                       (br $label$157)
                      )
                     )
                     (i32.store8
                      (local.get $18)
                      (i32.load8_u
                       (i32.add
                        (i32.load offset=4
                         (local.get $5)
                        )
                        (local.get $21)
                       )
                      )
                     )
                     (br_if $label$155
                      (i32.lt_u
                       (local.tee $21
                        (i32.add
                         (local.get $21)
                         (i32.const 1)
                        )
                       )
                       (local.tee $18
                        (i32.load offset=8
                         (local.get $5)
                        )
                       )
                      )
                     )
                    )
                    (block $label$158
                     (br_if $label$158
                      (i32.eqz
                       (local.get $25)
                      )
                     )
                     (i32.store8
                      (local.get $3)
                      (i32.load8_u offset=7472
                       (i32.const 0)
                      )
                     )
                     (local.set $3
                      (i32.add
                       (local.get $3)
                       (i32.const 1)
                      )
                     )
                     (local.set $18
                      (i32.load offset=8
                       (local.get $5)
                      )
                     )
                    )
                    (block $label$159
                     (br_if $label$159
                      (i32.le_u
                       (i32.sub
                        (local.tee $19
                         (i32.load offset=12
                          (local.get $5)
                         )
                        )
                        (local.get $18)
                       )
                       (local.get $25)
                      )
                     )
                     (i32.store offset=12
                      (local.get $5)
                      (local.tee $19
                       (i32.add
                        (local.get $18)
                        (local.get $25)
                       )
                      )
                     )
                    )
                    (block $label$160
                     (br_if $label$160
                      (i32.ge_u
                       (local.get $21)
                       (local.get $19)
                      )
                     )
                     (local.set $16
                      (i32.const 0)
                     )
                     (loop $label$161
                      (i32.store8
                       (i32.add
                        (local.get $3)
                        (local.get $16)
                       )
                       (i32.load8_u
                        (i32.add
                         (i32.add
                          (i32.load offset=4
                           (local.get $5)
                          )
                          (local.get $21)
                         )
                         (local.get $16)
                        )
                       )
                      )
                      (br_if $label$161
                       (i32.lt_u
                        (i32.add
                         (local.get $21)
                         (local.tee $16
                          (i32.add
                           (local.get $16)
                           (i32.const 1)
                          )
                         )
                        )
                        (local.tee $19
                         (i32.load offset=12
                          (local.get $5)
                         )
                        )
                       )
                      )
                     )
                     (local.set $3
                      (i32.add
                       (local.get $3)
                       (local.get $16)
                      )
                     )
                     (local.set $18
                      (i32.load offset=8
                       (local.get $5)
                      )
                     )
                    )
                    (local.set $25
                     (i32.add
                      (i32.sub
                       (local.get $25)
                       (local.get $19)
                      )
                      (local.get $18)
                     )
                    )
                    (br $label$133)
                   )
                   (br_if $label$141
                    (i32.lt_u
                     (local.get $21)
                     (i32.const 4)
                    )
                   )
                   (block $label$162
                    (br_if $label$162
                     (i32.eqz
                      (local.tee $18
                       (i32.and
                        (i32.add
                         (i32.shr_u
                          (local.tee $24
                           (i32.add
                            (local.get $21)
                            (i32.const -4)
                           )
                          )
                          (i32.const 2)
                         )
                         (i32.const 1)
                        )
                        (i32.const 7)
                       )
                      )
                     )
                    )
                    (loop $label$163
                     (i32.store
                      (local.get $3)
                      (i32.const 808464432)
                     )
                     (local.set $21
                      (i32.add
                       (local.get $21)
                       (i32.const -4)
                      )
                     )
                     (local.set $3
                      (i32.add
                       (local.get $3)
                       (i32.const 4)
                      )
                     )
                     (br_if $label$163
                      (local.tee $18
                       (i32.add
                        (local.get $18)
                        (i32.const -1)
                       )
                      )
                     )
                    )
                   )
                   (br_if $label$141
                    (i32.lt_u
                     (local.get $24)
                     (i32.const 28)
                    )
                   )
                   (loop $label$164
                    (i64.store align=4
                     (local.get $3)
                     (i64.const 3472328296227680304)
                    )
                    (i64.store align=4
                     (i32.add
                      (local.get $3)
                      (i32.const 24)
                     )
                     (i64.const 3472328296227680304)
                    )
                    (i64.store align=4
                     (i32.add
                      (local.get $3)
                      (i32.const 16)
                     )
                     (i64.const 3472328296227680304)
                    )
                    (i64.store align=4
                     (i32.add
                      (local.get $3)
                      (i32.const 8)
                     )
                     (i64.const 3472328296227680304)
                    )
                    (local.set $3
                     (i32.add
                      (local.get $3)
                      (i32.const 32)
                     )
                    )
                    (br_if $label$164
                     (i32.gt_u
                      (local.tee $21
                       (i32.add
                        (local.get $21)
                        (i32.const -32)
                       )
                      )
                      (i32.const 3)
                     )
                    )
                   )
                  )
                  (br_if $label$140
                   (i32.eqz
                    (local.get $21)
                   )
                  )
                  (loop $label$165
                   (block $label$166
                    (block $label$167
                     (br_if $label$167
                      (i32.eqz
                       (local.get $19)
                      )
                     )
                     (br_if $label$167
                      (i32.ne
                       (local.tee $16
                        (i32.add
                         (local.get $16)
                         (i32.const 1)
                        )
                       )
                       (i32.const 4)
                      )
                     )
                     (local.set $16
                      (i32.const 0)
                     )
                     (i32.store8
                      (local.get $3)
                      (i32.load8_u offset=7473
                       (i32.const 0)
                      )
                     )
                     (br $label$166)
                    )
                    (i32.store8
                     (local.get $3)
                     (i32.const 48)
                    )
                    (local.set $21
                     (i32.add
                      (local.get $21)
                      (i32.const -1)
                     )
                    )
                   )
                   (local.set $3
                    (i32.add
                     (local.get $3)
                     (i32.const 1)
                    )
                   )
                   (br_if $label$165
                    (local.get $21)
                   )
                  )
                 )
                 (local.set $24
                  (i32.add
                   (i32.sub
                    (local.get $3)
                    (local.get $11)
                   )
                   (i32.const 50331648)
                  )
                 )
                 (block $label$168
                  (br_if $label$168
                   (local.get $25)
                  )
                  (local.set $25
                   (i32.const 0)
                  )
                  (br $label$133)
                 )
                 (i32.store8
                  (local.get $3)
                  (i32.load8_u offset=7472
                   (i32.const 0)
                  )
                 )
                 (local.set $3
                  (i32.add
                   (local.get $3)
                   (i32.const 1)
                  )
                 )
                 (br $label$133)
                )
                (block $label$169
                 (br_if $label$169
                  (i32.lt_s
                   (local.get $16)
                   (i32.const 4)
                  )
                 )
                 (loop $label$170
                  (i32.store
                   (local.get $3)
                   (i32.const 808464432)
                  )
                  (local.set $3
                   (i32.add
                    (local.get $3)
                    (i32.const 4)
                   )
                  )
                  (local.set $18
                   (i32.gt_u
                    (local.get $16)
                    (i32.const 7)
                   )
                  )
                  (local.set $16
                   (i32.add
                    (local.get $16)
                    (i32.const -4)
                   )
                  )
                  (br_if $label$170
                   (local.get $18)
                  )
                 )
                )
                (block $label$171
                 (br_if $label$171
                  (i32.eqz
                   (local.get $16)
                  )
                 )
                 (local.set $19
                  (i32.add
                   (local.get $16)
                   (i32.const -1)
                  )
                 )
                 (block $label$172
                  (br_if $label$172
                   (i32.eqz
                    (local.tee $18
                     (i32.and
                      (local.get $16)
                      (i32.const 7)
                     )
                    )
                   )
                  )
                  (loop $label$173
                   (i32.store8
                    (local.get $3)
                    (i32.const 48)
                   )
                   (local.set $16
                    (i32.add
                     (local.get $16)
                     (i32.const -1)
                    )
                   )
                   (local.set $3
                    (i32.add
                     (local.get $3)
                     (i32.const 1)
                    )
                   )
                   (br_if $label$173
                    (local.tee $18
                     (i32.add
                      (local.get $18)
                      (i32.const -1)
                     )
                    )
                   )
                  )
                 )
                 (br_if $label$171
                  (i32.lt_u
                   (local.get $19)
                   (i32.const 7)
                  )
                 )
                 (loop $label$174
                  (i64.store align=1
                   (local.get $3)
                   (i64.const 3472328296227680304)
                  )
                  (local.set $3
                   (i32.add
                    (local.get $3)
                    (i32.const 8)
                   )
                  )
                  (br_if $label$174
                   (local.tee $16
                    (i32.add
                     (local.get $16)
                     (i32.const -8)
                    )
                   )
                  )
                 )
                )
                (block $label$175
                 (br_if $label$175
                  (i32.le_s
                   (local.tee $16
                    (i32.add
                     (local.tee $22
                      (i32.load offset=12
                       (local.get $5)
                      )
                     )
                     (local.get $24)
                    )
                   )
                   (local.get $25)
                  )
                 )
                 (i32.store offset=12
                  (local.get $5)
                  (local.tee $22
                   (i32.sub
                    (local.get $25)
                    (local.get $24)
                   )
                  )
                 )
                )
                (block $label$176
                 (br_if $label$176
                  (i32.eqz
                   (local.get $22)
                  )
                 )
                 (local.set $28
                  (i32.add
                   (select
                    (local.get $25)
                    (local.get $16)
                    (i32.lt_s
                     (local.get $25)
                     (local.get $16)
                    )
                   )
                   (i32.xor
                    (local.get $24)
                    (i32.const -1)
                   )
                  )
                 )
                 (block $label$177
                  (block $label$178
                   (br_if $label$178
                    (local.tee $16
                     (i32.and
                      (local.get $22)
                      (i32.const 3)
                     )
                    )
                   )
                   (local.set $16
                    (local.get $22)
                   )
                   (br $label$177)
                  )
                  (local.set $18
                   (i32.sub
                    (i32.const 0)
                    (local.get $16)
                   )
                  )
                  (local.set $16
                   (local.get $22)
                  )
                  (loop $label$179
                   (i32.store offset=4
                    (local.get $5)
                    (i32.add
                     (local.tee $19
                      (i32.load offset=4
                       (local.get $5)
                      )
                     )
                     (i32.const 1)
                    )
                   )
                   (i32.store8
                    (local.get $3)
                    (i32.load8_u
                     (local.get $19)
                    )
                   )
                   (local.set $16
                    (i32.add
                     (local.get $16)
                     (i32.const -1)
                    )
                   )
                   (local.set $3
                    (i32.add
                     (local.get $3)
                     (i32.const 1)
                    )
                   )
                   (local.set $21
                    (i32.ge_u
                     (local.tee $19
                      (i32.add
                       (local.get $18)
                       (i32.const 1)
                      )
                     )
                     (local.get $18)
                    )
                   )
                   (local.set $18
                    (local.get $19)
                   )
                   (br_if $label$179
                    (local.get $21)
                   )
                  )
                 )
                 (br_if $label$176
                  (i32.lt_u
                   (local.get $28)
                   (i32.const 3)
                  )
                 )
                 (loop $label$180
                  (i32.store offset=4
                   (local.get $5)
                   (i32.add
                    (local.tee $18
                     (i32.load offset=4
                      (local.get $5)
                     )
                    )
                    (i32.const 1)
                   )
                  )
                  (i32.store8
                   (local.get $3)
                   (i32.load8_u
                    (local.get $18)
                   )
                  )
                  (i32.store offset=4
                   (local.get $5)
                   (i32.add
                    (local.tee $18
                     (i32.load offset=4
                      (local.get $5)
                     )
                    )
                    (i32.const 1)
                   )
                  )
                  (i32.store8
                   (i32.add
                    (local.get $3)
                    (i32.const 1)
                   )
                   (i32.load8_u
                    (local.get $18)
                   )
                  )
                  (i32.store offset=4
                   (local.get $5)
                   (i32.add
                    (local.tee $18
                     (i32.load offset=4
                      (local.get $5)
                     )
                    )
                    (i32.const 1)
                   )
                  )
                  (i32.store8
                   (i32.add
                    (local.get $3)
                    (i32.const 2)
                   )
                   (i32.load8_u
                    (local.get $18)
                   )
                  )
                  (i32.store offset=4
                   (local.get $5)
                   (i32.add
                    (local.tee $18
                     (i32.load offset=4
                      (local.get $5)
                     )
                    )
                    (i32.const 1)
                   )
                  )
                  (i32.store8
                   (i32.add
                    (local.get $3)
                    (i32.const 3)
                   )
                   (i32.load8_u
                    (local.get $18)
                   )
                  )
                  (local.set $3
                   (i32.add
                    (local.get $3)
                    (i32.const 4)
                   )
                  )
                  (br_if $label$180
                   (local.tee $16
                    (i32.add
                     (local.get $16)
                     (i32.const -4)
                    )
                   )
                  )
                 )
                )
                (local.set $25
                 (i32.sub
                  (local.get $25)
                  (i32.add
                   (local.get $24)
                   (local.get $22)
                  )
                 )
                )
                (local.set $24
                 (i32.const 50331649)
                )
               )
               (br_if $label$45
                (i32.eqz
                 (i32.and
                  (local.get $17)
                  (i32.const 256)
                 )
                )
               )
               (i32.store8 offset=17
                (local.get $5)
                (i32.const 32)
               )
               (i32.store8 offset=16
                (local.get $5)
                (i32.xor
                 (local.tee $16
                  (i32.and
                   (i32.shr_u
                    (local.get $17)
                    (i32.const 10)
                   )
                   (i32.const 1)
                  )
                 )
                 (i32.const 1)
                )
               )
               (br_if $label$45
                (i32.lt_u
                 (local.get $17)
                 (i32.const 16777216)
                )
               )
               (local.set $19
                (i32.shr_u
                 (local.get $17)
                 (i32.const 24)
                )
               )
               (block $label$181
                (block $label$182
                 (block $label$183
                  (br_if $label$183
                   (i32.and
                    (local.get $17)
                    (i32.const 2048)
                   )
                  )
                  (local.set $18
                   (i32.sub
                    (i32.const 2)
                    (local.get $16)
                   )
                  )
                  (local.set $16
                   (i32.load8_u
                    (i32.add
                     (local.get $19)
                     (i32.const 3790)
                    )
                   )
                  )
                  (br $label$182)
                 )
                 (i32.store8
                  (i32.add
                   (i32.add
                    (local.get $5)
                    (i32.const 16)
                   )
                   (local.tee $18
                    (i32.sub
                     (i32.const 2)
                     (local.get $16)
                    )
                   )
                  )
                  (i32.load8_u
                   (i32.add
                    (local.get $19)
                    (i32.const 3796)
                   )
                  )
                 )
                 (br_if $label$181
                  (i32.ne
                   (i32.and
                    (local.get $17)
                    (i32.const 6144)
                   )
                   (i32.const 2048)
                  )
                 )
                 (local.set $18
                  (i32.xor
                   (local.get $16)
                   (i32.const 3)
                  )
                 )
                 (local.set $16
                  (i32.const 105)
                 )
                )
                (i32.store8
                 (i32.add
                  (i32.add
                   (local.get $5)
                   (i32.const 16)
                  )
                  (local.get $18)
                 )
                 (local.get $16)
                )
               )
               (i32.store8 offset=16
                (local.get $5)
                (local.get $18)
               )
              )
              (i32.store offset=12
               (local.get $5)
               (i32.sub
                (local.get $3)
                (local.get $11)
               )
              )
              (local.set $22
               (i32.const 0)
              )
              (local.set $16
               (local.get $11)
              )
              (br $label$41)
             )
             (local.set $24
              (i32.eq
               (local.get $22)
               (i32.const -1)
              )
             )
             (local.set $28
              (i32.eq
               (local.get $21)
               (i32.const 65)
              )
             )
             (local.set $18
              (i32.and
               (i32.wrap_i64
                (i64.shr_u
                 (local.tee $29
                  (i64.load
                   (local.tee $27
                    (i32.and
                     (i32.add
                      (local.get $19)
                      (i32.const 7)
                     )
                     (i32.const -8)
                    )
                   )
                  )
                 )
                 (i64.const 52)
                )
               )
               (i32.const 2047)
              )
             )
             (local.set $3
              (i32.const 45)
             )
             (block $label$184
              (block $label$185
               (br_if $label$185
                (i32.and
                 (local.tee $17
                  (select
                   (i32.or
                    (local.get $17)
                    (i32.const 128)
                   )
                   (local.get $17)
                   (i64.lt_s
                    (local.get $29)
                    (i64.const 0)
                   )
                  )
                 )
                 (i32.const 128)
                )
               )
               (local.set $3
                (i32.const 32)
               )
               (br_if $label$185
                (i32.and
                 (local.get $17)
                 (i32.const 4)
                )
               )
               (local.set $3
                (i32.const 43)
               )
               (local.set $16
                (i32.const 0)
               )
               (br_if $label$184
                (i32.eqz
                 (i32.and
                  (local.get $17)
                  (i32.const 2)
                 )
                )
               )
              )
              (i32.store8 offset=25
               (local.get $5)
               (local.get $3)
              )
              (local.set $16
               (i32.const 1)
              )
             )
             (local.set $21
              (select
               (i32.const 6)
               (local.get $22)
               (local.get $24)
              )
             )
             (local.set $3
              (select
               (i32.const 1056)
               (i32.const 1024)
               (local.get $28)
              )
             )
             (local.set $29
              (i64.and
               (local.get $29)
               (i64.const 4503599627370495)
              )
             )
             (block $label$186
              (block $label$187
               (br_if $label$187
                (local.get $18)
               )
               (i32.store offset=8
                (local.get $5)
                (local.tee $24
                 (select
                  (i32.const 0)
                  (i32.const -1022)
                  (i64.eqz
                   (local.get $29)
                  )
                 )
                )
               )
               (br $label$186)
              )
              (local.set $24
               (i32.add
                (local.get $18)
                (i32.const -1023)
               )
              )
              (local.set $29
               (i64.or
                (local.get $29)
                (i64.const 4503599627370496)
               )
              )
             )
             (i32.store16 align=1
              (i32.add
               (i32.add
                (local.get $16)
                (i32.add
                 (local.get $5)
                 (i32.const 24)
                )
               )
               (i32.const 1)
              )
              (i32.const 30768)
             )
             (i32.store8 offset=24
              (local.get $5)
              (i32.or
               (local.get $16)
               (i32.const 2)
              )
             )
             (i32.store8 offset=96
              (local.get $5)
              (i32.load8_u
               (i32.add
                (local.get $3)
                (i32.wrap_i64
                 (i64.shr_u
                  (local.tee $29
                   (i64.add
                    (i64.shl
                     (local.get $29)
                     (i64.const 8)
                    )
                    (select
                     (i64.shr_u
                      (i64.const 576460752303423488)
                      (i64.extend_i32_u
                       (i32.shl
                        (local.get $21)
                        (i32.const 2)
                       )
                      )
                     )
                     (i64.const 0)
                     (i32.lt_s
                      (local.get $21)
                      (i32.const 15)
                     )
                    )
                   )
                  )
                  (i64.const 60)
                 )
                )
               )
              )
             )
             (local.set $22
              (local.get $10)
             )
             (block $label$188
              (br_if $label$188
               (i32.eqz
                (local.get $21)
               )
              )
              (i32.store8 offset=97
               (local.get $5)
               (i32.load8_u offset=7472
                (i32.const 0)
               )
              )
              (local.set $22
               (local.get $9)
              )
             )
             (i32.store offset=4
              (local.get $5)
              (local.get $22)
             )
             (local.set $16
              (local.get $22)
             )
             (block $label$189
              (br_if $label$189
               (i32.eqz
                (local.tee $25
                 (select
                  (local.get $21)
                  (i32.const 13)
                  (i32.lt_u
                   (local.get $21)
                   (i32.const 13)
                  )
                 )
                )
               )
              )
              (local.set $26
               (i32.add
                (local.get $25)
                (i32.const -1)
               )
              )
              (block $label$190
               (block $label$191
                (br_if $label$191
                 (local.tee $19
                  (i32.and
                   (local.get $25)
                   (i32.const 3)
                  )
                 )
                )
                (local.set $16
                 (local.get $22)
                )
                (local.set $18
                 (local.get $25)
                )
                (br $label$190)
               )
               (local.set $16
                (local.get $22)
               )
               (local.set $18
                (local.get $25)
               )
               (loop $label$192
                (i32.store8
                 (local.get $16)
                 (i32.load8_u
                  (i32.add
                   (local.get $3)
                   (i32.wrap_i64
                    (i64.shr_u
                     (local.tee $29
                      (i64.shl
                       (local.get $29)
                       (i64.const 4)
                      )
                     )
                     (i64.const 60)
                    )
                   )
                  )
                 )
                )
                (local.set $16
                 (i32.add
                  (local.get $16)
                  (i32.const 1)
                 )
                )
                (local.set $18
                 (i32.add
                  (local.get $18)
                  (i32.const -1)
                 )
                )
                (br_if $label$192
                 (local.tee $19
                  (i32.add
                   (local.get $19)
                   (i32.const -1)
                  )
                 )
                )
               )
              )
              (br_if $label$189
               (i32.lt_u
                (local.get $26)
                (i32.const 3)
               )
              )
              (loop $label$193
               (i32.store8
                (i32.add
                 (local.get $16)
                 (i32.const 3)
                )
                (i32.load8_u
                 (i32.add
                  (local.get $3)
                  (i32.wrap_i64
                   (i64.shr_u
                    (local.tee $30
                     (i64.shl
                      (local.get $29)
                      (i64.const 16)
                     )
                    )
                    (i64.const 60)
                   )
                  )
                 )
                )
               )
               (i32.store8
                (i32.add
                 (local.get $16)
                 (i32.const 2)
                )
                (i32.load8_u
                 (i32.add
                  (local.get $3)
                  (i32.and
                   (i32.wrap_i64
                    (i64.shr_u
                     (local.get $29)
                     (i64.const 48)
                    )
                   )
                   (i32.const 15)
                  )
                 )
                )
               )
               (i32.store8
                (i32.add
                 (local.get $16)
                 (i32.const 1)
                )
                (i32.load8_u
                 (i32.add
                  (local.get $3)
                  (i32.and
                   (i32.wrap_i64
                    (i64.shr_u
                     (local.get $29)
                     (i64.const 52)
                    )
                   )
                   (i32.const 15)
                  )
                 )
                )
               )
               (i32.store8
                (local.get $16)
                (i32.load8_u
                 (i32.add
                  (local.get $3)
                  (i32.and
                   (i32.wrap_i64
                    (i64.shr_u
                     (local.get $29)
                     (i64.const 56)
                    )
                   )
                   (i32.const 15)
                  )
                 )
                )
               )
               (local.set $16
                (i32.add
                 (local.get $16)
                 (i32.const 4)
                )
               )
               (local.set $29
                (local.get $30)
               )
               (br_if $label$193
                (local.tee $18
                 (i32.add
                  (local.get $18)
                  (i32.const -4)
                 )
                )
               )
              )
             )
             (i32.store8 offset=17
              (local.get $5)
              (select
               (i32.const 80)
               (i32.const 112)
               (local.get $28)
              )
             )
             (block $label$194
              (block $label$195
               (br_if $label$195
                (i32.gt_s
                 (local.get $24)
                 (i32.const -1)
                )
               )
               (i32.store8 offset=18
                (local.get $5)
                (i32.const 45)
               )
               (local.set $24
                (i32.sub
                 (i32.const 0)
                 (local.get $24)
                )
               )
               (br $label$194)
              )
              (i32.store8 offset=18
               (local.get $5)
               (i32.const 43)
              )
             )
             (local.set $18
              (i32.gt_s
               (local.get $21)
               (local.get $25)
              )
             )
             (local.set $19
              (i32.sub
               (local.get $21)
               (local.get $25)
              )
             )
             (local.set $3
              (i32.const 6)
             )
             (block $label$196
              (block $label$197
               (br_if $label$197
                (i32.gt_u
                 (local.get $24)
                 (i32.const 999)
                )
               )
               (local.set $3
                (i32.const 5)
               )
               (br_if $label$197
                (i32.gt_u
                 (local.get $24)
                 (i32.const 99)
                )
               )
               (local.set $3
                (i32.const 4)
               )
               (br_if $label$197
                (i32.gt_u
                 (local.get $24)
                 (i32.const 9)
                )
               )
               (i32.store8 offset=16
                (local.get $5)
                (i32.const 3)
               )
               (i32.store8 offset=19
                (local.get $5)
                (i32.or
                 (i32.rem_u
                  (i32.and
                   (local.get $24)
                   (i32.const 255)
                  )
                  (i32.const 10)
                 )
                 (i32.const 48)
                )
               )
               (br $label$196)
              )
              (i32.store8 offset=16
               (local.get $5)
               (local.get $3)
              )
              (i32.store8
               (i32.add
                (i32.add
                 (local.get $5)
                 (i32.const 16)
                )
                (local.get $3)
               )
               (i32.or
                (i32.rem_u
                 (local.get $24)
                 (i32.const 10)
                )
                (i32.const 48)
               )
              )
              (i32.store8
               (i32.add
                (i32.add
                 (local.get $5)
                 (i32.const 16)
                )
                (local.tee $21
                 (i32.add
                  (local.get $3)
                  (i32.const -1)
                 )
                )
               )
               (i32.add
                (i32.rem_s
                 (i32.div_s
                  (local.get $24)
                  (i32.const 10)
                 )
                 (i32.const 10)
                )
                (i32.const 48)
               )
              )
              (br_if $label$196
               (i32.lt_u
                (local.get $21)
                (i32.const 4)
               )
              )
              (i32.store8
               (i32.add
                (i32.add
                 (local.get $5)
                 (i32.const 16)
                )
                (local.tee $21
                 (i32.add
                  (local.get $3)
                  (i32.const -2)
                 )
                )
               )
               (i32.add
                (i32.rem_s
                 (i32.div_s
                  (local.get $24)
                  (i32.const 100)
                 )
                 (i32.const 10)
                )
                (i32.const 48)
               )
              )
              (br_if $label$196
               (i32.lt_u
                (local.get $21)
                (i32.const 4)
               )
              )
              (i32.store8
               (i32.add
                (i32.add
                 (local.get $3)
                 (i32.add
                  (local.get $5)
                  (i32.const 16)
                 )
                )
                (i32.const -3)
               )
               (i32.add
                (i32.rem_s
                 (i32.div_s
                  (local.get $24)
                  (i32.const 1000)
                 )
                 (i32.const 10)
                )
                (i32.const 48)
               )
              )
             )
             (local.set $4
              (i32.add
               (local.get $27)
               (i32.const 8)
              )
             )
             (local.set $25
              (select
               (local.get $19)
               (i32.const 0)
               (local.get $18)
              )
             )
             (i32.store offset=12
              (local.get $5)
              (i32.sub
               (local.get $16)
               (local.get $11)
              )
             )
             (i32.store offset=8
              (local.get $5)
              (i32.sub
               (local.get $16)
               (local.get $22)
              )
             )
             (local.set $22
              (i32.const 0)
             )
             (local.set $24
              (i32.const 50331649)
             )
             (local.set $16
              (local.get $11)
             )
             (br $label$41)
            )
            (local.set $16
             (i32.load
              (local.get $19)
             )
            )
            (i32.store offset=12
             (local.get $5)
             (i32.const 1)
            )
            (i32.store8 offset=543
             (local.get $5)
             (local.get $16)
            )
            (local.set $24
             (i32.const 0)
            )
            (i32.store8 offset=24
             (local.get $5)
             (i32.const 0)
            )
            (i32.store8 offset=16
             (local.get $5)
             (i32.const 0)
            )
            (i32.store offset=8
             (local.get $5)
             (i32.const 0)
            )
            (local.set $4
             (i32.add
              (local.get $19)
              (i32.const 4)
             )
            )
            (local.set $16
             (local.get $7)
            )
           )
           (local.set $25
            (i32.const 0)
           )
           (local.set $22
            (i32.const 0)
           )
          )
          (local.set $20
           (select
            (i32.const 0)
            (i32.sub
             (local.get $20)
             (local.tee $21
              (i32.add
               (i32.add
                (i32.add
                 (local.get $25)
                 (local.tee $18
                  (i32.load8_s offset=24
                   (local.get $5)
                  )
                 )
                )
                (local.tee $19
                 (select
                  (local.tee $3
                   (i32.load offset=12
                    (local.get $5)
                   )
                  )
                  (local.get $22)
                  (i32.lt_s
                   (local.get $22)
                   (local.get $3)
                  )
                 )
                )
               )
               (i32.load8_s offset=16
                (local.get $5)
               )
              )
             )
            )
            (i32.lt_s
             (local.get $20)
             (local.get $21)
            )
           )
          )
          (local.set $22
           (i32.sub
            (local.get $19)
            (local.get $3)
           )
          )
          (block $label$198
           (br_if $label$198
            (i32.and
             (local.get $17)
             (i32.const 1)
            )
           )
           (block $label$199
            (br_if $label$199
             (i32.eqz
              (i32.and
               (local.get $17)
               (i32.const 16)
              )
             )
            )
            (local.set $22
             (select
              (local.get $20)
              (local.get $22)
              (i32.gt_s
               (local.get $20)
               (local.get $22)
              )
             )
            )
            (local.set $20
             (i32.const 0)
            )
            (br $label$198)
           )
           (local.set $17
            (i32.and
             (local.get $17)
             (i32.const -65)
            )
           )
          )
          (block $label$200
           (block $label$201
            (br_if $label$201
             (i32.eq
              (local.get $20)
              (i32.sub
               (i32.const 0)
               (local.get $22)
              )
             )
            )
            (block $label$202
             (br_if $label$202
              (i32.and
               (local.get $17)
               (i32.const 1)
              )
             )
             (br_if $label$202
              (i32.lt_s
               (local.get $20)
               (i32.const 1)
              )
             )
             (loop $label$203
              (block $label$204
               (block $label$205
                (block $label$206
                 (br_if $label$206
                  (i32.eqz
                   (local.tee $19
                    (select
                     (select
                      (local.tee $3
                       (i32.add
                        (i32.sub
                         (local.get $15)
                         (local.get $2)
                        )
                        (i32.const 512)
                       )
                      )
                      (local.get $20)
                      (i32.gt_s
                       (local.get $20)
                       (local.get $3)
                      )
                     )
                     (local.get $20)
                     (local.get $0)
                    )
                   )
                  )
                 )
                 (br_if $label$205
                  (i32.and
                   (local.get $2)
                   (i32.const 3)
                  )
                 )
                )
                (local.set $18
                 (local.get $19)
                )
                (local.set $3
                 (local.get $2)
                )
                (br $label$204)
               )
               (i32.store8
                (local.get $2)
                (i32.const 32)
               )
               (local.set $3
                (i32.add
                 (local.get $2)
                 (i32.const 1)
                )
               )
               (br_if $label$204
                (i32.eqz
                 (local.tee $18
                  (i32.add
                   (local.get $19)
                   (i32.const -1)
                  )
                 )
                )
               )
               (br_if $label$204
                (i32.eqz
                 (i32.and
                  (local.get $3)
                  (i32.const 3)
                 )
                )
               )
               (i32.store8 offset=1
                (local.get $2)
                (i32.const 32)
               )
               (local.set $3
                (i32.add
                 (local.get $2)
                 (i32.const 2)
                )
               )
               (br_if $label$204
                (i32.eqz
                 (local.tee $18
                  (i32.add
                   (local.get $19)
                   (i32.const -2)
                  )
                 )
                )
               )
               (br_if $label$204
                (i32.eqz
                 (i32.and
                  (local.get $3)
                  (i32.const 3)
                 )
                )
               )
               (i32.store8 offset=2
                (local.get $2)
                (i32.const 32)
               )
               (local.set $3
                (i32.add
                 (local.get $2)
                 (i32.const 3)
                )
               )
               (br_if $label$204
                (i32.eqz
                 (local.tee $18
                  (i32.add
                   (local.get $19)
                   (i32.const -3)
                  )
                 )
                )
               )
               (br_if $label$204
                (i32.eqz
                 (i32.and
                  (local.get $3)
                  (i32.const 3)
                 )
                )
               )
               (i32.store8 offset=3
                (local.get $2)
                (i32.const 32)
               )
               (local.set $18
                (i32.add
                 (local.get $19)
                 (i32.const -4)
                )
               )
               (local.set $3
                (i32.add
                 (local.get $2)
                 (i32.const 4)
                )
               )
              )
              (block $label$207
               (br_if $label$207
                (i32.lt_s
                 (local.get $18)
                 (i32.const 4)
                )
               )
               (loop $label$208
                (i32.store
                 (local.get $3)
                 (i32.const 538976288)
                )
                (local.set $3
                 (i32.add
                  (local.get $3)
                  (i32.const 4)
                 )
                )
                (local.set $2
                 (i32.gt_u
                  (local.get $18)
                  (i32.const 7)
                 )
                )
                (local.set $18
                 (i32.add
                  (local.get $18)
                  (i32.const -4)
                 )
                )
                (br_if $label$208
                 (local.get $2)
                )
               )
              )
              (block $label$209
               (br_if $label$209
                (i32.eqz
                 (local.get $18)
                )
               )
               (local.set $21
                (i32.add
                 (local.get $18)
                 (i32.const -1)
                )
               )
               (block $label$210
                (br_if $label$210
                 (i32.eqz
                  (local.tee $2
                   (i32.and
                    (local.get $18)
                    (i32.const 7)
                   )
                  )
                 )
                )
                (loop $label$211
                 (i32.store8
                  (local.get $3)
                  (i32.const 32)
                 )
                 (local.set $18
                  (i32.add
                   (local.get $18)
                   (i32.const -1)
                  )
                 )
                 (local.set $3
                  (i32.add
                   (local.get $3)
                   (i32.const 1)
                  )
                 )
                 (br_if $label$211
                  (local.tee $2
                   (i32.add
                    (local.get $2)
                    (i32.const -1)
                   )
                  )
                 )
                )
               )
               (br_if $label$209
                (i32.lt_u
                 (local.get $21)
                 (i32.const 7)
                )
               )
               (loop $label$212
                (i64.store align=1
                 (local.get $3)
                 (i64.const 2314885530818453536)
                )
                (local.set $3
                 (i32.add
                  (local.get $3)
                  (i32.const 8)
                 )
                )
                (br_if $label$212
                 (local.tee $18
                  (i32.add
                   (local.get $18)
                   (i32.const -8)
                  )
                 )
                )
               )
              )
              (block $label$213
               (block $label$214
                (br_if $label$214
                 (local.get $0)
                )
                (local.set $2
                 (local.get $3)
                )
                (br $label$213)
               )
               (block $label$215
                (br_if $label$215
                 (i32.ge_s
                  (local.tee $2
                   (i32.sub
                    (local.get $3)
                    (local.get $15)
                   )
                  )
                  (i32.const 511)
                 )
                )
                (local.set $2
                 (local.get $3)
                )
                (br $label$213)
               )
               (local.set $14
                (i32.add
                 (local.get $2)
                 (local.get $14)
                )
               )
               (br_if $label$2
                (i32.eqz
                 (local.tee $2
                  (call_indirect (type $i32_i32_i32_=>_i32)
                   (local.get $15)
                   (local.get $1)
                   (local.get $2)
                   (local.get $0)
                  )
                 )
                )
               )
               (local.set $15
                (local.get $2)
               )
              )
              (br_if $label$203
               (i32.gt_s
                (local.tee $20
                 (i32.sub
                  (local.get $20)
                  (local.get $19)
                 )
                )
                (i32.const 0)
               )
              )
             )
             (local.set $18
              (i32.load8_u offset=24
               (local.get $5)
              )
             )
            )
            (i32.store offset=4
             (local.get $5)
             (local.get $12)
            )
            (block $label$216
             (br_if $label$216
              (i32.eqz
               (i32.and
                (local.get $18)
                (i32.const 255)
               )
              )
             )
             (loop $label$217
              (i32.store8 offset=24
               (local.get $5)
               (i32.sub
                (local.get $18)
                (local.tee $3
                 (select
                  (select
                   (local.tee $19
                    (i32.add
                     (i32.sub
                      (local.get $15)
                      (local.get $2)
                     )
                     (i32.const 512)
                    )
                   )
                   (local.tee $3
                    (i32.shr_s
                     (i32.shl
                      (local.get $18)
                      (i32.const 24)
                     )
                     (i32.const 24)
                    )
                   )
                   (i32.lt_s
                    (local.get $19)
                    (local.get $3)
                   )
                  )
                  (local.get $3)
                  (local.get $0)
                 )
                )
               )
              )
              (block $label$218
               (br_if $label$218
                (i32.eqz
                 (local.get $3)
                )
               )
               (local.set $21
                (i32.add
                 (local.get $3)
                 (i32.const -1)
                )
               )
               (block $label$219
                (br_if $label$219
                 (i32.eqz
                  (local.tee $18
                   (i32.and
                    (local.get $3)
                    (i32.const 3)
                   )
                  )
                 )
                )
                (loop $label$220
                 (i32.store offset=4
                  (local.get $5)
                  (i32.add
                   (local.tee $19
                    (i32.load offset=4
                     (local.get $5)
                    )
                   )
                   (i32.const 1)
                  )
                 )
                 (i32.store8
                  (local.get $2)
                  (i32.load8_u
                   (local.get $19)
                  )
                 )
                 (local.set $3
                  (i32.add
                   (local.get $3)
                   (i32.const -1)
                  )
                 )
                 (local.set $2
                  (i32.add
                   (local.get $2)
                   (i32.const 1)
                  )
                 )
                 (br_if $label$220
                  (local.tee $18
                   (i32.add
                    (local.get $18)
                    (i32.const -1)
                   )
                  )
                 )
                )
               )
               (br_if $label$218
                (i32.lt_u
                 (local.get $21)
                 (i32.const 3)
                )
               )
               (loop $label$221
                (i32.store offset=4
                 (local.get $5)
                 (i32.add
                  (local.tee $18
                   (i32.load offset=4
                    (local.get $5)
                   )
                  )
                  (i32.const 1)
                 )
                )
                (i32.store8
                 (local.get $2)
                 (i32.load8_u
                  (local.get $18)
                 )
                )
                (i32.store offset=4
                 (local.get $5)
                 (i32.add
                  (local.tee $18
                   (i32.load offset=4
                    (local.get $5)
                   )
                  )
                  (i32.const 1)
                 )
                )
                (i32.store8
                 (i32.add
                  (local.get $2)
                  (i32.const 1)
                 )
                 (i32.load8_u
                  (local.get $18)
                 )
                )
                (i32.store offset=4
                 (local.get $5)
                 (i32.add
                  (local.tee $18
                   (i32.load offset=4
                    (local.get $5)
                   )
                  )
                  (i32.const 1)
                 )
                )
                (i32.store8
                 (i32.add
                  (local.get $2)
                  (i32.const 2)
                 )
                 (i32.load8_u
                  (local.get $18)
                 )
                )
                (i32.store offset=4
                 (local.get $5)
                 (i32.add
                  (local.tee $18
                   (i32.load offset=4
                    (local.get $5)
                   )
                  )
                  (i32.const 1)
                 )
                )
                (i32.store8
                 (i32.add
                  (local.get $2)
                  (i32.const 3)
                 )
                 (i32.load8_u
                  (local.get $18)
                 )
                )
                (local.set $2
                 (i32.add
                  (local.get $2)
                  (i32.const 4)
                 )
                )
                (br_if $label$221
                 (local.tee $3
                  (i32.add
                   (local.get $3)
                   (i32.const -4)
                  )
                 )
                )
               )
              )
              (block $label$222
               (br_if $label$222
                (i32.eqz
                 (local.get $0)
                )
               )
               (br_if $label$222
                (i32.lt_s
                 (local.tee $3
                  (i32.sub
                   (local.get $2)
                   (local.get $15)
                  )
                 )
                 (i32.const 511)
                )
               )
               (local.set $14
                (i32.add
                 (local.get $3)
                 (local.get $14)
                )
               )
               (br_if $label$2
                (i32.eqz
                 (local.tee $2
                  (call_indirect (type $i32_i32_i32_=>_i32)
                   (local.get $15)
                   (local.get $1)
                   (local.get $3)
                   (local.get $0)
                  )
                 )
                )
               )
               (local.set $15
                (local.get $2)
               )
              )
              (br_if $label$217
               (local.tee $18
                (i32.load8_u offset=24
                 (local.get $5)
                )
               )
              )
             )
            )
            (local.set $21
             (i32.shr_u
              (local.get $24)
              (i32.const 24)
             )
            )
            (local.set $18
             (i32.const 0)
            )
            (block $label$223
             (br_if $label$223
              (i32.eqz
               (local.tee $27
                (i32.and
                 (local.get $17)
                 (i32.const 64)
                )
               )
              )
             )
             (local.set $18
              (i32.sub
               (local.get $21)
               (i32.rem_u
                (i32.add
                 (local.get $22)
                 (i32.and
                  (local.get $24)
                  (i32.const 16777215)
                 )
                )
                (i32.add
                 (local.get $21)
                 (i32.const 1)
                )
               )
              )
             )
            )
            (block $label$224
             (br_if $label$224
              (i32.ge_s
               (local.get $22)
               (i32.const 1)
              )
             )
             (i32.store offset=4
              (local.get $5)
              (local.get $12)
             )
             (br $label$200)
            )
            (loop $label$225
             (local.set $28
              (select
               (select
                (local.tee $3
                 (i32.add
                  (i32.sub
                   (local.get $15)
                   (local.get $2)
                  )
                  (i32.const 512)
                 )
                )
                (local.get $22)
                (i32.gt_s
                 (local.get $22)
                 (local.get $3)
                )
               )
               (local.get $22)
               (local.get $0)
              )
             )
             (block $label$226
              (block $label$227
               (block $label$228
                (block $label$229
                 (block $label$230
                  (block $label$231
                   (br_if $label$231
                    (local.get $27)
                   )
                   (block $label$232
                    (block $label$233
                     (br_if $label$233
                      (i32.eqz
                       (local.get $28)
                      )
                     )
                     (br_if $label$232
                      (i32.and
                       (local.get $2)
                       (i32.const 3)
                      )
                     )
                    )
                    (local.set $3
                     (local.get $28)
                    )
                    (local.set $19
                     (local.get $2)
                    )
                    (br $label$230)
                   )
                   (i32.store8
                    (local.get $2)
                    (i32.const 48)
                   )
                   (local.set $19
                    (i32.add
                     (local.get $2)
                     (i32.const 1)
                    )
                   )
                   (br_if $label$230
                    (i32.eqz
                     (local.tee $3
                      (i32.add
                       (local.get $28)
                       (i32.const -1)
                      )
                     )
                    )
                   )
                   (br_if $label$230
                    (i32.eqz
                     (i32.and
                      (local.get $19)
                      (i32.const 3)
                     )
                    )
                   )
                   (i32.store8 offset=1
                    (local.get $2)
                    (i32.const 48)
                   )
                   (local.set $19
                    (i32.add
                     (local.get $2)
                     (i32.const 2)
                    )
                   )
                   (br_if $label$230
                    (i32.eqz
                     (local.tee $3
                      (i32.add
                       (local.get $28)
                       (i32.const -2)
                      )
                     )
                    )
                   )
                   (br_if $label$230
                    (i32.eqz
                     (i32.and
                      (local.get $19)
                      (i32.const 3)
                     )
                    )
                   )
                   (i32.store8 offset=2
                    (local.get $2)
                    (i32.const 48)
                   )
                   (local.set $19
                    (i32.add
                     (local.get $2)
                     (i32.const 3)
                    )
                   )
                   (br_if $label$230
                    (i32.eqz
                     (local.tee $3
                      (i32.add
                       (local.get $28)
                       (i32.const -3)
                      )
                     )
                    )
                   )
                   (br_if $label$230
                    (i32.eqz
                     (i32.and
                      (local.get $19)
                      (i32.const 3)
                     )
                    )
                   )
                   (i32.store8 offset=3
                    (local.get $2)
                    (i32.const 48)
                   )
                   (local.set $3
                    (i32.add
                     (local.get $28)
                     (i32.const -4)
                    )
                   )
                   (local.set $19
                    (i32.add
                     (local.get $2)
                     (i32.const 4)
                    )
                   )
                   (br $label$230)
                  )
                  (local.set $3
                   (local.get $28)
                  )
                  (br_if $label$226
                   (i32.eqz
                    (local.get $28)
                   )
                  )
                  (br $label$229)
                 )
                 (block $label$234
                  (br_if $label$234
                   (i32.lt_s
                    (local.get $3)
                    (i32.const 4)
                   )
                  )
                  (loop $label$235
                   (i32.store
                    (local.get $19)
                    (i32.const 808464432)
                   )
                   (local.set $19
                    (i32.add
                     (local.get $19)
                     (i32.const 4)
                    )
                   )
                   (local.set $2
                    (i32.gt_u
                     (local.get $3)
                     (i32.const 7)
                    )
                   )
                   (local.set $3
                    (i32.add
                     (local.get $3)
                     (i32.const -4)
                    )
                   )
                   (br_if $label$235
                    (local.get $2)
                   )
                  )
                 )
                 (br_if $label$227
                  (i32.eqz
                   (local.get $3)
                  )
                 )
                 (br_if $label$228
                  (i32.eqz
                   (local.get $27)
                  )
                 )
                 (local.set $2
                  (local.get $19)
                 )
                )
                (local.set $26
                 (i32.add
                  (local.get $3)
                  (i32.const -1)
                 )
                )
                (block $label$236
                 (br_if $label$236
                  (i32.eqz
                   (local.tee $19
                    (i32.and
                     (local.get $3)
                     (i32.const 3)
                    )
                   )
                  )
                 )
                 (loop $label$237
                  (i32.store8
                   (local.get $2)
                   (select
                    (i32.load8_u offset=7473
                     (i32.const 0)
                    )
                    (i32.const 48)
                    (local.tee $24
                     (i32.eq
                      (local.get $18)
                      (local.get $21)
                     )
                    )
                   )
                  )
                  (local.set $18
                   (select
                    (i32.const 0)
                    (i32.add
                     (local.get $18)
                     (i32.const 1)
                    )
                    (local.get $24)
                   )
                  )
                  (local.set $3
                   (i32.add
                    (local.get $3)
                    (i32.const -1)
                   )
                  )
                  (local.set $2
                   (i32.add
                    (local.get $2)
                    (i32.const 1)
                   )
                  )
                  (br_if $label$237
                   (local.tee $19
                    (i32.add
                     (local.get $19)
                     (i32.const -1)
                    )
                   )
                  )
                 )
                )
                (br_if $label$226
                 (i32.lt_u
                  (local.get $26)
                  (i32.const 3)
                 )
                )
                (loop $label$238
                 (i32.store8
                  (local.get $2)
                  (select
                   (i32.load8_u offset=7473
                    (i32.const 0)
                   )
                   (i32.const 48)
                   (local.tee $19
                    (i32.eq
                     (local.get $18)
                     (local.get $21)
                    )
                   )
                  )
                 )
                 (i32.store8
                  (i32.add
                   (local.get $2)
                   (i32.const 1)
                  )
                  (select
                   (i32.load8_u offset=7473
                    (i32.const 0)
                   )
                   (i32.const 48)
                   (local.tee $19
                    (i32.eq
                     (local.tee $18
                      (select
                       (i32.const 0)
                       (i32.add
                        (local.get $18)
                        (i32.const 1)
                       )
                       (local.get $19)
                      )
                     )
                     (local.get $21)
                    )
                   )
                  )
                 )
                 (i32.store8
                  (i32.add
                   (local.get $2)
                   (i32.const 2)
                  )
                  (select
                   (i32.load8_u offset=7473
                    (i32.const 0)
                   )
                   (i32.const 48)
                   (local.tee $19
                    (i32.eq
                     (local.tee $18
                      (select
                       (i32.const 0)
                       (i32.add
                        (local.get $18)
                        (i32.const 1)
                       )
                       (local.get $19)
                      )
                     )
                     (local.get $21)
                    )
                   )
                  )
                 )
                 (i32.store8
                  (i32.add
                   (local.get $2)
                   (i32.const 3)
                  )
                  (select
                   (i32.load8_u offset=7473
                    (i32.const 0)
                   )
                   (i32.const 48)
                   (local.tee $19
                    (i32.eq
                     (local.tee $18
                      (select
                       (i32.const 0)
                       (i32.add
                        (local.get $18)
                        (i32.const 1)
                       )
                       (local.get $19)
                      )
                     )
                     (local.get $21)
                    )
                   )
                  )
                 )
                 (local.set $18
                  (select
                   (i32.const 0)
                   (i32.add
                    (local.get $18)
                    (i32.const 1)
                   )
                   (local.get $19)
                  )
                 )
                 (local.set $2
                  (i32.add
                   (local.get $2)
                   (i32.const 4)
                  )
                 )
                 (br_if $label$238
                  (local.tee $3
                   (i32.add
                    (local.get $3)
                    (i32.const -4)
                   )
                  )
                 )
                 (br $label$226)
                )
               )
               (local.set $24
                (i32.add
                 (local.get $3)
                 (i32.const -1)
                )
               )
               (block $label$239
                (br_if $label$239
                 (i32.eqz
                  (local.tee $2
                   (i32.and
                    (local.get $3)
                    (i32.const 7)
                   )
                  )
                 )
                )
                (loop $label$240
                 (i32.store8
                  (local.get $19)
                  (i32.const 48)
                 )
                 (local.set $3
                  (i32.add
                   (local.get $3)
                   (i32.const -1)
                  )
                 )
                 (local.set $19
                  (i32.add
                   (local.get $19)
                   (i32.const 1)
                  )
                 )
                 (br_if $label$240
                  (local.tee $2
                   (i32.add
                    (local.get $2)
                    (i32.const -1)
                   )
                  )
                 )
                )
               )
               (br_if $label$227
                (i32.lt_u
                 (local.get $24)
                 (i32.const 7)
                )
               )
               (loop $label$241
                (i64.store align=1
                 (local.get $19)
                 (i64.const 3472328296227680304)
                )
                (local.set $19
                 (i32.add
                  (local.get $19)
                  (i32.const 8)
                 )
                )
                (br_if $label$241
                 (local.tee $3
                  (i32.add
                   (local.get $3)
                   (i32.const -8)
                  )
                 )
                )
               )
              )
              (local.set $2
               (local.get $19)
              )
             )
             (block $label$242
              (br_if $label$242
               (i32.eqz
                (local.get $0)
               )
              )
              (br_if $label$242
               (i32.lt_s
                (local.tee $3
                 (i32.sub
                  (local.get $2)
                  (local.get $15)
                 )
                )
                (i32.const 511)
               )
              )
              (local.set $14
               (i32.add
                (local.get $3)
                (local.get $14)
               )
              )
              (br_if $label$2
               (i32.eqz
                (local.tee $2
                 (call_indirect (type $i32_i32_i32_=>_i32)
                  (local.get $15)
                  (local.get $1)
                  (local.get $3)
                  (local.get $0)
                 )
                )
               )
              )
              (local.set $15
               (local.get $2)
              )
             )
             (br_if $label$225
              (i32.gt_s
               (local.tee $22
                (i32.sub
                 (local.get $22)
                 (local.get $28)
                )
               )
               (i32.const 0)
              )
             )
            )
            (local.set $18
             (i32.load8_u offset=24
              (local.get $5)
             )
            )
           )
           (i32.store offset=4
            (local.get $5)
            (local.get $12)
           )
           (br_if $label$200
            (i32.eqz
             (i32.and
              (local.get $18)
              (i32.const 255)
             )
            )
           )
           (loop $label$243
            (i32.store8 offset=24
             (local.get $5)
             (i32.sub
              (local.get $18)
              (local.tee $3
               (select
                (select
                 (local.tee $19
                  (i32.add
                   (i32.sub
                    (local.get $15)
                    (local.get $2)
                   )
                   (i32.const 512)
                  )
                 )
                 (local.tee $3
                  (i32.shr_s
                   (i32.shl
                    (local.get $18)
                    (i32.const 24)
                   )
                   (i32.const 24)
                  )
                 )
                 (i32.lt_s
                  (local.get $19)
                  (local.get $3)
                 )
                )
                (local.get $3)
                (local.get $0)
               )
              )
             )
            )
            (block $label$244
             (br_if $label$244
              (i32.eqz
               (local.get $3)
              )
             )
             (local.set $21
              (i32.add
               (local.get $3)
               (i32.const -1)
              )
             )
             (block $label$245
              (br_if $label$245
               (i32.eqz
                (local.tee $18
                 (i32.and
                  (local.get $3)
                  (i32.const 3)
                 )
                )
               )
              )
              (loop $label$246
               (i32.store offset=4
                (local.get $5)
                (i32.add
                 (local.tee $19
                  (i32.load offset=4
                   (local.get $5)
                  )
                 )
                 (i32.const 1)
                )
               )
               (i32.store8
                (local.get $2)
                (i32.load8_u
                 (local.get $19)
                )
               )
               (local.set $3
                (i32.add
                 (local.get $3)
                 (i32.const -1)
                )
               )
               (local.set $2
                (i32.add
                 (local.get $2)
                 (i32.const 1)
                )
               )
               (br_if $label$246
                (local.tee $18
                 (i32.add
                  (local.get $18)
                  (i32.const -1)
                 )
                )
               )
              )
             )
             (br_if $label$244
              (i32.lt_u
               (local.get $21)
               (i32.const 3)
              )
             )
             (loop $label$247
              (i32.store offset=4
               (local.get $5)
               (i32.add
                (local.tee $18
                 (i32.load offset=4
                  (local.get $5)
                 )
                )
                (i32.const 1)
               )
              )
              (i32.store8
               (local.get $2)
               (i32.load8_u
                (local.get $18)
               )
              )
              (i32.store offset=4
               (local.get $5)
               (i32.add
                (local.tee $18
                 (i32.load offset=4
                  (local.get $5)
                 )
                )
                (i32.const 1)
               )
              )
              (i32.store8
               (i32.add
                (local.get $2)
                (i32.const 1)
               )
               (i32.load8_u
                (local.get $18)
               )
              )
              (i32.store offset=4
               (local.get $5)
               (i32.add
                (local.tee $18
                 (i32.load offset=4
                  (local.get $5)
                 )
                )
                (i32.const 1)
               )
              )
              (i32.store8
               (i32.add
                (local.get $2)
                (i32.const 2)
               )
               (i32.load8_u
                (local.get $18)
               )
              )
              (i32.store offset=4
               (local.get $5)
               (i32.add
                (local.tee $18
                 (i32.load offset=4
                  (local.get $5)
                 )
                )
                (i32.const 1)
               )
              )
              (i32.store8
               (i32.add
                (local.get $2)
                (i32.const 3)
               )
               (i32.load8_u
                (local.get $18)
               )
              )
              (local.set $2
               (i32.add
                (local.get $2)
                (i32.const 4)
               )
              )
              (br_if $label$247
               (local.tee $3
                (i32.add
                 (local.get $3)
                 (i32.const -4)
                )
               )
              )
             )
            )
            (block $label$248
             (br_if $label$248
              (i32.eqz
               (local.get $0)
              )
             )
             (br_if $label$248
              (i32.lt_s
               (local.tee $3
                (i32.sub
                 (local.get $2)
                 (local.get $15)
                )
               )
               (i32.const 511)
              )
             )
             (local.set $14
              (i32.add
               (local.get $3)
               (local.get $14)
              )
             )
             (br_if $label$2
              (i32.eqz
               (local.tee $2
                (call_indirect (type $i32_i32_i32_=>_i32)
                 (local.get $15)
                 (local.get $1)
                 (local.get $3)
                 (local.get $0)
                )
               )
              )
             )
             (local.set $15
              (local.get $2)
             )
            )
            (br_if $label$243
             (local.tee $18
              (i32.load8_u offset=24
               (local.get $5)
              )
             )
            )
           )
          )
          (block $label$249
           (br_if $label$249
            (i32.eqz
             (local.tee $19
              (i32.load offset=12
               (local.get $5)
              )
             )
            )
           )
           (loop $label$250
            (local.set $3
             (local.tee $21
              (select
               (select
                (local.tee $3
                 (i32.add
                  (i32.sub
                   (local.get $15)
                   (local.get $2)
                  )
                  (i32.const 512)
                 )
                )
                (local.get $19)
                (i32.gt_s
                 (local.get $19)
                 (local.get $3)
                )
               )
               (local.get $19)
               (local.get $0)
              )
             )
            )
            (block $label$251
             (br_if $label$251
              (i32.lt_s
               (local.get $21)
               (i32.const 4)
              )
             )
             (loop $label$252
              (i32.store
               (local.get $2)
               (i32.load
                (local.get $16)
               )
              )
              (local.set $16
               (i32.add
                (local.get $16)
                (i32.const 4)
               )
              )
              (local.set $2
               (i32.add
                (local.get $2)
                (i32.const 4)
               )
              )
              (local.set $18
               (i32.gt_u
                (local.get $3)
                (i32.const 7)
               )
              )
              (local.set $3
               (i32.add
                (local.get $3)
                (i32.const -4)
               )
              )
              (br_if $label$252
               (local.get $18)
              )
             )
            )
            (block $label$253
             (br_if $label$253
              (i32.eqz
               (local.get $3)
              )
             )
             (local.set $24
              (i32.add
               (local.get $3)
               (i32.const -1)
              )
             )
             (block $label$254
              (br_if $label$254
               (i32.eqz
                (local.tee $18
                 (i32.and
                  (local.get $3)
                  (i32.const 7)
                 )
                )
               )
              )
              (loop $label$255
               (i32.store8
                (local.get $2)
                (i32.load8_u
                 (local.get $16)
                )
               )
               (local.set $3
                (i32.add
                 (local.get $3)
                 (i32.const -1)
                )
               )
               (local.set $2
                (i32.add
                 (local.get $2)
                 (i32.const 1)
                )
               )
               (local.set $16
                (i32.add
                 (local.get $16)
                 (i32.const 1)
                )
               )
               (br_if $label$255
                (local.tee $18
                 (i32.add
                  (local.get $18)
                  (i32.const -1)
                 )
                )
               )
              )
             )
             (br_if $label$253
              (i32.lt_u
               (local.get $24)
               (i32.const 7)
              )
             )
             (loop $label$256
              (i32.store8
               (local.get $2)
               (i32.load8_u
                (local.get $16)
               )
              )
              (i32.store8
               (i32.add
                (local.get $2)
                (i32.const 1)
               )
               (i32.load8_u
                (i32.add
                 (local.get $16)
                 (i32.const 1)
                )
               )
              )
              (i32.store8
               (i32.add
                (local.get $2)
                (i32.const 2)
               )
               (i32.load8_u
                (i32.add
                 (local.get $16)
                 (i32.const 2)
                )
               )
              )
              (i32.store8
               (i32.add
                (local.get $2)
                (i32.const 3)
               )
               (i32.load8_u
                (i32.add
                 (local.get $16)
                 (i32.const 3)
                )
               )
              )
              (i32.store8
               (i32.add
                (local.get $2)
                (i32.const 4)
               )
               (i32.load8_u
                (i32.add
                 (local.get $16)
                 (i32.const 4)
                )
               )
              )
              (i32.store8
               (i32.add
                (local.get $2)
                (i32.const 5)
               )
               (i32.load8_u
                (i32.add
                 (local.get $16)
                 (i32.const 5)
                )
               )
              )
              (i32.store8
               (i32.add
                (local.get $2)
                (i32.const 6)
               )
               (i32.load8_u
                (i32.add
                 (local.get $16)
                 (i32.const 6)
                )
               )
              )
              (i32.store8
               (i32.add
                (local.get $2)
                (i32.const 7)
               )
               (i32.load8_u
                (i32.add
                 (local.get $16)
                 (i32.const 7)
                )
               )
              )
              (local.set $2
               (i32.add
                (local.get $2)
                (i32.const 8)
               )
              )
              (local.set $16
               (i32.add
                (local.get $16)
                (i32.const 8)
               )
              )
              (br_if $label$256
               (local.tee $3
                (i32.add
                 (local.get $3)
                 (i32.const -8)
                )
               )
              )
             )
            )
            (block $label$257
             (br_if $label$257
              (i32.eqz
               (local.get $0)
              )
             )
             (br_if $label$257
              (i32.lt_s
               (local.tee $3
                (i32.sub
                 (local.get $2)
                 (local.get $15)
                )
               )
               (i32.const 511)
              )
             )
             (local.set $14
              (i32.add
               (local.get $3)
               (local.get $14)
              )
             )
             (br_if $label$2
              (i32.eqz
               (local.tee $2
                (call_indirect (type $i32_i32_i32_=>_i32)
                 (local.get $15)
                 (local.get $1)
                 (local.get $3)
                 (local.get $0)
                )
               )
              )
             )
             (local.set $15
              (local.get $2)
             )
            )
            (br_if $label$250
             (local.tee $19
              (i32.sub
               (local.get $19)
               (local.get $21)
              )
             )
            )
           )
          )
          (block $label$258
           (br_if $label$258
            (i32.eqz
             (local.get $25)
            )
           )
           (loop $label$259
            (block $label$260
             (block $label$261
              (block $label$262
               (br_if $label$262
                (i32.eqz
                 (local.tee $18
                  (select
                   (select
                    (local.tee $16
                     (i32.add
                      (i32.sub
                       (local.get $15)
                       (local.get $2)
                      )
                      (i32.const 512)
                     )
                    )
                    (local.get $25)
                    (i32.gt_s
                     (local.get $25)
                     (local.get $16)
                    )
                   )
                   (local.get $25)
                   (local.get $0)
                  )
                 )
                )
               )
               (br_if $label$261
                (i32.and
                 (local.get $2)
                 (i32.const 3)
                )
               )
              )
              (local.set $3
               (local.get $18)
              )
              (local.set $16
               (local.get $2)
              )
              (br $label$260)
             )
             (i32.store8
              (local.get $2)
              (i32.const 48)
             )
             (local.set $16
              (i32.add
               (local.get $2)
               (i32.const 1)
              )
             )
             (br_if $label$260
              (i32.eqz
               (local.tee $3
                (i32.add
                 (local.get $18)
                 (i32.const -1)
                )
               )
              )
             )
             (br_if $label$260
              (i32.eqz
               (i32.and
                (local.get $16)
                (i32.const 3)
               )
              )
             )
             (i32.store8 offset=1
              (local.get $2)
              (i32.const 48)
             )
             (local.set $16
              (i32.add
               (local.get $2)
               (i32.const 2)
              )
             )
             (br_if $label$260
              (i32.eqz
               (local.tee $3
                (i32.add
                 (local.get $18)
                 (i32.const -2)
                )
               )
              )
             )
             (br_if $label$260
              (i32.eqz
               (i32.and
                (local.get $16)
                (i32.const 3)
               )
              )
             )
             (i32.store8 offset=2
              (local.get $2)
              (i32.const 48)
             )
             (local.set $16
              (i32.add
               (local.get $2)
               (i32.const 3)
              )
             )
             (br_if $label$260
              (i32.eqz
               (local.tee $3
                (i32.add
                 (local.get $18)
                 (i32.const -3)
                )
               )
              )
             )
             (br_if $label$260
              (i32.eqz
               (i32.and
                (local.get $16)
                (i32.const 3)
               )
              )
             )
             (i32.store8 offset=3
              (local.get $2)
              (i32.const 48)
             )
             (local.set $3
              (i32.add
               (local.get $18)
               (i32.const -4)
              )
             )
             (local.set $16
              (i32.add
               (local.get $2)
               (i32.const 4)
              )
             )
            )
            (block $label$263
             (br_if $label$263
              (i32.lt_s
               (local.get $3)
               (i32.const 4)
              )
             )
             (loop $label$264
              (i32.store
               (local.get $16)
               (i32.const 808464432)
              )
              (local.set $16
               (i32.add
                (local.get $16)
                (i32.const 4)
               )
              )
              (local.set $2
               (i32.gt_u
                (local.get $3)
                (i32.const 7)
               )
              )
              (local.set $3
               (i32.add
                (local.get $3)
                (i32.const -4)
               )
              )
              (br_if $label$264
               (local.get $2)
              )
             )
            )
            (block $label$265
             (br_if $label$265
              (i32.eqz
               (local.get $3)
              )
             )
             (local.set $19
              (i32.add
               (local.get $3)
               (i32.const -1)
              )
             )
             (block $label$266
              (br_if $label$266
               (i32.eqz
                (local.tee $2
                 (i32.and
                  (local.get $3)
                  (i32.const 7)
                 )
                )
               )
              )
              (loop $label$267
               (i32.store8
                (local.get $16)
                (i32.const 48)
               )
               (local.set $3
                (i32.add
                 (local.get $3)
                 (i32.const -1)
                )
               )
               (local.set $16
                (i32.add
                 (local.get $16)
                 (i32.const 1)
                )
               )
               (br_if $label$267
                (local.tee $2
                 (i32.add
                  (local.get $2)
                  (i32.const -1)
                 )
                )
               )
              )
             )
             (br_if $label$265
              (i32.lt_u
               (local.get $19)
               (i32.const 7)
              )
             )
             (loop $label$268
              (i64.store align=1
               (local.get $16)
               (i64.const 3472328296227680304)
              )
              (local.set $16
               (i32.add
                (local.get $16)
                (i32.const 8)
               )
              )
              (br_if $label$268
               (local.tee $3
                (i32.add
                 (local.get $3)
                 (i32.const -8)
                )
               )
              )
             )
            )
            (block $label$269
             (block $label$270
              (br_if $label$270
               (local.get $0)
              )
              (local.set $2
               (local.get $16)
              )
              (br $label$269)
             )
             (block $label$271
              (br_if $label$271
               (i32.ge_s
                (local.tee $2
                 (i32.sub
                  (local.get $16)
                  (local.get $15)
                 )
                )
                (i32.const 511)
               )
              )
              (local.set $2
               (local.get $16)
              )
              (br $label$269)
             )
             (local.set $14
              (i32.add
               (local.get $2)
               (local.get $14)
              )
             )
             (br_if $label$2
              (i32.eqz
               (local.tee $2
                (call_indirect (type $i32_i32_i32_=>_i32)
                 (local.get $15)
                 (local.get $1)
                 (local.get $2)
                 (local.get $0)
                )
               )
              )
             )
             (local.set $15
              (local.get $2)
             )
            )
            (br_if $label$259
             (local.tee $25
              (i32.sub
               (local.get $25)
               (local.get $18)
              )
             )
            )
           )
          )
          (i32.store offset=4
           (local.get $5)
           (local.get $8)
          )
          (block $label$272
           (loop $label$273
            (br_if $label$272
             (i32.eqz
              (local.tee $3
               (i32.load8_u offset=16
                (local.get $5)
               )
              )
             )
            )
            (i32.store8 offset=16
             (local.get $5)
             (i32.sub
              (local.get $3)
              (local.tee $16
               (select
                (select
                 (local.tee $18
                  (i32.add
                   (i32.sub
                    (local.get $15)
                    (local.get $2)
                   )
                   (i32.const 512)
                  )
                 )
                 (local.tee $16
                  (i32.shr_s
                   (i32.shl
                    (local.get $3)
                    (i32.const 24)
                   )
                   (i32.const 24)
                  )
                 )
                 (i32.lt_s
                  (local.get $18)
                  (local.get $16)
                 )
                )
                (local.get $16)
                (local.get $0)
               )
              )
             )
            )
            (block $label$274
             (br_if $label$274
              (i32.eqz
               (local.get $16)
              )
             )
             (local.set $19
              (i32.add
               (local.get $16)
               (i32.const -1)
              )
             )
             (block $label$275
              (br_if $label$275
               (i32.eqz
                (local.tee $3
                 (i32.and
                  (local.get $16)
                  (i32.const 3)
                 )
                )
               )
              )
              (loop $label$276
               (i32.store offset=4
                (local.get $5)
                (i32.add
                 (local.tee $18
                  (i32.load offset=4
                   (local.get $5)
                  )
                 )
                 (i32.const 1)
                )
               )
               (i32.store8
                (local.get $2)
                (i32.load8_u
                 (local.get $18)
                )
               )
               (local.set $16
                (i32.add
                 (local.get $16)
                 (i32.const -1)
                )
               )
               (local.set $2
                (i32.add
                 (local.get $2)
                 (i32.const 1)
                )
               )
               (br_if $label$276
                (local.tee $3
                 (i32.add
                  (local.get $3)
                  (i32.const -1)
                 )
                )
               )
              )
             )
             (br_if $label$274
              (i32.lt_u
               (local.get $19)
               (i32.const 3)
              )
             )
             (loop $label$277
              (i32.store offset=4
               (local.get $5)
               (i32.add
                (local.tee $3
                 (i32.load offset=4
                  (local.get $5)
                 )
                )
                (i32.const 1)
               )
              )
              (i32.store8
               (local.get $2)
               (i32.load8_u
                (local.get $3)
               )
              )
              (i32.store offset=4
               (local.get $5)
               (i32.add
                (local.tee $3
                 (i32.load offset=4
                  (local.get $5)
                 )
                )
                (i32.const 1)
               )
              )
              (i32.store8
               (i32.add
                (local.get $2)
                (i32.const 1)
               )
               (i32.load8_u
                (local.get $3)
               )
              )
              (i32.store offset=4
               (local.get $5)
               (i32.add
                (local.tee $3
                 (i32.load offset=4
                  (local.get $5)
                 )
                )
                (i32.const 1)
               )
              )
              (i32.store8
               (i32.add
                (local.get $2)
                (i32.const 2)
               )
               (i32.load8_u
                (local.get $3)
               )
              )
              (i32.store offset=4
               (local.get $5)
               (i32.add
                (local.tee $3
                 (i32.load offset=4
                  (local.get $5)
                 )
                )
                (i32.const 1)
               )
              )
              (i32.store8
               (i32.add
                (local.get $2)
                (i32.const 3)
               )
               (i32.load8_u
                (local.get $3)
               )
              )
              (local.set $2
               (i32.add
                (local.get $2)
                (i32.const 4)
               )
              )
              (br_if $label$277
               (local.tee $16
                (i32.add
                 (local.get $16)
                 (i32.const -4)
                )
               )
              )
             )
            )
            (br_if $label$273
             (i32.eqz
              (local.get $0)
             )
            )
            (br_if $label$273
             (i32.lt_s
              (local.tee $16
               (i32.sub
                (local.get $2)
                (local.get $15)
               )
              )
              (i32.const 511)
             )
            )
            (local.set $14
             (i32.add
              (local.get $16)
              (local.get $14)
             )
            )
            (br_if $label$2
             (i32.eqz
              (local.tee $2
               (call_indirect (type $i32_i32_i32_=>_i32)
                (local.get $15)
                (local.get $1)
                (local.get $16)
                (local.get $0)
               )
              )
             )
            )
            (local.set $15
             (local.get $2)
            )
            (br $label$273)
           )
          )
          (br_if $label$40
           (i32.eqz
            (i32.and
             (local.get $17)
             (i32.const 1)
            )
           )
          )
          (br_if $label$40
           (i32.lt_s
            (local.get $20)
            (i32.const 1)
           )
          )
          (br_if $label$40
           (i32.eqz
            (local.get $20)
           )
          )
          (loop $label$278
           (block $label$279
            (block $label$280
             (block $label$281
              (br_if $label$281
               (i32.eqz
                (local.tee $18
                 (select
                  (select
                   (local.tee $16
                    (i32.add
                     (i32.sub
                      (local.get $15)
                      (local.get $2)
                     )
                     (i32.const 512)
                    )
                   )
                   (local.get $20)
                   (i32.gt_s
                    (local.get $20)
                    (local.get $16)
                   )
                  )
                  (local.get $20)
                  (local.get $0)
                 )
                )
               )
              )
              (br_if $label$280
               (i32.and
                (local.get $2)
                (i32.const 3)
               )
              )
             )
             (local.set $16
              (local.get $2)
             )
             (local.set $3
              (local.get $18)
             )
             (br $label$279)
            )
            (i32.store8
             (local.get $2)
             (i32.const 32)
            )
            (local.set $16
             (i32.add
              (local.get $2)
              (i32.const 1)
             )
            )
            (br_if $label$279
             (i32.eqz
              (local.tee $3
               (i32.add
                (local.get $18)
                (i32.const -1)
               )
              )
             )
            )
            (br_if $label$279
             (i32.eqz
              (i32.and
               (local.get $16)
               (i32.const 3)
              )
             )
            )
            (i32.store8 offset=1
             (local.get $2)
             (i32.const 32)
            )
            (local.set $16
             (i32.add
              (local.get $2)
              (i32.const 2)
             )
            )
            (br_if $label$279
             (i32.eqz
              (local.tee $3
               (i32.add
                (local.get $18)
                (i32.const -2)
               )
              )
             )
            )
            (br_if $label$279
             (i32.eqz
              (i32.and
               (local.get $16)
               (i32.const 3)
              )
             )
            )
            (i32.store8 offset=2
             (local.get $2)
             (i32.const 32)
            )
            (local.set $16
             (i32.add
              (local.get $2)
              (i32.const 3)
             )
            )
            (br_if $label$279
             (i32.eqz
              (local.tee $3
               (i32.add
                (local.get $18)
                (i32.const -3)
               )
              )
             )
            )
            (br_if $label$279
             (i32.eqz
              (i32.and
               (local.get $16)
               (i32.const 3)
              )
             )
            )
            (i32.store8 offset=3
             (local.get $2)
             (i32.const 32)
            )
            (local.set $3
             (i32.add
              (local.get $18)
              (i32.const -4)
             )
            )
            (local.set $16
             (i32.add
              (local.get $2)
              (i32.const 4)
             )
            )
           )
           (block $label$282
            (br_if $label$282
             (i32.lt_s
              (local.get $3)
              (i32.const 4)
             )
            )
            (loop $label$283
             (i32.store
              (local.get $16)
              (i32.const 538976288)
             )
             (local.set $16
              (i32.add
               (local.get $16)
               (i32.const 4)
              )
             )
             (local.set $2
              (i32.gt_u
               (local.get $3)
               (i32.const 7)
              )
             )
             (local.set $3
              (i32.add
               (local.get $3)
               (i32.const -4)
              )
             )
             (br_if $label$283
              (local.get $2)
             )
            )
           )
           (block $label$284
            (br_if $label$284
             (i32.eqz
              (local.get $3)
             )
            )
            (local.set $17
             (i32.add
              (local.get $3)
              (i32.const -1)
             )
            )
            (block $label$285
             (br_if $label$285
              (i32.eqz
               (local.tee $2
                (i32.and
                 (local.get $3)
                 (i32.const 7)
                )
               )
              )
             )
             (loop $label$286
              (i32.store8
               (local.get $16)
               (i32.const 32)
              )
              (local.set $16
               (i32.add
                (local.get $16)
                (i32.const 1)
               )
              )
              (local.set $3
               (i32.add
                (local.get $3)
                (i32.const -1)
               )
              )
              (br_if $label$286
               (local.tee $2
                (i32.add
                 (local.get $2)
                 (i32.const -1)
                )
               )
              )
             )
            )
            (br_if $label$284
             (i32.lt_u
              (local.get $17)
              (i32.const 7)
             )
            )
            (loop $label$287
             (i64.store align=1
              (local.get $16)
              (i64.const 2314885530818453536)
             )
             (local.set $16
              (i32.add
               (local.get $16)
               (i32.const 8)
              )
             )
             (br_if $label$287
              (local.tee $3
               (i32.add
                (local.get $3)
                (i32.const -8)
               )
              )
             )
            )
           )
           (block $label$288
            (block $label$289
             (br_if $label$289
              (local.get $0)
             )
             (local.set $2
              (local.get $16)
             )
             (br $label$288)
            )
            (block $label$290
             (br_if $label$290
              (i32.ge_s
               (local.tee $2
                (i32.sub
                 (local.get $16)
                 (local.get $15)
                )
               )
               (i32.const 511)
              )
             )
             (local.set $2
              (local.get $16)
             )
             (br $label$288)
            )
            (local.set $14
             (i32.add
              (local.get $2)
              (local.get $14)
             )
            )
            (br_if $label$2
             (i32.eqz
              (local.tee $2
               (call_indirect (type $i32_i32_i32_=>_i32)
                (local.get $15)
                (local.get $1)
                (local.get $2)
                (local.get $0)
               )
              )
             )
            )
            (local.set $15
             (local.get $2)
            )
           )
           (br_if $label$278
            (local.tee $20
             (i32.sub
              (local.get $20)
              (local.get $18)
             )
            )
           )
          )
         )
         (local.set $3
          (i32.add
           (local.get $23)
           (i32.const 1)
          )
         )
         (br $label$3)
        )
        (local.set $16
         (i32.add
          (local.get $16)
          (i32.const 1)
         )
        )
        (local.set $17
         (i32.or
          (local.get $17)
          (local.get $3)
         )
        )
        (br $label$12)
       )
      )
      (local.set $3
       (i32.add
        (local.get $3)
        (i32.const -4)
       )
      )
     )
     (block $label$291
      (br_if $label$291
       (i32.eqz
        (i32.and
         (local.get $16)
         (i32.const 255)
        )
       )
      )
      (block $label$292
       (br_if $label$292
        (i32.eqz
         (local.get $0)
        )
       )
       (br_if $label$292
        (i32.lt_s
         (local.tee $18
          (i32.sub
           (local.get $2)
           (local.get $15)
          )
         )
         (i32.const 511)
        )
       )
       (local.set $14
        (i32.add
         (local.get $18)
         (local.get $14)
        )
       )
       (br_if $label$2
        (i32.eqz
         (local.tee $2
          (call_indirect (type $i32_i32_i32_=>_i32)
           (local.get $15)
           (local.get $1)
           (local.get $18)
           (local.get $0)
          )
         )
        )
       )
       (local.set $16
        (i32.load8_u
         (local.get $3)
        )
       )
       (local.set $15
        (local.get $2)
       )
      )
      (i32.store8
       (local.get $2)
       (local.get $16)
      )
      (local.set $3
       (i32.add
        (local.get $3)
        (i32.const 1)
       )
      )
      (local.set $2
       (i32.add
        (local.get $2)
        (i32.const 1)
       )
      )
      (br $label$3)
     )
    )
    (block $label$293
     (br_if $label$293
      (local.get $0)
     )
     (i32.store8
      (local.get $2)
      (i32.const 0)
     )
     (br $label$1)
    )
    (br_if $label$1
     (i32.lt_s
      (local.tee $16
       (i32.sub
        (local.get $2)
        (local.get $15)
       )
      )
      (i32.const 1)
     )
    )
    (local.set $14
     (i32.add
      (local.get $16)
      (local.get $14)
     )
    )
    (br_if $label$2
     (i32.eqz
      (local.tee $2
       (call_indirect (type $i32_i32_i32_=>_i32)
        (local.get $15)
        (local.get $1)
        (local.get $16)
        (local.get $0)
       )
      )
     )
    )
    (local.set $15
     (local.get $2)
    )
    (br $label$1)
   )
   (local.set $2
    (i32.const 0)
   )
   (local.set $15
    (i32.const 0)
   )
  )
  (global.set $__stack_pointer
   (i32.add
    (local.get $5)
    (i32.const 544)
   )
  )
  (i32.sub
   (i32.add
    (local.get $14)
    (local.get $2)
   )
   (local.get $15)
  )
 )
 (func $stbsp__real_to_str (param $0 i32) (param $1 i32) (param $2 i32) (param $3 i32) (param $4 f64) (param $5 i32) (result i32)
  (local $6 i64)
  (local $7 i64)
  (local $8 i64)
  (local $9 i64)
  (local $10 i64)
  (local $11 i64)
  (local $12 i64)
  (local $13 i32)
  (local $14 i32)
  (local $15 i32)
  (local $16 i32)
  (local $17 i32)
  (local $18 i32)
  (local $19 i32)
  (local $20 i32)
  (local $21 f64)
  (local $22 f64)
  (local $23 f64)
  (local $24 f64)
  (block $label$1
   (block $label$2
    (block $label$3
     (block $label$4
      (block $label$5
       (block $label$6
        (block $label$7
         (br_if $label$7
          (i32.eqz
           (local.tee $13
            (i32.and
             (i32.wrap_i64
              (i64.shr_u
               (local.tee $6
                (i64.reinterpret_f64
                 (local.get $4)
                )
               )
               (i64.const 52)
              )
             )
             (i32.const 2047)
            )
           )
          )
         )
         (br_if $label$6
          (i32.ne
           (local.get $13)
           (i32.const 2047)
          )
         )
         (i32.store
          (local.get $3)
          (i32.const 28672)
         )
         (i32.store
          (local.get $0)
          (select
           (i32.const 2653)
           (i32.const 3827)
           (i64.eqz
            (i64.and
             (local.get $6)
             (i64.const 4503599627370495)
            )
           )
          )
         )
         (local.set $14
          (i32.const 3)
         )
         (br $label$1)
        )
        (br_if $label$2
         (i64.eqz
          (i64.and
           (local.get $6)
           (i64.const 9223372036854775807)
          )
         )
        )
        (local.set $7
         (i64.const 2251799813685248)
        )
        (local.set $15
         (i32.const -1023)
        )
        (br_if $label$5
         (i64.ne
          (i64.and
           (local.get $6)
           (i64.const 2251799813685248)
          )
          (i64.const 0)
         )
        )
        (local.set $13
         (i32.const 0)
        )
        (loop $label$8
         (local.set $13
          (i32.add
           (local.get $13)
           (i32.const -1)
          )
         )
         (br_if $label$8
          (i64.eqz
           (i64.and
            (local.tee $7
             (i64.shr_u
              (local.get $7)
              (i64.const 1)
             )
            )
            (local.get $6)
           )
          )
         )
        )
       )
       (local.set $15
        (i32.add
         (local.get $13)
         (i32.const -1023)
        )
       )
       (br_if $label$4
        (i32.gt_s
         (local.get $13)
         (i32.const 1022)
        )
       )
      )
      (local.set $13
       (i32.div_s
        (i32.mul
         (local.get $15)
         (i32.const 617)
        )
        (i32.const 2048)
       )
      )
      (br $label$3)
     )
     (local.set $13
      (i32.add
       (i32.div_s
        (i32.mul
         (local.get $15)
         (i32.const 1233)
        )
        (i32.const 4096)
       )
       (i32.const 1)
      )
     )
    )
    (local.set $4
     (select
      (f64.neg
       (local.get $4)
      )
      (local.get $4)
      (i64.lt_s
       (local.get $6)
       (i64.const 0)
      )
     )
    )
    (block $label$9
     (block $label$10
      (br_if $label$10
       (i32.gt_u
        (local.tee $15
         (i32.sub
          (i32.const 18)
          (local.get $13)
         )
        )
        (i32.const 22)
       )
      )
      (local.set $4
       (f64.mul
        (f64.load
         (i32.add
          (i32.shl
           (local.get $15)
           (i32.const 3)
          )
          (i32.const 6448)
         )
        )
        (local.get $4)
       )
      )
      (local.set $21
       (f64.const 0)
      )
      (br $label$9)
     )
     (local.set $15
      (i32.add
       (i32.mul
        (local.tee $16
         (select
          (local.tee $16
           (i32.shr_u
            (i32.mul
             (local.tee $15
              (select
               (i32.sub
                (i32.const 0)
                (local.get $15)
               )
               (local.get $15)
               (i32.gt_s
                (local.get $13)
                (i32.const 18)
               )
              )
             )
             (i32.const 713)
            )
            (i32.const 14)
           )
          )
          (i32.const 13)
          (i32.lt_u
           (local.get $16)
           (i32.const 13)
          )
         )
        )
        (i32.const -23)
       )
       (local.get $15)
      )
     )
     (block $label$11
      (br_if $label$11
       (i32.lt_s
        (local.get $13)
        (i32.const 19)
       )
      )
      (block $label$12
       (block $label$13
        (br_if $label$13
         (local.get $15)
        )
        (local.set $21
         (f64.const 0)
        )
        (br $label$12)
       )
       (local.set $21
        (f64.sub
         (f64.mul
          (f64.add
           (f64.load
            (i32.add
             (local.tee $15
              (i32.shl
               (local.get $15)
               (i32.const 3)
              )
             )
             (i32.const 6808)
            )
           )
           (local.tee $21
            (f64.load
             (i32.add
              (local.get $15)
              (i32.const 6632)
             )
            )
           )
          )
          (local.get $4)
         )
         (local.tee $4
          (f64.mul
           (local.get $21)
           (local.get $4)
          )
         )
        )
       )
      )
      (br_if $label$9
       (i32.eqz
        (local.get $16)
       )
      )
      (local.set $21
       (f64.sub
        (f64.mul
         (f64.add
          (f64.load
           (i32.add
            (local.tee $15
             (i32.shl
              (local.get $16)
              (i32.const 3)
             )
            )
            (i32.const 7096)
           )
          )
          (local.tee $22
           (f64.load
            (i32.add
             (local.get $15)
             (i32.const 6984)
            )
           )
          )
         )
         (local.tee $4
          (f64.add
           (local.get $21)
           (local.get $4)
          )
         )
        )
        (local.tee $4
         (f64.mul
          (local.get $22)
          (local.get $4)
         )
        )
       )
      )
      (br $label$9)
     )
     (local.set $21
      (f64.const 0)
     )
     (block $label$14
      (br_if $label$14
       (i32.eqz
        (local.get $15)
       )
      )
      (local.set $22
       (f64.add
        (f64.sub
         (f64.mul
          (local.get $4)
          (local.tee $23
           (f64.reinterpret_i64
            (i64.and
             (i64.reinterpret_f64
              (local.tee $22
               (f64.load
                (i32.add
                 (i32.shl
                  (local.tee $17
                   (select
                    (local.get $15)
                    (i32.const 22)
                    (i32.lt_s
                     (local.get $15)
                     (i32.const 22)
                    )
                   )
                  )
                  (i32.const 3)
                 )
                 (i32.const 6448)
                )
               )
              )
             )
             (i64.const -134217728)
            )
           )
          )
         )
         (local.tee $24
          (f64.mul
           (local.get $22)
           (local.get $4)
          )
         )
        )
        (f64.mul
         (f64.sub
          (local.get $22)
          (local.get $23)
         )
         (local.get $4)
        )
       )
      )
      (block $label$15
       (br_if $label$15
        (local.tee $15
         (i32.sub
          (local.get $15)
          (local.get $17)
         )
        )
       )
       (local.set $4
        (local.get $24)
       )
       (local.set $21
        (local.get $22)
       )
       (br $label$14)
      )
      (local.set $4
       (f64.mul
        (f64.load
         (i32.add
          (i32.shl
           (local.get $15)
           (i32.const 3)
          )
          (i32.const 6448)
         )
        )
        (f64.add
         (local.get $22)
         (local.get $24)
        )
       )
      )
     )
     (br_if $label$9
      (i32.eqz
       (local.get $16)
      )
     )
     (local.set $21
      (f64.sub
       (f64.mul
        (f64.add
         (f64.load
          (i32.add
           (local.tee $15
            (i32.shl
             (local.get $16)
             (i32.const 3)
            )
           )
           (i32.const 7320)
          )
         )
         (local.tee $22
          (f64.load
           (i32.add
            (local.get $15)
            (i32.const 7208)
           )
          )
         )
        )
        (local.tee $4
         (f64.add
          (local.get $21)
          (local.get $4)
         )
        )
       )
       (local.tee $4
        (f64.mul
         (local.get $22)
         (local.get $4)
        )
       )
      )
     )
    )
    (block $label$16
     (block $label$17
      (br_if $label$17
       (i32.eqz
        (f64.lt
         (f64.abs
          (local.tee $21
           (f64.sub
            (local.tee $4
             (f64.add
              (local.get $21)
              (local.get $4)
             )
            )
            (f64.trunc
             (local.get $4)
            )
           )
          )
         )
         (f64.const 9223372036854775808)
        )
       )
      )
      (local.set $7
       (i64.trunc_f64_s
        (local.get $21)
       )
      )
      (br $label$16)
     )
     (local.set $7
      (i64.const -9223372036854775808)
     )
    )
    (block $label$18
     (block $label$19
      (br_if $label$19
       (i32.eqz
        (f64.lt
         (f64.abs
          (local.get $4)
         )
         (f64.const 9223372036854775808)
        )
       )
      )
      (local.set $8
       (i64.trunc_f64_s
        (local.get $4)
       )
      )
      (br $label$18)
     )
     (local.set $8
      (i64.const -9223372036854775808)
     )
    )
    (block $label$20
     (br_if $label$20
      (i32.gt_u
       (local.tee $15
        (select
         (i32.add
          (i32.and
           (local.get $5)
           (i32.const 134217727)
          )
          (i32.const 1)
         )
         (i32.add
          (local.tee $18
           (i32.add
            (local.get $13)
            (i64.gt_u
             (local.tee $7
              (i64.add
               (local.get $7)
               (local.get $8)
              )
             )
             (i64.const 999999999999999999)
            )
           )
          )
          (local.get $5)
         )
         (i32.lt_s
          (local.get $5)
          (i32.const 0)
         )
        )
       )
       (i32.const 23)
      )
     )
     (local.set $5
      (i32.sub
       (i32.const 0)
       (local.tee $13
        (select
         (i32.const 10)
         (i32.const 1)
         (i64.gt_u
          (local.get $7)
          (i64.const 999999999)
         )
        )
       )
      )
     )
     (local.set $13
      (i32.add
       (i32.shl
        (local.get $13)
        (i32.const 3)
       )
       (i32.const 6288)
      )
     )
     (block $label$21
      (loop $label$22
       (br_if $label$21
        (i64.lt_u
         (local.get $7)
         (local.tee $8
          (i64.load
           (local.get $13)
          )
         )
        )
       )
       (local.set $13
        (i32.add
         (local.get $13)
         (i32.const 8)
        )
       )
       (br_if $label$22
        (i32.ne
         (local.tee $5
          (i32.add
           (local.get $5)
           (i32.const -1)
          )
         )
         (i32.const -20)
        )
       )
       (br $label$20)
      )
     )
     (br_if $label$20
      (i32.le_u
       (i32.sub
        (i32.const 0)
        (local.get $5)
       )
       (local.get $15)
      )
     )
     (br_if $label$20
      (i32.gt_u
       (i32.sub
        (i32.const 0)
        (i32.add
         (local.get $15)
         (local.get $5)
        )
       )
       (i32.const 23)
      )
     )
     (local.set $7
      (i64.div_u
       (local.tee $10
        (i64.add
         (i64.shr_u
          (local.tee $9
           (i64.load
            (i32.sub
             (local.get $13)
             (i32.shl
              (local.get $15)
              (i32.const 3)
             )
            )
           )
          )
          (i64.const 1)
         )
         (local.get $7)
        )
       )
       (local.get $9)
      )
     )
     (local.set $18
      (i32.add
       (local.get $18)
       (i64.ge_u
        (local.get $10)
        (local.get $8)
       )
      )
     )
    )
    (local.set $9
     (i64.const 0)
    )
    (local.set $10
     (i64.const 0)
    )
    (local.set $11
     (i64.const 0)
    )
    (local.set $12
     (i64.const 0)
    )
    (local.set $8
     (i64.const 0)
    )
    (block $label$23
     (br_if $label$23
      (i64.eqz
       (local.get $7)
      )
     )
     (block $label$24
      (block $label$25
       (block $label$26
        (br_if $label$26
         (i64.ge_s
          (local.get $7)
          (i64.const 4294967296)
         )
        )
        (local.set $8
         (local.get $7)
        )
        (br $label$25)
       )
       (loop $label$27
        (br_if $label$24
         (i64.ne
          (i64.sub
           (local.get $7)
           (i64.mul
            (local.tee $8
             (i64.div_u
              (local.get $7)
              (i64.const 1000)
             )
            )
            (i64.const 1000)
           )
          )
          (i64.const 0)
         )
        )
        (local.set $13
         (i64.gt_u
          (local.get $7)
          (i64.const 4294967295999)
         )
        )
        (local.set $7
         (local.get $8)
        )
        (br_if $label$27
         (local.get $13)
        )
       )
      )
      (block $label$28
       (br_if $label$28
        (i32.rem_u
         (local.tee $13
          (i32.wrap_i64
           (local.get $8)
          )
         )
         (i32.const 1000)
        )
       )
       (loop $label$29
        (br_if $label$29
         (i32.eqz
          (i32.rem_u
           (local.tee $13
            (i32.div_u
             (local.get $13)
             (i32.const 1000)
            )
           )
           (i32.const 1000)
          )
         )
        )
       )
      )
      (local.set $8
       (i64.extend_i32_u
        (local.get $13)
       )
      )
      (local.set $9
       (i64.const 0)
      )
      (local.set $10
       (i64.const 0)
      )
      (local.set $11
       (i64.const 0)
      )
      (local.set $12
       (i64.const 0)
      )
      (br $label$23)
     )
     (local.set $12
      (i64.and
       (local.get $7)
       (i64.const 1095216660480)
      )
     )
     (local.set $11
      (i64.and
       (local.get $7)
       (i64.const 280375465082880)
      )
     )
     (local.set $10
      (i64.and
       (local.get $7)
       (i64.const 71776119061217280)
      )
     )
     (local.set $9
      (i64.and
       (local.get $7)
       (i64.const -72057594037927936)
      )
     )
     (local.set $8
      (local.get $7)
     )
    )
    (local.set $7
     (i64.or
      (i64.or
       (i64.or
        (i64.or
         (i64.or
          (i64.or
           (i64.or
            (local.get $9)
            (local.get $10)
           )
           (local.get $11)
          )
          (local.get $12)
         )
         (i64.and
          (local.get $8)
          (i64.const 4278190080)
         )
        )
        (i64.and
         (local.get $8)
         (i64.const 16711680)
        )
       )
       (i64.and
        (local.get $8)
        (i64.const 65280)
       )
      )
      (i64.and
       (local.get $8)
       (i64.const 255)
      )
     )
    )
    (local.set $19
     (i32.add
      (local.get $2)
      (i32.const 56)
     )
    )
    (local.set $17
     (i32.add
      (local.get $2)
      (i32.const 63)
     )
    )
    (local.set $16
     (i32.add
      (local.get $2)
      (i32.const 62)
     )
    )
    (local.set $20
     (i32.add
      (local.get $2)
      (i32.const 64)
     )
    )
    (local.set $14
     (i32.const 0)
    )
    (block $label$30
     (block $label$31
      (loop $label$32
       (block $label$33
        (block $label$34
         (block $label$35
          (block $label$36
           (block $label$37
            (block $label$38
             (br_if $label$38
              (i64.lt_s
               (local.get $7)
               (i64.const 100000000)
              )
             )
             (block $label$39
              (br_if $label$39
               (i32.eqz
                (local.tee $13
                 (i32.wrap_i64
                  (i64.sub
                   (local.get $7)
                   (i64.mul
                    (local.tee $8
                     (i64.div_u
                      (local.get $7)
                      (i64.const 100000000)
                     )
                    )
                    (i64.const 100000000)
                   )
                  )
                 )
                )
               )
              )
              (local.set $7
               (local.get $8)
              )
              (br $label$37)
             )
             (local.set $5
              (i32.const 0)
             )
             (local.set $7
              (local.get $8)
             )
             (br $label$34)
            )
            (local.set $13
             (i32.wrap_i64
              (local.get $7)
             )
            )
            (local.set $7
             (i64.const 0)
            )
            (br_if $label$37
             (local.get $13)
            )
            (local.set $5
             (i32.const 0)
            )
            (br $label$36)
           )
           (local.set $5
            (i32.const 0)
           )
           (loop $label$40
            (i32.store16
             (i32.add
              (local.get $16)
              (local.get $5)
             )
             (i32.load16_u
              (i32.add
               (i32.shl
                (i32.sub
                 (local.get $13)
                 (i32.mul
                  (local.tee $2
                   (i32.div_u
                    (local.get $13)
                    (i32.const 100)
                   )
                  )
                  (i32.const 100)
                 )
                )
                (i32.const 1)
               )
               (i32.const 6068)
              )
             )
            )
            (local.set $5
             (i32.add
              (local.get $5)
              (i32.const -2)
             )
            )
            (local.set $15
             (i32.gt_u
              (local.get $13)
              (i32.const 99)
             )
            )
            (local.set $13
             (local.get $2)
            )
            (br_if $label$40
             (local.get $15)
            )
           )
           (br_if $label$35
            (i64.ne
             (local.get $7)
             (i64.const 0)
            )
           )
           (local.set $14
            (i32.sub
             (local.get $14)
             (local.get $5)
            )
           )
          )
          (local.set $13
           (i32.add
            (local.get $20)
            (local.get $5)
           )
          )
          (br_if $label$31
           (local.get $14)
          )
          (local.set $14
           (i32.const 0)
          )
          (br $label$30)
         )
         (local.set $14
          (i32.sub
           (local.get $14)
           (local.get $5)
          )
         )
         (br_if $label$33
          (i32.eq
           (local.get $5)
           (i32.const -8)
          )
         )
        )
        (local.set $13
         (local.get $5)
        )
        (block $label$41
         (br_if $label$41
          (i32.eqz
           (local.tee $2
            (i32.and
             (local.get $5)
             (i32.const 7)
            )
           )
          )
         )
         (local.set $13
          (local.get $5)
         )
         (loop $label$42
          (i32.store8
           (i32.add
            (local.get $17)
            (local.get $13)
           )
           (i32.const 48)
          )
          (local.set $13
           (i32.add
            (local.get $13)
            (i32.const -1)
           )
          )
          (br_if $label$42
           (local.tee $2
            (i32.add
             (local.get $2)
             (i32.const -1)
            )
           )
          )
         )
        )
        (local.set $2
         (i32.add
          (local.get $14)
          (i32.const 8)
         )
        )
        (block $label$43
         (br_if $label$43
          (i32.gt_u
           (local.get $5)
           (i32.const -8)
          )
         )
         (loop $label$44
          (i64.store align=1
           (i32.add
            (local.get $19)
            (local.get $13)
           )
           (i64.const 3472328296227680304)
          )
          (br_if $label$44
           (i32.ne
            (local.tee $13
             (i32.add
              (local.get $13)
              (i32.const -8)
             )
            )
            (i32.const -8)
           )
          )
         )
        )
        (local.set $14
         (i32.add
          (local.get $2)
          (local.get $5)
         )
        )
       )
       (local.set $19
        (i32.add
         (local.get $19)
         (i32.const -8)
        )
       )
       (local.set $17
        (i32.add
         (local.get $17)
         (i32.const -8)
        )
       )
       (local.set $16
        (i32.add
         (local.get $16)
         (i32.const -8)
        )
       )
       (local.set $20
        (i32.add
         (local.get $20)
         (i32.const -8)
        )
       )
       (br $label$32)
      )
     )
     (br_if $label$30
      (i32.ne
       (i32.load8_u
        (local.get $13)
       )
       (i32.const 48)
      )
     )
     (local.set $14
      (i32.add
       (local.get $14)
       (i32.const -1)
      )
     )
     (local.set $13
      (i32.add
       (local.get $13)
       (i32.const 1)
      )
     )
    )
    (i32.store
     (local.get $0)
     (local.get $13)
    )
    (i32.store
     (local.get $3)
     (local.get $18)
    )
    (br $label$1)
   )
   (i32.store
    (local.get $0)
    (local.get $2)
   )
   (local.set $14
    (i32.const 1)
   )
   (i32.store
    (local.get $3)
    (i32.const 1)
   )
   (i32.store8
    (local.get $2)
    (i32.const 48)
   )
  )
  (i32.store
   (local.get $1)
   (local.get $14)
  )
  (i32.wrap_i64
   (i64.shr_u
    (local.get $6)
    (i64.const 63)
   )
  )
 )
 (func $stbsp_sprintf (param $0 i32) (param $1 i32) (param $2 i32) (result i32)
  (local $3 i32)
  (global.set $__stack_pointer
   (local.tee $3
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 16)
    )
   )
  )
  (i32.store offset=12
   (local.get $3)
   (local.get $2)
  )
  (local.set $2
   (call $stbsp_vsprintfcb
    (i32.const 0)
    (i32.const 0)
    (local.get $0)
    (local.get $1)
    (local.get $2)
   )
  )
  (global.set $__stack_pointer
   (i32.add
    (local.get $3)
    (i32.const 16)
   )
  )
  (local.get $2)
 )
 (func $stbsp_vsnprintf (param $0 i32) (param $1 i32) (param $2 i32) (param $3 i32) (result i32)
  (local $4 i32)
  (local $5 i32)
  (global.set $__stack_pointer
   (local.tee $4
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 528)
    )
   )
  )
  (block $label$1
   (block $label$2
    (br_if $label$2
     (local.get $0)
    )
    (br_if $label$2
     (local.get $1)
    )
    (i32.store offset=8
     (local.get $4)
     (i32.const 0)
    )
    (drop
     (call $stbsp_vsprintfcb
      (i32.const 1)
      (local.get $4)
      (i32.add
       (local.get $4)
       (i32.const 12)
      )
      (local.get $2)
      (local.get $3)
     )
    )
    (br $label$1)
   )
   (i32.store offset=8
    (local.get $4)
    (i32.const 0)
   )
   (i32.store
    (local.get $4)
    (local.get $0)
   )
   (i32.store offset=4
    (local.get $4)
    (local.get $1)
   )
   (block $label$3
    (block $label$4
     (block $label$5
      (block $label$6
       (br_if $label$6
        (i32.gt_s
         (local.get $1)
         (i32.const -1)
        )
       )
       (i32.store offset=4
        (local.get $4)
        (i32.const 0)
       )
       (i32.store
        (local.get $4)
        (local.get $1)
       )
       (br $label$5)
      )
      (br_if $label$4
       (local.get $1)
      )
     )
     (local.set $5
      (i32.add
       (local.get $4)
       (i32.const 12)
      )
     )
     (br $label$3)
    )
    (local.set $5
     (select
      (local.get $0)
      (i32.add
       (local.get $4)
       (i32.const 12)
      )
      (i32.gt_u
       (local.get $1)
       (i32.const 511)
      )
     )
    )
   )
   (drop
    (call $stbsp_vsprintfcb
     (i32.const 2)
     (local.get $4)
     (local.get $5)
     (local.get $2)
     (local.get $3)
    )
   )
   (i32.store8
    (i32.add
     (local.get $0)
     (select
      (local.tee $2
       (i32.sub
        (i32.load
         (local.get $4)
        )
        (local.get $0)
       )
      )
      (i32.add
       (local.get $1)
       (i32.const -1)
      )
      (i32.lt_s
       (local.get $2)
       (local.get $1)
      )
     )
    )
    (i32.const 0)
   )
  )
  (local.set $1
   (i32.load offset=8
    (local.get $4)
   )
  )
  (global.set $__stack_pointer
   (i32.add
    (local.get $4)
    (i32.const 528)
   )
  )
  (local.get $1)
 )
 (func $stbsp__count_clamp_callback (param $0 i32) (param $1 i32) (param $2 i32) (result i32)
  (i32.store offset=8
   (local.get $1)
   (i32.add
    (i32.load offset=8
     (local.get $1)
    )
    (local.get $2)
   )
  )
  (i32.add
   (local.get $1)
   (i32.const 12)
  )
 )
 (func $stbsp__clamp_callback (param $0 i32) (param $1 i32) (param $2 i32) (result i32)
  (local $3 i32)
  (local $4 i32)
  (i32.store offset=8
   (local.get $1)
   (i32.add
    (i32.load offset=8
     (local.get $1)
    )
    (local.get $2)
   )
  )
  (block $label$1
   (br_if $label$1
    (i32.eqz
     (local.tee $4
      (select
       (local.tee $3
        (i32.load offset=4
         (local.get $1)
        )
       )
       (local.get $2)
       (i32.lt_s
        (local.get $3)
        (local.get $2)
       )
      )
     )
    )
   )
   (block $label$2
    (br_if $label$2
     (i32.eq
      (local.tee $2
       (i32.load
        (local.get $1)
       )
      )
      (local.get $0)
     )
    )
    (local.set $3
     (i32.add
      (local.get $0)
      (local.get $4)
     )
    )
    (loop $label$3
     (i32.store8
      (local.get $2)
      (i32.load8_u
       (local.get $0)
      )
     )
     (local.set $2
      (i32.add
       (local.get $2)
       (i32.const 1)
      )
     )
     (br_if $label$3
      (i32.lt_u
       (local.tee $0
        (i32.add
         (local.get $0)
         (i32.const 1)
        )
       )
       (local.get $3)
      )
     )
    )
    (local.set $3
     (i32.load offset=4
      (local.get $1)
     )
    )
    (local.set $0
     (i32.load
      (local.get $1)
     )
    )
   )
   (i32.store offset=4
    (local.get $1)
    (local.tee $3
     (i32.sub
      (local.get $3)
      (local.get $4)
     )
    )
   )
   (i32.store
    (local.get $1)
    (i32.add
     (local.get $0)
     (local.get $4)
    )
   )
  )
  (block $label$4
   (br_if $label$4
    (i32.gt_s
     (local.get $3)
     (i32.const 0)
    )
   )
   (return
    (i32.add
     (local.get $1)
     (i32.const 12)
    )
   )
  )
  (block $label$5
   (br_if $label$5
    (i32.lt_u
     (local.get $3)
     (i32.const 512)
    )
   )
   (return
    (i32.load
     (local.get $1)
    )
   )
  )
  (i32.add
   (local.get $1)
   (i32.const 12)
  )
 )
 (func $stbsp_snprintf (param $0 i32) (param $1 i32) (param $2 i32) (param $3 i32) (result i32)
  (local $4 i32)
  (local $5 i32)
  (global.set $__stack_pointer
   (local.tee $4
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 544)
    )
   )
  )
  (i32.store offset=12
   (local.get $4)
   (local.get $3)
  )
  (block $label$1
   (block $label$2
    (br_if $label$2
     (local.get $0)
    )
    (br_if $label$2
     (local.get $1)
    )
    (i32.store offset=24
     (local.get $4)
     (i32.const 0)
    )
    (drop
     (call $stbsp_vsprintfcb
      (i32.const 1)
      (i32.add
       (local.get $4)
       (i32.const 16)
      )
      (i32.add
       (local.get $4)
       (i32.const 28)
      )
      (local.get $2)
      (local.get $3)
     )
    )
    (br $label$1)
   )
   (i32.store offset=24
    (local.get $4)
    (i32.const 0)
   )
   (i32.store offset=16
    (local.get $4)
    (local.get $0)
   )
   (i32.store offset=20
    (local.get $4)
    (local.get $1)
   )
   (block $label$3
    (block $label$4
     (block $label$5
      (block $label$6
       (br_if $label$6
        (i32.gt_s
         (local.get $1)
         (i32.const -1)
        )
       )
       (i32.store offset=20
        (local.get $4)
        (i32.const 0)
       )
       (i32.store offset=16
        (local.get $4)
        (local.get $1)
       )
       (br $label$5)
      )
      (br_if $label$4
       (local.get $1)
      )
     )
     (local.set $5
      (i32.add
       (local.get $4)
       (i32.const 28)
      )
     )
     (br $label$3)
    )
    (local.set $5
     (select
      (local.get $0)
      (i32.add
       (local.get $4)
       (i32.const 28)
      )
      (i32.gt_u
       (local.get $1)
       (i32.const 511)
      )
     )
    )
   )
   (drop
    (call $stbsp_vsprintfcb
     (i32.const 2)
     (i32.add
      (local.get $4)
      (i32.const 16)
     )
     (local.get $5)
     (local.get $2)
     (local.get $3)
    )
   )
   (i32.store8
    (i32.add
     (local.get $0)
     (select
      (local.tee $3
       (i32.sub
        (i32.load offset=16
         (local.get $4)
        )
        (local.get $0)
       )
      )
      (i32.add
       (local.get $1)
       (i32.const -1)
      )
      (i32.lt_s
       (local.get $3)
       (local.get $1)
      )
     )
    )
    (i32.const 0)
   )
  )
  (local.set $1
   (i32.load offset=24
    (local.get $4)
   )
  )
  (global.set $__stack_pointer
   (i32.add
    (local.get $4)
    (i32.const 544)
   )
  )
  (local.get $1)
 )
 (func $stbsp_vsprintf (param $0 i32) (param $1 i32) (param $2 i32) (result i32)
  (call $stbsp_vsprintfcb
   (i32.const 0)
   (i32.const 0)
   (local.get $0)
   (local.get $1)
   (local.get $2)
  )
 )
 (func $eval_negate (param $0 i32) (result i32)
  (local $1 i32)
  (local.set $0
   (i32.load
    (local.get $0)
   )
  )
  (i32.store
   (local.tee $1
    (call $GC_allocate
     (i32.const 1)
     (i32.const 4)
    )
   )
   (i32.load
    (local.get $0)
   )
  )
  (f64.store offset=8
   (local.get $1)
   (f64.neg
    (f64.load offset=8
     (local.get $0)
    )
   )
  )
  (local.get $1)
 )
 (func $GC_allocate (param $0 i32) (param $1 i32) (result i32)
  (local $2 i32)
  (local $3 i32)
  (local $4 i32)
  (local $5 i32)
  (local $6 i32)
  (global.set $__stack_pointer
   (local.tee $2
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 48)
    )
   )
  )
  (local.set $3
   (i32.load offset=8772
    (i32.const 0)
   )
  )
  (i32.store offset=44
   (local.get $2)
   (local.tee $4
    (i32.load offset=8776
     (i32.const 0)
    )
   )
  )
  (block $label$1
   (br_if $label$1
    (i32.lt_u
     (local.tee $5
      (i32.add
       (local.get $3)
       (i32.shl
        (local.get $1)
        (i32.const 2)
       )
      )
     )
     (local.get $4)
    )
   )
   (block $label$2
    (br_if $label$2
     (local.tee $3
      (call $bitmap_find_space
       (i32.const 8744)
       (local.get $4)
       (local.get $1)
       (i32.add
        (local.get $2)
        (i32.const 44)
       )
      )
     )
    )
    (call $mark
     (i32.const 8744)
     (i32.load offset=8780
      (i32.const 0)
     )
    )
    (call $sweepJsRefs
     (i32.const 0)
    )
    (block $label$3
     (br_if $label$3
      (i32.gt_u
       (local.tee $4
        (i32.load offset=8784
         (i32.const 0)
        )
       )
       (i32.shr_u
        (local.tee $5
         (i32.shr_s
          (i32.sub
           (local.tee $3
            (i32.load offset=8748
             (i32.const 0)
            )
           )
           (local.tee $6
            (i32.load offset=8780
             (i32.const 0)
            )
           )
          )
          (i32.const 2)
         )
        )
        (i32.const 1)
       )
      )
     )
     (br_if $label$3
      (i32.lt_u
       (i32.sub
        (local.get $5)
        (local.get $4)
       )
       (local.get $1)
      )
     )
     (br_if $label$2
      (local.tee $3
       (call $bitmap_find_space
        (i32.const 8744)
        (local.get $6)
        (local.get $1)
        (i32.add
         (local.get $2)
         (i32.const 44)
        )
       )
      )
     )
     (local.set $3
      (i32.load offset=8748
       (i32.const 0)
      )
     )
    )
    (call $grow_heap
     (i32.const 8744)
     (local.get $1)
    )
    (i32.store offset=44
     (local.get $2)
     (i32.load offset=8748
      (i32.const 0)
     )
    )
   )
   (i32.store offset=8776
    (i32.const 0)
    (i32.load offset=44
     (local.get $2)
    )
   )
   (local.set $5
    (i32.add
     (local.get $3)
     (i32.shl
      (local.get $1)
      (i32.const 2)
     )
    )
   )
  )
  (block $label$4
   (br_if $label$4
    (i32.eqz
     (local.get $0)
    )
   )
   (i32.store8
    (i32.add
     (local.tee $1
      (i32.load16_u offset=8794
       (i32.const 0)
      )
     )
     (i32.const 49760)
    )
    (i32.const 65)
   )
   (i32.store16 offset=8794
    (i32.const 0)
    (local.tee $4
     (i32.add
      (local.get $1)
      (i32.const 1)
     )
    )
   )
   (i32.store
    (i32.add
     (i32.shl
      (local.get $1)
      (i32.const 2)
     )
     (i32.const 8800)
    )
    (local.get $3)
   )
   (br_if $label$4
    (i32.lt_u
     (i32.and
      (local.get $4)
      (i32.const 65535)
     )
     (i32.const 10240)
    )
   )
   (i32.store offset=40
    (local.get $2)
    (i32.const 71)
   )
   (i32.store offset=36
    (local.get $2)
    (i32.const 3486)
   )
   (i32.store offset=32
    (local.get $2)
    (i32.const 2837)
   )
   (call $safe_printf
    (i32.const 5284)
    (i32.add
     (local.get $2)
     (i32.const 32)
    )
   )
   (i32.store offset=16
    (local.get $2)
    (i32.const 3858)
   )
   (call $safe_printf
    (i32.const 4957)
    (i32.add
     (local.get $2)
     (i32.const 16)
    )
   )
   (i64.store offset=8
    (local.get $2)
    (i64.and
     (i64.extend_i32_u
      (local.get $4)
     )
     (i64.const 65535)
    )
   )
   (i32.store
    (local.get $2)
    (i32.const 1255)
   )
   (call $safe_printf
    (i32.const 6035)
    (local.get $2)
   )
   (call $abort)
  )
  (i32.store offset=8772
   (i32.const 0)
   (local.get $5)
  )
  (global.set $__stack_pointer
   (i32.add
    (local.get $2)
    (i32.const 48)
   )
  )
  (local.get $3)
 )
 (func $bitmap_find_space (param $0 i32) (param $1 i32) (param $2 i32) (param $3 i32) (result i32)
  (local $4 i32)
  (local $5 i32)
  (local $6 i32)
  (local $7 i32)
  (local $8 i32)
  (local $9 i32)
  (local $10 i32)
  (local $11 i32)
  (local $12 i32)
  (local $13 i32)
  (local $14 i32)
  (local $15 i32)
  (local $16 i32)
  (local $17 i64)
  (local.set $4
   (i32.const 0)
  )
  (block $label$1
   (br_if $label$1
    (i32.le_u
     (local.tee $5
      (i32.load offset=4
       (local.get $0)
      )
     )
     (local.get $1)
    )
   )
   (local.set $7
    (i32.add
     (local.tee $6
      (i32.load offset=8
       (local.get $0)
      )
     )
     (i32.const 8)
    )
   )
   (local.set $8
    (i32.add
     (local.get $6)
     (i32.const -8)
    )
   )
   (local.set $10
    (i32.div_s
     (i32.shr_s
      (i32.sub
       (local.get $1)
       (local.tee $9
        (i32.load
         (local.get $0)
        )
       )
      )
      (i32.const 2)
     )
     (i32.const 64)
    )
   )
   (local.set $11
    (i32.load offset=12
     (local.get $0)
    )
   )
   (local.set $4
    (i32.const 0)
   )
   (block $label$2
    (block $label$3
     (loop $label$4
      (br_if $label$1
       (i32.ge_u
        (local.get $10)
        (local.get $11)
       )
      )
      (local.set $1
       (i32.sub
        (i32.const 0)
        (local.get $10)
       )
      )
      (local.set $0
       (i32.add
        (local.get $7)
        (local.tee $12
         (i32.shl
          (local.get $10)
          (i32.const 3)
         )
        )
       )
      )
      (local.set $12
       (i32.add
        (local.get $8)
        (local.get $12)
       )
      )
      (local.set $14
       (local.tee $13
        (i32.add
         (local.get $9)
         (i32.shl
          (local.get $10)
          (i32.const 8)
         )
        )
       )
      )
      (block $label$5
       (loop $label$6
        (br_if $label$5
         (i64.eqz
          (i64.load
           (local.tee $10
            (i32.add
             (local.get $12)
             (i32.const 8)
            )
           )
          )
         )
        )
        (local.set $0
         (i32.add
          (local.get $0)
          (i32.const 8)
         )
        )
        (local.set $13
         (i32.add
          (local.get $13)
          (i32.const 256)
         )
        )
        (local.set $14
         (i32.add
          (local.get $14)
          (i32.const 256)
         )
        )
        (local.set $12
         (local.get $10)
        )
        (br_if $label$6
         (i32.add
          (local.get $11)
          (local.tee $1
           (i32.add
            (local.get $1)
            (i32.const -1)
           )
          )
         )
        )
        (br $label$1)
       )
      )
      (local.set $15
       (i32.const 0)
      )
      (local.set $10
       (i32.sub
        (i32.const 0)
        (local.get $1)
       )
      )
      (loop $label$7
       (br_if $label$3
        (local.tee $16
         (i32.ge_u
          (local.tee $10
           (i32.add
            (local.get $10)
            (i32.const 1)
           )
          )
          (local.get $11)
         )
        )
       )
       (local.set $15
        (i32.add
         (local.get $15)
         (i32.const 256)
        )
       )
       (local.set $17
        (i64.load
         (local.get $0)
        )
       )
       (local.set $0
        (i32.add
         (local.get $0)
         (i32.const 8)
        )
       )
       (br_if $label$7
        (i64.eqz
         (local.get $17)
        )
       )
      )
      (br_if $label$4
       (i32.lt_u
        (i32.shr_s
         (local.get $15)
         (i32.const 2)
        )
        (local.get $2)
       )
      )
     )
     (local.set $5
      (i32.add
       (local.get $14)
       (local.get $15)
      )
     )
     (br $label$2)
    )
    (local.set $4
     (i32.const 0)
    )
    (br_if $label$1
     (i32.lt_u
      (i32.shr_s
       (i32.sub
        (local.get $5)
        (local.get $13)
       )
       (i32.const 2)
      )
      (local.get $2)
     )
    )
    (local.set $10
     (select
      (local.get $11)
      (local.tee $0
       (i32.sub
        (i32.const 1)
        (local.get $1)
       )
      )
      (i32.gt_u
       (local.get $11)
       (local.get $0)
      )
     )
    )
   )
   (block $label$8
    (block $label$9
     (br_if $label$9
      (local.get $1)
     )
     (local.set $4
      (local.get $14)
     )
     (br $label$8)
    )
    (block $label$10
     (br_if $label$10
      (i64.ne
       (local.tee $17
        (i64.load
         (local.get $12)
        )
       )
       (i64.const -1)
      )
     )
     (local.set $4
      (local.get $14)
     )
     (br $label$8)
    )
    (local.set $4
     (i32.sub
      (local.get $14)
      (i32.shl
       (select
        (i32.or
         (local.tee $0
          (select
           (i32.or
            (local.tee $0
             (i32.shl
              (i64.lt_u
               (local.get $17)
               (i64.const 4294967296)
              )
              (i32.const 5)
             )
            )
            (i32.const 16)
           )
           (local.get $0)
           (i64.eqz
            (i64.and
             (local.get $17)
             (i64.const -281470681808896)
            )
           )
          )
         )
         (i32.const 8)
        )
        (local.get $0)
        (i64.eqz
         (i64.and
          (local.get $17)
          (i64.const -71777214294589696)
         )
        )
       )
       (i32.const 2)
      )
     )
    )
   )
   (block $label$11
    (br_if $label$11
     (local.get $16)
    )
    (br_if $label$11
     (i64.eq
      (local.tee $17
       (i64.load
        (i32.add
         (local.get $6)
         (i32.shl
          (local.get $10)
          (i32.const 3)
         )
        )
       )
      )
      (i64.const -1)
     )
    )
    (local.set $5
     (i32.add
      (local.get $5)
      (i32.shl
       (select
        (i32.or
         (local.tee $0
          (select
           (i32.or
            (local.tee $0
             (i32.shl
              (i32.eqz
               (i32.wrap_i64
                (local.get $17)
               )
              )
              (i32.const 5)
             )
            )
            (i32.const 16)
           )
           (local.get $0)
           (i64.eqz
            (i64.and
             (local.get $17)
             (i64.const 281470681808895)
            )
           )
          )
         )
         (i32.const 8)
        )
        (local.get $0)
        (i64.eqz
         (i64.and
          (local.get $17)
          (i64.const 71777214294589695)
         )
        )
       )
       (i32.const 2)
      )
     )
    )
   )
   (i32.store
    (local.get $3)
    (local.get $5)
   )
  )
  (local.get $4)
 )
 (func $mark (param $0 i32) (param $1 i32)
  (local $2 i32)
  (local $3 i32)
  (local $4 i32)
  (local $5 i32)
  (local $6 i32)
  (local $7 i32)
  (local $8 i32)
  (local $9 i32)
  (local $10 i32)
  (local $11 i32)
  (local.set $2
   (i32.load offset=24
    (local.get $0)
   )
  )
  (local.set $3
   (i32.load offset=20
    (local.get $0)
   )
  )
  (local.set $4
   (i32.load offset=16
    (local.get $0)
   )
  )
  (local.set $5
   (i32.load offset=8
    (local.get $0)
   )
  )
  (block $label$1
   (br_if $label$1
    (i32.eqz
     (local.tee $6
      (i32.load offset=12
       (local.get $0)
      )
     )
    )
   )
   (local.set $7
    (i32.and
     (local.get $6)
     (i32.const 7)
    )
   )
   (local.set $8
    (i32.const 0)
   )
   (block $label$2
    (br_if $label$2
     (i32.lt_u
      (i32.add
       (local.get $6)
       (i32.const -1)
      )
      (i32.const 7)
     )
    )
    (local.set $9
     (i32.add
      (local.get $5)
      (i32.const 32)
     )
    )
    (local.set $10
     (i32.and
      (local.get $6)
      (i32.const -8)
     )
    )
    (local.set $8
     (i32.const 0)
    )
    (loop $label$3
     (i64.store
      (local.get $9)
      (i64.const 0)
     )
     (i64.store
      (i32.add
       (local.get $9)
       (i32.const 24)
      )
      (i64.const 0)
     )
     (i64.store
      (i32.add
       (local.get $9)
       (i32.const 16)
      )
      (i64.const 0)
     )
     (i64.store
      (i32.add
       (local.get $9)
       (i32.const 8)
      )
      (i64.const 0)
     )
     (i64.store
      (i32.add
       (local.get $9)
       (i32.const -8)
      )
      (i64.const 0)
     )
     (i64.store
      (i32.add
       (local.get $9)
       (i32.const -16)
      )
      (i64.const 0)
     )
     (i64.store
      (i32.add
       (local.get $9)
       (i32.const -24)
      )
      (i64.const 0)
     )
     (i64.store
      (i32.add
       (local.get $9)
       (i32.const -32)
      )
      (i64.const 0)
     )
     (local.set $9
      (i32.add
       (local.get $9)
       (i32.const 64)
      )
     )
     (br_if $label$3
      (i32.ne
       (local.get $10)
       (local.tee $8
        (i32.add
         (local.get $8)
         (i32.const 8)
        )
       )
      )
     )
    )
   )
   (br_if $label$1
    (i32.eqz
     (local.get $7)
    )
   )
   (local.set $9
    (i32.add
     (local.get $5)
     (i32.shl
      (local.get $8)
      (i32.const 3)
     )
    )
   )
   (loop $label$4
    (i64.store
     (local.get $9)
     (i64.const 0)
    )
    (local.set $9
     (i32.add
      (local.get $9)
      (i32.const 8)
     )
    )
    (br_if $label$4
     (local.tee $7
      (i32.add
       (local.get $7)
       (i32.const -1)
      )
     )
    )
   )
  )
  (local.set $9
   (i32.const 0)
  )
  (i32.store offset=40
   (local.get $0)
   (i32.const 0)
  )
  (block $label$5
   (br_if $label$5
    (i32.eqz
     (local.tee $8
      (i32.load16_u
       (i32.add
        (local.get $0)
        (i32.const 50)
       )
      )
     )
    )
   )
   (local.set $7
    (i32.const 8800)
   )
   (loop $label$6
    (block $label$7
     (br_if $label$7
      (i32.eq
       (i32.load8_u
        (i32.add
         (local.get $9)
         (i32.const 49760)
        )
       )
       (i32.const 70)
      )
     )
     (call $mark_trace
      (local.get $0)
      (i32.load
       (local.get $7)
      )
      (local.get $1)
     )
     (local.set $8
      (i32.load16_u offset=50
       (local.get $0)
      )
     )
    )
    (local.set $7
     (i32.add
      (local.get $7)
      (i32.const 4)
     )
    )
    (br_if $label$6
     (i32.lt_u
      (local.tee $9
       (i32.add
        (local.get $9)
        (i32.const 1)
       )
      )
      (i32.and
       (local.get $8)
       (i32.const 65535)
      )
     )
    )
   )
  )
  (block $label$8
   (br_if $label$8
    (i32.eq
     (local.tee $9
      (i32.load offset=44
       (local.get $0)
      )
     )
     (i32.const 8512)
    )
   )
   (loop $label$9
    (drop
     (call $mark_words
      (local.get $0)
      (local.get $9)
      (i32.const 3)
     )
    )
    (call $mark_trace
     (local.get $0)
     (i32.load
      (i32.load offset=4
       (local.get $9)
      )
     )
     (local.get $1)
    )
    (br_if $label$9
     (i32.ne
      (local.tee $9
       (i32.load offset=8
        (local.get $9)
       )
      )
      (i32.const 8512)
     )
    )
   )
  )
  (block $label$10
   (br_if $label$10
    (i32.eq
     (local.tee $9
      (i32.load offset=24
       (local.get $0)
      )
     )
     (local.get $2)
    )
   )
   (i32.store offset=24
    (local.get $0)
    (local.tee $7
     (i32.add
      (local.tee $7
       (i32.load
        (local.get $0)
       )
      )
      (i32.and
       (local.tee $9
        (i32.sub
         (local.get $9)
         (local.get $7)
        )
       )
       (i32.const -4)
      )
     )
    )
   )
   (i32.store offset=20
    (local.get $0)
    (local.tee $9
     (i32.div_u
      (i32.add
       (local.get $9)
       (i32.const 267)
      )
      (i32.const 268)
     )
    )
   )
   (i32.store offset=12
    (local.get $0)
    (local.get $9)
   )
   (i32.store offset=16
    (local.get $0)
    (local.tee $7
     (i32.sub
      (local.get $7)
      (i32.shl
       (local.get $9)
       (i32.const 2)
      )
     )
    )
   )
   (i32.store offset=8
    (local.get $0)
    (local.tee $10
     (i32.sub
      (local.get $7)
      (i32.shl
       (local.get $9)
       (i32.const 3)
      )
     )
    )
   )
   (i32.store offset=4
    (local.get $0)
    (local.get $10)
   )
   (local.set $2
    (i32.shl
     (local.get $6)
     (i32.const 2)
    )
   )
   (block $label$11
    (br_if $label$11
     (i32.eqz
      (i32.and
       (local.get $10)
       (i32.const 7)
      )
     )
    )
    (i32.store
     (local.get $10)
     (i32.load
      (local.get $5)
     )
    )
    (local.set $5
     (i32.add
      (local.get $5)
      (i32.const 4)
     )
    )
    (local.set $10
     (i32.add
      (local.get $10)
      (i32.const 4)
     )
    )
    (local.set $2
     (i32.add
      (local.get $2)
      (i32.const -4)
     )
    )
   )
   (local.set $11
    (i32.const 0)
   )
   (block $label$12
    (br_if $label$12
     (i32.lt_u
      (local.get $2)
      (i32.const 8)
     )
    )
    (local.set $1
     (i32.and
      (local.tee $11
       (i32.shr_u
        (local.get $2)
        (i32.const 3)
       )
      )
      (i32.const 3)
     )
    )
    (local.set $8
     (i32.const 0)
    )
    (block $label$13
     (br_if $label$13
      (i32.lt_u
       (i32.add
        (local.get $11)
        (i32.const -1)
       )
       (i32.const 3)
      )
     )
     (local.set $6
      (i32.and
       (local.get $11)
       (i32.const 536870908)
      )
     )
     (local.set $9
      (i32.const 0)
     )
     (local.set $8
      (i32.const 0)
     )
     (loop $label$14
      (i64.store
       (local.tee $0
        (i32.add
         (local.get $10)
         (local.get $9)
        )
       )
       (i64.load
        (local.tee $7
         (i32.add
          (local.get $5)
          (local.get $9)
         )
        )
       )
      )
      (i64.store
       (i32.add
        (local.get $0)
        (i32.const 8)
       )
       (i64.load
        (i32.add
         (local.get $7)
         (i32.const 8)
        )
       )
      )
      (i64.store
       (i32.add
        (local.get $0)
        (i32.const 16)
       )
       (i64.load
        (i32.add
         (local.get $7)
         (i32.const 16)
        )
       )
      )
      (i64.store
       (i32.add
        (local.get $0)
        (i32.const 24)
       )
       (i64.load
        (i32.add
         (local.get $7)
         (i32.const 24)
        )
       )
      )
      (local.set $9
       (i32.add
        (local.get $9)
        (i32.const 32)
       )
      )
      (br_if $label$14
       (i32.ne
        (local.get $6)
        (local.tee $8
         (i32.add
          (local.get $8)
          (i32.const 4)
         )
        )
       )
      )
     )
    )
    (br_if $label$12
     (i32.eqz
      (local.get $1)
     )
    )
    (local.set $9
     (i32.add
      (local.get $5)
      (local.tee $0
       (i32.shl
        (local.get $8)
        (i32.const 3)
       )
      )
     )
    )
    (local.set $0
     (i32.add
      (local.get $10)
      (local.get $0)
     )
    )
    (loop $label$15
     (i64.store
      (local.get $0)
      (i64.load
       (local.get $9)
      )
     )
     (local.set $9
      (i32.add
       (local.get $9)
       (i32.const 8)
      )
     )
     (local.set $0
      (i32.add
       (local.get $0)
       (i32.const 8)
      )
     )
     (br_if $label$15
      (local.tee $1
       (i32.add
        (local.get $1)
        (i32.const -1)
       )
      )
     )
    )
   )
   (block $label$16
    (br_if $label$16
     (i32.eqz
      (i32.and
       (local.get $2)
       (i32.const 7)
      )
     )
    )
    (i32.store
     (i32.add
      (local.get $10)
      (local.tee $9
       (i32.shl
        (local.get $11)
        (i32.const 3)
       )
      )
     )
     (i32.load
      (i32.add
       (local.get $5)
       (local.get $9)
      )
     )
    )
   )
   (br_if $label$10
    (i32.eqz
     (local.get $3)
    )
   )
   (local.set $0
    (i32.and
     (local.get $3)
     (i32.const 7)
    )
   )
   (local.set $7
    (i32.const 0)
   )
   (block $label$17
    (br_if $label$17
     (i32.lt_u
      (i32.add
       (local.get $3)
       (i32.const -1)
      )
      (i32.const 7)
     )
    )
    (local.set $9
     (i32.add
      (local.get $4)
      (i32.const 16)
     )
    )
    (local.set $1
     (i32.and
      (local.get $3)
      (i32.const -8)
     )
    )
    (local.set $7
     (i32.const 0)
    )
    (loop $label$18
     (i64.store align=4
      (local.get $9)
      (i64.const 0)
     )
     (i64.store align=4
      (i32.add
       (local.get $9)
       (i32.const 8)
      )
      (i64.const 0)
     )
     (i64.store align=4
      (i32.add
       (local.get $9)
       (i32.const -8)
      )
      (i64.const 0)
     )
     (i64.store align=4
      (i32.add
       (local.get $9)
       (i32.const -16)
      )
      (i64.const 0)
     )
     (local.set $9
      (i32.add
       (local.get $9)
       (i32.const 32)
      )
     )
     (br_if $label$18
      (i32.ne
       (local.get $1)
       (local.tee $7
        (i32.add
         (local.get $7)
         (i32.const 8)
        )
       )
      )
     )
    )
   )
   (br_if $label$10
    (i32.eqz
     (local.get $0)
    )
   )
   (local.set $9
    (i32.add
     (local.get $4)
     (i32.shl
      (local.get $7)
      (i32.const 2)
     )
    )
   )
   (loop $label$19
    (i32.store
     (local.get $9)
     (i32.const 0)
    )
    (local.set $9
     (i32.add
      (local.get $9)
      (i32.const 4)
     )
    )
    (br_if $label$19
     (local.tee $0
      (i32.add
       (local.get $0)
       (i32.const -1)
      )
     )
    )
   )
  )
 )
 (func $grow_heap (param $0 i32) (param $1 i32)
  (local $2 i32)
  (local $3 i32)
  (local $4 i32)
  (local $5 i32)
  (local $6 i32)
  (local $7 i32)
  (local $8 i32)
  (local $9 i32)
  (local $10 i32)
  (local $11 i32)
  (local.set $2
   (i32.load offset=20
    (local.get $0)
   )
  )
  (local.set $3
   (i32.load offset=16
    (local.get $0)
   )
  )
  (local.set $4
   (i32.load offset=12
    (local.get $0)
   )
  )
  (local.set $5
   (i32.load offset=8
    (local.get $0)
   )
  )
  (block $label$1
   (br_if $label$1
    (i32.eq
     (local.tee $6
      (i32.add
       (local.tee $6
        (i32.load
         (local.get $0)
        )
       )
       (local.tee $1
        (i32.and
         (i32.add
          (i32.shl
           (i32.add
            (select
             (local.tee $7
              (i32.add
               (i32.shr_u
                (local.get $1)
                (i32.const 4)
               )
               (local.get $1)
              )
             )
             (local.tee $1
              (i32.shr_s
               (i32.sub
                (local.tee $8
                 (i32.load offset=24
                  (local.get $0)
                 )
                )
                (local.get $6)
               )
               (i32.const 2)
              )
             )
             (i32.gt_u
              (local.get $7)
              (local.get $1)
             )
            )
            (local.get $1)
           )
           (i32.const 2)
          )
          (i32.const 65536)
         )
         (i32.const -65536)
        )
       )
      )
     )
     (local.get $8)
    )
   )
   (br_if $label$1
    (i32.eqz
     (call $brk
      (local.get $6)
     )
    )
   )
   (call $perror
    (i32.const 2401)
   )
   (call $exit
    (i32.const 1)
   )
  )
  (i32.store offset=24
   (local.get $0)
   (local.tee $6
    (i32.add
     (i32.load
      (local.get $0)
     )
     (local.get $1)
    )
   )
  )
  (i32.store offset=20
   (local.get $0)
   (local.tee $1
    (i32.div_u
     (i32.or
      (local.get $1)
      (i32.const 264)
     )
     (i32.const 268)
    )
   )
  )
  (i32.store offset=12
   (local.get $0)
   (local.get $1)
  )
  (i32.store offset=16
   (local.get $0)
   (local.tee $6
    (i32.sub
     (local.get $6)
     (i32.shl
      (local.get $1)
      (i32.const 2)
     )
    )
   )
  )
  (i32.store offset=8
   (local.get $0)
   (local.tee $8
    (i32.sub
     (local.get $6)
     (i32.shl
      (local.get $1)
      (i32.const 3)
     )
    )
   )
  )
  (i32.store offset=4
   (local.get $0)
   (local.get $8)
  )
  (local.set $9
   (i32.shl
    (local.get $4)
    (i32.const 2)
   )
  )
  (block $label$2
   (br_if $label$2
    (i32.eqz
     (i32.and
      (local.get $8)
      (i32.const 7)
     )
    )
   )
   (i32.store
    (local.get $8)
    (i32.load
     (local.get $5)
    )
   )
   (local.set $8
    (i32.add
     (local.get $8)
     (i32.const 4)
    )
   )
   (local.set $5
    (i32.add
     (local.get $5)
     (i32.const 4)
    )
   )
   (local.set $9
    (i32.add
     (local.get $9)
     (i32.const -4)
    )
   )
  )
  (local.set $10
   (i32.const 0)
  )
  (block $label$3
   (br_if $label$3
    (i32.lt_u
     (local.get $9)
     (i32.const 8)
    )
   )
   (local.set $6
    (i32.and
     (local.tee $10
      (i32.shr_u
       (local.get $9)
       (i32.const 3)
      )
     )
     (i32.const 3)
    )
   )
   (local.set $7
    (i32.const 0)
   )
   (block $label$4
    (br_if $label$4
     (i32.lt_u
      (i32.add
       (local.get $10)
       (i32.const -1)
      )
      (i32.const 3)
     )
    )
    (local.set $11
     (i32.and
      (local.get $10)
      (i32.const 536870908)
     )
    )
    (local.set $0
     (i32.const 0)
    )
    (local.set $7
     (i32.const 0)
    )
    (loop $label$5
     (i64.store
      (local.tee $1
       (i32.add
        (local.get $8)
        (local.get $0)
       )
      )
      (i64.load
       (local.tee $4
        (i32.add
         (local.get $5)
         (local.get $0)
        )
       )
      )
     )
     (i64.store
      (i32.add
       (local.get $1)
       (i32.const 8)
      )
      (i64.load
       (i32.add
        (local.get $4)
        (i32.const 8)
       )
      )
     )
     (i64.store
      (i32.add
       (local.get $1)
       (i32.const 16)
      )
      (i64.load
       (i32.add
        (local.get $4)
        (i32.const 16)
       )
      )
     )
     (i64.store
      (i32.add
       (local.get $1)
       (i32.const 24)
      )
      (i64.load
       (i32.add
        (local.get $4)
        (i32.const 24)
       )
      )
     )
     (local.set $0
      (i32.add
       (local.get $0)
       (i32.const 32)
      )
     )
     (br_if $label$5
      (i32.ne
       (local.get $11)
       (local.tee $7
        (i32.add
         (local.get $7)
         (i32.const 4)
        )
       )
      )
     )
    )
   )
   (br_if $label$3
    (i32.eqz
     (local.get $6)
    )
   )
   (local.set $0
    (i32.add
     (local.get $5)
     (local.tee $1
      (i32.shl
       (local.get $7)
       (i32.const 3)
      )
     )
    )
   )
   (local.set $1
    (i32.add
     (local.get $8)
     (local.get $1)
    )
   )
   (loop $label$6
    (i64.store
     (local.get $1)
     (i64.load
      (local.get $0)
     )
    )
    (local.set $0
     (i32.add
      (local.get $0)
      (i32.const 8)
     )
    )
    (local.set $1
     (i32.add
      (local.get $1)
      (i32.const 8)
     )
    )
    (br_if $label$6
     (local.tee $6
      (i32.add
       (local.get $6)
       (i32.const -1)
      )
     )
    )
   )
  )
  (block $label$7
   (br_if $label$7
    (i32.eqz
     (i32.and
      (local.get $9)
      (i32.const 7)
     )
    )
   )
   (i32.store
    (i32.add
     (local.get $8)
     (local.tee $0
      (i32.shl
       (local.get $10)
       (i32.const 3)
      )
     )
    )
    (i32.load
     (i32.add
      (local.get $5)
      (local.get $0)
     )
    )
   )
  )
  (block $label$8
   (br_if $label$8
    (i32.eqz
     (local.get $2)
    )
   )
   (local.set $1
    (i32.and
     (local.get $2)
     (i32.const 7)
    )
   )
   (local.set $4
    (i32.const 0)
   )
   (block $label$9
    (br_if $label$9
     (i32.lt_u
      (i32.add
       (local.get $2)
       (i32.const -1)
      )
      (i32.const 7)
     )
    )
    (local.set $0
     (i32.add
      (local.get $3)
      (i32.const 16)
     )
    )
    (local.set $6
     (i32.and
      (local.get $2)
      (i32.const -8)
     )
    )
    (local.set $4
     (i32.const 0)
    )
    (loop $label$10
     (i64.store align=4
      (local.get $0)
      (i64.const 0)
     )
     (i64.store align=4
      (i32.add
       (local.get $0)
       (i32.const 8)
      )
      (i64.const 0)
     )
     (i64.store align=4
      (i32.add
       (local.get $0)
       (i32.const -8)
      )
      (i64.const 0)
     )
     (i64.store align=4
      (i32.add
       (local.get $0)
       (i32.const -16)
      )
      (i64.const 0)
     )
     (local.set $0
      (i32.add
       (local.get $0)
       (i32.const 32)
      )
     )
     (br_if $label$10
      (i32.ne
       (local.get $6)
       (local.tee $4
        (i32.add
         (local.get $4)
         (i32.const 8)
        )
       )
      )
     )
    )
   )
   (br_if $label$8
    (i32.eqz
     (local.get $1)
    )
   )
   (local.set $0
    (i32.add
     (local.get $3)
     (i32.shl
      (local.get $4)
      (i32.const 2)
     )
    )
   )
   (loop $label$11
    (i32.store
     (local.get $0)
     (i32.const 0)
    )
    (local.set $0
     (i32.add
      (local.get $0)
      (i32.const 4)
     )
    )
    (br_if $label$11
     (local.tee $1
      (i32.add
       (local.get $1)
       (i32.const -1)
      )
     )
    )
   )
  )
 )
 (func $safe_printf (param $0 i32) (param $1 i32)
  (local $2 i32)
  (global.set $__stack_pointer
   (local.tee $2
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 1600)
    )
   )
  )
  (i32.store offset=44
   (local.get $2)
   (local.get $1)
  )
  (i64.store offset=1076 align=4
   (local.get $2)
   (i64.const 1024)
  )
  (i32.store offset=1072
   (local.get $2)
   (i32.add
    (local.get $2)
    (i32.const 48)
   )
  )
  (drop
   (call $stbsp_vsprintfcb
    (i32.const 2)
    (i32.add
     (local.get $2)
     (i32.const 1072)
    )
    (i32.add
     (local.get $2)
     (i32.const 48)
    )
    (local.get $0)
    (local.get $1)
   )
  )
  (i32.store8
   (i32.add
    (i32.add
     (local.get $2)
     (i32.const 48)
    )
    (select
     (local.tee $1
      (i32.sub
       (i32.load offset=1072
        (local.get $2)
       )
       (i32.add
        (local.get $2)
        (i32.const 48)
       )
      )
     )
     (i32.const 1023)
     (i32.lt_s
      (local.get $1)
      (i32.const 1023)
     )
    )
   )
   (i32.const 0)
  )
  (local.set $1
   (i32.load offset=1080
    (local.get $2)
   )
  )
  (block $label$1
   (br_if $label$1
    (i32.eq
     (local.get $1)
     (local.tee $0
      (call $write
       (i32.const 1)
       (i32.add
        (local.get $2)
        (i32.const 48)
       )
       (local.get $1)
      )
     )
    )
   )
   (i32.store offset=40
    (local.get $2)
    (i32.const 31)
   )
   (i32.store offset=36
    (local.get $2)
    (i32.const 3515)
   )
   (i32.store offset=32
    (local.get $2)
    (i32.const 2640)
   )
   (call $safe_printf
    (i32.const 5317)
    (i32.add
     (local.get $2)
     (i32.const 32)
    )
   )
   (i64.store offset=24
    (local.get $2)
    (i64.extend_i32_s
     (local.get $0)
    )
   )
   (i32.store offset=16
    (local.get $2)
    (i32.const 2219)
   )
   (call $safe_printf
    (i32.const 4798)
    (i32.add
     (local.get $2)
     (i32.const 16)
    )
   )
   (i64.store offset=8
    (local.get $2)
    (i64.extend_i32_s
     (local.get $1)
    )
   )
   (i32.store
    (local.get $2)
    (i32.const 1443)
   )
   (call $safe_printf
    (i32.const 4798)
    (local.get $2)
   )
   (call $abort)
  )
  (global.set $__stack_pointer
   (i32.add
    (local.get $2)
    (i32.const 1600)
   )
  )
 )
 (func $eval_add (param $0 i32) (result i32)
  (local $1 i32)
  (local $2 i32)
  (local.set $1
   (i32.load offset=4
    (local.get $0)
   )
  )
  (local.set $0
   (i32.load
    (local.get $0)
   )
  )
  (i32.store
   (local.tee $2
    (call $GC_allocate
     (i32.const 1)
     (i32.const 4)
    )
   )
   (i32.load
    (local.get $0)
   )
  )
  (f64.store offset=8
   (local.get $2)
   (f64.add
    (f64.load offset=8
     (local.get $1)
    )
    (f64.load offset=8
     (local.get $0)
    )
   )
  )
  (local.get $2)
 )
 (func $eval_sub (param $0 i32) (result i32)
  (local $1 i32)
  (local $2 i32)
  (local.set $1
   (i32.load offset=4
    (local.get $0)
   )
  )
  (local.set $0
   (i32.load
    (local.get $0)
   )
  )
  (i32.store
   (local.tee $2
    (call $GC_allocate
     (i32.const 1)
     (i32.const 4)
    )
   )
   (i32.load
    (local.get $0)
   )
  )
  (f64.store offset=8
   (local.get $2)
   (f64.sub
    (f64.load offset=8
     (local.get $0)
    )
    (f64.load offset=8
     (local.get $1)
    )
   )
  )
  (local.get $2)
 )
 (func $eval_mul (param $0 i32) (result i32)
  (local $1 i32)
  (local $2 i32)
  (local.set $1
   (i32.load offset=4
    (local.get $0)
   )
  )
  (local.set $0
   (i32.load
    (local.get $0)
   )
  )
  (i32.store
   (local.tee $2
    (call $GC_allocate
     (i32.const 1)
     (i32.const 4)
    )
   )
   (i32.load
    (local.get $0)
   )
  )
  (f64.store offset=8
   (local.get $2)
   (f64.mul
    (f64.load offset=8
     (local.get $1)
    )
    (f64.load offset=8
     (local.get $0)
    )
   )
  )
  (local.get $2)
 )
 (func $eval_fdiv (param $0 i32) (result i32)
  (local $1 i32)
  (local $2 i32)
  (local.set $1
   (i32.load offset=4
    (local.get $0)
   )
  )
  (local.set $0
   (i32.load
    (local.get $0)
   )
  )
  (i32.store
   (local.tee $2
    (call $GC_allocate
     (i32.const 1)
     (i32.const 4)
    )
   )
   (i32.load
    (local.get $0)
   )
  )
  (f64.store offset=8
   (local.get $2)
   (f64.div
    (f64.load offset=8
     (local.get $0)
    )
    (f64.load offset=8
     (local.get $1)
    )
   )
  )
  (local.get $2)
 )
 (func $eval_idiv (param $0 i32) (result i32)
  (local $1 f64)
  (local $2 f64)
  (local $3 i64)
  (local $4 i64)
  (local.set $1
   (f64.load offset=8
    (i32.load
     (local.get $0)
    )
   )
  )
  (local.set $2
   (f64.load offset=8
    (i32.load offset=4
     (local.get $0)
    )
   )
  )
  (i32.store
   (local.tee $0
    (call $GC_allocate
     (i32.const 1)
     (i32.const 4)
    )
   )
   (i32.const 4)
  )
  (block $label$1
   (block $label$2
    (br_if $label$2
     (i32.eqz
      (f64.lt
       (f64.abs
        (local.get $2)
       )
       (f64.const 9223372036854775808)
      )
     )
    )
    (local.set $3
     (i64.trunc_f64_s
      (local.get $2)
     )
    )
    (br $label$1)
   )
   (local.set $3
    (i64.const -9223372036854775808)
   )
  )
  (block $label$3
   (block $label$4
    (br_if $label$4
     (i32.eqz
      (f64.lt
       (f64.abs
        (local.get $1)
       )
       (f64.const 9223372036854775808)
      )
     )
    )
    (local.set $4
     (i64.trunc_f64_s
      (local.get $1)
     )
    )
    (br $label$3)
   )
   (local.set $4
    (i64.const -9223372036854775808)
   )
  )
  (f64.store offset=8
   (local.get $0)
   (f64.convert_i32_s
    (i32.wrap_i64
     (i64.div_s
      (local.get $4)
      (local.get $3)
     )
    )
   )
  )
  (local.get $0)
 )
 (func $newElmInt (param $0 i32) (result i32)
  (local $1 i32)
  (f64.store offset=8
   (local.tee $1
    (call $GC_allocate
     (i32.const 1)
     (i32.const 4)
    )
   )
   (f64.convert_i32_s
    (local.get $0)
   )
  )
  (i32.store
   (local.get $1)
   (i32.const 4)
  )
  (local.get $1)
 )
 (func $eval_pow (param $0 i32) (result i32)
  (local $1 i32)
  (local $2 i32)
  (local.set $1
   (i32.load offset=4
    (local.get $0)
   )
  )
  (local.set $0
   (i32.load
    (local.get $0)
   )
  )
  (i32.store
   (local.tee $2
    (call $GC_allocate
     (i32.const 1)
     (i32.const 4)
    )
   )
   (i32.load
    (local.get $0)
   )
  )
  (f64.store offset=8
   (local.get $2)
   (f64.convert_i32_s
    (call $pow
     (f64.load offset=8
      (local.get $0)
     )
     (f64.load offset=8
      (local.get $1)
     )
    )
   )
  )
  (local.get $2)
 )
 (func $eval_toFloat (param $0 i32) (result i32)
  (local $1 f64)
  (local.set $1
   (f64.load offset=8
    (i32.load
     (local.get $0)
    )
   )
  )
  (f64.store offset=8
   (local.tee $0
    (call $GC_allocate
     (i32.const 1)
     (i32.const 4)
    )
   )
   (local.get $1)
  )
  (i32.store
   (local.get $0)
   (i32.const 268435460)
  )
  (local.get $0)
 )
 (func $newElmFloat (param $0 f64) (result i32)
  (local $1 i32)
  (f64.store offset=8
   (local.tee $1
    (call $GC_allocate
     (i32.const 1)
     (i32.const 4)
    )
   )
   (local.get $0)
  )
  (i32.store
   (local.get $1)
   (i32.const 268435460)
  )
  (local.get $1)
 )
 (func $eval_round (param $0 i32) (result i32)
  (local $1 i32)
  (local.set $1
   (call $round
    (f64.load offset=8
     (i32.load
      (local.get $0)
     )
    )
   )
  )
  (f64.store offset=8
   (local.tee $0
    (call $GC_allocate
     (i32.const 1)
     (i32.const 4)
    )
   )
   (f64.convert_i32_s
    (local.get $1)
   )
  )
  (i32.store
   (local.get $0)
   (i32.const 4)
  )
  (local.get $0)
 )
 (func $eval_floor (param $0 i32) (result i32)
  (local $1 i32)
  (local.set $1
   (call $floor
    (f64.load offset=8
     (i32.load
      (local.get $0)
     )
    )
   )
  )
  (f64.store offset=8
   (local.tee $0
    (call $GC_allocate
     (i32.const 1)
     (i32.const 4)
    )
   )
   (f64.convert_i32_s
    (local.get $1)
   )
  )
  (i32.store
   (local.get $0)
   (i32.const 4)
  )
  (local.get $0)
 )
 (func $eval_ceiling (param $0 i32) (result i32)
  (local $1 i32)
  (local.set $1
   (call $ceil
    (f64.load offset=8
     (i32.load
      (local.get $0)
     )
    )
   )
  )
  (f64.store offset=8
   (local.tee $0
    (call $GC_allocate
     (i32.const 1)
     (i32.const 4)
    )
   )
   (f64.convert_i32_s
    (local.get $1)
   )
  )
  (i32.store
   (local.get $0)
   (i32.const 4)
  )
  (local.get $0)
 )
 (func $eval_not (param $0 i32) (result i32)
  (select
   (i32.const 8532)
   (i32.const 8540)
   (i32.eq
    (i32.load
     (local.get $0)
    )
    (i32.const 8540)
   )
  )
 )
 (func $eval_and (param $0 i32) (result i32)
  (local $1 i32)
  (local.set $1
   (i32.const 8540)
  )
  (block $label$1
   (br_if $label$1
    (i32.ne
     (i32.load
      (local.get $0)
     )
     (i32.const 8532)
    )
   )
   (local.set $1
    (select
     (i32.const 8532)
     (i32.const 8540)
     (i32.eq
      (i32.load offset=4
       (local.get $0)
      )
      (i32.const 8532)
     )
    )
   )
  )
  (local.get $1)
 )
 (func $eval_or (param $0 i32) (result i32)
  (local $1 i32)
  (local.set $1
   (i32.const 8532)
  )
  (block $label$1
   (br_if $label$1
    (i32.eq
     (i32.load
      (local.get $0)
     )
     (i32.const 8532)
    )
   )
   (local.set $1
    (select
     (i32.const 8532)
     (i32.const 8540)
     (i32.eq
      (i32.load offset=4
       (local.get $0)
      )
      (i32.const 8532)
     )
    )
   )
  )
  (local.get $1)
 )
 (func $eval_xor (param $0 i32) (result i32)
  (select
   (i32.const 8540)
   (i32.const 8532)
   (i32.eq
    (i32.load
     (local.get $0)
    )
    (i32.load offset=4
     (local.get $0)
    )
   )
  )
 )
 (func $eval_remainderBy (param $0 i32) (result i32)
  (local $1 f64)
  (local $2 f64)
  (local $3 i64)
  (local $4 i64)
  (local.set $1
   (f64.load offset=8
    (i32.load offset=4
     (local.get $0)
    )
   )
  )
  (local.set $2
   (f64.load offset=8
    (i32.load
     (local.get $0)
    )
   )
  )
  (i32.store
   (local.tee $0
    (call $GC_allocate
     (i32.const 1)
     (i32.const 4)
    )
   )
   (i32.const 4)
  )
  (block $label$1
   (block $label$2
    (br_if $label$2
     (i32.eqz
      (f64.lt
       (f64.abs
        (local.get $2)
       )
       (f64.const 9223372036854775808)
      )
     )
    )
    (local.set $3
     (i64.trunc_f64_s
      (local.get $2)
     )
    )
    (br $label$1)
   )
   (local.set $3
    (i64.const -9223372036854775808)
   )
  )
  (block $label$3
   (block $label$4
    (br_if $label$4
     (i32.eqz
      (f64.lt
       (f64.abs
        (local.get $1)
       )
       (f64.const 9223372036854775808)
      )
     )
    )
    (local.set $4
     (i64.trunc_f64_s
      (local.get $1)
     )
    )
    (br $label$3)
   )
   (local.set $4
    (i64.const -9223372036854775808)
   )
  )
  (f64.store offset=8
   (local.get $0)
   (f64.convert_i32_s
    (i32.wrap_i64
     (i64.rem_s
      (local.get $4)
      (local.get $3)
     )
    )
   )
  )
  (local.get $0)
 )
 (func $eval_modBy (param $0 i32) (result i32)
  (local $1 i32)
  (local $2 i32)
  (local $3 f64)
  (global.set $__stack_pointer
   (local.tee $1
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 48)
    )
   )
  )
  (block $label$1
   (block $label$2
    (br_if $label$2
     (i32.eqz
      (f64.lt
       (f64.abs
        (local.tee $3
         (f64.load offset=8
          (i32.load
           (local.get $0)
          )
         )
        )
       )
       (f64.const 2147483648)
      )
     )
    )
    (local.set $2
     (i32.trunc_f64_s
      (local.get $3)
     )
    )
    (br $label$1)
   )
   (local.set $2
    (i32.const -2147483648)
   )
  )
  (block $label$3
   (block $label$4
    (br_if $label$4
     (local.get $2)
    )
    (i32.store offset=40
     (local.get $1)
     (i32.const 283)
    )
    (i32.store offset=36
     (local.get $1)
     (i32.const 3406)
    )
    (i32.store offset=32
     (local.get $1)
     (i32.const 1244)
    )
    (call $safe_printf
     (i32.const 5284)
     (i32.add
      (local.get $1)
      (i32.const 32)
     )
    )
    (i32.store offset=16
     (local.get $1)
     (i32.const 4050)
    )
    (call $safe_printf
     (i32.const 4957)
     (i32.add
      (local.get $1)
      (i32.const 16)
     )
    )
    (i64.store offset=8
     (local.get $1)
     (i64.const 0)
    )
    (i32.store
     (local.get $1)
     (i32.const 1642)
    )
    (call $safe_printf
     (i32.const 6035)
     (local.get $1)
    )
    (call $abort)
    (br $label$3)
   )
   (block $label$5
    (block $label$6
     (br_if $label$6
      (i32.eqz
       (f64.lt
        (f64.abs
         (local.tee $3
          (f64.load offset=8
           (i32.load offset=4
            (local.get $0)
           )
          )
         )
        )
        (f64.const 2147483648)
       )
      )
     )
     (local.set $0
      (i32.trunc_f64_s
       (local.get $3)
      )
     )
     (br $label$5)
    )
    (local.set $0
     (i32.const -2147483648)
    )
   )
   (local.set $0
    (i32.rem_s
     (local.get $0)
     (local.get $2)
    )
   )
   (block $label$7
    (block $label$8
     (br_if $label$8
      (i32.gt_s
       (local.get $2)
       (i32.const -1)
      )
     )
     (br_if $label$7
      (i32.gt_s
       (local.get $0)
       (i32.const 0)
      )
     )
    )
    (br_if $label$3
     (i32.lt_s
      (local.get $2)
      (i32.const 1)
     )
    )
    (br_if $label$3
     (i32.gt_s
      (local.get $0)
      (i32.const -1)
     )
    )
   )
   (local.set $0
    (i32.add
     (local.get $0)
     (local.get $2)
    )
   )
  )
  (f64.store offset=8
   (local.tee $2
    (call $GC_allocate
     (i32.const 1)
     (i32.const 4)
    )
   )
   (f64.convert_i32_s
    (local.get $0)
   )
  )
  (i32.store
   (local.get $2)
   (i32.const 4)
  )
  (global.set $__stack_pointer
   (i32.add
    (local.get $1)
    (i32.const 48)
   )
  )
  (local.get $2)
 )
 (func $Debug_assert (param $0 i32) (param $1 i32) (param $2 i32) (param $3 i32) (param $4 i32) (param $5 i32) (param $6 i64)
  (local $7 i32)
  (global.set $__stack_pointer
   (local.tee $7
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 48)
    )
   )
  )
  (block $label$1
   (br_if $label$1
    (local.get $5)
   )
   (i32.store offset=40
    (local.get $7)
    (local.get $1)
   )
   (i32.store offset=36
    (local.get $7)
    (local.get $0)
   )
   (i32.store offset=32
    (local.get $7)
    (local.get $2)
   )
   (call $safe_printf
    (i32.const 5284)
    (i32.add
     (local.get $7)
     (i32.const 32)
    )
   )
   (i32.store offset=16
    (local.get $7)
    (local.get $3)
   )
   (call $safe_printf
    (i32.const 4957)
    (i32.add
     (local.get $7)
     (i32.const 16)
    )
   )
   (i64.store offset=8
    (local.get $7)
    (local.get $6)
   )
   (i32.store
    (local.get $7)
    (local.get $4)
   )
   (call $safe_printf
    (i32.const 6035)
    (local.get $7)
   )
   (call $abort)
  )
  (global.set $__stack_pointer
   (i32.add
    (local.get $7)
    (i32.const 48)
   )
  )
 )
 (func $eval_log (param $0 i32) (result i32)
  (local $1 i32)
  (local.set $1
   (call $log
    (f64.load offset=8
     (i32.load
      (local.get $0)
     )
    )
   )
  )
  (f64.store offset=8
   (local.tee $0
    (call $GC_allocate
     (i32.const 1)
     (i32.const 4)
    )
   )
   (f64.convert_i32_s
    (local.get $1)
   )
  )
  (i32.store
   (local.get $0)
   (i32.const 268435460)
  )
  (local.get $0)
 )
 (func $eval_identity (param $0 i32) (result i32)
  (i32.load
   (local.get $0)
  )
 )
 (func $eval_Bitwise_and (param $0 i32) (result i32)
  (local $1 f64)
  (local $2 f64)
  (local $3 i32)
  (local $4 i32)
  (local.set $1
   (f64.load offset=8
    (i32.load offset=4
     (local.get $0)
    )
   )
  )
  (local.set $2
   (f64.load offset=8
    (i32.load
     (local.get $0)
    )
   )
  )
  (i32.store
   (local.tee $0
    (call $GC_allocate
     (i32.const 1)
     (i32.const 4)
    )
   )
   (i32.const 4)
  )
  (block $label$1
   (block $label$2
    (br_if $label$2
     (i32.eqz
      (f64.lt
       (f64.abs
        (local.get $2)
       )
       (f64.const 2147483648)
      )
     )
    )
    (local.set $3
     (i32.trunc_f64_s
      (local.get $2)
     )
    )
    (br $label$1)
   )
   (local.set $3
    (i32.const -2147483648)
   )
  )
  (block $label$3
   (block $label$4
    (br_if $label$4
     (i32.eqz
      (f64.lt
       (f64.abs
        (local.get $1)
       )
       (f64.const 2147483648)
      )
     )
    )
    (local.set $4
     (i32.trunc_f64_s
      (local.get $1)
     )
    )
    (br $label$3)
   )
   (local.set $4
    (i32.const -2147483648)
   )
  )
  (f64.store offset=8
   (local.get $0)
   (f64.convert_i32_s
    (i32.and
     (local.get $4)
     (local.get $3)
    )
   )
  )
  (local.get $0)
 )
 (func $eval_Bitwise_or (param $0 i32) (result i32)
  (local $1 f64)
  (local $2 f64)
  (local $3 i32)
  (local $4 i32)
  (local.set $1
   (f64.load offset=8
    (i32.load offset=4
     (local.get $0)
    )
   )
  )
  (local.set $2
   (f64.load offset=8
    (i32.load
     (local.get $0)
    )
   )
  )
  (i32.store
   (local.tee $0
    (call $GC_allocate
     (i32.const 1)
     (i32.const 4)
    )
   )
   (i32.const 4)
  )
  (block $label$1
   (block $label$2
    (br_if $label$2
     (i32.eqz
      (f64.lt
       (f64.abs
        (local.get $2)
       )
       (f64.const 2147483648)
      )
     )
    )
    (local.set $3
     (i32.trunc_f64_s
      (local.get $2)
     )
    )
    (br $label$1)
   )
   (local.set $3
    (i32.const -2147483648)
   )
  )
  (block $label$3
   (block $label$4
    (br_if $label$4
     (i32.eqz
      (f64.lt
       (f64.abs
        (local.get $1)
       )
       (f64.const 2147483648)
      )
     )
    )
    (local.set $4
     (i32.trunc_f64_s
      (local.get $1)
     )
    )
    (br $label$3)
   )
   (local.set $4
    (i32.const -2147483648)
   )
  )
  (f64.store offset=8
   (local.get $0)
   (f64.convert_i32_s
    (i32.or
     (local.get $4)
     (local.get $3)
    )
   )
  )
  (local.get $0)
 )
 (func $eval_Bitwise_xor (param $0 i32) (result i32)
  (local $1 f64)
  (local $2 f64)
  (local $3 i32)
  (local $4 i32)
  (local.set $1
   (f64.load offset=8
    (i32.load offset=4
     (local.get $0)
    )
   )
  )
  (local.set $2
   (f64.load offset=8
    (i32.load
     (local.get $0)
    )
   )
  )
  (i32.store
   (local.tee $0
    (call $GC_allocate
     (i32.const 1)
     (i32.const 4)
    )
   )
   (i32.const 4)
  )
  (block $label$1
   (block $label$2
    (br_if $label$2
     (i32.eqz
      (f64.lt
       (f64.abs
        (local.get $2)
       )
       (f64.const 2147483648)
      )
     )
    )
    (local.set $3
     (i32.trunc_f64_s
      (local.get $2)
     )
    )
    (br $label$1)
   )
   (local.set $3
    (i32.const -2147483648)
   )
  )
  (block $label$3
   (block $label$4
    (br_if $label$4
     (i32.eqz
      (f64.lt
       (f64.abs
        (local.get $1)
       )
       (f64.const 2147483648)
      )
     )
    )
    (local.set $4
     (i32.trunc_f64_s
      (local.get $1)
     )
    )
    (br $label$3)
   )
   (local.set $4
    (i32.const -2147483648)
   )
  )
  (f64.store offset=8
   (local.get $0)
   (f64.convert_i32_s
    (i32.xor
     (local.get $4)
     (local.get $3)
    )
   )
  )
  (local.get $0)
 )
 (func $eval_Bitwise_complement (param $0 i32) (result i32)
  (local $1 f64)
  (local $2 i32)
  (local.set $1
   (f64.load offset=8
    (i32.load
     (local.get $0)
    )
   )
  )
  (i32.store
   (local.tee $0
    (call $GC_allocate
     (i32.const 1)
     (i32.const 4)
    )
   )
   (i32.const 4)
  )
  (block $label$1
   (block $label$2
    (br_if $label$2
     (i32.eqz
      (f64.lt
       (f64.abs
        (local.get $1)
       )
       (f64.const 2147483648)
      )
     )
    )
    (local.set $2
     (i32.trunc_f64_s
      (local.get $1)
     )
    )
    (br $label$1)
   )
   (local.set $2
    (i32.const -2147483648)
   )
  )
  (f64.store offset=8
   (local.get $0)
   (f64.convert_i32_s
    (i32.xor
     (local.get $2)
     (i32.const -1)
    )
   )
  )
  (local.get $0)
 )
 (func $eval_Bitwise_shiftLeftBy (param $0 i32) (result i32)
  (local $1 f64)
  (local $2 f64)
  (local $3 i32)
  (local $4 i32)
  (local.set $1
   (f64.load offset=8
    (i32.load offset=4
     (local.get $0)
    )
   )
  )
  (local.set $2
   (f64.load offset=8
    (i32.load
     (local.get $0)
    )
   )
  )
  (i32.store
   (local.tee $0
    (call $GC_allocate
     (i32.const 1)
     (i32.const 4)
    )
   )
   (i32.const 4)
  )
  (block $label$1
   (block $label$2
    (br_if $label$2
     (i32.eqz
      (f64.lt
       (f64.abs
        (local.get $2)
       )
       (f64.const 2147483648)
      )
     )
    )
    (local.set $3
     (i32.trunc_f64_s
      (local.get $2)
     )
    )
    (br $label$1)
   )
   (local.set $3
    (i32.const -2147483648)
   )
  )
  (block $label$3
   (block $label$4
    (br_if $label$4
     (i32.eqz
      (f64.lt
       (f64.abs
        (local.get $1)
       )
       (f64.const 2147483648)
      )
     )
    )
    (local.set $4
     (i32.trunc_f64_s
      (local.get $1)
     )
    )
    (br $label$3)
   )
   (local.set $4
    (i32.const -2147483648)
   )
  )
  (f64.store offset=8
   (local.get $0)
   (f64.convert_i32_s
    (i32.shl
     (local.get $4)
     (local.get $3)
    )
   )
  )
  (local.get $0)
 )
 (func $eval_Bitwise_shiftRightBy (param $0 i32) (result i32)
  (local $1 f64)
  (local $2 f64)
  (local $3 i32)
  (local $4 i32)
  (local.set $1
   (f64.load offset=8
    (i32.load offset=4
     (local.get $0)
    )
   )
  )
  (local.set $2
   (f64.load offset=8
    (i32.load
     (local.get $0)
    )
   )
  )
  (i32.store
   (local.tee $0
    (call $GC_allocate
     (i32.const 1)
     (i32.const 4)
    )
   )
   (i32.const 4)
  )
  (block $label$1
   (block $label$2
    (br_if $label$2
     (i32.eqz
      (f64.lt
       (f64.abs
        (local.get $2)
       )
       (f64.const 2147483648)
      )
     )
    )
    (local.set $3
     (i32.trunc_f64_s
      (local.get $2)
     )
    )
    (br $label$1)
   )
   (local.set $3
    (i32.const -2147483648)
   )
  )
  (block $label$3
   (block $label$4
    (br_if $label$4
     (i32.eqz
      (f64.lt
       (f64.abs
        (local.get $1)
       )
       (f64.const 2147483648)
      )
     )
    )
    (local.set $4
     (i32.trunc_f64_s
      (local.get $1)
     )
    )
    (br $label$3)
   )
   (local.set $4
    (i32.const -2147483648)
   )
  )
  (f64.store offset=8
   (local.get $0)
   (f64.convert_i32_s
    (i32.shr_s
     (local.get $4)
     (local.get $3)
    )
   )
  )
  (local.get $0)
 )
 (func $eval_Bitwise_shiftRightZfBy (param $0 i32) (result i32)
  (local $1 f64)
  (local $2 f64)
  (local $3 i64)
  (local $4 i32)
  (local.set $1
   (f64.load offset=8
    (i32.load
     (local.get $0)
    )
   )
  )
  (local.set $2
   (f64.load offset=8
    (i32.load offset=4
     (local.get $0)
    )
   )
  )
  (i32.store
   (local.tee $0
    (call $GC_allocate
     (i32.const 1)
     (i32.const 4)
    )
   )
   (i32.const 4)
  )
  (block $label$1
   (block $label$2
    (br_if $label$2
     (i32.eqz
      (f64.lt
       (f64.abs
        (local.get $2)
       )
       (f64.const 9223372036854775808)
      )
     )
    )
    (local.set $3
     (i64.trunc_f64_s
      (local.get $2)
     )
    )
    (br $label$1)
   )
   (local.set $3
    (i64.const -9223372036854775808)
   )
  )
  (local.set $3
   (i64.and
    (local.get $3)
    (i64.const 4294967295)
   )
  )
  (block $label$3
   (block $label$4
    (br_if $label$4
     (i32.eqz
      (f64.lt
       (f64.abs
        (local.get $1)
       )
       (f64.const 2147483648)
      )
     )
    )
    (local.set $4
     (i32.trunc_f64_s
      (local.get $1)
     )
    )
    (br $label$3)
   )
   (local.set $4
    (i32.const -2147483648)
   )
  )
  (f64.store offset=8
   (local.get $0)
   (f64.convert_i32_s
    (i32.wrap_i64
     (i64.shr_u
      (local.get $3)
      (i64.extend_i32_u
       (local.get $4)
      )
     )
    )
   )
  )
  (local.get $0)
 )
 (func $eval_toCode (param $0 i32) (result i32)
  (local $1 i32)
  (local.set $0
   (i32.load16_u offset=4
    (local.tee $1
     (i32.load
      (local.get $0)
     )
    )
   )
  )
  (block $label$1
   (br_if $label$1
    (i32.eqz
     (local.tee $1
      (i32.load16_u
       (i32.add
        (local.get $1)
        (i32.const 6)
       )
      )
     )
    )
   )
   (local.set $0
    (i32.add
     (i32.or
      (i32.add
       (i32.shl
        (local.get $0)
        (i32.const 10)
       )
       (i32.const -56623104)
      )
      (i32.add
       (local.get $1)
       (i32.const -56320)
      )
     )
     (i32.const 65536)
    )
   )
  )
  (f64.store offset=8
   (local.tee $1
    (call $GC_allocate
     (i32.const 1)
     (i32.const 4)
    )
   )
   (f64.convert_i32_s
    (local.get $0)
   )
  )
  (i32.store
   (local.get $1)
   (i32.const 4)
  )
  (local.get $1)
 )
 (func $newDynamicArray (param $0 i32) (result i32)
  (local $1 i32)
  (local $2 i32)
  (local $3 i32)
  (local $4 i32)
  (local.set $1
   (i32.const 0)
  )
  (i32.store offset=4
   (local.tee $3
    (call $GC_allocate
     (i32.const 1)
     (local.tee $2
      (i32.add
       (local.get $0)
       (i32.const 2)
      )
     )
    )
   )
   (i32.const 0)
  )
  (i32.store
   (local.get $3)
   (i32.or
    (i32.and
     (local.get $2)
     (i32.const 268435455)
    )
    (i32.const 1879048192)
   )
  )
  (block $label$1
   (br_if $label$1
    (i32.eqz
     (local.get $0)
    )
   )
   (local.set $4
    (i32.and
     (local.get $0)
     (i32.const 7)
    )
   )
   (block $label$2
    (br_if $label$2
     (i32.lt_u
      (i32.add
       (local.get $0)
       (i32.const -1)
      )
      (i32.const 7)
     )
    )
    (local.set $2
     (i32.add
      (local.get $3)
      (i32.const 20)
     )
    )
    (local.set $0
     (i32.and
      (local.get $0)
      (i32.const -8)
     )
    )
    (local.set $1
     (i32.const 0)
    )
    (loop $label$3
     (i64.store align=4
      (i32.add
       (local.get $2)
       (i32.const 12)
      )
      (i64.const 0)
     )
     (i64.store align=4
      (i32.add
       (local.get $2)
       (i32.const 4)
      )
      (i64.const 0)
     )
     (i64.store align=4
      (i32.add
       (local.get $2)
       (i32.const -4)
      )
      (i64.const 0)
     )
     (i64.store align=4
      (i32.add
       (local.get $2)
       (i32.const -12)
      )
      (i64.const 0)
     )
     (local.set $2
      (i32.add
       (local.get $2)
       (i32.const 32)
      )
     )
     (br_if $label$3
      (i32.ne
       (local.get $0)
       (local.tee $1
        (i32.add
         (local.get $1)
         (i32.const 8)
        )
       )
      )
     )
    )
   )
   (br_if $label$1
    (i32.eqz
     (local.get $4)
    )
   )
   (local.set $2
    (i32.add
     (i32.add
      (i32.shl
       (local.get $1)
       (i32.const 2)
      )
      (local.get $3)
     )
     (i32.const 8)
    )
   )
   (loop $label$4
    (i32.store
     (local.get $2)
     (i32.const 0)
    )
    (local.set $2
     (i32.add
      (local.get $2)
      (i32.const 4)
     )
    )
    (br_if $label$4
     (local.tee $4
      (i32.add
       (local.get $4)
       (i32.const -1)
      )
     )
    )
   )
  )
  (local.get $3)
 )
 (func $DynamicArray_push (param $0 i32) (param $1 i32)
  (local $2 i32)
  (local $3 i32)
  (local $4 i32)
  (local $5 i32)
  (local $6 i32)
  (local $7 i32)
  (local $8 i32)
  (local $9 i32)
  (local $10 i32)
  (local $11 i32)
  (local $12 i32)
  (block $label$1
   (block $label$2
    (br_if $label$2
     (i32.ge_u
      (i32.load offset=4
       (local.tee $2
        (i32.load
         (local.get $0)
        )
       )
      )
      (local.tee $4
       (i32.add
        (local.tee $3
         (i32.and
          (i32.load
           (local.get $2)
          )
          (i32.const 268435455)
         )
        )
        (i32.const -2)
       )
      )
     )
    )
    (local.set $5
     (local.get $2)
    )
    (br $label$1)
   )
   (local.set $6
    (i32.const 0)
   )
   (i32.store offset=4
    (local.tee $5
     (call $GC_allocate
      (i32.const 1)
      (local.tee $9
       (i32.add
        (local.tee $8
         (select
          (i32.shl
           (local.get $4)
           (i32.const 1)
          )
          (i32.add
           (local.get $3)
           (i32.const 1022)
          )
          (local.tee $7
           (i32.lt_u
            (local.get $4)
            (i32.const 1024)
           )
          )
         )
        )
        (i32.const 2)
       )
      )
     )
    )
    (i32.const 0)
   )
   (i32.store
    (local.get $5)
    (i32.or
     (i32.and
      (local.get $9)
      (i32.const 268435455)
     )
     (i32.const 1879048192)
    )
   )
   (block $label$3
    (br_if $label$3
     (i32.eqz
      (local.get $8)
     )
    )
    (local.set $10
     (i32.and
      (local.get $8)
      (i32.const 7)
     )
    )
    (block $label$4
     (br_if $label$4
      (i32.lt_u
       (i32.add
        (i32.add
         (select
          (local.get $4)
          (i32.const 1024)
          (local.get $7)
         )
         (local.get $3)
        )
        (i32.const -3)
       )
       (i32.const 7)
      )
     )
     (local.set $9
      (i32.add
       (local.get $5)
       (i32.const 20)
      )
     )
     (local.set $7
      (i32.and
       (local.get $8)
       (i32.const -8)
      )
     )
     (local.set $6
      (i32.const 0)
     )
     (loop $label$5
      (i64.store align=4
       (i32.add
        (local.get $9)
        (i32.const 12)
       )
       (i64.const 0)
      )
      (i64.store align=4
       (i32.add
        (local.get $9)
        (i32.const 4)
       )
       (i64.const 0)
      )
      (i64.store align=4
       (i32.add
        (local.get $9)
        (i32.const -4)
       )
       (i64.const 0)
      )
      (i64.store align=4
       (i32.add
        (local.get $9)
        (i32.const -12)
       )
       (i64.const 0)
      )
      (local.set $9
       (i32.add
        (local.get $9)
        (i32.const 32)
       )
      )
      (br_if $label$5
       (i32.ne
        (local.get $7)
        (local.tee $6
         (i32.add
          (local.get $6)
          (i32.const 8)
         )
        )
       )
      )
     )
    )
    (br_if $label$3
     (i32.eqz
      (local.get $10)
     )
    )
    (local.set $9
     (i32.add
      (i32.add
       (i32.shl
        (local.get $6)
        (i32.const 2)
       )
       (local.get $5)
      )
      (i32.const 8)
     )
    )
    (loop $label$6
     (i32.store
      (local.get $9)
      (i32.const 0)
     )
     (local.set $9
      (i32.add
       (local.get $9)
       (i32.const 4)
      )
     )
     (br_if $label$6
      (local.tee $10
       (i32.add
        (local.get $10)
        (i32.const -1)
       )
      )
     )
    )
   )
   (i32.store offset=4
    (local.get $5)
    (i32.load offset=4
     (local.get $2)
    )
   )
   (block $label$7
    (br_if $label$7
     (i32.eqz
      (local.get $4)
     )
    )
    (local.set $7
     (i32.and
      (local.get $4)
      (i32.const 3)
     )
    )
    (local.set $11
     (i32.const 0)
    )
    (block $label$8
     (br_if $label$8
      (i32.lt_u
       (i32.add
        (local.get $3)
        (i32.const -3)
       )
       (i32.const 3)
      )
     )
     (local.set $12
      (i32.and
       (local.get $4)
       (i32.const -4)
      )
     )
     (local.set $9
      (i32.const 0)
     )
     (local.set $11
      (i32.const 0)
     )
     (loop $label$9
      (i32.store
       (i32.add
        (local.tee $10
         (i32.add
          (local.get $5)
          (local.get $9)
         )
        )
        (i32.const 8)
       )
       (i32.load
        (i32.add
         (local.tee $6
          (i32.add
           (local.get $2)
           (local.get $9)
          )
         )
         (i32.const 8)
        )
       )
      )
      (i32.store
       (i32.add
        (local.get $10)
        (i32.const 12)
       )
       (i32.load
        (i32.add
         (local.get $6)
         (i32.const 12)
        )
       )
      )
      (i32.store
       (i32.add
        (local.get $10)
        (i32.const 16)
       )
       (i32.load
        (i32.add
         (local.get $6)
         (i32.const 16)
        )
       )
      )
      (i32.store
       (i32.add
        (local.get $10)
        (i32.const 20)
       )
       (i32.load
        (i32.add
         (local.get $6)
         (i32.const 20)
        )
       )
      )
      (local.set $9
       (i32.add
        (local.get $9)
        (i32.const 16)
       )
      )
      (br_if $label$9
       (i32.ne
        (local.get $12)
        (local.tee $11
         (i32.add
          (local.get $11)
          (i32.const 4)
         )
        )
       )
      )
     )
    )
    (br_if $label$7
     (i32.eqz
      (local.get $7)
     )
    )
    (local.set $9
     (i32.add
      (i32.add
       (local.get $2)
       (local.tee $10
        (i32.shl
         (local.get $11)
         (i32.const 2)
        )
       )
      )
      (i32.const 8)
     )
    )
    (local.set $10
     (i32.add
      (i32.add
       (local.get $10)
       (local.get $5)
      )
      (i32.const 8)
     )
    )
    (loop $label$10
     (i32.store
      (local.get $10)
      (i32.load
       (local.get $9)
      )
     )
     (local.set $9
      (i32.add
       (local.get $9)
       (i32.const 4)
      )
     )
     (local.set $10
      (i32.add
       (local.get $10)
       (i32.const 4)
      )
     )
     (br_if $label$10
      (local.tee $7
       (i32.add
        (local.get $7)
        (i32.const -1)
       )
      )
     )
    )
   )
   (br_if $label$1
    (i32.ge_u
     (local.get $4)
     (local.get $8)
    )
   )
   (local.set $7
    (i32.add
     (local.tee $6
      (select
       (local.get $4)
       (i32.const 1024)
       (i32.lt_u
        (local.get $4)
        (i32.const 1024)
       )
      )
     )
     (i32.const -1)
    )
   )
   (block $label$11
    (br_if $label$11
     (i32.eqz
      (local.tee $10
       (i32.and
        (local.get $6)
        (i32.const 7)
       )
      )
     )
    )
    (local.set $9
     (i32.add
      (local.get $5)
      (i32.shl
       (local.get $3)
       (i32.const 2)
      )
     )
    )
    (loop $label$12
     (i32.store
      (local.get $9)
      (i32.const 0)
     )
     (local.set $9
      (i32.add
       (local.get $9)
       (i32.const 4)
      )
     )
     (local.set $4
      (i32.add
       (local.get $4)
       (i32.const 1)
      )
     )
     (br_if $label$12
      (local.tee $10
       (i32.add
        (local.get $10)
        (i32.const -1)
       )
      )
     )
    )
   )
   (br_if $label$1
    (i32.lt_u
     (local.get $7)
     (i32.const 7)
    )
   )
   (local.set $9
    (i32.add
     (i32.add
      (i32.shl
       (local.get $4)
       (i32.const 2)
      )
      (local.get $5)
     )
     (i32.const 36)
    )
   )
   (local.set $10
    (i32.add
     (i32.sub
      (i32.add
       (local.get $6)
       (local.get $3)
      )
      (local.get $4)
     )
     (i32.const -2)
    )
   )
   (loop $label$13
    (i64.store align=4
     (i32.add
      (local.get $9)
      (i32.const -4)
     )
     (i64.const 0)
    )
    (i64.store align=4
     (i32.add
      (local.get $9)
      (i32.const -12)
     )
     (i64.const 0)
    )
    (i64.store align=4
     (i32.add
      (local.get $9)
      (i32.const -20)
     )
     (i64.const 0)
    )
    (i64.store align=4
     (i32.add
      (local.get $9)
      (i32.const -28)
     )
     (i64.const 0)
    )
    (local.set $9
     (i32.add
      (local.get $9)
      (i32.const 32)
     )
    )
    (br_if $label$13
     (local.tee $10
      (i32.add
       (local.get $10)
       (i32.const -8)
      )
     )
    )
   )
  )
  (i32.store
   (i32.add
    (i32.add
     (local.get $5)
     (i32.shl
      (local.tee $9
       (i32.load offset=4
        (local.get $5)
       )
      )
      (i32.const 2)
     )
    )
    (i32.const 8)
   )
   (local.get $1)
  )
  (i32.store offset=4
   (local.get $5)
   (i32.add
    (local.get $9)
    (i32.const 1)
   )
  )
  (i32.store
   (local.get $0)
   (local.get $5)
  )
 )
 (func $custom_params (param $0 i32) (result i32)
  (i32.add
   (i32.and
    (i32.load
     (local.get $0)
    )
    (i32.const 268435455)
   )
   (i32.const -2)
  )
 )
 (func $DynamicArray_remove_ordered (param $0 i32) (param $1 i32)
  (local $2 i32)
  (local $3 i32)
  (local $4 i32)
  (local $5 i32)
  (local $6 i32)
  (local $7 i32)
  (block $label$1
   (br_if $label$1
    (i32.le_u
     (local.tee $3
      (i32.add
       (local.tee $2
        (i32.load offset=4
         (local.get $0)
        )
       )
       (i32.const -1)
      )
     )
     (local.get $1)
    )
   )
   (local.set $4
    (i32.add
     (i32.sub
      (local.get $2)
      (local.get $1)
     )
     (i32.const -2)
    )
   )
   (block $label$2
    (br_if $label$2
     (i32.eqz
      (local.tee $5
       (i32.and
        (i32.add
         (local.get $2)
         (i32.xor
          (local.get $1)
          (i32.const -1)
         )
        )
        (i32.const 3)
       )
      )
     )
    )
    (local.set $6
     (i32.add
      (i32.add
       (local.get $0)
       (i32.shl
        (local.get $1)
        (i32.const 2)
       )
      )
      (i32.const 8)
     )
    )
    (loop $label$3
     (i32.store
      (local.get $6)
      (i32.load
       (local.tee $7
        (i32.add
         (local.get $6)
         (i32.const 4)
        )
       )
      )
     )
     (local.set $1
      (i32.add
       (local.get $1)
       (i32.const 1)
      )
     )
     (local.set $6
      (local.get $7)
     )
     (br_if $label$3
      (local.tee $5
       (i32.add
        (local.get $5)
        (i32.const -1)
       )
      )
     )
    )
   )
   (br_if $label$1
    (i32.lt_u
     (local.get $4)
     (i32.const 3)
    )
   )
   (local.set $5
    (i32.add
     (i32.xor
      (local.get $1)
      (i32.const -1)
     )
     (local.get $2)
    )
   )
   (local.set $6
    (i32.add
     (i32.add
      (local.get $0)
      (i32.shl
       (local.get $1)
       (i32.const 2)
      )
     )
     (i32.const 24)
    )
   )
   (loop $label$4
    (i64.store align=4
     (i32.add
      (local.get $6)
      (i32.const -16)
     )
     (i64.load align=4
      (i32.add
       (local.get $6)
       (i32.const -12)
      )
     )
    )
    (i64.store align=4
     (i32.add
      (local.get $6)
      (i32.const -8)
     )
     (i64.load align=4
      (i32.add
       (local.get $6)
       (i32.const -4)
      )
     )
    )
    (local.set $6
     (i32.add
      (local.get $6)
      (i32.const 16)
     )
    )
    (br_if $label$4
     (local.tee $5
      (i32.add
       (local.get $5)
       (i32.const -4)
      )
     )
    )
   )
  )
  (i32.store offset=4
   (local.get $0)
   (local.get $3)
  )
  (i32.store
   (i32.add
    (i32.add
     (local.get $0)
     (i32.shl
      (local.get $3)
      (i32.const 2)
     )
    )
    (i32.const 8)
   )
   (i32.const 0)
  )
 )
 (func $DynamicArray_remove_unordered (param $0 i32) (param $1 i32)
  (local $2 i32)
  (i32.store
   (i32.add
    (local.tee $2
     (i32.add
      (local.get $0)
      (i32.const 8)
     )
    )
    (i32.shl
     (local.get $1)
     (i32.const 2)
    )
   )
   (i32.load
    (local.tee $2
     (i32.add
      (local.get $2)
      (i32.shl
       (local.tee $1
        (i32.add
         (i32.load offset=4
          (local.get $0)
         )
         (i32.const -1)
        )
       )
       (i32.const 2)
      )
     )
    )
   )
  )
  (i32.store offset=4
   (local.get $0)
   (local.get $1)
  )
  (i32.store
   (local.get $2)
   (i32.const 0)
  )
 )
 (func $eval_JsArray_singleton (param $0 i32) (result i32)
  (local $1 i32)
  (i64.store align=4
   (local.tee $1
    (call $GC_allocate
     (i32.const 1)
     (i32.const 3)
    )
   )
   (i64.const 351843735652270083)
  )
  (block $label$1
   (br_if $label$1
    (i32.eqz
     (local.get $0)
    )
   )
   (i32.store offset=8
    (local.get $1)
    (i32.load
     (local.get $0)
    )
   )
  )
  (local.get $1)
 )
 (func $newCustom (param $0 i32) (param $1 i32) (param $2 i32) (result i32)
  (local $3 i32)
  (local $4 i32)
  (local $5 i32)
  (local $6 i32)
  (local $7 i32)
  (i32.store offset=4
   (local.tee $4
    (call $GC_allocate
     (i32.const 1)
     (i32.and
      (local.tee $3
       (i32.add
        (local.get $1)
        (i32.const 2)
       )
      )
      (i32.const 1073741823)
     )
    )
   )
   (local.get $0)
  )
  (i32.store
   (local.get $4)
   (i32.or
    (i32.and
     (local.get $3)
     (i32.const 268435455)
    )
    (i32.const 1879048192)
   )
  )
  (block $label$1
   (br_if $label$1
    (i32.eqz
     (local.get $2)
    )
   )
   (br_if $label$1
    (i32.eqz
     (local.get $1)
    )
   )
   (local.set $5
    (i32.and
     (local.get $1)
     (i32.const 3)
    )
   )
   (local.set $6
    (i32.const 0)
   )
   (block $label$2
    (br_if $label$2
     (i32.lt_u
      (i32.add
       (local.get $1)
       (i32.const -1)
      )
      (i32.const 3)
     )
    )
    (local.set $7
     (i32.and
      (local.get $1)
      (i32.const -4)
     )
    )
    (local.set $1
     (i32.const 0)
    )
    (local.set $6
     (i32.const 0)
    )
    (loop $label$3
     (i32.store
      (i32.add
       (local.tee $0
        (i32.add
         (local.get $4)
         (local.get $1)
        )
       )
       (i32.const 8)
      )
      (i32.load
       (local.tee $3
        (i32.add
         (local.get $2)
         (local.get $1)
        )
       )
      )
     )
     (i32.store
      (i32.add
       (local.get $0)
       (i32.const 12)
      )
      (i32.load
       (i32.add
        (local.get $3)
        (i32.const 4)
       )
      )
     )
     (i32.store
      (i32.add
       (local.get $0)
       (i32.const 16)
      )
      (i32.load
       (i32.add
        (local.get $3)
        (i32.const 8)
       )
      )
     )
     (i32.store
      (i32.add
       (local.get $0)
       (i32.const 20)
      )
      (i32.load
       (i32.add
        (local.get $3)
        (i32.const 12)
       )
      )
     )
     (local.set $1
      (i32.add
       (local.get $1)
       (i32.const 16)
      )
     )
     (br_if $label$3
      (i32.ne
       (local.get $7)
       (local.tee $6
        (i32.add
         (local.get $6)
         (i32.const 4)
        )
       )
      )
     )
    )
   )
   (br_if $label$1
    (i32.eqz
     (local.get $5)
    )
   )
   (local.set $1
    (i32.add
     (local.get $2)
     (local.tee $0
      (i32.shl
       (local.get $6)
       (i32.const 2)
      )
     )
    )
   )
   (local.set $0
    (i32.add
     (i32.add
      (local.get $0)
      (local.get $4)
     )
     (i32.const 8)
    )
   )
   (loop $label$4
    (i32.store
     (local.get $0)
     (i32.load
      (local.get $1)
     )
    )
    (local.set $1
     (i32.add
      (local.get $1)
      (i32.const 4)
     )
    )
    (local.set $0
     (i32.add
      (local.get $0)
      (i32.const 4)
     )
    )
    (br_if $label$4
     (local.tee $5
      (i32.add
       (local.get $5)
       (i32.const -1)
      )
     )
    )
   )
  )
  (local.get $4)
 )
 (func $eval_JsArray_length (param $0 i32) (result i32)
  (local $1 i32)
  (local.set $1
   (i32.load
    (i32.load
     (local.get $0)
    )
   )
  )
  (i32.store
   (local.tee $0
    (call $GC_allocate
     (i32.const 1)
     (i32.const 4)
    )
   )
   (i32.const 4)
  )
  (f64.store offset=8
   (local.get $0)
   (f64.convert_i32_s
    (i32.add
     (i32.and
      (local.get $1)
      (i32.const 268435455)
     )
     (i32.const -2)
    )
   )
  )
  (local.get $0)
 )
 (func $eval_JsArray_initialize (param $0 i32) (result i32)
  (local $1 i32)
  (local $2 i32)
  (local $3 i32)
  (local $4 i32)
  (local $5 i32)
  (local $6 i32)
  (local $7 f64)
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
     (i32.eqz
      (i32.and
       (f64.lt
        (local.tee $7
         (f64.load offset=8
          (i32.load
           (local.get $0)
          )
         )
        )
        (f64.const 4294967296)
       )
       (f64.ge
        (local.get $7)
        (f64.const 0)
       )
      )
     )
    )
    (local.set $2
     (i32.trunc_f64_u
      (local.get $7)
     )
    )
    (br $label$1)
   )
   (local.set $2
    (i32.const 0)
   )
  )
  (local.set $3
   (i32.load offset=8
    (local.get $0)
   )
  )
  (local.set $7
   (f64.load offset=8
    (i32.load offset=4
     (local.get $0)
    )
   )
  )
  (i32.store offset=4
   (local.tee $4
    (call $GC_allocate
     (i32.const 1)
     (i32.and
      (local.tee $0
       (i32.add
        (local.get $2)
        (i32.const 2)
       )
      )
      (i32.const 1073741823)
     )
    )
   )
   (i32.const 81920003)
  )
  (i32.store
   (local.get $4)
   (i32.or
    (i32.and
     (local.get $0)
     (i32.const 268435455)
    )
    (i32.const 1879048192)
   )
  )
  (block $label$3
   (block $label$4
    (br_if $label$4
     (i32.eqz
      (f64.lt
       (f64.abs
        (local.get $7)
       )
       (f64.const 2147483648)
      )
     )
    )
    (local.set $0
     (i32.trunc_f64_s
      (local.get $7)
     )
    )
    (br $label$3)
   )
   (local.set $0
    (i32.const -2147483648)
   )
  )
  (block $label$5
   (br_if $label$5
    (i32.eqz
     (local.get $2)
    )
   )
   (local.set $5
    (i32.add
     (local.get $4)
     (i32.const 8)
    )
   )
   (loop $label$6
    (i32.store
     (local.tee $6
      (call $GC_allocate
       (i32.const 1)
       (i32.const 4)
      )
     )
     (i32.const 4)
    )
    (f64.store offset=8
     (local.get $6)
     (f64.convert_i32_s
      (local.get $0)
     )
    )
    (i32.store offset=12
     (local.get $1)
     (local.get $6)
    )
    (i32.store
     (local.get $5)
     (call $Utils_apply
      (local.get $3)
      (i32.const 1)
      (i32.add
       (local.get $1)
       (i32.const 12)
      )
     )
    )
    (local.set $5
     (i32.add
      (local.get $5)
      (i32.const 4)
     )
    )
    (local.set $0
     (i32.add
      (local.get $0)
      (i32.const 1)
     )
    )
    (br_if $label$6
     (local.tee $2
      (i32.add
       (local.get $2)
       (i32.const -1)
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
  (local.get $4)
 )
 (func $Utils_apply (param $0 i32) (param $1 i32) (param $2 i32) (result i32)
  (local $3 i32)
  (local $4 i32)
  (local $5 i32)
  (local $6 i32)
  (local $7 i32)
  (local $8 i32)
  (local $9 i32)
  (local $10 i32)
  (local $11 i32)
  (local $12 i32)
  (local $13 i32)
  (local $14 i32)
  (global.set $__stack_pointer
   (local.tee $3
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 96)
    )
   )
  )
  (block $label$1
   (block $label$2
    (block $label$3
     (block $label$4
      (br_table $label$3 $label$2 $label$4
       (i32.add
        (local.tee $4
         (i32.shr_u
          (i32.load
           (local.get $0)
          )
          (i32.const 28)
         )
        )
        (i32.const -10)
       )
      )
     )
     (i32.store offset=88
      (local.get $3)
      (i32.const 132)
     )
     (i32.store offset=84
      (local.get $3)
      (i32.const 3382)
     )
     (i32.store offset=80
      (local.get $3)
      (i32.const 1111)
     )
     (call $safe_printf
      (i32.const 5284)
      (i32.add
       (local.get $3)
       (i32.const 80)
      )
     )
     (i32.store offset=64
      (local.get $3)
      (i32.const 2876)
     )
     (call $safe_printf
      (i32.const 4957)
      (i32.add
       (local.get $3)
       (i32.const 64)
      )
     )
     (i64.store offset=56
      (local.get $3)
      (i64.extend_i32_u
       (local.get $4)
      )
     )
     (i32.store offset=48
      (local.get $3)
      (i32.const 2582)
     )
     (call $safe_printf
      (i32.const 6035)
      (i32.add
       (local.get $3)
       (i32.const 48)
      )
     )
     (call $abort)
    )
    (loop $label$5
     (block $label$6
      (br_if $label$6
       (i32.ge_u
        (local.tee $5
         (i32.and
          (local.get $1)
          (i32.const 65535)
         )
        )
        (i32.load16_u offset=6
         (local.get $0)
        )
       )
      )
      (block $label$7
       (br_if $label$7
        (local.get $5)
       )
       (local.set $2
        (i32.add
         (local.get $0)
         (i32.const 12)
        )
       )
       (br $label$6)
      )
      (i32.store16 offset=4
       (local.tee $8
        (call $GC_allocate
         (i32.const 1)
         (i32.add
          (local.tee $7
           (i32.and
            (local.tee $4
             (i32.add
              (local.tee $6
               (i32.load16_u offset=4
                (local.get $0)
               )
              )
              (local.get $1)
             )
            )
            (i32.const 65535)
           )
          )
          (i32.const 3)
         )
        )
       )
       (local.get $4)
      )
      (i32.store
       (local.get $8)
       (i32.add
        (local.get $7)
        (i32.const -1610612733)
       )
      )
      (i32.store16 offset=6
       (local.get $8)
       (local.tee $9
        (i32.load16_u offset=6
         (local.get $0)
        )
       )
      )
      (i32.store offset=8
       (local.get $8)
       (i32.load offset=8
        (local.get $0)
       )
      )
      (block $label$8
       (br_if $label$8
        (i32.eqz
         (local.get $6)
        )
       )
       (local.set $10
        (i32.and
         (local.get $6)
         (i32.const 3)
        )
       )
       (local.set $11
        (i32.const 0)
       )
       (block $label$9
        (br_if $label$9
         (i32.lt_u
          (i32.add
           (local.get $6)
           (i32.const -1)
          )
          (i32.const 3)
         )
        )
        (local.set $12
         (i32.and
          (local.get $6)
          (i32.const 65532)
         )
        )
        (local.set $4
         (i32.const 0)
        )
        (local.set $11
         (i32.const 0)
        )
        (loop $label$10
         (i32.store
          (i32.add
           (local.tee $13
            (i32.add
             (local.get $8)
             (local.get $4)
            )
           )
           (i32.const 12)
          )
          (i32.load
           (i32.add
            (local.tee $14
             (i32.add
              (local.get $0)
              (local.get $4)
             )
            )
            (i32.const 12)
           )
          )
         )
         (i32.store
          (i32.add
           (local.get $13)
           (i32.const 16)
          )
          (i32.load
           (i32.add
            (local.get $14)
            (i32.const 16)
           )
          )
         )
         (i32.store
          (i32.add
           (local.get $13)
           (i32.const 20)
          )
          (i32.load
           (i32.add
            (local.get $14)
            (i32.const 20)
           )
          )
         )
         (i32.store
          (i32.add
           (local.get $13)
           (i32.const 24)
          )
          (i32.load
           (i32.add
            (local.get $14)
            (i32.const 24)
           )
          )
         )
         (local.set $4
          (i32.add
           (local.get $4)
           (i32.const 16)
          )
         )
         (br_if $label$10
          (i32.ne
           (local.get $12)
           (local.tee $11
            (i32.add
             (local.get $11)
             (i32.const 4)
            )
           )
          )
         )
        )
       )
       (br_if $label$8
        (i32.eqz
         (local.get $10)
        )
       )
       (local.set $4
        (i32.add
         (i32.add
          (local.get $0)
          (local.tee $13
           (i32.shl
            (local.get $11)
            (i32.const 2)
           )
          )
         )
         (i32.const 12)
        )
       )
       (local.set $13
        (i32.add
         (i32.add
          (local.get $8)
          (local.get $13)
         )
         (i32.const 12)
        )
       )
       (loop $label$11
        (i32.store
         (local.get $13)
         (i32.load
          (local.get $4)
         )
        )
        (local.set $4
         (i32.add
          (local.get $4)
          (i32.const 4)
         )
        )
        (local.set $13
         (i32.add
          (local.get $13)
          (i32.const 4)
         )
        )
        (br_if $label$11
         (local.tee $10
          (i32.add
           (local.get $10)
           (i32.const -1)
          )
         )
        )
       )
      )
      (local.set $10
       (i32.and
        (local.tee $4
         (select
          (local.get $5)
          (i32.const 1)
          (i32.gt_u
           (local.get $5)
           (i32.const 1)
          )
         )
        )
        (i32.const 3)
       )
      )
      (local.set $11
       (i32.const 0)
      )
      (block $label$12
       (br_if $label$12
        (i32.lt_u
         (i32.add
          (local.get $4)
          (i32.const -1)
         )
         (i32.const 3)
        )
       )
       (local.set $12
        (i32.and
         (local.get $4)
         (i32.const 65532)
        )
       )
       (local.set $5
        (i32.add
         (local.get $8)
         (i32.shl
          (local.get $6)
          (i32.const 2)
         )
        )
       )
       (local.set $4
        (i32.const 0)
       )
       (local.set $11
        (i32.const 0)
       )
       (loop $label$13
        (i32.store
         (i32.add
          (local.tee $13
           (i32.add
            (local.get $5)
            (local.get $4)
           )
          )
          (i32.const 12)
         )
         (i32.load
          (local.tee $14
           (i32.add
            (local.get $2)
            (local.get $4)
           )
          )
         )
        )
        (i32.store
         (i32.add
          (local.get $13)
          (i32.const 16)
         )
         (i32.load
          (i32.add
           (local.get $14)
           (i32.const 4)
          )
         )
        )
        (i32.store
         (i32.add
          (local.get $13)
          (i32.const 20)
         )
         (i32.load
          (i32.add
           (local.get $14)
           (i32.const 8)
          )
         )
        )
        (i32.store
         (i32.add
          (local.get $13)
          (i32.const 24)
         )
         (i32.load
          (i32.add
           (local.get $14)
           (i32.const 12)
          )
         )
        )
        (local.set $4
         (i32.add
          (local.get $4)
          (i32.const 16)
         )
        )
        (br_if $label$13
         (i32.ne
          (local.get $12)
          (local.tee $11
           (i32.add
            (local.get $11)
            (i32.const 4)
           )
          )
         )
        )
       )
      )
      (block $label$14
       (br_if $label$14
        (i32.eqz
         (local.get $10)
        )
       )
       (local.set $4
        (i32.add
         (local.get $2)
         (i32.shl
          (local.get $11)
          (i32.const 2)
         )
        )
       )
       (local.set $13
        (i32.add
         (i32.add
          (local.get $8)
          (i32.shl
           (i32.add
            (local.get $11)
            (local.get $6)
           )
           (i32.const 2)
          )
         )
         (i32.const 12)
        )
       )
       (loop $label$15
        (i32.store
         (local.get $13)
         (i32.load
          (local.get $4)
         )
        )
        (local.set $4
         (i32.add
          (local.get $4)
          (i32.const 4)
         )
        )
        (local.set $13
         (i32.add
          (local.get $13)
          (i32.const 4)
         )
        )
        (br_if $label$15
         (local.tee $10
          (i32.add
           (local.get $10)
           (i32.const -1)
          )
         )
        )
       )
      )
      (br_if $label$1
       (i32.lt_u
        (local.get $7)
        (i32.and
         (local.get $9)
         (i32.const 65535)
        )
       )
      )
      (local.set $2
       (i32.add
        (local.get $8)
        (i32.const 12)
       )
      )
     )
     (local.set $13
      (i32.load offset=8
       (local.get $0)
      )
     )
     (i32.store8
      (i32.add
       (local.tee $4
        (i32.load16_u offset=8794
         (i32.const 0)
        )
       )
       (i32.const 49760)
      )
      (i32.const 70)
     )
     (i32.store
      (i32.add
       (i32.shl
        (local.get $4)
        (i32.const 2)
       )
       (i32.const 8800)
      )
      (i32.load16_u offset=8792
       (i32.const 0)
      )
     )
     (i32.store8
      (i32.add
       (local.tee $14
        (i32.and
         (i32.add
          (local.get $4)
          (i32.const 1)
         )
         (i32.const 65535)
        )
       )
       (i32.const 49760)
      )
      (i32.const 67)
     )
     (i32.store
      (i32.add
       (i32.shl
        (local.get $14)
        (i32.const 2)
       )
       (i32.const 8800)
      )
      (local.get $13)
     )
     (i32.store16 offset=8792
      (i32.const 0)
      (local.get $4)
     )
     (i32.store16 offset=8794
      (i32.const 0)
      (i32.add
       (local.get $4)
       (i32.const 2)
      )
     )
     (local.set $8
      (call_indirect (type $i32_=>_i32)
       (local.get $2)
       (i32.load offset=8
        (local.get $0)
       )
      )
     )
     (call $GC_stack_pop_frame
      (i32.load offset=8
       (local.get $0)
      )
      (local.get $8)
      (local.get $4)
     )
     (br_if $label$1
      (i32.le_u
       (i32.and
        (local.tee $13
         (i32.add
          (i32.load16_u offset=4
           (local.get $0)
          )
          (local.get $1)
         )
        )
        (i32.const 65535)
       )
       (local.tee $4
        (i32.load16_u offset=6
         (local.get $0)
        )
       )
      )
     )
     (block $label$16
      (br_if $label$16
       (i32.eq
        (local.tee $14
         (i32.shr_u
          (i32.load
           (local.get $8)
          )
          (i32.const 28)
         )
        )
        (i32.const 10)
       )
      )
      (i32.store offset=40
       (local.get $3)
       (i32.const 194)
      )
      (i32.store offset=36
       (local.get $3)
       (i32.const 3382)
      )
      (i32.store offset=32
       (local.get $3)
       (i32.const 1111)
      )
      (call $safe_printf
       (i32.const 5284)
       (i32.add
        (local.get $3)
        (i32.const 32)
       )
      )
      (i32.store offset=16
       (local.get $3)
       (i32.const 2905)
      )
      (call $safe_printf
       (i32.const 4957)
       (i32.add
        (local.get $3)
        (i32.const 16)
       )
      )
      (i64.store offset=8
       (local.get $3)
       (i64.extend_i32_u
        (local.get $14)
       )
      )
      (i32.store
       (local.get $3)
       (i32.const 2615)
      )
      (call $safe_printf
       (i32.const 6035)
       (local.get $3)
      )
      (call $abort)
     )
     (local.set $1
      (i32.sub
       (local.get $13)
       (local.get $4)
      )
     )
     (local.set $2
      (i32.add
       (local.get $2)
       (i32.shl
        (local.get $4)
        (i32.const 2)
       )
      )
     )
     (local.set $0
      (local.get $8)
     )
     (br $label$5)
    )
   )
   (i32.store8
    (i32.add
     (local.tee $4
      (i32.load16_u offset=8794
       (i32.const 0)
      )
     )
     (i32.const 49760)
    )
    (i32.const 70)
   )
   (i32.store8
    (i32.add
     (local.tee $13
      (i32.and
       (i32.add
        (local.get $4)
        (i32.const 1)
       )
       (i32.const 65535)
      )
     )
     (i32.const 49760)
    )
    (i32.const 74)
   )
   (local.set $14
    (i32.load16_u offset=8792
     (i32.const 0)
    )
   )
   (i32.store16 offset=8792
    (i32.const 0)
    (local.get $4)
   )
   (i32.store16 offset=8794
    (i32.const 0)
    (i32.add
     (local.get $4)
     (i32.const 2)
    )
   )
   (i32.store
    (i32.add
     (i32.shl
      (local.get $4)
      (i32.const 2)
     )
     (i32.const 8800)
    )
    (local.get $14)
   )
   (i32.store
    (i32.add
     (i32.shl
      (local.get $13)
      (i32.const 2)
     )
     (i32.const 8800)
    )
    (local.get $0)
   )
   (call $GC_stack_pop_frame
    (local.get $0)
    (local.tee $8
     (call $applyJsRef
      (i32.load offset=4
       (local.get $0)
      )
      (local.get $1)
      (local.get $2)
     )
    )
    (local.get $4)
   )
  )
  (global.set $__stack_pointer
   (i32.add
    (local.get $3)
    (i32.const 96)
   )
  )
  (local.get $8)
 )
 (func $GC_stack_pop_frame (param $0 i32) (param $1 i32) (param $2 i32)
  (local $3 i32)
  (local $4 i32)
  (local $5 i32)
  (local $6 i64)
  (global.set $__stack_pointer
   (local.tee $3
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 96)
    )
   )
  )
  (call $Debug_assert_sanity
   (i32.const 3486)
   (i32.const 103)
   (i32.const 2947)
   (i32.const 1481)
   (local.get $1)
  )
  (block $label$1
   (br_if $label$1
    (i64.eq
     (local.tee $6
      (i64.load8_s
       (i32.add
        (local.get $2)
        (i32.const 49760)
       )
      )
     )
     (i64.const 70)
    )
   )
   (i32.store offset=88
    (local.get $3)
    (i32.const 104)
   )
   (i32.store offset=84
    (local.get $3)
    (i32.const 3486)
   )
   (i32.store offset=80
    (local.get $3)
    (i32.const 2947)
   )
   (call $safe_printf
    (i32.const 5317)
    (i32.add
     (local.get $3)
     (i32.const 80)
    )
   )
   (i64.store offset=72
    (local.get $3)
    (local.get $6)
   )
   (i32.store offset=64
    (local.get $3)
    (i32.const 3747)
   )
   (call $safe_printf
    (i32.const 4798)
    (i32.add
     (local.get $3)
     (i32.const 64)
    )
   )
   (i64.store offset=56
    (local.get $3)
    (i64.const 70)
   )
   (i32.store offset=48
    (local.get $3)
    (i32.const 4111)
   )
   (call $safe_printf
    (i32.const 4798)
    (i32.add
     (local.get $3)
     (i32.const 48)
    )
   )
   (call $abort)
  )
  (block $label$2
   (br_if $label$2
    (i32.eq
     (local.tee $5
      (i32.load
       (i32.add
        (i32.shl
         (local.tee $4
          (i32.add
           (local.get $2)
           (i32.const 1)
          )
         )
         (i32.const 2)
        )
        (i32.const 8800)
       )
      )
     )
     (local.get $0)
    )
   )
   (i32.store offset=40
    (local.get $3)
    (i32.const 105)
   )
   (i32.store offset=36
    (local.get $3)
    (i32.const 3486)
   )
   (i32.store offset=32
    (local.get $3)
    (i32.const 2947)
   )
   (call $safe_printf
    (i32.const 5317)
    (i32.add
     (local.get $3)
     (i32.const 32)
    )
   )
   (i64.store offset=24
    (local.get $3)
    (i64.extend_i32_u
     (local.get $5)
    )
   )
   (i32.store offset=16
    (local.get $3)
    (i32.const 3766)
   )
   (call $safe_printf
    (i32.const 4798)
    (i32.add
     (local.get $3)
     (i32.const 16)
    )
   )
   (i64.store offset=8
    (local.get $3)
    (i64.extend_i32_u
     (local.get $0)
    )
   )
   (i32.store
    (local.get $3)
    (i32.const 3346)
   )
   (call $safe_printf
    (i32.const 4798)
    (local.get $3)
   )
   (call $abort)
  )
  (i32.store16 offset=8794
   (i32.const 0)
   (local.get $4)
  )
  (i32.store8
   (i32.add
    (local.get $2)
    (i32.const 49760)
   )
   (i32.const 82)
  )
  (local.set $0
   (i32.load
    (local.tee $2
     (i32.add
      (i32.shl
       (local.get $2)
       (i32.const 2)
      )
      (i32.const 8800)
     )
    )
   )
  )
  (i32.store
   (local.get $2)
   (local.get $1)
  )
  (i32.store16 offset=8792
   (i32.const 0)
   (local.get $0)
  )
  (global.set $__stack_pointer
   (i32.add
    (local.get $3)
    (i32.const 96)
   )
  )
 )
 (func $eval_JsArray_initializeFromList (param $0 i32) (result i32)
  (local $1 f64)
  (local $2 i32)
  (local $3 i32)
  (local $4 i32)
  (local $5 i32)
  (block $label$1
   (block $label$2
    (br_if $label$2
     (i32.eqz
      (f64.lt
       (f64.abs
        (local.tee $1
         (f64.load offset=8
          (i32.load
           (local.get $0)
          )
         )
        )
       )
       (f64.const 2147483648)
      )
     )
    )
    (local.set $2
     (i32.trunc_f64_s
      (local.get $1)
     )
    )
    (br $label$1)
   )
   (local.set $2
    (i32.const -2147483648)
   )
  )
  (local.set $0
   (i32.load offset=4
    (local.get $0)
   )
  )
  (i32.store
   (local.tee $4
    (call $GC_allocate
     (i32.const 1)
     (i32.and
      (local.tee $3
       (i32.add
        (local.get $2)
        (i32.const 2)
       )
      )
      (i32.const 1073741823)
     )
    )
   )
   (i32.or
    (i32.and
     (local.get $3)
     (i32.const 268435455)
    )
    (i32.const 1879048192)
   )
  )
  (i32.store offset=4
   (local.get $4)
   (i32.const 81920003)
  )
  (block $label$3
   (block $label$4
    (br_if $label$4
     (i32.ge_s
      (local.get $2)
      (i32.const 1)
     )
    )
    (local.set $5
     (i32.const 0)
    )
    (br $label$3)
   )
   (block $label$5
    (br_if $label$5
     (i32.ne
      (local.get $0)
      (i32.load offset=7844
       (i32.const 0)
      )
     )
    )
    (local.set $5
     (i32.const 0)
    )
    (br $label$3)
   )
   (local.set $3
    (i32.add
     (local.get $4)
     (i32.const 8)
    )
   )
   (local.set $5
    (i32.const 0)
   )
   (loop $label$6
    (i32.store
     (local.get $3)
     (i32.load offset=4
      (local.get $0)
     )
    )
    (local.set $0
     (i32.load offset=8
      (local.get $0)
     )
    )
    (br_if $label$3
     (i32.ge_s
      (local.tee $5
       (i32.add
        (local.get $5)
        (i32.const 1)
       )
      )
      (local.get $2)
     )
    )
    (local.set $3
     (i32.add
      (local.get $3)
      (i32.const 4)
     )
    )
    (br_if $label$6
     (i32.ne
      (local.get $0)
      (i32.load offset=7844
       (i32.const 0)
      )
     )
    )
   )
  )
  (i32.store
   (local.get $4)
   (i32.or
    (i32.and
     (i32.add
      (local.get $5)
      (i32.const 2)
     )
     (i32.const 268435455)
    )
    (i32.const 1879048192)
   )
  )
  (drop
   (call $GC_allocate
    (i32.const 0)
    (i32.sub
     (local.get $5)
     (local.get $2)
    )
   )
  )
  (i32.store offset=8
   (local.tee $3
    (call $GC_allocate
     (i32.const 1)
     (i32.const 3)
    )
   )
   (local.get $0)
  )
  (i32.store offset=4
   (local.get $3)
   (local.get $4)
  )
  (i32.store
   (local.get $3)
   (i32.const 1342177283)
  )
  (local.get $3)
 )
 (func $newTuple2 (param $0 i32) (param $1 i32) (result i32)
  (local $2 i32)
  (i32.store offset=8
   (local.tee $2
    (call $GC_allocate
     (i32.const 1)
     (i32.const 3)
    )
   )
   (local.get $1)
  )
  (i32.store offset=4
   (local.get $2)
   (local.get $0)
  )
  (i32.store
   (local.get $2)
   (i32.const 1342177283)
  )
  (local.get $2)
 )
 (func $eval_JsArray_unsafeGet (param $0 i32) (result i32)
  (local $1 f64)
  (local $2 i32)
  (block $label$1
   (block $label$2
    (br_if $label$2
     (i32.eqz
      (f64.lt
       (f64.abs
        (local.tee $1
         (f64.load offset=8
          (i32.load
           (local.get $0)
          )
         )
        )
       )
       (f64.const 2147483648)
      )
     )
    )
    (local.set $2
     (i32.trunc_f64_s
      (local.get $1)
     )
    )
    (br $label$1)
   )
   (local.set $2
    (i32.const -2147483648)
   )
  )
  (i32.load
   (i32.add
    (i32.add
     (i32.load offset=4
      (local.get $0)
     )
     (i32.shl
      (local.get $2)
      (i32.const 2)
     )
    )
    (i32.const 8)
   )
  )
 )
 (func $eval_JsArray_unsafeSet (param $0 i32) (result i32)
  (local $1 i32)
  (local $2 i32)
  (local $3 i32)
  (local $4 i32)
  (local $5 i32)
  (local $6 i32)
  (local $7 i32)
  (local $8 i32)
  (local $9 i32)
  (local $10 i32)
  (local $11 i32)
  (local $12 i32)
  (local $13 f64)
  (local.set $1
   (i32.load offset=4
    (local.get $0)
   )
  )
  (local.set $2
   (i32.load
    (local.get $0)
   )
  )
  (block $label$1
   (block $label$2
    (br_if $label$2
     (i32.ne
      (i32.load offset=7844
       (i32.const 0)
      )
      (local.tee $3
       (i32.load offset=8
        (local.get $0)
       )
      )
     )
    )
    (local.set $4
     (local.get $3)
    )
    (br $label$1)
   )
   (block $label$3
    (br_if $label$3
     (i32.ne
      (local.tee $0
       (i32.load
        (local.get $3)
       )
      )
      (i32.const 1879048194)
     )
    )
    (local.set $4
     (local.get $3)
    )
    (br $label$1)
   )
   (local.set $4
    (call $GC_allocate
     (i32.const 1)
     (i32.and
      (local.get $0)
      (i32.const 268435455)
     )
    )
   )
   (local.set $5
    (i32.and
     (i32.shl
      (local.tee $0
       (i32.load
        (local.get $3)
       )
      )
      (i32.const 2)
     )
     (i32.const 1073741820)
    )
   )
   (block $label$4
    (block $label$5
     (br_if $label$5
      (i32.and
       (local.get $4)
       (i32.const 7)
      )
     )
     (local.set $6
      (local.get $4)
     )
     (br $label$4)
    )
    (i32.store
     (local.get $4)
     (local.get $0)
    )
    (local.set $6
     (i32.add
      (local.get $4)
      (i32.const 4)
     )
    )
    (local.set $3
     (i32.add
      (local.get $3)
      (i32.const 4)
     )
    )
    (local.set $5
     (i32.add
      (local.get $5)
      (i32.const -4)
     )
    )
   )
   (local.set $7
    (i32.const 0)
   )
   (block $label$6
    (br_if $label$6
     (i32.lt_u
      (local.get $5)
      (i32.const 8)
     )
    )
    (local.set $8
     (i32.and
      (local.tee $7
       (i32.shr_u
        (local.get $5)
        (i32.const 3)
       )
      )
      (i32.const 3)
     )
    )
    (local.set $9
     (i32.const 0)
    )
    (block $label$7
     (br_if $label$7
      (i32.lt_u
       (i32.add
        (local.get $7)
        (i32.const -1)
       )
       (i32.const 3)
      )
     )
     (local.set $10
      (i32.and
       (local.get $7)
       (i32.const 536870908)
      )
     )
     (local.set $0
      (i32.const 0)
     )
     (local.set $9
      (i32.const 0)
     )
     (loop $label$8
      (i64.store
       (local.tee $11
        (i32.add
         (local.get $6)
         (local.get $0)
        )
       )
       (i64.load
        (local.tee $12
         (i32.add
          (local.get $3)
          (local.get $0)
         )
        )
       )
      )
      (i64.store
       (i32.add
        (local.get $11)
        (i32.const 8)
       )
       (i64.load
        (i32.add
         (local.get $12)
         (i32.const 8)
        )
       )
      )
      (i64.store
       (i32.add
        (local.get $11)
        (i32.const 16)
       )
       (i64.load
        (i32.add
         (local.get $12)
         (i32.const 16)
        )
       )
      )
      (i64.store
       (i32.add
        (local.get $11)
        (i32.const 24)
       )
       (i64.load
        (i32.add
         (local.get $12)
         (i32.const 24)
        )
       )
      )
      (local.set $0
       (i32.add
        (local.get $0)
        (i32.const 32)
       )
      )
      (br_if $label$8
       (i32.ne
        (local.get $10)
        (local.tee $9
         (i32.add
          (local.get $9)
          (i32.const 4)
         )
        )
       )
      )
     )
    )
    (br_if $label$6
     (i32.eqz
      (local.get $8)
     )
    )
    (local.set $0
     (i32.add
      (local.get $3)
      (local.tee $11
       (i32.shl
        (local.get $9)
        (i32.const 3)
       )
      )
     )
    )
    (local.set $11
     (i32.add
      (local.get $6)
      (local.get $11)
     )
    )
    (loop $label$9
     (i64.store
      (local.get $11)
      (i64.load
       (local.get $0)
      )
     )
     (local.set $0
      (i32.add
       (local.get $0)
       (i32.const 8)
      )
     )
     (local.set $11
      (i32.add
       (local.get $11)
       (i32.const 8)
      )
     )
     (br_if $label$9
      (local.tee $8
       (i32.add
        (local.get $8)
        (i32.const -1)
       )
      )
     )
    )
   )
   (br_if $label$1
    (i32.eqz
     (i32.and
      (local.get $5)
      (i32.const 7)
     )
    )
   )
   (i32.store
    (i32.add
     (local.get $6)
     (local.tee $0
      (i32.shl
       (local.get $7)
       (i32.const 3)
      )
     )
    )
    (i32.load
     (i32.add
      (local.get $3)
      (local.get $0)
     )
    )
   )
  )
  (block $label$10
   (block $label$11
    (br_if $label$11
     (i32.eqz
      (f64.lt
       (f64.abs
        (local.tee $13
         (f64.load offset=8
          (local.get $2)
         )
        )
       )
       (f64.const 2147483648)
      )
     )
    )
    (local.set $0
     (i32.trunc_f64_s
      (local.get $13)
     )
    )
    (br $label$10)
   )
   (local.set $0
    (i32.const -2147483648)
   )
  )
  (i32.store
   (i32.add
    (i32.add
     (local.get $4)
     (i32.shl
      (local.get $0)
      (i32.const 2)
     )
    )
    (i32.const 8)
   )
   (local.get $1)
  )
  (local.get $4)
 )
 (func $Utils_clone (param $0 i32) (result i32)
  (local $1 i32)
  (local $2 i32)
  (local $3 i32)
  (local $4 i32)
  (local $5 i32)
  (local $6 i32)
  (local $7 i32)
  (local $8 i32)
  (local $9 i32)
  (local $10 i32)
  (block $label$1
   (br_if $label$1
    (i32.ne
     (i32.load offset=7844
      (i32.const 0)
     )
     (local.get $0)
    )
   )
   (return
    (local.get $0)
   )
  )
  (block $label$2
   (br_if $label$2
    (i32.ne
     (local.tee $1
      (i32.load
       (local.get $0)
      )
     )
     (i32.const 1879048194)
    )
   )
   (return
    (local.get $0)
   )
  )
  (local.set $2
   (call $GC_allocate
    (i32.const 1)
    (i32.and
     (local.get $1)
     (i32.const 268435455)
    )
   )
  )
  (local.set $3
   (i32.and
    (i32.shl
     (local.tee $1
      (i32.load
       (local.get $0)
      )
     )
     (i32.const 2)
    )
    (i32.const 1073741820)
   )
  )
  (block $label$3
   (block $label$4
    (br_if $label$4
     (i32.and
      (local.get $2)
      (i32.const 7)
     )
    )
    (local.set $4
     (local.get $2)
    )
    (br $label$3)
   )
   (i32.store
    (local.get $2)
    (local.get $1)
   )
   (local.set $4
    (i32.add
     (local.get $2)
     (i32.const 4)
    )
   )
   (local.set $0
    (i32.add
     (local.get $0)
     (i32.const 4)
    )
   )
   (local.set $3
    (i32.add
     (local.get $3)
     (i32.const -4)
    )
   )
  )
  (local.set $5
   (i32.const 0)
  )
  (block $label$5
   (br_if $label$5
    (i32.lt_u
     (local.get $3)
     (i32.const 8)
    )
   )
   (local.set $6
    (i32.and
     (local.tee $5
      (i32.shr_u
       (local.get $3)
       (i32.const 3)
      )
     )
     (i32.const 3)
    )
   )
   (local.set $7
    (i32.const 0)
   )
   (block $label$6
    (br_if $label$6
     (i32.lt_u
      (i32.add
       (local.get $5)
       (i32.const -1)
      )
      (i32.const 3)
     )
    )
    (local.set $8
     (i32.and
      (local.get $5)
      (i32.const 536870908)
     )
    )
    (local.set $1
     (i32.const 0)
    )
    (local.set $7
     (i32.const 0)
    )
    (loop $label$7
     (i64.store
      (local.tee $9
       (i32.add
        (local.get $4)
        (local.get $1)
       )
      )
      (i64.load
       (local.tee $10
        (i32.add
         (local.get $0)
         (local.get $1)
        )
       )
      )
     )
     (i64.store
      (i32.add
       (local.get $9)
       (i32.const 8)
      )
      (i64.load
       (i32.add
        (local.get $10)
        (i32.const 8)
       )
      )
     )
     (i64.store
      (i32.add
       (local.get $9)
       (i32.const 16)
      )
      (i64.load
       (i32.add
        (local.get $10)
        (i32.const 16)
       )
      )
     )
     (i64.store
      (i32.add
       (local.get $9)
       (i32.const 24)
      )
      (i64.load
       (i32.add
        (local.get $10)
        (i32.const 24)
       )
      )
     )
     (local.set $1
      (i32.add
       (local.get $1)
       (i32.const 32)
      )
     )
     (br_if $label$7
      (i32.ne
       (local.get $8)
       (local.tee $7
        (i32.add
         (local.get $7)
         (i32.const 4)
        )
       )
      )
     )
    )
   )
   (br_if $label$5
    (i32.eqz
     (local.get $6)
    )
   )
   (local.set $1
    (i32.add
     (local.get $0)
     (local.tee $9
      (i32.shl
       (local.get $7)
       (i32.const 3)
      )
     )
    )
   )
   (local.set $9
    (i32.add
     (local.get $4)
     (local.get $9)
    )
   )
   (loop $label$8
    (i64.store
     (local.get $9)
     (i64.load
      (local.get $1)
     )
    )
    (local.set $1
     (i32.add
      (local.get $1)
      (i32.const 8)
     )
    )
    (local.set $9
     (i32.add
      (local.get $9)
      (i32.const 8)
     )
    )
    (br_if $label$8
     (local.tee $6
      (i32.add
       (local.get $6)
       (i32.const -1)
      )
     )
    )
   )
  )
  (block $label$9
   (br_if $label$9
    (i32.eqz
     (i32.and
      (local.get $3)
      (i32.const 7)
     )
    )
   )
   (i32.store
    (i32.add
     (local.get $4)
     (local.tee $1
      (i32.shl
       (local.get $5)
       (i32.const 3)
      )
     )
    )
    (i32.load
     (i32.add
      (local.get $0)
      (local.get $1)
     )
    )
   )
  )
  (local.get $2)
 )
 (func $eval_JsArray_push (param $0 i32) (result i32)
  (local $1 i32)
  (local $2 i32)
  (local $3 i32)
  (local $4 i32)
  (local $5 i32)
  (local $6 i32)
  (local $7 i32)
  (local $8 i32)
  (local $9 i32)
  (local $10 i32)
  (local $11 i32)
  (local $12 i32)
  (local $13 i32)
  (local.set $3
   (i32.shl
    (local.tee $2
     (i32.and
      (i32.load
       (local.tee $1
        (i32.load offset=4
         (local.get $0)
        )
       )
      )
      (i32.const 268435455)
     )
    )
    (i32.const 2)
   )
  )
  (local.set $4
   (i32.load
    (local.get $0)
   )
  )
  (block $label$1
   (block $label$2
    (br_if $label$2
     (i32.and
      (local.tee $6
       (call $GC_allocate
        (i32.const 1)
        (local.tee $5
         (i32.add
          (local.get $2)
          (i32.const 1)
         )
        )
       )
      )
      (i32.const 7)
     )
    )
    (local.set $7
     (local.get $6)
    )
    (br $label$1)
   )
   (i32.store
    (local.get $6)
    (i32.load
     (local.get $1)
    )
   )
   (local.set $7
    (i32.add
     (local.get $6)
     (i32.const 4)
    )
   )
   (local.set $1
    (i32.add
     (local.get $1)
     (i32.const 4)
    )
   )
   (local.set $3
    (i32.add
     (local.get $3)
     (i32.const -4)
    )
   )
  )
  (local.set $8
   (i32.const 0)
  )
  (block $label$3
   (br_if $label$3
    (i32.lt_u
     (local.get $3)
     (i32.const 8)
    )
   )
   (local.set $9
    (i32.and
     (local.tee $8
      (i32.shr_u
       (local.get $3)
       (i32.const 3)
      )
     )
     (i32.const 3)
    )
   )
   (local.set $10
    (i32.const 0)
   )
   (block $label$4
    (br_if $label$4
     (i32.lt_u
      (i32.add
       (local.get $8)
       (i32.const -1)
      )
      (i32.const 3)
     )
    )
    (local.set $11
     (i32.and
      (local.get $8)
      (i32.const 536870908)
     )
    )
    (local.set $0
     (i32.const 0)
    )
    (local.set $10
     (i32.const 0)
    )
    (loop $label$5
     (i64.store
      (local.tee $12
       (i32.add
        (local.get $7)
        (local.get $0)
       )
      )
      (i64.load
       (local.tee $13
        (i32.add
         (local.get $1)
         (local.get $0)
        )
       )
      )
     )
     (i64.store
      (i32.add
       (local.get $12)
       (i32.const 8)
      )
      (i64.load
       (i32.add
        (local.get $13)
        (i32.const 8)
       )
      )
     )
     (i64.store
      (i32.add
       (local.get $12)
       (i32.const 16)
      )
      (i64.load
       (i32.add
        (local.get $13)
        (i32.const 16)
       )
      )
     )
     (i64.store
      (i32.add
       (local.get $12)
       (i32.const 24)
      )
      (i64.load
       (i32.add
        (local.get $13)
        (i32.const 24)
       )
      )
     )
     (local.set $0
      (i32.add
       (local.get $0)
       (i32.const 32)
      )
     )
     (br_if $label$5
      (i32.ne
       (local.get $11)
       (local.tee $10
        (i32.add
         (local.get $10)
         (i32.const 4)
        )
       )
      )
     )
    )
   )
   (br_if $label$3
    (i32.eqz
     (local.get $9)
    )
   )
   (local.set $0
    (i32.add
     (local.get $1)
     (local.tee $12
      (i32.shl
       (local.get $10)
       (i32.const 3)
      )
     )
    )
   )
   (local.set $12
    (i32.add
     (local.get $7)
     (local.get $12)
    )
   )
   (loop $label$6
    (i64.store
     (local.get $12)
     (i64.load
      (local.get $0)
     )
    )
    (local.set $0
     (i32.add
      (local.get $0)
      (i32.const 8)
     )
    )
    (local.set $12
     (i32.add
      (local.get $12)
      (i32.const 8)
     )
    )
    (br_if $label$6
     (local.tee $9
      (i32.add
       (local.get $9)
       (i32.const -1)
      )
     )
    )
   )
  )
  (block $label$7
   (br_if $label$7
    (i32.eqz
     (i32.and
      (local.get $3)
      (i32.const 7)
     )
    )
   )
   (i32.store
    (i32.add
     (local.get $7)
     (local.tee $0
      (i32.shl
       (local.get $8)
       (i32.const 3)
      )
     )
    )
    (i32.load
     (i32.add
      (local.get $1)
      (local.get $0)
     )
    )
   )
  )
  (i32.store
   (local.get $6)
   (i32.or
    (i32.and
     (i32.load
      (local.get $6)
     )
     (i32.const -268435456)
    )
    (i32.and
     (local.get $5)
     (i32.const 268435455)
    )
   )
  )
  (i32.store
   (i32.add
    (local.get $6)
    (i32.shl
     (local.get $2)
     (i32.const 2)
    )
   )
   (local.get $4)
  )
  (local.get $6)
 )
 (func $GC_memcpy (param $0 i32) (param $1 i32) (param $2 i32) (result i32)
  (local $3 i32)
  (local $4 i32)
  (local $5 i32)
  (local $6 i32)
  (local $7 i32)
  (local $8 i32)
  (local $9 i32)
  (local.set $3
   (i32.shl
    (local.get $2)
    (i32.const 2)
   )
  )
  (block $label$1
   (br_if $label$1
    (i32.eqz
     (i32.and
      (local.get $0)
      (i32.const 7)
     )
    )
   )
   (i32.store
    (local.get $0)
    (i32.load
     (local.get $1)
    )
   )
   (local.set $0
    (i32.add
     (local.get $0)
     (i32.const 4)
    )
   )
   (local.set $1
    (i32.add
     (local.get $1)
     (i32.const 4)
    )
   )
   (local.set $3
    (i32.add
     (local.get $3)
     (i32.const -4)
    )
   )
  )
  (local.set $4
   (i32.const 0)
  )
  (block $label$2
   (br_if $label$2
    (i32.lt_u
     (local.get $3)
     (i32.const 8)
    )
   )
   (local.set $5
    (i32.and
     (local.tee $4
      (i32.shr_u
       (local.get $3)
       (i32.const 3)
      )
     )
     (i32.const 3)
    )
   )
   (local.set $6
    (i32.const 0)
   )
   (block $label$3
    (br_if $label$3
     (i32.lt_u
      (i32.add
       (local.get $4)
       (i32.const -1)
      )
      (i32.const 3)
     )
    )
    (local.set $7
     (i32.and
      (local.get $4)
      (i32.const 536870908)
     )
    )
    (local.set $2
     (i32.const 0)
    )
    (local.set $6
     (i32.const 0)
    )
    (loop $label$4
     (i64.store
      (local.tee $8
       (i32.add
        (local.get $0)
        (local.get $2)
       )
      )
      (i64.load
       (local.tee $9
        (i32.add
         (local.get $1)
         (local.get $2)
        )
       )
      )
     )
     (i64.store
      (i32.add
       (local.get $8)
       (i32.const 8)
      )
      (i64.load
       (i32.add
        (local.get $9)
        (i32.const 8)
       )
      )
     )
     (i64.store
      (i32.add
       (local.get $8)
       (i32.const 16)
      )
      (i64.load
       (i32.add
        (local.get $9)
        (i32.const 16)
       )
      )
     )
     (i64.store
      (i32.add
       (local.get $8)
       (i32.const 24)
      )
      (i64.load
       (i32.add
        (local.get $9)
        (i32.const 24)
       )
      )
     )
     (local.set $2
      (i32.add
       (local.get $2)
       (i32.const 32)
      )
     )
     (br_if $label$4
      (i32.ne
       (local.get $7)
       (local.tee $6
        (i32.add
         (local.get $6)
         (i32.const 4)
        )
       )
      )
     )
    )
   )
   (br_if $label$2
    (i32.eqz
     (local.get $5)
    )
   )
   (local.set $2
    (i32.add
     (local.get $1)
     (local.tee $8
      (i32.shl
       (local.get $6)
       (i32.const 3)
      )
     )
    )
   )
   (local.set $8
    (i32.add
     (local.get $0)
     (local.get $8)
    )
   )
   (loop $label$5
    (i64.store
     (local.get $8)
     (i64.load
      (local.get $2)
     )
    )
    (local.set $2
     (i32.add
      (local.get $2)
      (i32.const 8)
     )
    )
    (local.set $8
     (i32.add
      (local.get $8)
      (i32.const 8)
     )
    )
    (br_if $label$5
     (local.tee $5
      (i32.add
       (local.get $5)
       (i32.const -1)
      )
     )
    )
   )
  )
  (block $label$6
   (br_if $label$6
    (i32.eqz
     (i32.and
      (local.get $3)
      (i32.const 7)
     )
    )
   )
   (i32.store
    (i32.add
     (local.get $0)
     (local.tee $2
      (i32.shl
       (local.get $4)
       (i32.const 3)
      )
     )
    )
    (i32.load
     (i32.add
      (local.get $1)
      (local.get $2)
     )
    )
   )
  )
  (local.get $0)
 )
 (func $eval_JsArray_foldl (param $0 i32) (result i32)
  (local $1 i32)
  (local $2 i32)
  (local $3 i32)
  (local $4 i32)
  (local $5 i32)
  (global.set $__stack_pointer
   (local.tee $1
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 16)
    )
   )
  )
  (local.set $2
   (i32.load offset=4
    (local.get $0)
   )
  )
  (block $label$1
   (br_if $label$1
    (i32.eqz
     (local.tee $4
      (i32.add
       (i32.and
        (i32.load
         (local.tee $3
          (i32.load offset=8
           (local.get $0)
          )
         )
        )
        (i32.const 268435455)
       )
       (i32.const -2)
      )
     )
    )
   )
   (local.set $5
    (i32.load
     (local.get $0)
    )
   )
   (local.set $0
    (i32.add
     (local.get $3)
     (i32.const 8)
    )
   )
   (loop $label$2
    (local.set $3
     (i32.load
      (local.get $0)
     )
    )
    (i32.store offset=12
     (local.get $1)
     (local.get $2)
    )
    (i32.store offset=8
     (local.get $1)
     (local.get $3)
    )
    (local.set $0
     (i32.add
      (local.get $0)
      (i32.const 4)
     )
    )
    (local.set $2
     (call $Utils_apply
      (local.get $5)
      (i32.const 2)
      (i32.add
       (local.get $1)
       (i32.const 8)
      )
     )
    )
    (br_if $label$2
     (local.tee $4
      (i32.add
       (local.get $4)
       (i32.const -1)
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
  (local.get $2)
 )
 (func $eval_JsArray_foldr (param $0 i32) (result i32)
  (local $1 i32)
  (local $2 i32)
  (local $3 i32)
  (local $4 i32)
  (local $5 i32)
  (local $6 i32)
  (global.set $__stack_pointer
   (local.tee $1
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 16)
    )
   )
  )
  (local.set $2
   (i32.load offset=4
    (local.get $0)
   )
  )
  (block $label$1
   (br_if $label$1
    (i32.lt_u
     (local.tee $4
      (i32.and
       (i32.load
        (local.tee $3
         (i32.load offset=8
          (local.get $0)
         )
        )
       )
       (i32.const 268435455)
      )
     )
     (i32.const 3)
    )
   )
   (local.set $5
    (i32.load
     (local.get $0)
    )
   )
   (local.set $6
    (i32.add
     (local.get $3)
     (i32.const -4)
    )
   )
   (local.set $0
    (i32.shl
     (local.get $4)
     (i32.const 2)
    )
   )
   (loop $label$2
    (local.set $3
     (i32.load
      (i32.add
       (local.get $6)
       (local.get $0)
      )
     )
    )
    (i32.store offset=12
     (local.get $1)
     (local.get $2)
    )
    (i32.store offset=8
     (local.get $1)
     (local.get $3)
    )
    (local.set $2
     (call $Utils_apply
      (local.get $5)
      (i32.const 2)
      (i32.add
       (local.get $1)
       (i32.const 8)
      )
     )
    )
    (br_if $label$2
     (i32.ne
      (local.tee $0
       (i32.add
        (local.get $0)
        (i32.const -4)
       )
      )
      (i32.const 8)
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
  (local.get $2)
 )
 (func $eval_JsArray_map (param $0 i32) (result i32)
  (local $1 i32)
  (local $2 i32)
  (local $3 i32)
  (local $4 i32)
  (local $5 i32)
  (global.set $__stack_pointer
   (local.tee $1
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 16)
    )
   )
  )
  (local.set $2
   (i32.load
    (local.get $0)
   )
  )
  (i32.store offset=4
   (local.tee $4
    (call $GC_allocate
     (i32.const 1)
     (local.tee $0
      (i32.and
       (i32.load
        (local.tee $3
         (i32.load offset=4
          (local.get $0)
         )
        )
       )
       (i32.const 268435455)
      )
     )
    )
   )
   (i32.const 81920003)
  )
  (i32.store
   (local.get $4)
   (i32.or
    (local.get $0)
    (i32.const 1879048192)
   )
  )
  (block $label$1
   (br_if $label$1
    (i32.eqz
     (local.tee $5
      (i32.add
       (local.get $0)
       (i32.const -2)
      )
     )
    )
   )
   (local.set $0
    (i32.add
     (local.get $4)
     (i32.const 8)
    )
   )
   (local.set $3
    (i32.add
     (local.get $3)
     (i32.const 8)
    )
   )
   (loop $label$2
    (i32.store offset=12
     (local.get $1)
     (i32.load
      (local.get $3)
     )
    )
    (i32.store
     (local.get $0)
     (call $Utils_apply
      (local.get $2)
      (i32.const 1)
      (i32.add
       (local.get $1)
       (i32.const 12)
      )
     )
    )
    (local.set $0
     (i32.add
      (local.get $0)
      (i32.const 4)
     )
    )
    (local.set $3
     (i32.add
      (local.get $3)
      (i32.const 4)
     )
    )
    (br_if $label$2
     (local.tee $5
      (i32.add
       (local.get $5)
       (i32.const -1)
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
  (local.get $4)
 )
 (func $eval_JsArray_indexedMap (param $0 i32) (result i32)
  (local $1 i32)
  (local $2 i32)
  (local $3 i32)
  (local $4 i32)
  (local $5 i32)
  (local $6 i32)
  (local $7 i32)
  (local $8 f64)
  (global.set $__stack_pointer
   (local.tee $1
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 16)
    )
   )
  )
  (local.set $2
   (i32.load
    (local.get $0)
   )
  )
  (local.set $8
   (f64.load offset=8
    (i32.load offset=4
     (local.get $0)
    )
   )
  )
  (i32.store offset=4
   (local.tee $5
    (call $GC_allocate
     (i32.const 1)
     (local.tee $4
      (i32.and
       (i32.load
        (local.tee $3
         (i32.load offset=8
          (local.get $0)
         )
        )
       )
       (i32.const 268435455)
      )
     )
    )
   )
   (i32.const 81920003)
  )
  (i32.store
   (local.get $5)
   (i32.or
    (local.get $4)
    (i32.const 1879048192)
   )
  )
  (local.set $6
   (i32.lt_u
    (local.get $4)
    (i32.const 3)
   )
  )
  (block $label$1
   (block $label$2
    (br_if $label$2
     (i32.eqz
      (f64.lt
       (f64.abs
        (local.get $8)
       )
       (f64.const 2147483648)
      )
     )
    )
    (local.set $0
     (i32.trunc_f64_s
      (local.get $8)
     )
    )
    (br $label$1)
   )
   (local.set $0
    (i32.const -2147483648)
   )
  )
  (block $label$3
   (br_if $label$3
    (local.get $6)
   )
   (local.set $7
    (i32.add
     (local.get $4)
     (i32.const -2)
    )
   )
   (local.set $4
    (i32.add
     (local.get $5)
     (i32.const 8)
    )
   )
   (local.set $6
    (i32.add
     (local.get $3)
     (i32.const 8)
    )
   )
   (loop $label$4
    (i32.store
     (local.tee $3
      (call $GC_allocate
       (i32.const 1)
       (i32.const 4)
      )
     )
     (i32.const 4)
    )
    (f64.store offset=8
     (local.get $3)
     (f64.convert_i32_s
      (local.get $0)
     )
    )
    (i32.store offset=8
     (local.get $1)
     (local.get $3)
    )
    (i32.store offset=12
     (local.get $1)
     (i32.load
      (local.get $6)
     )
    )
    (i32.store
     (local.get $4)
     (call $Utils_apply
      (local.get $2)
      (i32.const 2)
      (i32.add
       (local.get $1)
       (i32.const 8)
      )
     )
    )
    (local.set $4
     (i32.add
      (local.get $4)
      (i32.const 4)
     )
    )
    (local.set $6
     (i32.add
      (local.get $6)
      (i32.const 4)
     )
    )
    (local.set $0
     (i32.add
      (local.get $0)
      (i32.const 1)
     )
    )
    (br_if $label$4
     (local.tee $7
      (i32.add
       (local.get $7)
       (i32.const -1)
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
  (local.get $5)
 )
 (func $eval_JsArray_slice (param $0 i32) (result i32)
  (local $1 i32)
  (local $2 i32)
  (local $3 i32)
  (local $4 i32)
  (local $5 i32)
  (local $6 f64)
  (local $7 f64)
  (block $label$1
   (block $label$2
    (br_if $label$2
     (i32.eqz
      (f64.lt
       (f64.abs
        (local.tee $6
         (f64.load offset=8
          (local.tee $1
           (i32.load
            (local.get $0)
           )
          )
         )
        )
       )
       (f64.const 2147483648)
      )
     )
    )
    (local.set $2
     (i32.trunc_f64_s
      (local.get $6)
     )
    )
    (br $label$1)
   )
   (local.set $2
    (i32.const -2147483648)
   )
  )
  (block $label$3
   (block $label$4
    (br_if $label$4
     (i32.eqz
      (f64.lt
       (f64.abs
        (local.tee $6
         (f64.load offset=8
          (local.tee $3
           (i32.load offset=4
            (local.get $0)
           )
          )
         )
        )
       )
       (f64.const 2147483648)
      )
     )
    )
    (local.set $4
     (i32.trunc_f64_s
      (local.get $6)
     )
    )
    (br $label$3)
   )
   (local.set $4
    (i32.const -2147483648)
   )
  )
  (local.set $5
   (i32.load offset=8
    (local.get $0)
   )
  )
  (i32.store
   (local.tee $4
    (call $GC_allocate
     (i32.const 1)
     (i32.and
      (local.tee $0
       (i32.add
        (i32.sub
         (local.get $4)
         (local.get $2)
        )
        (i32.const 2)
       )
      )
      (i32.const 1073741823)
     )
    )
   )
   (i32.or
    (i32.and
     (local.get $0)
     (i32.const 268435455)
    )
    (i32.const 1879048192)
   )
  )
  (i32.store offset=4
   (local.get $4)
   (i32.const 81920003)
  )
  (local.set $0
   (f64.le
    (local.tee $7
     (f64.load offset=8
      (local.get $3)
     )
    )
    (f64.trunc
     (local.tee $6
      (f64.load offset=8
       (local.get $1)
      )
     )
    )
   )
  )
  (block $label$5
   (block $label$6
    (br_if $label$6
     (i32.eqz
      (f64.lt
       (f64.abs
        (local.get $6)
       )
       (f64.const 2147483648)
      )
     )
    )
    (local.set $2
     (i32.trunc_f64_s
      (local.get $6)
     )
    )
    (br $label$5)
   )
   (local.set $2
    (i32.const -2147483648)
   )
  )
  (block $label$7
   (br_if $label$7
    (local.get $0)
   )
   (local.set $0
    (i32.add
     (local.get $4)
     (i32.const 8)
    )
   )
   (local.set $1
    (i32.add
     (local.get $2)
     (i32.const 1)
    )
   )
   (local.set $2
    (i32.add
     (i32.add
      (local.get $5)
      (i32.shl
       (local.get $2)
       (i32.const 2)
      )
     )
     (i32.const 8)
    )
   )
   (loop $label$8
    (i32.store
     (local.get $0)
     (i32.load
      (local.get $2)
     )
    )
    (local.set $0
     (i32.add
      (local.get $0)
      (i32.const 4)
     )
    )
    (local.set $2
     (i32.add
      (local.get $2)
      (i32.const 4)
     )
    )
    (local.set $6
     (f64.convert_i32_s
      (local.get $1)
     )
    )
    (local.set $1
     (i32.add
      (local.get $1)
      (i32.const 1)
     )
    )
    (br_if $label$8
     (f64.gt
      (local.get $7)
      (local.get $6)
     )
    )
   )
  )
  (local.get $4)
 )
 (func $eval_JsArray_appendN (param $0 i32) (result i32)
  (local $1 i32)
  (local $2 i32)
  (local $3 i32)
  (local $4 i32)
  (local $5 i32)
  (local $6 i32)
  (local $7 i32)
  (local $8 i32)
  (local $9 i32)
  (local $10 i32)
  (local $11 f64)
  (local.set $2
   (i32.add
    (i32.and
     (i32.load
      (local.tee $1
       (i32.load offset=8
        (local.get $0)
       )
      )
     )
     (i32.const 268435455)
    )
    (i32.const -2)
   )
  )
  (block $label$1
   (block $label$2
    (br_if $label$2
     (i32.eqz
      (f64.lt
       (f64.abs
        (local.tee $11
         (f64.sub
          (f64.load offset=8
           (i32.load
            (local.get $0)
           )
          )
          (f64.convert_i32_s
           (local.tee $5
            (i32.add
             (local.tee $4
              (i32.and
               (i32.load
                (local.tee $3
                 (i32.load offset=4
                  (local.get $0)
                 )
                )
               )
               (i32.const 268435455)
              )
             )
             (i32.const -2)
            )
           )
          )
         )
        )
       )
       (f64.const 2147483648)
      )
     )
    )
    (local.set $0
     (i32.trunc_f64_s
      (local.get $11)
     )
    )
    (br $label$1)
   )
   (local.set $0
    (i32.const -2147483648)
   )
  )
  (i32.store offset=4
   (local.tee $7
    (call $GC_allocate
     (i32.const 1)
     (i32.and
      (local.tee $0
       (i32.add
        (local.tee $6
         (select
          (local.get $2)
          (local.get $0)
          (i32.lt_s
           (local.get $2)
           (local.get $0)
          )
         )
        )
        (local.get $4)
       )
      )
      (i32.const 1073741823)
     )
    )
   )
   (i32.const 81920003)
  )
  (i32.store
   (local.get $7)
   (i32.or
    (i32.and
     (local.get $0)
     (i32.const 268435455)
    )
    (i32.const 1879048192)
   )
  )
  (block $label$3
   (br_if $label$3
    (i32.lt_u
     (local.get $4)
     (i32.const 3)
    )
   )
   (local.set $8
    (i32.and
     (local.get $5)
     (i32.const 3)
    )
   )
   (local.set $9
    (i32.const 0)
   )
   (block $label$4
    (br_if $label$4
     (i32.lt_u
      (i32.add
       (local.get $4)
       (i32.const -3)
      )
      (i32.const 3)
     )
    )
    (local.set $10
     (i32.and
      (local.get $5)
      (i32.const -4)
     )
    )
    (local.set $0
     (i32.const 0)
    )
    (local.set $9
     (i32.const 0)
    )
    (loop $label$5
     (i32.store
      (i32.add
       (local.tee $2
        (i32.add
         (local.get $7)
         (local.get $0)
        )
       )
       (i32.const 8)
      )
      (i32.load
       (i32.add
        (local.tee $5
         (i32.add
          (local.get $3)
          (local.get $0)
         )
        )
        (i32.const 8)
       )
      )
     )
     (i32.store
      (i32.add
       (local.get $2)
       (i32.const 12)
      )
      (i32.load
       (i32.add
        (local.get $5)
        (i32.const 12)
       )
      )
     )
     (i32.store
      (i32.add
       (local.get $2)
       (i32.const 16)
      )
      (i32.load
       (i32.add
        (local.get $5)
        (i32.const 16)
       )
      )
     )
     (i32.store
      (i32.add
       (local.get $2)
       (i32.const 20)
      )
      (i32.load
       (i32.add
        (local.get $5)
        (i32.const 20)
       )
      )
     )
     (local.set $0
      (i32.add
       (local.get $0)
       (i32.const 16)
      )
     )
     (br_if $label$5
      (i32.ne
       (local.get $10)
       (local.tee $9
        (i32.add
         (local.get $9)
         (i32.const 4)
        )
       )
      )
     )
    )
   )
   (br_if $label$3
    (i32.eqz
     (local.get $8)
    )
   )
   (local.set $0
    (i32.add
     (i32.add
      (local.get $3)
      (local.tee $2
       (i32.shl
        (local.get $9)
        (i32.const 2)
       )
      )
     )
     (i32.const 8)
    )
   )
   (local.set $2
    (i32.add
     (i32.add
      (local.get $2)
      (local.get $7)
     )
     (i32.const 8)
    )
   )
   (loop $label$6
    (i32.store
     (local.get $2)
     (i32.load
      (local.get $0)
     )
    )
    (local.set $0
     (i32.add
      (local.get $0)
      (i32.const 4)
     )
    )
    (local.set $2
     (i32.add
      (local.get $2)
      (i32.const 4)
     )
    )
    (br_if $label$6
     (local.tee $8
      (i32.add
       (local.get $8)
       (i32.const -1)
      )
     )
    )
   )
  )
  (block $label$7
   (br_if $label$7
    (i32.lt_s
     (local.get $6)
     (i32.const 1)
    )
   )
   (local.set $8
    (i32.and
     (local.get $6)
     (i32.const 3)
    )
   )
   (local.set $9
    (i32.const 0)
   )
   (block $label$8
    (br_if $label$8
     (i32.lt_u
      (i32.add
       (local.get $6)
       (i32.const -1)
      )
      (i32.const 3)
     )
    )
    (local.set $3
     (i32.and
      (local.get $6)
      (i32.const -4)
     )
    )
    (local.set $10
     (i32.add
      (local.get $7)
      (i32.shl
       (local.get $4)
       (i32.const 2)
      )
     )
    )
    (local.set $0
     (i32.const 0)
    )
    (local.set $9
     (i32.const 0)
    )
    (loop $label$9
     (i32.store
      (local.tee $2
       (i32.add
        (local.get $10)
        (local.get $0)
       )
      )
      (i32.load
       (i32.add
        (local.tee $5
         (i32.add
          (local.get $1)
          (local.get $0)
         )
        )
        (i32.const 8)
       )
      )
     )
     (i32.store
      (i32.add
       (local.get $2)
       (i32.const 4)
      )
      (i32.load
       (i32.add
        (local.get $5)
        (i32.const 12)
       )
      )
     )
     (i32.store
      (i32.add
       (local.get $2)
       (i32.const 8)
      )
      (i32.load
       (i32.add
        (local.get $5)
        (i32.const 16)
       )
      )
     )
     (i32.store
      (i32.add
       (local.get $2)
       (i32.const 12)
      )
      (i32.load
       (i32.add
        (local.get $5)
        (i32.const 20)
       )
      )
     )
     (local.set $0
      (i32.add
       (local.get $0)
       (i32.const 16)
      )
     )
     (br_if $label$9
      (i32.ne
       (local.get $3)
       (local.tee $9
        (i32.add
         (local.get $9)
         (i32.const 4)
        )
       )
      )
     )
    )
   )
   (br_if $label$7
    (i32.eqz
     (local.get $8)
    )
   )
   (local.set $0
    (i32.add
     (i32.add
      (local.get $1)
      (i32.shl
       (local.get $9)
       (i32.const 2)
      )
     )
     (i32.const 8)
    )
   )
   (local.set $2
    (i32.add
     (local.get $7)
     (i32.shl
      (i32.add
       (local.get $9)
       (local.get $4)
      )
      (i32.const 2)
     )
    )
   )
   (loop $label$10
    (i32.store
     (local.get $2)
     (i32.load
      (local.get $0)
     )
    )
    (local.set $0
     (i32.add
      (local.get $0)
      (i32.const 4)
     )
    )
    (local.set $2
     (i32.add
      (local.get $2)
      (i32.const 4)
     )
    )
    (br_if $label$10
     (local.tee $8
      (i32.add
       (local.get $8)
       (i32.const -1)
      )
     )
    )
   )
  )
  (local.get $7)
 )
 (func $List_create (param $0 i32) (param $1 i32) (result i32)
  (local $2 i32)
  (local $3 i32)
  (local $4 i32)
  (block $label$1
   (block $label$2
    (br_if $label$2
     (local.get $0)
    )
    (local.set $1
     (i32.const 8512)
    )
    (br $label$1)
   )
   (local.set $2
    (i32.add
     (i32.add
      (i32.shl
       (local.get $0)
       (i32.const 2)
      )
      (local.get $1)
     )
     (i32.const -4)
    )
   )
   (local.set $3
    (i32.const 8512)
   )
   (loop $label$3
    (local.set $1
     (call $GC_allocate
      (i32.const 1)
      (i32.const 3)
     )
    )
    (local.set $4
     (i32.load
      (local.get $2)
     )
    )
    (i32.store offset=8
     (local.get $1)
     (local.get $3)
    )
    (i32.store offset=4
     (local.get $1)
     (local.get $4)
    )
    (i32.store
     (local.get $1)
     (i32.const 1073741827)
    )
    (local.set $2
     (i32.add
      (local.get $2)
      (i32.const -4)
     )
    )
    (local.set $3
     (local.get $1)
    )
    (br_if $label$3
     (local.tee $0
      (i32.add
       (local.get $0)
       (i32.const -1)
      )
     )
    )
   )
  )
  (local.get $1)
 )
 (func $eval_List_cons (param $0 i32) (result i32)
  (local $1 i64)
  (local.set $1
   (i64.load align=4
    (local.get $0)
   )
  )
  (i64.store offset=4 align=4
   (local.tee $0
    (call $GC_allocate
     (i32.const 1)
     (i32.const 3)
    )
   )
   (local.get $1)
  )
  (i32.store
   (local.get $0)
   (i32.const 1073741827)
  )
  (local.get $0)
 )
 (func $newCons (param $0 i32) (param $1 i32) (result i32)
  (local $2 i32)
  (i32.store offset=8
   (local.tee $2
    (call $GC_allocate
     (i32.const 1)
     (i32.const 3)
    )
   )
   (local.get $1)
  )
  (i32.store offset=4
   (local.get $2)
   (local.get $0)
  )
  (i32.store
   (local.get $2)
   (i32.const 1073741827)
  )
  (local.get $2)
 )
 (func $eval_List_append (param $0 i32) (result i32)
  (local $1 i32)
  (local $2 i32)
  (local $3 i32)
  (local.set $1
   (i32.load offset=4
    (local.get $0)
   )
  )
  (block $label$1
   (br_if $label$1
    (i32.eq
     (local.tee $0
      (i32.load
       (local.get $0)
      )
     )
     (i32.const 8512)
    )
   )
   (block $label$2
    (br_if $label$2
     (i32.ne
      (local.get $1)
      (i32.const 8512)
     )
    )
    (return
     (local.get $0)
    )
   )
   (local.set $2
    (local.get $0)
   )
   (loop $label$3
    (i32.store offset=8
     (local.tee $3
      (call $GC_allocate
       (i32.const 1)
       (i32.const 3)
      )
     )
     (local.get $1)
    )
    (i64.store align=4
     (local.get $3)
     (i64.const 1073741827)
    )
    (local.set $1
     (local.get $3)
    )
    (br_if $label$3
     (i32.ne
      (local.tee $2
       (i32.load offset=8
        (local.get $2)
       )
      )
      (i32.const 8512)
     )
    )
   )
   (local.set $1
    (local.get $3)
   )
   (loop $label$4
    (i32.store offset=4
     (local.get $1)
     (i32.load offset=4
      (local.get $0)
     )
    )
    (local.set $1
     (i32.load offset=8
      (local.get $1)
     )
    )
    (br_if $label$4
     (i32.ne
      (local.tee $0
       (i32.load offset=8
        (local.get $0)
       )
      )
      (i32.const 8512)
     )
    )
   )
   (local.set $1
    (local.get $3)
   )
  )
  (local.get $1)
 )
 (func $eval_List_map2 (param $0 i32) (result i32)
  (local $1 i32)
  (local $2 i32)
  (local $3 i32)
  (local $4 i32)
  (local $5 i32)
  (local $6 i32)
  (local $7 i32)
  (local $8 i32)
  (global.set $__stack_pointer
   (local.tee $1
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 16)
    )
   )
  )
  (local.set $2
   (i32.load offset=8
    (local.get $0)
   )
  )
  (local.set $3
   (i32.load
    (local.get $0)
   )
  )
  (local.set $4
   (i32.load offset=4
    (local.get $0)
   )
  )
  (local.set $0
   (i32.load offset=7844
    (i32.const 0)
   )
  )
  (i32.store offset=8
   (local.tee $5
    (call $GC_allocate
     (i32.const 1)
     (i32.const 3)
    )
   )
   (local.get $0)
  )
  (i64.store align=4
   (local.get $5)
   (i64.const 1073741827)
  )
  (block $label$1
   (br_if $label$1
    (i32.eq
     (local.get $4)
     (local.tee $6
      (i32.load offset=7844
       (i32.const 0)
      )
     )
    )
   )
   (br_if $label$1
    (i32.eq
     (local.get $2)
     (local.get $6)
    )
   )
   (local.set $6
    (local.get $5)
   )
   (block $label$2
    (loop $label$3
     (i32.store offset=8
      (local.get $1)
      (i32.load offset=4
       (local.get $4)
      )
     )
     (i32.store offset=12
      (local.get $1)
      (i32.load offset=4
       (local.get $2)
      )
     )
     (local.set $7
      (call $Utils_apply
       (local.get $3)
       (i32.const 2)
       (i32.add
        (local.get $1)
        (i32.const 8)
       )
      )
     )
     (local.set $8
      (i32.load offset=7844
       (i32.const 0)
      )
     )
     (i32.store offset=8
      (local.tee $0
       (call $GC_allocate
        (i32.const 1)
        (i32.const 3)
       )
      )
      (local.get $8)
     )
     (i32.store
      (local.get $0)
      (i32.const 1073741827)
     )
     (i32.store offset=8
      (local.get $6)
      (local.get $0)
     )
     (i32.store offset=4
      (local.get $0)
      (local.get $7)
     )
     (br_if $label$2
      (i32.eq
       (local.tee $4
        (i32.load offset=8
         (local.get $4)
        )
       )
       (local.tee $7
        (i32.load offset=7844
         (i32.const 0)
        )
       )
      )
     )
     (local.set $6
      (local.get $0)
     )
     (br_if $label$3
      (i32.ne
       (local.tee $2
        (i32.load offset=8
         (local.get $2)
        )
       )
       (local.get $7)
      )
     )
    )
   )
   (local.set $0
    (i32.load offset=8
     (local.get $5)
    )
   )
  )
  (global.set $__stack_pointer
   (i32.add
    (local.get $1)
    (i32.const 16)
   )
  )
  (local.get $0)
 )
 (func $eval_List_sortBy (param $0 i32) (result i32)
  (i32.const 8512)
 )
 (func $Platform_initOnIntercept (param $0 i32) (param $1 i32)
  (i32.store offset=8708
   (i32.const 0)
   (local.get $1)
  )
  (i32.store offset=8704
   (i32.const 0)
   (local.get $0)
  )
  (local.set $1
   (i32.load offset=8788
    (i32.const 0)
   )
  )
  (i32.store
   (local.tee $0
    (call $GC_allocate
     (i32.const 1)
     (i32.const 3)
    )
   )
   (i32.const 1073741827)
  )
  (i32.store offset=8
   (local.get $0)
   (local.get $1)
  )
  (i32.store offset=4
   (local.get $0)
   (i32.const 8712)
  )
  (i32.store offset=8788
   (i32.const 0)
   (local.get $0)
  )
  (i32.store16 offset=8794
   (i32.const 0)
   (i32.add
    (i32.load16_u offset=8794
     (i32.const 0)
    )
    (i32.const -1)
   )
  )
  (i32.store
   (local.tee $1
    (call $GC_allocate
     (i32.const 1)
     (i32.const 3)
    )
   )
   (i32.const 1073741827)
  )
  (i32.store offset=8
   (local.get $1)
   (local.get $0)
  )
  (i32.store offset=4
   (local.get $1)
   (i32.const 8704)
  )
  (i32.store offset=8788
   (i32.const 0)
   (local.get $1)
  )
  (i32.store16 offset=8794
   (i32.const 0)
   (i32.add
    (i32.load16_u offset=8794
     (i32.const 0)
    )
    (i32.const -1)
   )
  )
  (i32.store
   (local.tee $0
    (call $GC_allocate
     (i32.const 1)
     (i32.const 3)
    )
   )
   (i32.const 1073741827)
  )
  (i32.store offset=8
   (local.get $0)
   (local.get $1)
  )
  (i32.store offset=4
   (local.get $0)
   (i32.const 8708)
  )
  (i32.store offset=8788
   (i32.const 0)
   (local.get $0)
  )
  (i32.store16 offset=8794
   (i32.const 0)
   (i32.add
    (i32.load16_u offset=8794
     (i32.const 0)
    )
    (i32.const -1)
   )
  )
 )
 (func $GC_register_root (param $0 i32)
  (local $1 i32)
  (local $2 i32)
  (local.set $1
   (i32.load offset=8788
    (i32.const 0)
   )
  )
  (i32.store
   (local.tee $2
    (call $GC_allocate
     (i32.const 1)
     (i32.const 3)
    )
   )
   (i32.const 1073741827)
  )
  (i32.store offset=8
   (local.get $2)
   (local.get $1)
  )
  (i32.store offset=4
   (local.get $2)
   (local.get $0)
  )
  (i32.store offset=8788
   (i32.const 0)
   (local.get $2)
  )
  (i32.store16 offset=8794
   (i32.const 0)
   (i32.add
    (i32.load16_u offset=8794
     (i32.const 0)
    )
    (i32.const -1)
   )
  )
 )
 (func $eval_sendToApp_revArgs (param $0 i32) (result i32)
  (local $1 i32)
  (local $2 i32)
  (global.set $__stack_pointer
   (local.tee $1
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 16)
    )
   )
  )
  (i32.store offset=8
   (local.get $1)
   (i32.load offset=4
    (local.get $0)
   )
  )
  (i32.store offset=12
   (local.get $1)
   (i32.load offset=8712
    (i32.const 0)
   )
  )
  (local.set $0
   (i32.load
    (local.get $0)
   )
  )
  (i32.store offset=8712
   (i32.const 0)
   (i32.load offset=4
    (local.tee $2
     (call $Utils_apply
      (i32.load offset=8704
       (i32.const 0)
      )
      (i32.const 2)
      (i32.add
       (local.get $1)
       (i32.const 8)
      )
     )
    )
   )
  )
  (call $jsStepper
   (local.get $0)
  )
  (i32.store offset=4
   (local.get $1)
   (i32.load offset=8712
    (i32.const 0)
   )
  )
  (local.set $0
   (i32.load offset=8
    (local.get $2)
   )
  )
  (local.set $2
   (call $Utils_apply
    (i32.load offset=8708
     (i32.const 0)
    )
    (i32.const 1)
    (i32.add
     (local.get $1)
     (i32.const 4)
    )
   )
  )
  (call $Platform_enqueueEffects
   (i32.load offset=8716
    (i32.const 0)
   )
   (local.get $0)
   (local.get $2)
  )
  (global.set $__stack_pointer
   (i32.add
    (local.get $1)
    (i32.const 16)
   )
  )
  (i32.const 0)
 )
 (func $Platform_enqueueEffects (param $0 i32) (param $1 i32) (param $2 i32)
  (local $3 i32)
  (i32.store offset=12
   (local.tee $3
    (call $GC_allocate
     (i32.const 1)
     (i32.const 4)
    )
   )
   (local.get $2)
  )
  (i32.store offset=8
   (local.get $3)
   (local.get $1)
  )
  (i32.store offset=4
   (local.get $3)
   (local.get $0)
  )
  (i32.store
   (local.get $3)
   (i32.const 1610612740)
  )
  (i32.store
   (local.tee $0
    (call $GC_allocate
     (i32.const 1)
     (i32.const 3)
    )
   )
   (i32.const 1073741827)
  )
  (i32.store offset=8
   (local.get $0)
   (i32.const 8512)
  )
  (i32.store offset=4
   (local.get $0)
   (local.get $3)
  )
  (block $label$1
   (br_if $label$1
    (i32.eq
     (local.tee $3
      (i32.load offset=8084
       (i32.const 0)
      )
     )
     (i32.const 8512)
    )
   )
   (i32.store offset=8
    (local.get $3)
    (local.get $0)
   )
  )
  (i32.store offset=8084
   (i32.const 0)
   (local.get $0)
  )
  (block $label$2
   (br_if $label$2
    (i32.ne
     (local.tee $3
      (i32.load offset=8080
       (i32.const 0)
      )
     )
     (i32.const 8512)
    )
   )
   (i32.store offset=8080
    (i32.const 0)
    (local.get $0)
   )
   (local.set $3
    (local.get $0)
   )
  )
  (block $label$3
   (br_if $label$3
    (i32.load8_u offset=8732
     (i32.const 0)
    )
   )
   (i32.store8 offset=8732
    (i32.const 0)
    (i32.const 1)
   )
   (block $label$4
    (br_if $label$4
     (i32.eq
      (local.get $3)
      (i32.const 8512)
     )
    )
    (loop $label$5
     (i32.store offset=8080
      (i32.const 0)
      (i32.load offset=8
       (local.get $3)
      )
     )
     (br_if $label$4
      (i32.eqz
       (local.tee $3
        (i32.load offset=4
         (local.get $3)
        )
       )
      )
     )
     (call $Platform_dispatchEffects
      (i32.load offset=4
       (local.get $3)
      )
      (i32.load offset=8
       (local.get $3)
      )
      (i32.load offset=12
       (local.get $3)
      )
     )
     (br_if $label$5
      (i32.ne
       (local.tee $3
        (i32.load offset=8080
         (i32.const 0)
        )
       )
       (i32.const 8512)
      )
     )
    )
   )
   (i32.store8 offset=8732
    (i32.const 0)
    (i32.const 0)
   )
  )
 )
 (func $Platform_dispatchEffects (param $0 i32) (param $1 i32) (param $2 i32)
  (local $3 i32)
  (local $4 i32)
  (local $5 i32)
  (local $6 i32)
  (local $7 i32)
  (local $8 i32)
  (i32.store offset=4
   (local.tee $4
    (call $GC_allocate
     (i32.const 1)
     (local.tee $3
      (i32.and
       (i32.load
        (local.get $0)
       )
       (i32.const 268435455)
      )
     )
    )
   )
   (i32.const 1024000)
  )
  (i32.store
   (local.get $4)
   (i32.or
    (local.get $3)
    (i32.const 1879048192)
   )
  )
  (block $label$1
   (block $label$2
    (br_if $label$2
     (i32.eqz
      (local.tee $5
       (i32.add
        (local.get $3)
        (i32.const -2)
       )
      )
     )
    )
    (local.set $6
     (i32.and
      (local.get $5)
      (i32.const 7)
     )
    )
    (local.set $7
     (i32.const 0)
    )
    (block $label$3
     (br_if $label$3
      (i32.lt_u
       (i32.add
        (local.get $3)
        (i32.const -3)
       )
       (i32.const 7)
      )
     )
     (local.set $3
      (i32.add
       (local.get $4)
       (i32.const 20)
      )
     )
     (local.set $8
      (i32.and
       (local.get $5)
       (i32.const -8)
      )
     )
     (local.set $7
      (i32.const 0)
     )
     (loop $label$4
      (i64.store align=4
       (i32.add
        (local.get $3)
        (i32.const 12)
       )
       (i64.const 0)
      )
      (i64.store align=4
       (i32.add
        (local.get $3)
        (i32.const 4)
       )
       (i64.const 0)
      )
      (i64.store align=4
       (i32.add
        (local.get $3)
        (i32.const -4)
       )
       (i64.const 0)
      )
      (i64.store align=4
       (i32.add
        (local.get $3)
        (i32.const -12)
       )
       (i64.const 0)
      )
      (local.set $3
       (i32.add
        (local.get $3)
        (i32.const 32)
       )
      )
      (br_if $label$4
       (i32.ne
        (local.get $8)
        (local.tee $7
         (i32.add
          (local.get $7)
          (i32.const 8)
         )
        )
       )
      )
     )
    )
    (block $label$5
     (br_if $label$5
      (i32.eqz
       (local.get $6)
      )
     )
     (local.set $3
      (i32.add
       (i32.add
        (i32.shl
         (local.get $7)
         (i32.const 2)
        )
        (local.get $4)
       )
       (i32.const 8)
      )
     )
     (loop $label$6
      (i32.store
       (local.get $3)
       (i32.const 0)
      )
      (local.set $3
       (i32.add
        (local.get $3)
        (i32.const 4)
       )
      )
      (br_if $label$6
       (local.tee $6
        (i32.add
         (local.get $6)
         (i32.const -1)
        )
       )
      )
     )
    )
    (call $Platform_gatherEffects
     (i32.const 1)
     (local.get $1)
     (local.get $4)
     (i32.const 8512)
    )
    (call $Platform_gatherEffects
     (i32.const 0)
     (local.get $2)
     (local.get $4)
     (i32.const 8512)
    )
    (br_if $label$1
     (i32.eqz
      (local.get $5)
     )
    )
    (local.set $8
     (i32.add
      (local.get $4)
      (i32.const 8)
     )
    )
    (local.set $4
     (i32.add
      (local.get $0)
      (i32.const 8)
     )
    )
    (loop $label$7
     (local.set $3
      (i32.load
       (local.get $4)
      )
     )
     (block $label$8
      (br_if $label$8
       (local.tee $7
        (i32.load
         (local.get $8)
        )
       )
      )
      (i32.store offset=12
       (local.tee $7
        (call $GC_allocate
         (i32.const 1)
         (i32.const 4)
        )
       )
       (i32.const 8512)
      )
      (i32.store offset=8
       (local.get $7)
       (i32.const 8512)
      )
      (i64.store align=4
       (local.get $7)
       (i64.const 4398065570021380)
      )
     )
     (i32.store
      (local.tee $6
       (call $GC_allocate
        (i32.const 1)
        (i32.const 3)
       )
      )
      (i32.const 1073741827)
     )
     (i32.store offset=8
      (local.get $6)
      (i32.const 8512)
     )
     (i32.store offset=4
      (local.get $6)
      (local.get $7)
     )
     (block $label$9
      (br_if $label$9
       (i32.eq
        (local.tee $7
         (i32.load
          (i32.add
           (local.get $3)
           (i32.const 20)
          )
         )
        )
        (i32.const 8512)
       )
      )
      (i32.store offset=8
       (local.get $7)
       (local.get $6)
      )
     )
     (i32.store offset=20
      (local.get $3)
      (local.get $6)
     )
     (block $label$10
      (br_if $label$10
       (i32.ne
        (i32.load offset=16
         (local.get $3)
        )
        (i32.const 8512)
       )
      )
      (i32.store offset=16
       (local.get $3)
       (local.get $6)
      )
     )
     (call $Scheduler_enqueue
      (local.get $3)
     )
     (local.set $8
      (i32.add
       (local.get $8)
       (i32.const 4)
      )
     )
     (local.set $4
      (i32.add
       (local.get $4)
       (i32.const 4)
      )
     )
     (br_if $label$7
      (local.tee $5
       (i32.add
        (local.get $5)
        (i32.const -1)
       )
      )
     )
     (br $label$1)
    )
   )
   (call $Platform_gatherEffects
    (i32.const 1)
    (local.get $1)
    (local.get $4)
    (i32.const 8512)
   )
   (call $Platform_gatherEffects
    (i32.const 0)
    (local.get $2)
    (local.get $4)
    (i32.const 8512)
   )
  )
 )
 (func $Platform_initializeEffects (result i32)
  (local $0 i32)
  (local $1 i32)
  (local $2 i32)
  (global.set $__stack_pointer
   (local.tee $0
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 16)
    )
   )
  )
  (block $label$1
   (block $label$2
    (br_if $label$2
     (i32.eqz
      (i32.load offset=8708
       (i32.const 0)
      )
     )
    )
    (br_if $label$1
     (i32.load offset=8712
      (i32.const 0)
     )
    )
   )
   (call $safe_printf
    (i32.const 4292)
    (i32.const 0)
   )
   (call $exit
    (i32.const -1)
   )
  )
  (i32.store
   (local.tee $2
    (call $GC_allocate
     (i32.const 1)
     (i32.and
      (local.tee $1
       (i32.add
        (i32.load
         (i32.const 0)
        )
        (i32.const 2)
       )
      )
      (i32.const 1073741823)
     )
    )
   )
   (i32.or
    (i32.and
     (local.get $1)
     (i32.const 268435455)
    )
    (i32.const 1879048192)
   )
  )
  (i32.store offset=4
   (local.get $2)
   (i32.const 1024000)
  )
  (i32.store offset=8716
   (i32.const 0)
   (local.get $2)
  )
  (local.set $1
   (i32.load offset=8788
    (i32.const 0)
   )
  )
  (i32.store
   (local.tee $2
    (call $GC_allocate
     (i32.const 1)
     (i32.const 3)
    )
   )
   (i32.const 1073741827)
  )
  (i32.store offset=8
   (local.get $2)
   (local.get $1)
  )
  (i32.store offset=4
   (local.get $2)
   (i32.const 8716)
  )
  (i32.store offset=8788
   (i32.const 0)
   (local.get $2)
  )
  (i32.store16 offset=8794
   (i32.const 0)
   (i32.add
    (i32.load16_u offset=8794
     (i32.const 0)
    )
    (i32.const -1)
   )
  )
  (i64.store offset=32 align=4
   (local.tee $2
    (call $GC_allocate
     (i32.const 1)
     (i32.const 10)
    )
   )
   (i64.const 0)
  )
  (i64.store offset=24 align=4
   (local.get $2)
   (i64.const 0)
  )
  (i64.store offset=16 align=4
   (local.get $2)
   (i64.const 0)
  )
  (i64.store offset=8 align=4
   (local.get $2)
   (i64.const 0)
  )
  (i64.store align=4
   (local.get $2)
   (i64.const 1879048202)
  )
  (i32.store offset=8720
   (i32.const 0)
   (local.get $2)
  )
  (local.set $1
   (i32.load offset=8788
    (i32.const 0)
   )
  )
  (i32.store
   (local.tee $2
    (call $GC_allocate
     (i32.const 1)
     (i32.const 3)
    )
   )
   (i32.const 1073741827)
  )
  (i32.store offset=8
   (local.get $2)
   (local.get $1)
  )
  (i32.store offset=4
   (local.get $2)
   (i32.const 8720)
  )
  (i32.store offset=8788
   (i32.const 0)
   (local.get $2)
  )
  (i32.store16 offset=8794
   (i32.const 0)
   (i32.add
    (i32.load16_u offset=8794
     (i32.const 0)
    )
    (i32.const -1)
   )
  )
  (i64.store align=4
   (local.tee $2
    (call $GC_allocate
     (i32.const 1)
     (i32.const 4)
    )
   )
   (i64.const 562956932743172)
  )
  (i32.store offset=8
   (local.get $2)
   (i32.const 3)
  )
  (local.set $2
   (call $Platform_setupEffects
    (i32.load offset=8716
     (i32.const 0)
    )
    (local.get $2)
   )
  )
  (i32.store offset=12
   (local.get $0)
   (i32.load offset=8712
    (i32.const 0)
   )
  )
  (local.set $1
   (call $Utils_apply
    (i32.load offset=8708
     (i32.const 0)
    )
    (i32.const 1)
    (i32.add
     (local.get $0)
     (i32.const 12)
    )
   )
  )
  (call $Platform_enqueueEffects
   (i32.load offset=8716
    (i32.const 0)
   )
   (i32.load offset=8724
    (i32.const 0)
   )
   (local.get $1)
  )
  (i32.store offset=8724
   (i32.const 0)
   (i32.const 0)
  )
  (global.set $__stack_pointer
   (i32.add
    (local.get $0)
    (i32.const 16)
   )
  )
  (local.get $2)
 )
 (func $Platform_setupEffects (param $0 i32) (param $1 i32) (result i32)
  (local $2 i32)
  (local $3 i32)
  (local $4 i32)
  (local $5 i32)
  (local $6 i32)
  (local $7 i32)
  (local $8 i32)
  (local $9 i32)
  (global.set $__stack_pointer
   (local.tee $2
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 32)
    )
   )
  )
  (block $label$1
   (block $label$2
    (br_if $label$2
     (i32.load
      (i32.const 0)
     )
    )
    (local.set $3
     (i32.const 8512)
    )
    (br $label$1)
   )
   (local.set $4
    (i32.const 8)
   )
   (local.set $3
    (i32.const 8512)
   )
   (local.set $5
    (i32.const 0)
   )
   (loop $label$3
    (block $label$4
     (block $label$5
      (block $label$6
       (block $label$7
        (br_table $label$4 $label$6 $label$7 $label$6
         (i32.load offset=4
          (local.tee $6
           (i32.load
            (i32.add
             (i32.load offset=8728
              (i32.const 0)
             )
             (local.get $4)
            )
           )
          )
         )
        )
       )
       (i64.store align=4
        (local.tee $7
         (call $GC_allocate
          (i32.const 1)
          (i32.const 6)
         )
        )
        (i64.const 3489660934)
       )
       (i32.store offset=20
        (local.get $7)
        (i32.const 0)
       )
       (i64.store offset=12 align=4
        (local.get $7)
        (i64.const 0)
       )
       (i32.store offset=8
        (local.get $7)
        (i32.const 0)
       )
       (i32.store offset=8
        (local.get $6)
        (local.get $7)
       )
       (i32.store offset=12
        (local.tee $7
         (call $GC_allocate
          (i32.const 1)
          (i32.const 4)
         )
        )
        (local.get $6)
       )
       (i32.store offset=8
        (local.get $7)
        (i32.const 4)
       )
       (i64.store align=4
        (local.get $7)
        (i64.const 1125906886164484)
       )
       (i32.store offset=12
        (local.get $6)
        (local.get $7)
       )
       (i32.store
        (i32.add
         (local.get $6)
         (i32.const 36)
        )
        (i32.const 8512)
       )
       (local.set $7
        (call $Wrapper_setupIncomingPort
         (local.get $5)
        )
       )
       (i32.store offset=4
        (local.tee $8
         (call $GC_allocate
          (i32.const 1)
          (i32.const 2)
         )
        )
        (local.get $7)
       )
       (i32.store
        (local.get $8)
        (i32.const -1342177278)
       )
       (br $label$5)
      )
      (i64.store
       (i32.add
        (local.get $2)
        (i32.const 24)
       )
       (i64.load offset=6280
        (i32.const 0)
       )
      )
      (i64.store offset=16
       (local.get $2)
       (i64.load offset=6272
        (i32.const 0)
       )
      )
      (i32.store offset=12
       (local.get $2)
       (i32.add
        (local.get $2)
        (i32.const 16)
       )
      )
      (i32.store offset=8
       (local.get $6)
       (call $Utils_apply
        (i32.const 8112)
        (i32.const 1)
        (i32.add
         (local.get $2)
         (i32.const 12)
        )
       )
      )
      (local.set $8
       (i32.load offset=8
        (local.tee $7
         (call $Wrapper_setupOutgoingPort)
        )
       )
      )
      (local.set $9
       (i32.load offset=4
        (local.get $7)
       )
      )
      (i32.store offset=16
       (local.tee $7
        (call $GC_allocate
         (i32.const 1)
         (i32.const 5)
        )
       )
       (local.get $6)
      )
      (i32.store offset=12
       (local.get $7)
       (local.get $9)
      )
      (i32.store offset=8
       (local.get $7)
       (i32.const 5)
      )
      (i64.store align=4
       (local.get $7)
       (i64.const 1407386157842437)
      )
      (i32.store offset=12
       (local.get $6)
       (local.get $7)
      )
     )
     (local.set $9
      (i32.load offset=28
       (local.get $6)
      )
     )
     (i32.store offset=8
      (local.tee $7
       (call $GC_allocate
        (i32.const 1)
        (i32.const 3)
       )
      )
      (local.get $8)
     )
     (i32.store offset=4
      (local.get $7)
      (local.get $9)
     )
     (i32.store
      (local.get $7)
      (i32.const 1342177283)
     )
     (i32.store offset=8
      (local.tee $8
       (call $GC_allocate
        (i32.const 1)
        (i32.const 3)
       )
      )
      (local.get $3)
     )
     (i32.store offset=4
      (local.get $8)
      (local.get $7)
     )
     (i32.store
      (local.get $8)
      (i32.const 1073741827)
     )
     (local.set $3
      (local.get $8)
     )
    )
    (i32.store offset=8
     (local.tee $8
      (call $GC_allocate
       (i32.const 1)
       (i32.const 4)
      )
     )
     (local.get $1)
    )
    (i64.store align=4
     (local.get $8)
     (i64.const 4398048390152196)
    )
    (i32.store offset=16
     (local.tee $7
      (call $GC_allocate
       (i32.const 1)
       (i32.const 5)
      )
     )
     (local.get $8)
    )
    (i32.store offset=12
     (local.get $7)
     (local.get $6)
    )
    (i32.store offset=8
     (local.get $7)
     (i32.const 6)
    )
    (i64.store align=4
     (local.get $7)
     (i64.const 844436204421125)
    )
    (local.set $9
     (i32.load offset=8
      (local.get $6)
     )
    )
    (i32.store offset=20
     (local.tee $6
      (call $GC_allocate
       (i32.const 1)
       (i32.const 6)
      )
     )
     (local.get $9)
    )
    (i32.store offset=16
     (local.get $6)
     (i32.const 0)
    )
    (i32.store offset=12
     (local.get $6)
     (local.get $7)
    )
    (i32.store offset=8
     (local.get $6)
     (i32.const 0)
    )
    (i64.store align=4
     (local.get $6)
     (i64.const 16374562822)
    )
    (i32.store offset=16
     (local.get $2)
     (local.get $6)
    )
    (i32.store offset=12
     (local.get $8)
     (local.tee $6
      (call $eval_Scheduler_rawSpawn
       (i32.add
        (local.get $2)
        (i32.const 16)
       )
      )
     )
    )
    (i32.store
     (i32.add
      (local.get $0)
      (local.get $4)
     )
     (local.get $6)
    )
    (local.set $4
     (i32.add
      (local.get $4)
      (i32.const 4)
     )
    )
    (br_if $label$3
     (i32.lt_u
      (local.tee $5
       (i32.add
        (local.get $5)
        (i32.const 1)
       )
      )
      (i32.load
       (i32.const 0)
      )
     )
    )
   )
  )
  (global.set $__stack_pointer
   (i32.add
    (local.get $2)
    (i32.const 32)
   )
  )
  (local.get $3)
 )
 (func $newClosure (param $0 i32) (param $1 i32) (param $2 i32) (param $3 i32) (result i32)
  (local $4 i32)
  (local $5 i32)
  (local $6 i32)
  (local $7 i32)
  (i32.store offset=8
   (local.tee $4
    (call $GC_allocate
     (i32.const 1)
     (i32.add
      (local.get $0)
      (i32.const 3)
     )
    )
   )
   (local.get $2)
  )
  (i32.store16 offset=6
   (local.get $4)
   (local.get $1)
  )
  (i32.store16 offset=4
   (local.get $4)
   (local.get $0)
  )
  (i32.store
   (local.get $4)
   (i32.add
    (local.get $0)
    (i32.const -1610612733)
   )
  )
  (block $label$1
   (br_if $label$1
    (i32.eqz
     (local.get $3)
    )
   )
   (br_if $label$1
    (i32.eqz
     (local.get $0)
    )
   )
   (local.set $5
    (i32.and
     (local.get $0)
     (i32.const 3)
    )
   )
   (local.set $6
    (i32.const 0)
   )
   (block $label$2
    (br_if $label$2
     (i32.lt_u
      (i32.add
       (local.get $0)
       (i32.const -1)
      )
      (i32.const 3)
     )
    )
    (local.set $7
     (i32.and
      (local.get $0)
      (i32.const 65532)
     )
    )
    (local.set $0
     (i32.const 0)
    )
    (local.set $6
     (i32.const 0)
    )
    (loop $label$3
     (i32.store
      (i32.add
       (local.tee $1
        (i32.add
         (local.get $4)
         (local.get $0)
        )
       )
       (i32.const 12)
      )
      (i32.load
       (local.tee $2
        (i32.add
         (local.get $3)
         (local.get $0)
        )
       )
      )
     )
     (i32.store
      (i32.add
       (local.get $1)
       (i32.const 16)
      )
      (i32.load
       (i32.add
        (local.get $2)
        (i32.const 4)
       )
      )
     )
     (i32.store
      (i32.add
       (local.get $1)
       (i32.const 20)
      )
      (i32.load
       (i32.add
        (local.get $2)
        (i32.const 8)
       )
      )
     )
     (i32.store
      (i32.add
       (local.get $1)
       (i32.const 24)
      )
      (i32.load
       (i32.add
        (local.get $2)
        (i32.const 12)
       )
      )
     )
     (local.set $0
      (i32.add
       (local.get $0)
       (i32.const 16)
      )
     )
     (br_if $label$3
      (i32.ne
       (local.get $7)
       (local.tee $6
        (i32.add
         (local.get $6)
         (i32.const 4)
        )
       )
      )
     )
    )
   )
   (br_if $label$1
    (i32.eqz
     (local.get $5)
    )
   )
   (local.set $0
    (i32.add
     (local.get $3)
     (local.tee $1
      (i32.shl
       (local.get $6)
       (i32.const 2)
      )
     )
    )
   )
   (local.set $1
    (i32.add
     (i32.add
      (local.get $1)
      (local.get $4)
     )
     (i32.const 12)
    )
   )
   (loop $label$4
    (i32.store
     (local.get $1)
     (i32.load
      (local.get $0)
     )
    )
    (local.set $0
     (i32.add
      (local.get $0)
      (i32.const 4)
     )
    )
    (local.set $1
     (i32.add
      (local.get $1)
      (i32.const 4)
     )
    )
    (br_if $label$4
     (local.tee $5
      (i32.add
       (local.get $5)
       (i32.const -1)
      )
     )
    )
   )
  )
  (local.get $4)
 )
 (func $eval_Platform_incomingPortOnEffects (param $0 i32) (result i32)
  (local $1 i32)
  (i32.store offset=36
   (local.tee $1
    (i32.load
     (local.get $0)
    )
   )
   (i32.load offset=8
    (local.get $0)
   )
  )
  (i32.load offset=8
   (local.get $1)
  )
 )
 (func $eval_Platform_outgoingPortOnEffects (param $0 i32) (result i32)
  (local $1 i32)
  (local $2 i32)
  (local $3 i32)
  (local $4 i32)
  (global.set $__stack_pointer
   (local.tee $1
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 16)
    )
   )
  )
  (local.set $2
   (i32.load offset=4
    (local.get $0)
   )
  )
  (block $label$1
   (br_if $label$1
    (i32.eq
     (local.tee $3
      (i32.load offset=12
       (local.get $0)
      )
     )
     (i32.const 8512)
    )
   )
   (local.set $0
    (i32.load
     (local.get $0)
    )
   )
   (local.set $4
    (i32.load offset=32
     (local.get $2)
    )
   )
   (loop $label$2
    (i32.store offset=12
     (local.get $1)
     (i32.load offset=4
      (local.get $3)
     )
    )
    (i32.store offset=8
     (local.get $1)
     (i32.load offset=8
      (call $Utils_apply
       (local.get $4)
       (i32.const 1)
       (i32.add
        (local.get $1)
        (i32.const 12)
       )
      )
     )
    )
    (drop
     (call $Utils_apply
      (local.get $0)
      (i32.const 1)
      (i32.add
       (local.get $1)
       (i32.const 8)
      )
     )
    )
    (br_if $label$2
     (i32.ne
      (local.tee $3
       (i32.load offset=8
        (local.get $3)
       )
      )
      (i32.const 8512)
     )
    )
   )
  )
  (local.set $3
   (i32.load offset=8
    (local.get $2)
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
 (func $eval_manager_loop (param $0 i32) (result i32)
  (local $1 i32)
  (local $2 i32)
  (local $3 i32)
  (i32.store offset=8
   (local.tee $1
    (call $GC_allocate
     (i32.const 1)
     (i32.const 5)
    )
   )
   (i32.const 6)
  )
  (i64.store align=4
   (local.get $1)
   (i64.const 844436204421125)
  )
  (block $label$1
   (br_if $label$1
    (i32.eqz
     (local.get $0)
    )
   )
   (i32.store offset=12
    (local.get $1)
    (i32.load
     (local.get $0)
    )
   )
   (i32.store offset=16
    (local.get $1)
    (i32.load offset=4
     (local.get $0)
    )
   )
  )
  (i32.store offset=8
   (local.tee $2
    (call $GC_allocate
     (i32.const 1)
     (i32.const 6)
    )
   )
   (i32.const 7)
  )
  (i64.store align=4
   (local.get $2)
   (i64.const 1125915476099078)
  )
  (block $label$2
   (br_if $label$2
    (i32.eqz
     (local.get $0)
    )
   )
   (i32.store offset=12
    (local.get $2)
    (i32.load
     (local.get $0)
    )
   )
   (i32.store offset=16
    (local.get $2)
    (i32.load offset=4
     (local.get $0)
    )
   )
   (i32.store offset=20
    (local.get $2)
    (i32.load offset=8
     (local.get $0)
    )
   )
  )
  (i64.store offset=16 align=4
   (local.tee $3
    (call $GC_allocate
     (i32.const 1)
     (i32.const 6)
    )
   )
   (i64.const 0)
  )
  (i32.store offset=12
   (local.get $3)
   (local.get $2)
  )
  (i32.store offset=8
   (local.get $3)
   (i32.const 0)
  )
  (i64.store align=4
   (local.get $3)
   (i64.const 24964497414)
  )
  (i32.store offset=20
   (local.tee $0
    (call $GC_allocate
     (i32.const 1)
     (i32.const 6)
    )
   )
   (local.get $3)
  )
  (i32.store offset=16
   (local.get $0)
   (i32.const 0)
  )
  (i32.store offset=12
   (local.get $0)
   (local.get $1)
  )
  (i32.store offset=8
   (local.get $0)
   (i32.const 0)
  )
  (i64.store align=4
   (local.get $0)
   (i64.const 16374562822)
  )
  (local.get $0)
 )
 (func $eval_Scheduler_rawSpawn (param $0 i32) (result i32)
  (local $1 i32)
  (local $2 i32)
  (local $3 i32)
  (local $4 i32)
  (local $5 i32)
  (local $6 i32)
  (local $7 i32)
  (local $8 i32)
  (local $9 i32)
  (local $10 i32)
  (local $11 i32)
  (local.set $0
   (i32.load
    (local.get $0)
   )
  )
  (i32.store
   (local.tee $1
    (call $GC_allocate
     (i32.const 1)
     (i32.const 6)
    )
   )
   (i32.const -1073741818)
  )
  (i32.store offset=20
   (local.get $1)
   (i32.const 8512)
  )
  (i32.store offset=16
   (local.get $1)
   (i32.const 8512)
  )
  (i32.store offset=12
   (local.get $1)
   (i32.const 0)
  )
  (i32.store offset=8
   (local.get $1)
   (local.get $0)
  )
  (i32.store offset=4
   (local.get $1)
   (local.tee $0
    (i32.load offset=8736
     (i32.const 0)
    )
   )
  )
  (i32.store offset=8736
   (i32.const 0)
   (i32.add
    (local.get $0)
    (i32.const 1)
   )
  )
  (block $label$1
   (block $label$2
    (br_if $label$2
     (i32.ge_u
      (i32.load offset=4
       (local.tee $2
        (i32.load offset=8720
         (i32.const 0)
        )
       )
      )
      (local.tee $4
       (i32.add
        (local.tee $3
         (i32.and
          (i32.load
           (local.get $2)
          )
          (i32.const 268435455)
         )
        )
        (i32.const -2)
       )
      )
     )
    )
    (local.set $5
     (local.get $2)
    )
    (br $label$1)
   )
   (i32.store offset=4
    (local.tee $5
     (call $GC_allocate
      (i32.const 1)
      (local.tee $0
       (i32.add
        (local.tee $7
         (select
          (i32.shl
           (local.get $4)
           (i32.const 1)
          )
          (i32.add
           (local.get $3)
           (i32.const 1022)
          )
          (local.tee $6
           (i32.lt_u
            (local.get $4)
            (i32.const 1024)
           )
          )
         )
        )
        (i32.const 2)
       )
      )
     )
    )
    (i32.const 0)
   )
   (i32.store
    (local.get $5)
    (i32.or
     (i32.and
      (local.get $0)
      (i32.const 268435455)
     )
     (i32.const 1879048192)
    )
   )
   (block $label$3
    (br_if $label$3
     (i32.eqz
      (local.get $7)
     )
    )
    (local.set $8
     (i32.and
      (local.get $7)
      (i32.const 7)
     )
    )
    (local.set $9
     (i32.const 0)
    )
    (block $label$4
     (br_if $label$4
      (i32.lt_u
       (i32.add
        (i32.add
         (select
          (local.get $4)
          (i32.const 1024)
          (local.get $6)
         )
         (local.get $3)
        )
        (i32.const -3)
       )
       (i32.const 7)
      )
     )
     (local.set $0
      (i32.add
       (local.get $5)
       (i32.const 20)
      )
     )
     (local.set $6
      (i32.and
       (local.get $7)
       (i32.const -8)
      )
     )
     (local.set $9
      (i32.const 0)
     )
     (loop $label$5
      (i64.store align=4
       (i32.add
        (local.get $0)
        (i32.const 12)
       )
       (i64.const 0)
      )
      (i64.store align=4
       (i32.add
        (local.get $0)
        (i32.const 4)
       )
       (i64.const 0)
      )
      (i64.store align=4
       (i32.add
        (local.get $0)
        (i32.const -4)
       )
       (i64.const 0)
      )
      (i64.store align=4
       (i32.add
        (local.get $0)
        (i32.const -12)
       )
       (i64.const 0)
      )
      (local.set $0
       (i32.add
        (local.get $0)
        (i32.const 32)
       )
      )
      (br_if $label$5
       (i32.ne
        (local.get $6)
        (local.tee $9
         (i32.add
          (local.get $9)
          (i32.const 8)
         )
        )
       )
      )
     )
    )
    (br_if $label$3
     (i32.eqz
      (local.get $8)
     )
    )
    (local.set $0
     (i32.add
      (i32.add
       (i32.shl
        (local.get $9)
        (i32.const 2)
       )
       (local.get $5)
      )
      (i32.const 8)
     )
    )
    (loop $label$6
     (i32.store
      (local.get $0)
      (i32.const 0)
     )
     (local.set $0
      (i32.add
       (local.get $0)
       (i32.const 4)
      )
     )
     (br_if $label$6
      (local.tee $8
       (i32.add
        (local.get $8)
        (i32.const -1)
       )
      )
     )
    )
   )
   (i32.store offset=4
    (local.get $5)
    (i32.load offset=4
     (local.get $2)
    )
   )
   (block $label$7
    (br_if $label$7
     (i32.eqz
      (local.get $4)
     )
    )
    (local.set $6
     (i32.and
      (local.get $4)
      (i32.const 3)
     )
    )
    (local.set $10
     (i32.const 0)
    )
    (block $label$8
     (br_if $label$8
      (i32.lt_u
       (i32.add
        (local.get $3)
        (i32.const -3)
       )
       (i32.const 3)
      )
     )
     (local.set $11
      (i32.and
       (local.get $4)
       (i32.const -4)
      )
     )
     (local.set $0
      (i32.const 0)
     )
     (local.set $10
      (i32.const 0)
     )
     (loop $label$9
      (i32.store
       (i32.add
        (local.tee $8
         (i32.add
          (local.get $5)
          (local.get $0)
         )
        )
        (i32.const 8)
       )
       (i32.load
        (i32.add
         (local.tee $9
          (i32.add
           (local.get $2)
           (local.get $0)
          )
         )
         (i32.const 8)
        )
       )
      )
      (i32.store
       (i32.add
        (local.get $8)
        (i32.const 12)
       )
       (i32.load
        (i32.add
         (local.get $9)
         (i32.const 12)
        )
       )
      )
      (i32.store
       (i32.add
        (local.get $8)
        (i32.const 16)
       )
       (i32.load
        (i32.add
         (local.get $9)
         (i32.const 16)
        )
       )
      )
      (i32.store
       (i32.add
        (local.get $8)
        (i32.const 20)
       )
       (i32.load
        (i32.add
         (local.get $9)
         (i32.const 20)
        )
       )
      )
      (local.set $0
       (i32.add
        (local.get $0)
        (i32.const 16)
       )
      )
      (br_if $label$9
       (i32.ne
        (local.get $11)
        (local.tee $10
         (i32.add
          (local.get $10)
          (i32.const 4)
         )
        )
       )
      )
     )
    )
    (br_if $label$7
     (i32.eqz
      (local.get $6)
     )
    )
    (local.set $0
     (i32.add
      (i32.add
       (local.get $2)
       (local.tee $8
        (i32.shl
         (local.get $10)
         (i32.const 2)
        )
       )
      )
      (i32.const 8)
     )
    )
    (local.set $8
     (i32.add
      (i32.add
       (local.get $8)
       (local.get $5)
      )
      (i32.const 8)
     )
    )
    (loop $label$10
     (i32.store
      (local.get $8)
      (i32.load
       (local.get $0)
      )
     )
     (local.set $0
      (i32.add
       (local.get $0)
       (i32.const 4)
      )
     )
     (local.set $8
      (i32.add
       (local.get $8)
       (i32.const 4)
      )
     )
     (br_if $label$10
      (local.tee $6
       (i32.add
        (local.get $6)
        (i32.const -1)
       )
      )
     )
    )
   )
   (br_if $label$1
    (i32.ge_u
     (local.get $4)
     (local.get $7)
    )
   )
   (local.set $6
    (i32.add
     (local.tee $9
      (select
       (local.get $4)
       (i32.const 1024)
       (i32.lt_u
        (local.get $4)
        (i32.const 1024)
       )
      )
     )
     (i32.const -1)
    )
   )
   (block $label$11
    (br_if $label$11
     (i32.eqz
      (local.tee $8
       (i32.and
        (local.get $9)
        (i32.const 7)
       )
      )
     )
    )
    (local.set $0
     (i32.add
      (local.get $5)
      (i32.shl
       (local.get $3)
       (i32.const 2)
      )
     )
    )
    (loop $label$12
     (i32.store
      (local.get $0)
      (i32.const 0)
     )
     (local.set $0
      (i32.add
       (local.get $0)
       (i32.const 4)
      )
     )
     (local.set $4
      (i32.add
       (local.get $4)
       (i32.const 1)
      )
     )
     (br_if $label$12
      (local.tee $8
       (i32.add
        (local.get $8)
        (i32.const -1)
       )
      )
     )
    )
   )
   (br_if $label$1
    (i32.lt_u
     (local.get $6)
     (i32.const 7)
    )
   )
   (local.set $0
    (i32.add
     (i32.add
      (i32.shl
       (local.get $4)
       (i32.const 2)
      )
      (local.get $5)
     )
     (i32.const 36)
    )
   )
   (local.set $8
    (i32.add
     (i32.sub
      (i32.add
       (local.get $9)
       (local.get $3)
      )
      (local.get $4)
     )
     (i32.const -2)
    )
   )
   (loop $label$13
    (i64.store align=4
     (i32.add
      (local.get $0)
      (i32.const -4)
     )
     (i64.const 0)
    )
    (i64.store align=4
     (i32.add
      (local.get $0)
      (i32.const -12)
     )
     (i64.const 0)
    )
    (i64.store align=4
     (i32.add
      (local.get $0)
      (i32.const -20)
     )
     (i64.const 0)
    )
    (i64.store align=4
     (i32.add
      (local.get $0)
      (i32.const -28)
     )
     (i64.const 0)
    )
    (local.set $0
     (i32.add
      (local.get $0)
      (i32.const 32)
     )
    )
    (br_if $label$13
     (local.tee $8
      (i32.add
       (local.get $8)
       (i32.const -8)
      )
     )
    )
   )
  )
  (i32.store
   (i32.add
    (i32.add
     (local.get $5)
     (i32.shl
      (local.tee $0
       (i32.load offset=4
        (local.get $5)
       )
      )
      (i32.const 2)
     )
    )
    (i32.const 8)
   )
   (local.get $1)
  )
  (i32.store offset=4
   (local.get $5)
   (i32.add
    (local.get $0)
    (i32.const 1)
   )
  )
  (i32.store offset=8720
   (i32.const 0)
   (local.get $5)
  )
  (call $Scheduler_enqueue
   (local.get $1)
  )
  (local.get $1)
 )
 (func $Platform_setupIncomingPort (param $0 i32) (param $1 i32) (result i32)
  (local $2 i32)
  (i64.store align=4
   (local.tee $2
    (call $GC_allocate
     (i32.const 1)
     (i32.const 6)
    )
   )
   (i64.const 3489660934)
  )
  (i32.store offset=20
   (local.get $2)
   (i32.const 0)
  )
  (i64.store offset=12 align=4
   (local.get $2)
   (i64.const 0)
  )
  (i32.store offset=8
   (local.get $2)
   (i32.const 0)
  )
  (i32.store offset=8
   (local.get $1)
   (local.get $2)
  )
  (i32.store offset=12
   (local.tee $2
    (call $GC_allocate
     (i32.const 1)
     (i32.const 4)
    )
   )
   (local.get $1)
  )
  (i32.store offset=8
   (local.get $2)
   (i32.const 4)
  )
  (i64.store align=4
   (local.get $2)
   (i64.const 1125906886164484)
  )
  (i32.store offset=12
   (local.get $1)
   (local.get $2)
  )
  (i32.store offset=36
   (local.get $1)
   (i32.const 8512)
  )
  (local.set $2
   (call $Wrapper_setupIncomingPort
    (local.get $0)
   )
  )
  (i32.store offset=4
   (local.tee $1
    (call $GC_allocate
     (i32.const 1)
     (i32.const 2)
    )
   )
   (local.get $2)
  )
  (i32.store
   (local.get $1)
   (i32.const -1342177278)
  )
  (local.get $1)
 )
 (func $Platform_setupOutgoingPort (param $0 i32) (param $1 i32) (result i32)
  (local $2 i32)
  (local $3 i32)
  (local $4 i32)
  (local $5 i32)
  (global.set $__stack_pointer
   (local.tee $2
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 32)
    )
   )
  )
  (i64.store
   (i32.add
    (local.get $2)
    (i32.const 24)
   )
   (i64.load offset=6280
    (i32.const 0)
   )
  )
  (i64.store offset=16
   (local.get $2)
   (i64.load offset=6272
    (i32.const 0)
   )
  )
  (i32.store offset=12
   (local.get $2)
   (i32.add
    (local.get $2)
    (i32.const 16)
   )
  )
  (i32.store offset=8
   (local.get $1)
   (call $Utils_apply
    (i32.const 8112)
    (i32.const 1)
    (i32.add
     (local.get $2)
     (i32.const 12)
    )
   )
  )
  (local.set $4
   (i32.load offset=8
    (local.tee $3
     (call $Wrapper_setupOutgoingPort)
    )
   )
  )
  (local.set $5
   (i32.load offset=4
    (local.get $3)
   )
  )
  (i32.store offset=16
   (local.tee $3
    (call $GC_allocate
     (i32.const 1)
     (i32.const 5)
    )
   )
   (local.get $1)
  )
  (i32.store offset=12
   (local.get $3)
   (local.get $5)
  )
  (i32.store offset=8
   (local.get $3)
   (i32.const 5)
  )
  (i64.store align=4
   (local.get $3)
   (i64.const 1407386157842437)
  )
  (i32.store offset=12
   (local.get $1)
   (local.get $3)
  )
  (global.set $__stack_pointer
   (i32.add
    (local.get $2)
    (i32.const 32)
   )
  )
  (local.get $4)
 )
 (func $Platform_instantiateManager (param $0 i32) (param $1 i32) (result i32)
  (local $2 i32)
  (local $3 i32)
  (local $4 i32)
  (global.set $__stack_pointer
   (local.tee $2
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 16)
    )
   )
  )
  (i32.store offset=8
   (local.tee $3
    (call $GC_allocate
     (i32.const 1)
     (i32.const 4)
    )
   )
   (local.get $1)
  )
  (i64.store align=4
   (local.get $3)
   (i64.const 4398048390152196)
  )
  (i32.store offset=16
   (local.tee $1
    (call $GC_allocate
     (i32.const 1)
     (i32.const 5)
    )
   )
   (local.get $3)
  )
  (i32.store offset=12
   (local.get $1)
   (local.get $0)
  )
  (i32.store offset=8
   (local.get $1)
   (i32.const 6)
  )
  (i64.store align=4
   (local.get $1)
   (i64.const 844436204421125)
  )
  (local.set $4
   (i32.load offset=8
    (local.get $0)
   )
  )
  (i32.store offset=20
   (local.tee $0
    (call $GC_allocate
     (i32.const 1)
     (i32.const 6)
    )
   )
   (local.get $4)
  )
  (i32.store offset=16
   (local.get $0)
   (i32.const 0)
  )
  (i32.store offset=12
   (local.get $0)
   (local.get $1)
  )
  (i32.store offset=8
   (local.get $0)
   (i32.const 0)
  )
  (i64.store align=4
   (local.get $0)
   (i64.const 16374562822)
  )
  (i32.store offset=12
   (local.get $2)
   (local.get $0)
  )
  (i32.store offset=12
   (local.get $3)
   (local.tee $0
    (call $eval_Scheduler_rawSpawn
     (i32.add
      (local.get $2)
      (i32.const 12)
     )
    )
   )
  )
  (global.set $__stack_pointer
   (i32.add
    (local.get $2)
    (i32.const 16)
   )
  )
  (local.get $0)
 )
 (func $Platform_createManager (param $0 i32) (param $1 i32) (param $2 i32) (param $3 i32) (param $4 i32) (result i32)
  (local $5 i32)
  (i32.store offset=24
   (local.tee $5
    (call $GC_allocate
     (i32.const 0)
     (i32.const 7)
    )
   )
   (local.get $4)
  )
  (i32.store offset=20
   (local.get $5)
   (local.get $3)
  )
  (i32.store offset=16
   (local.get $5)
   (local.get $2)
  )
  (i32.store offset=12
   (local.get $5)
   (local.get $1)
  )
  (i32.store offset=8
   (local.get $5)
   (local.get $0)
  )
  (i64.store align=4
   (local.get $5)
   (i64.const 1879048199)
  )
  (local.get $5)
 )
 (func $eval_manager_loop_receive (param $0 i32) (result i32)
  (local $1 i32)
  (local $2 i32)
  (local $3 i32)
  (local $4 i32)
  (local $5 i32)
  (local $6 i64)
  (global.set $__stack_pointer
   (local.tee $1
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 64)
    )
   )
  )
  (local.set $2
   (i32.load offset=8
    (local.get $0)
   )
  )
  (local.set $3
   (i32.load offset=4
    (local.get $0)
   )
  )
  (local.set $4
   (i32.load
    (local.get $0)
   )
  )
  (block $label$1
   (block $label$2
    (br_if $label$2
     (i32.ne
      (i32.load offset=4
       (local.tee $0
        (i32.load offset=12
         (local.get $0)
        )
       )
      )
      (i32.const 1024000)
     )
    )
    (i32.store offset=52
     (local.get $1)
     (local.get $3)
    )
    (local.set $0
     (i32.load offset=8
      (local.get $0)
     )
    )
    (i32.store offset=60
     (local.get $1)
     (local.get $2)
    )
    (i32.store offset=56
     (local.get $1)
     (local.get $0)
    )
    (local.set $0
     (call $Utils_apply
      (i32.load offset=16
       (local.get $4)
      )
      (i32.const 3)
      (i32.add
       (local.get $1)
       (i32.const 52)
      )
     )
    )
    (br $label$1)
   )
   (block $label$3
    (br_if $label$3
     (i32.eqz
      (i32.load offset=20
       (local.get $4)
      )
     )
    )
    (local.set $5
     (i32.load offset=12
      (local.get $4)
     )
    )
    (block $label$4
     (br_if $label$4
      (i32.eqz
       (i32.load offset=24
        (local.get $4)
       )
      )
     )
     (i32.store offset=36
      (local.get $1)
      (local.get $3)
     )
     (local.set $6
      (i64.load offset=8 align=4
       (local.get $0)
      )
     )
     (i32.store offset=48
      (local.get $1)
      (local.get $2)
     )
     (i64.store offset=40 align=4
      (local.get $1)
      (local.get $6)
     )
     (local.set $0
      (call $Utils_apply
       (local.get $5)
       (i32.const 4)
       (i32.add
        (local.get $1)
        (i32.const 36)
       )
      )
     )
     (br $label$1)
    )
    (i32.store offset=24
     (local.get $1)
     (local.get $3)
    )
    (local.set $0
     (i32.load offset=8
      (local.get $0)
     )
    )
    (i32.store offset=32
     (local.get $1)
     (local.get $2)
    )
    (i32.store offset=28
     (local.get $1)
     (local.get $0)
    )
    (local.set $0
     (call $Utils_apply
      (local.get $5)
      (i32.const 3)
      (i32.add
       (local.get $1)
       (i32.const 24)
      )
     )
    )
    (br $label$1)
   )
   (i32.store offset=12
    (local.get $1)
    (local.get $3)
   )
   (i32.store offset=20
    (local.get $1)
    (local.get $2)
   )
   (i32.store offset=16
    (local.get $1)
    (i32.load
     (i32.add
      (local.get $0)
      (i32.const 12)
     )
    )
   )
   (local.set $0
    (call $Utils_apply
     (i32.load offset=12
      (local.get $4)
     )
     (i32.const 3)
     (i32.add
      (local.get $1)
      (i32.const 12)
     )
    )
   )
  )
  (global.set $__stack_pointer
   (i32.add
    (local.get $1)
    (i32.const 64)
   )
  )
  (local.get $0)
 )
 (func $eval_Scheduler_receive (param $0 i32) (result i32)
  (local $1 i32)
  (local.set $1
   (i32.load
    (local.get $0)
   )
  )
  (i64.store offset=16 align=4
   (local.tee $0
    (call $GC_allocate
     (i32.const 1)
     (i32.const 6)
    )
   )
   (i64.const 0)
  )
  (i32.store offset=12
   (local.get $0)
   (local.get $1)
  )
  (i32.store offset=8
   (local.get $0)
   (i32.const 0)
  )
  (i64.store align=4
   (local.get $0)
   (i64.const 24964497414)
  )
  (local.get $0)
 )
 (func $eval_Scheduler_andThen (param $0 i32) (result i32)
  (local $1 i32)
  (local $2 i32)
  (local.set $1
   (i32.load
    (local.get $0)
   )
  )
  (local.set $2
   (i32.load offset=4
    (local.get $0)
   )
  )
  (i32.store offset=20
   (local.tee $0
    (call $GC_allocate
     (i32.const 1)
     (i32.const 6)
    )
   )
   (local.get $2)
  )
  (i32.store offset=16
   (local.get $0)
   (i32.const 0)
  )
  (i32.store offset=12
   (local.get $0)
   (local.get $1)
  )
  (i32.store offset=8
   (local.get $0)
   (i32.const 0)
  )
  (i64.store align=4
   (local.get $0)
   (i64.const 16374562822)
  )
  (local.get $0)
 )
 (func $Scheduler_enqueue (param $0 i32)
  (local $1 i32)
  (local $2 i32)
  (local $3 i32)
  (local $4 i32)
  (local $5 i32)
  (global.set $__stack_pointer
   (local.tee $1
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 32)
    )
   )
  )
  (i32.store
   (local.tee $2
    (call $GC_allocate
     (i32.const 1)
     (i32.const 3)
    )
   )
   (i32.const 1073741827)
  )
  (i32.store offset=8
   (local.get $2)
   (i32.const 8512)
  )
  (i32.store offset=4
   (local.get $2)
   (local.get $0)
  )
  (block $label$1
   (br_if $label$1
    (i32.eq
     (local.tee $0
      (i32.load offset=8260
       (i32.const 0)
      )
     )
     (i32.const 8512)
    )
   )
   (i32.store offset=8
    (local.get $0)
    (local.get $2)
   )
  )
  (i32.store offset=8260
   (i32.const 0)
   (local.get $2)
  )
  (block $label$2
   (br_if $label$2
    (i32.ne
     (local.tee $0
      (i32.load offset=8256
       (i32.const 0)
      )
     )
     (i32.const 8512)
    )
   )
   (i32.store offset=8256
    (i32.const 0)
    (local.get $2)
   )
   (local.set $0
    (local.get $2)
   )
  )
  (block $label$3
   (br_if $label$3
    (i32.load8_u offset=8740
     (i32.const 0)
    )
   )
   (i32.store8 offset=8740
    (i32.const 0)
    (i32.const 1)
   )
   (block $label$4
    (br_if $label$4
     (i32.eq
      (local.get $0)
      (i32.const 8512)
     )
    )
    (loop $label$5
     (i32.store offset=8256
      (i32.const 0)
      (i32.load offset=8
       (local.get $0)
      )
     )
     (br_if $label$4
      (i32.eqz
       (local.tee $2
        (i32.load offset=4
         (local.get $0)
        )
       )
      )
     )
     (block $label$6
      (br_if $label$6
       (i32.eqz
        (local.tee $3
         (i32.load offset=8
          (local.get $2)
         )
        )
       )
      )
      (block $label$7
       (loop $label$8
        (block $label$9
         (block $label$10
          (br_if $label$10
           (i32.gt_u
            (local.tee $4
             (i32.load offset=4
              (local.get $3)
             )
            )
            (i32.const 1)
           )
          )
          (br_if $label$7
           (i32.eqz
            (local.tee $0
             (i32.load offset=12
              (local.get $2)
             )
            )
           )
          )
          (block $label$11
           (loop $label$12
            (br_if $label$11
             (i32.eq
              (i32.load offset=4
               (local.get $0)
              )
              (local.get $4)
             )
            )
            (i32.store offset=12
             (local.get $2)
             (local.tee $0
              (i32.load offset=12
               (local.get $0)
              )
             )
            )
            (br_if $label$7
             (i32.eqz
              (local.get $0)
             )
            )
            (br $label$12)
           )
          )
          (i32.store offset=28
           (local.get $1)
           (i32.load offset=8
            (local.get $3)
           )
          )
          (i32.store offset=8
           (local.get $2)
           (local.tee $3
            (call $Utils_apply
             (i32.load offset=8
              (local.get $0)
             )
             (i32.const 1)
             (i32.add
              (local.get $1)
              (i32.const 28)
             )
            )
           )
          )
          (i32.store offset=12
           (local.get $2)
           (i32.load offset=12
            (i32.load offset=12
             (local.get $2)
            )
           )
          )
          (br $label$9)
         )
         (block $label$13
          (block $label$14
           (block $label$15
            (block $label$16
             (br_table $label$16 $label$14 $label$14 $label$15 $label$14
              (i32.add
               (local.get $4)
               (i32.const -2)
              )
             )
            )
            (i32.store offset=12
             (local.tee $0
              (call $GC_allocate
               (i32.const 1)
               (i32.const 4)
              )
             )
             (local.get $2)
            )
            (i32.store offset=8
             (local.get $0)
             (i32.const 8)
            )
            (i64.store align=4
             (local.get $0)
             (i64.const 562956932743172)
            )
            (i32.store offset=24
             (local.get $1)
             (local.get $0)
            )
            (local.set $0
             (call $Utils_apply
              (i32.load offset=12
               (i32.load offset=8
                (local.get $2)
               )
              )
              (i32.const 1)
              (i32.add
               (local.get $1)
               (i32.const 24)
              )
             )
            )
            (i32.store offset=16
             (i32.load offset=8
              (local.get $2)
             )
             (local.get $0)
            )
            (br $label$6)
           )
           (br_if $label$6
            (i32.eq
             (local.tee $0
              (i32.load offset=16
               (local.get $2)
              )
             )
             (i32.const 8512)
            )
           )
           (i32.store offset=16
            (local.get $2)
            (i32.load offset=8
             (local.get $0)
            )
           )
           (br_if $label$6
            (i32.eqz
             (local.tee $0
              (i32.load offset=4
               (local.get $0)
              )
             )
            )
           )
           (i32.store offset=20
            (local.get $1)
            (local.get $0)
           )
           (local.set $3
            (call $Utils_apply
             (i32.load offset=12
              (local.get $3)
             )
             (i32.const 1)
             (i32.add
              (local.get $1)
              (i32.const 20)
             )
            )
           )
           (br $label$13)
          )
          (local.set $3
           (i32.load offset=12
            (local.get $3)
           )
          )
          (local.set $5
           (i32.load offset=12
            (local.get $2)
           )
          )
          (i32.store
           (local.tee $0
            (call $GC_allocate
             (i32.const 1)
             (i32.const 4)
            )
           )
           (i32.const 1879048196)
          )
          (i32.store offset=12
           (local.get $0)
           (local.get $5)
          )
          (i32.store offset=8
           (local.get $0)
           (local.get $3)
          )
          (i32.store offset=4
           (local.get $0)
           (i32.ne
            (local.get $4)
            (i32.const 3)
           )
          )
          (i32.store offset=12
           (local.get $2)
           (local.get $0)
          )
          (local.set $3
           (i32.load offset=20
            (i32.load offset=8
             (local.get $2)
            )
           )
          )
         )
         (i32.store offset=8
          (local.get $2)
          (local.get $3)
         )
        )
        (br_if $label$8
         (local.get $3)
        )
        (br $label$6)
       )
      )
      (block $label$17
       (br_if $label$17
        (i32.eqz
         (local.tee $4
          (i32.load offset=4
           (local.tee $0
            (i32.load offset=8720
             (i32.const 0)
            )
           )
          )
         )
        )
       )
       (local.set $0
        (i32.add
         (local.get $0)
         (i32.const 8)
        )
       )
       (loop $label$18
        (br_if $label$6
         (i32.eq
          (i32.load
           (local.get $0)
          )
          (local.get $2)
         )
        )
        (local.set $0
         (i32.add
          (local.get $0)
          (i32.const 4)
         )
        )
        (br_if $label$18
         (local.tee $4
          (i32.add
           (local.get $4)
           (i32.const -1)
          )
         )
        )
       )
      )
      (local.set $0
       (i32.load offset=4
        (local.get $2)
       )
      )
      (i32.store offset=4
       (local.get $1)
       (local.get $2)
      )
      (i32.store
       (local.get $1)
       (local.get $0)
      )
      (call $safe_printf
       (i32.const 5142)
       (local.get $1)
      )
     )
     (br_if $label$5
      (i32.ne
       (local.tee $0
        (i32.load offset=8256
         (i32.const 0)
        )
       )
       (i32.const 8512)
      )
     )
    )
   )
   (i32.store8 offset=8740
    (i32.const 0)
    (i32.const 0)
   )
  )
  (global.set $__stack_pointer
   (i32.add
    (local.get $1)
    (i32.const 32)
   )
  )
 )
 (func $eval_Platform_sendToApp_lambda (param $0 i32) (result i32)
  (local $1 i32)
  (local $2 i32)
  (local $3 i32)
  (global.set $__stack_pointer
   (local.tee $1
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 16)
    )
   )
  )
  (i32.store offset=12
   (local.get $1)
   (i32.load offset=4
    (local.get $0)
   )
  )
  (local.set $2
   (i32.load offset=8
    (local.get $0)
   )
  )
  (drop
   (call $Utils_apply
    (i32.load offset=8
     (i32.load
      (local.get $0)
     )
    )
    (i32.const 1)
    (i32.add
     (local.get $1)
     (i32.const 12)
    )
   )
  )
  (local.set $3
   (i32.load offset=8016
    (i32.const 0)
   )
  )
  (i32.store offset=20
   (local.tee $0
    (call $GC_allocate
     (i32.const 1)
     (i32.const 6)
    )
   )
   (i32.const 0)
  )
  (i64.store offset=12 align=4
   (local.get $0)
   (i64.const 0)
  )
  (i32.store offset=8
   (local.get $0)
   (local.get $3)
  )
  (i64.store align=4
   (local.get $0)
   (i64.const 3489660934)
  )
  (i32.store offset=8
   (local.get $1)
   (local.get $0)
  )
  (drop
   (call $Utils_apply
    (local.get $2)
    (i32.const 1)
    (i32.add
     (local.get $1)
     (i32.const 8)
    )
   )
  )
  (global.set $__stack_pointer
   (i32.add
    (local.get $1)
    (i32.const 16)
   )
  )
  (i32.const 0)
 )
 (func $eval_Scheduler_succeed (param $0 i32) (result i32)
  (local $1 i32)
  (local.set $1
   (i32.load
    (local.get $0)
   )
  )
  (i32.store offset=20
   (local.tee $0
    (call $GC_allocate
     (i32.const 1)
     (i32.const 6)
    )
   )
   (i32.const 0)
  )
  (i64.store offset=12 align=4
   (local.get $0)
   (i64.const 0)
  )
  (i32.store offset=8
   (local.get $0)
   (local.get $1)
  )
  (i64.store align=4
   (local.get $0)
   (i64.const 3489660934)
  )
  (local.get $0)
 )
 (func $eval_Platform_sendToApp (param $0 i32) (result i32)
  (local $1 i32)
  (i32.store offset=8
   (local.tee $1
    (call $GC_allocate
     (i32.const 1)
     (i32.const 5)
    )
   )
   (i32.const 9)
  )
  (i64.store align=4
   (local.get $1)
   (i64.const 844436204421125)
  )
  (block $label$1
   (br_if $label$1
    (i32.eqz
     (local.get $0)
    )
   )
   (i32.store offset=12
    (local.get $1)
    (i32.load
     (local.get $0)
    )
   )
   (i32.store offset=16
    (local.get $1)
    (i32.load offset=4
     (local.get $0)
    )
   )
  )
  (i64.store offset=16 align=4
   (local.tee $0
    (call $GC_allocate
     (i32.const 1)
     (i32.const 6)
    )
   )
   (i64.const 0)
  )
  (i32.store offset=12
   (local.get $0)
   (local.get $1)
  )
  (i32.store offset=8
   (local.get $0)
   (i32.const 0)
  )
  (i64.store align=4
   (local.get $0)
   (i64.const 12079595526)
  )
  (local.get $0)
 )
 (func $eval_Scheduler_binding (param $0 i32) (result i32)
  (local $1 i32)
  (local.set $1
   (i32.load
    (local.get $0)
   )
  )
  (i64.store offset=16 align=4
   (local.tee $0
    (call $GC_allocate
     (i32.const 1)
     (i32.const 6)
    )
   )
   (i64.const 0)
  )
  (i32.store offset=12
   (local.get $0)
   (local.get $1)
  )
  (i32.store offset=8
   (local.get $0)
   (i32.const 0)
  )
  (i64.store align=4
   (local.get $0)
   (i64.const 12079595526)
  )
  (local.get $0)
 )
 (func $eval_Platform_sendToSelf (param $0 i32) (result i32)
  (local $1 i32)
  (local $2 i32)
  (local.set $1
   (i32.load offset=12
    (i32.load
     (local.get $0)
    )
   )
  )
  (local.set $0
   (i32.load offset=4
    (local.get $0)
   )
  )
  (i32.store offset=8
   (local.tee $2
    (call $GC_allocate
     (i32.const 1)
     (i32.const 3)
    )
   )
   (local.get $0)
  )
  (i64.store align=4
   (local.get $2)
   (i64.const 4398048390152195)
  )
  (i32.store offset=16
   (local.tee $0
    (call $GC_allocate
     (i32.const 1)
     (i32.const 5)
    )
   )
   (local.get $2)
  )
  (i32.store offset=12
   (local.get $0)
   (local.get $1)
  )
  (i32.store offset=8
   (local.get $0)
   (i32.const 10)
  )
  (i64.store align=4
   (local.get $0)
   (i64.const 844436204421125)
  )
  (i64.store offset=16 align=4
   (local.tee $2
    (call $GC_allocate
     (i32.const 1)
     (i32.const 6)
    )
   )
   (i64.const 0)
  )
  (i32.store offset=12
   (local.get $2)
   (local.get $0)
  )
  (i32.store offset=8
   (local.get $2)
   (i32.const 0)
  )
  (i64.store align=4
   (local.get $2)
   (i64.const 12079595526)
  )
  (local.get $2)
 )
 (func $eval_Scheduler_send_lambda (param $0 i32) (result i32)
  (local $1 i32)
  (local $2 i32)
  (local $3 i32)
  (local $4 i32)
  (global.set $__stack_pointer
   (local.tee $1
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 16)
    )
   )
  )
  (local.set $2
   (i32.load offset=8
    (local.get $0)
   )
  )
  (local.set $3
   (i32.load
    (local.get $0)
   )
  )
  (local.set $4
   (i32.load offset=4
    (local.get $0)
   )
  )
  (i32.store
   (local.tee $0
    (call $GC_allocate
     (i32.const 1)
     (i32.const 3)
    )
   )
   (i32.const 1073741827)
  )
  (i32.store offset=8
   (local.get $0)
   (i32.const 8512)
  )
  (i32.store offset=4
   (local.get $0)
   (local.get $4)
  )
  (block $label$1
   (br_if $label$1
    (i32.eq
     (local.tee $4
      (i32.load
       (i32.add
        (local.get $3)
        (i32.const 20)
       )
      )
     )
     (i32.const 8512)
    )
   )
   (i32.store offset=8
    (local.get $4)
    (local.get $0)
   )
  )
  (i32.store offset=20
   (local.get $3)
   (local.get $0)
  )
  (block $label$2
   (br_if $label$2
    (i32.ne
     (i32.load offset=16
      (local.get $3)
     )
     (i32.const 8512)
    )
   )
   (i32.store offset=16
    (local.get $3)
    (local.get $0)
   )
  )
  (call $Scheduler_enqueue
   (local.get $3)
  )
  (local.set $0
   (i32.load offset=8016
    (i32.const 0)
   )
  )
  (i32.store offset=20
   (local.tee $3
    (call $GC_allocate
     (i32.const 1)
     (i32.const 6)
    )
   )
   (i32.const 0)
  )
  (i64.store offset=12 align=4
   (local.get $3)
   (i64.const 0)
  )
  (i32.store offset=8
   (local.get $3)
   (local.get $0)
  )
  (i64.store align=4
   (local.get $3)
   (i64.const 3489660934)
  )
  (i32.store offset=12
   (local.get $1)
   (local.get $3)
  )
  (drop
   (call $Utils_apply
    (local.get $2)
    (i32.const 1)
    (i32.add
     (local.get $1)
     (i32.const 12)
    )
   )
  )
  (global.set $__stack_pointer
   (i32.add
    (local.get $1)
    (i32.const 16)
   )
  )
  (i32.const 0)
 )
 (func $eval_Scheduler_send (param $0 i32) (result i32)
  (local $1 i32)
  (i32.store offset=8
   (local.tee $1
    (call $GC_allocate
     (i32.const 1)
     (i32.const 5)
    )
   )
   (i32.const 10)
  )
  (i64.store align=4
   (local.get $1)
   (i64.const 844436204421125)
  )
  (block $label$1
   (br_if $label$1
    (i32.eqz
     (local.get $0)
    )
   )
   (i32.store offset=12
    (local.get $1)
    (i32.load
     (local.get $0)
    )
   )
   (i32.store offset=16
    (local.get $1)
    (i32.load offset=4
     (local.get $0)
    )
   )
  )
  (i64.store offset=16 align=4
   (local.tee $0
    (call $GC_allocate
     (i32.const 1)
     (i32.const 6)
    )
   )
   (i64.const 0)
  )
  (i32.store offset=12
   (local.get $0)
   (local.get $1)
  )
  (i32.store offset=8
   (local.get $0)
   (i32.const 0)
  )
  (i64.store align=4
   (local.get $0)
   (i64.const 12079595526)
  )
  (local.get $0)
 )
 (func $eval_Platform_leaf (param $0 i32) (result i32)
  (local $1 i32)
  (i64.store align=4
   (local.tee $1
    (call $GC_allocate
     (i32.const 1)
     (i32.const 4)
    )
   )
   (i64.const 4398052685119492)
  )
  (block $label$1
   (br_if $label$1
    (i32.eqz
     (local.get $0)
    )
   )
   (i32.store offset=8
    (local.get $1)
    (i32.load
     (local.get $0)
    )
   )
   (i32.store offset=12
    (local.get $1)
    (i32.load offset=4
     (local.get $0)
    )
   )
  )
  (local.get $1)
 )
 (func $eval_Platform_batch (param $0 i32) (result i32)
  (local $1 i32)
  (i64.store align=4
   (local.tee $1
    (call $GC_allocate
     (i32.const 1)
     (i32.const 3)
    )
   )
   (i64.const 4398056980086787)
  )
  (block $label$1
   (br_if $label$1
    (i32.eqz
     (local.get $0)
    )
   )
   (i32.store offset=8
    (local.get $1)
    (i32.load
     (local.get $0)
    )
   )
  )
  (local.get $1)
 )
 (func $eval_Platform_map (param $0 i32) (result i32)
  (local $1 i32)
  (i64.store align=4
   (local.tee $1
    (call $GC_allocate
     (i32.const 1)
     (i32.const 4)
    )
   )
   (i64.const 4398061275054084)
  )
  (block $label$1
   (br_if $label$1
    (i32.eqz
     (local.get $0)
    )
   )
   (i32.store offset=8
    (local.get $1)
    (i32.load
     (local.get $0)
    )
   )
   (i32.store offset=12
    (local.get $1)
    (i32.load offset=4
     (local.get $0)
    )
   )
  )
  (local.get $1)
 )
 (func $Queue_push (param $0 i32) (param $1 i32)
  (local $2 i32)
  (i32.store
   (local.tee $2
    (call $GC_allocate
     (i32.const 1)
     (i32.const 3)
    )
   )
   (i32.const 1073741827)
  )
  (i32.store offset=8
   (local.get $2)
   (i32.const 8512)
  )
  (i32.store offset=4
   (local.get $2)
   (local.get $1)
  )
  (block $label$1
   (br_if $label$1
    (i32.eq
     (local.tee $1
      (i32.load offset=4
       (local.get $0)
      )
     )
     (i32.const 8512)
    )
   )
   (i32.store offset=8
    (local.get $1)
    (local.get $2)
   )
  )
  (i32.store offset=4
   (local.get $0)
   (local.get $2)
  )
  (block $label$2
   (br_if $label$2
    (i32.ne
     (i32.load
      (local.get $0)
     )
     (i32.const 8512)
    )
   )
   (i32.store
    (local.get $0)
    (local.get $2)
   )
  )
 )
 (func $newTuple3 (param $0 i32) (param $1 i32) (param $2 i32) (result i32)
  (local $3 i32)
  (i32.store offset=12
   (local.tee $3
    (call $GC_allocate
     (i32.const 1)
     (i32.const 4)
    )
   )
   (local.get $2)
  )
  (i32.store offset=8
   (local.get $3)
   (local.get $1)
  )
  (i32.store offset=4
   (local.get $3)
   (local.get $0)
  )
  (i32.store
   (local.get $3)
   (i32.const 1610612740)
  )
  (local.get $3)
 )
 (func $Queue_shift (param $0 i32) (result i32)
  (local $1 i32)
  (block $label$1
   (br_if $label$1
    (i32.ne
     (local.tee $1
      (i32.load
       (local.get $0)
      )
     )
     (i32.const 8512)
    )
   )
   (return
    (i32.const 0)
   )
  )
  (i32.store
   (local.get $0)
   (i32.load offset=8
    (local.get $1)
   )
  )
  (i32.load offset=4
   (local.get $1)
  )
 )
 (func $Platform_gatherEffects (param $0 i32) (param $1 i32) (param $2 i32) (param $3 i32)
  (local $4 i32)
  (local $5 i32)
  (local $6 i32)
  (local $7 f64)
  (global.set $__stack_pointer
   (local.tee $4
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 80)
    )
   )
  )
  (block $label$1
   (block $label$2
    (loop $label$3
     (block $label$4
      (br_if $label$4
       (i32.eq
        (local.tee $5
         (i32.load offset=4
          (local.get $1)
         )
        )
        (i32.const 1024003)
       )
      )
      (block $label$5
       (block $label$6
        (br_table $label$6 $label$5 $label$2
         (i32.add
          (local.get $5)
          (i32.const -1024001)
         )
        )
       )
       (block $label$7
        (block $label$8
         (br_if $label$8
          (i32.eqz
           (f64.lt
            (f64.abs
             (local.tee $7
              (f64.load offset=8
               (i32.load offset=8
                (local.get $1)
               )
              )
             )
            )
            (f64.const 2147483648)
           )
          )
         )
         (local.set $5
          (i32.trunc_f64_s
           (local.get $7)
          )
         )
         (br $label$7)
        )
        (local.set $5
         (i32.const -2147483648)
        )
       )
       (block $label$9
        (block $label$10
         (br_if $label$10
          (i32.lt_s
           (local.get $5)
           (i32.const 0)
          )
         )
         (br_if $label$9
          (i32.gt_u
           (i32.load
            (i32.const 0)
           )
           (local.get $5)
          )
         )
        )
        (i32.store offset=56
         (local.get $4)
         (i32.const 333)
        )
        (i32.store offset=52
         (local.get $4)
         (i32.const 3431)
        )
        (i32.store offset=48
         (local.get $4)
         (i32.const 1650)
        )
        (call $safe_printf
         (i32.const 5284)
         (i32.add
          (local.get $4)
          (i32.const 48)
         )
        )
        (i32.store offset=32
         (local.get $4)
         (i32.const 2711)
        )
        (call $safe_printf
         (i32.const 4957)
         (i32.add
          (local.get $4)
          (i32.const 32)
         )
        )
        (i64.store offset=24
         (local.get $4)
         (i64.extend_i32_s
          (local.get $5)
         )
        )
        (i32.store offset=16
         (local.get $4)
         (i32.const 2942)
        )
        (call $safe_printf
         (i32.const 6035)
         (i32.add
          (local.get $4)
          (i32.const 16)
         )
        )
        (call $abort)
       )
       (local.set $6
        (i32.load
         (i32.add
          (local.get $1)
          (i32.const 12)
         )
        )
       )
       (i32.store offset=12
        (local.tee $1
         (call $GC_allocate
          (i32.const 1)
          (i32.const 4)
         )
        )
        (local.get $3)
       )
       (i32.store offset=8
        (local.get $1)
        (i32.const 11)
       )
       (i64.store align=4
        (local.get $1)
        (i64.const 562956932743172)
       )
       (local.set $3
        (i32.load
         (i32.add
          (i32.add
           (i32.load offset=8728
            (i32.const 0)
           )
           (local.tee $5
            (i32.shl
             (local.get $5)
             (i32.const 2)
            )
           )
          )
          (i32.const 8)
         )
        )
       )
       (i32.store offset=72
        (local.get $4)
        (local.get $1)
       )
       (i32.store offset=76
        (local.get $4)
        (local.get $6)
       )
       (local.set $3
        (call $Utils_apply
         (i32.load
          (i32.add
           (local.get $3)
           (select
            (i32.const 20)
            (i32.const 24)
            (local.get $0)
           )
          )
         )
         (i32.const 2)
         (i32.add
          (local.get $4)
          (i32.const 72)
         )
        )
       )
       (block $label$11
        (br_if $label$11
         (local.tee $1
          (i32.load
           (local.tee $5
            (i32.add
             (i32.add
              (local.get $2)
              (local.get $5)
             )
             (i32.const 8)
            )
           )
          )
         )
        )
        (i32.store offset=12
         (local.tee $1
          (call $GC_allocate
           (i32.const 1)
           (i32.const 4)
          )
         )
         (i32.const 8512)
        )
        (i32.store offset=8
         (local.get $1)
         (i32.const 8512)
        )
        (i64.store align=4
         (local.get $1)
         (i64.const 4398065570021380)
        )
       )
       (block $label$12
        (br_if $label$12
         (i32.eqz
          (local.get $0)
         )
        )
        (local.set $0
         (i32.load offset=8
          (local.get $1)
         )
        )
        (i32.store offset=8
         (local.tee $6
          (call $GC_allocate
           (i32.const 1)
           (i32.const 3)
          )
         )
         (local.get $0)
        )
        (i32.store offset=4
         (local.get $6)
         (local.get $3)
        )
        (i32.store
         (local.get $6)
         (i32.const 1073741827)
        )
        (i32.store offset=8
         (local.get $1)
         (local.get $6)
        )
        (i32.store
         (local.get $5)
         (local.get $1)
        )
        (br $label$1)
       )
       (local.set $2
        (i32.load
         (local.tee $0
          (i32.add
           (local.get $1)
           (i32.const 12)
          )
         )
        )
       )
       (i32.store offset=8
        (local.tee $6
         (call $GC_allocate
          (i32.const 1)
          (i32.const 3)
         )
        )
        (local.get $2)
       )
       (i32.store offset=4
        (local.get $6)
        (local.get $3)
       )
       (i32.store
        (local.get $6)
        (i32.const 1073741827)
       )
       (i32.store
        (local.get $0)
        (local.get $6)
       )
       (i32.store
        (local.get $5)
        (local.get $1)
       )
       (br $label$1)
      )
      (br_if $label$1
       (i32.eq
        (local.tee $1
         (i32.load offset=8
          (local.get $1)
         )
        )
        (i32.const 8512)
       )
      )
      (loop $label$13
       (call $Platform_gatherEffects
        (local.get $0)
        (i32.load offset=4
         (local.get $1)
        )
        (local.get $2)
        (local.get $3)
       )
       (br_if $label$13
        (i32.ne
         (local.tee $1
          (i32.load offset=8
           (local.get $1)
          )
         )
         (i32.const 8512)
        )
       )
       (br $label$1)
      )
     )
     (local.set $6
      (i32.load offset=8
       (local.get $1)
      )
     )
     (i32.store offset=8
      (local.tee $5
       (call $GC_allocate
        (i32.const 1)
        (i32.const 3)
       )
      )
      (local.get $3)
     )
     (i32.store offset=4
      (local.get $5)
      (local.get $6)
     )
     (i32.store
      (local.get $5)
      (i32.const 1073741827)
     )
     (local.set $1
      (i32.load
       (i32.add
        (local.get $1)
        (i32.const 12)
       )
      )
     )
     (local.set $3
      (local.get $5)
     )
     (br $label$3)
    )
   )
   (i32.store
    (local.get $4)
    (local.get $5)
   )
   (call $log_error
    (i32.const 5444)
    (local.get $4)
   )
  )
  (global.set $__stack_pointer
   (i32.add
    (local.get $4)
    (i32.const 80)
   )
  )
 )
 (func $eval_applyTaggers (param $0 i32) (result i32)
  (local $1 i32)
  (local $2 i32)
  (global.set $__stack_pointer
   (local.tee $1
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 16)
    )
   )
  )
  (local.set $2
   (i32.load offset=4
    (local.get $0)
   )
  )
  (block $label$1
   (br_if $label$1
    (i32.eq
     (local.tee $0
      (i32.load
       (local.get $0)
      )
     )
     (i32.const 8512)
    )
   )
   (loop $label$2
    (i32.store offset=12
     (local.get $1)
     (local.get $2)
    )
    (local.set $2
     (call $Utils_apply
      (i32.load offset=4
       (local.get $0)
      )
      (i32.const 1)
      (i32.add
       (local.get $1)
       (i32.const 12)
      )
     )
    )
    (br_if $label$2
     (i32.ne
      (local.tee $0
       (i32.load offset=8
        (local.get $0)
       )
      )
      (i32.const 8512)
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
  (local.get $2)
 )
 (func $log_error (param $0 i32) (param $1 i32)
  (local $2 i32)
  (global.set $__stack_pointer
   (local.tee $2
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 16)
    )
   )
  )
  (i32.store offset=12
   (local.get $2)
   (local.get $1)
  )
  (call $safe_vprintf
   (local.get $0)
   (local.get $1)
  )
  (call $exit
   (i32.const 1)
  )
  (global.set $__stack_pointer
   (i32.add
    (local.get $2)
    (i32.const 16)
   )
  )
 )
 (func $eval_Scheduler_rawSend (param $0 i32) (result i32)
  (local $1 i32)
  (local $2 i32)
  (local.set $1
   (i32.load
    (local.get $0)
   )
  )
  (local.set $2
   (i32.load offset=4
    (local.get $0)
   )
  )
  (i32.store
   (local.tee $0
    (call $GC_allocate
     (i32.const 1)
     (i32.const 3)
    )
   )
   (i32.const 1073741827)
  )
  (i32.store offset=8
   (local.get $0)
   (i32.const 8512)
  )
  (i32.store offset=4
   (local.get $0)
   (local.get $2)
  )
  (block $label$1
   (br_if $label$1
    (i32.eq
     (local.tee $2
      (i32.load
       (i32.add
        (local.get $1)
        (i32.const 20)
       )
      )
     )
     (i32.const 8512)
    )
   )
   (i32.store offset=8
    (local.get $2)
    (local.get $0)
   )
  )
  (i32.store offset=20
   (local.get $1)
   (local.get $0)
  )
  (block $label$2
   (br_if $label$2
    (i32.ne
     (i32.load offset=16
      (local.get $1)
     )
     (i32.const 8512)
    )
   )
   (i32.store offset=16
    (local.get $1)
    (local.get $0)
   )
  )
  (call $Scheduler_enqueue
   (local.get $1)
  )
  (i32.const 0)
 )
 (func $Platform_toEffect (param $0 i32) (param $1 i32) (param $2 i32) (param $3 i32) (result i32)
  (local $4 i32)
  (local $5 i32)
  (global.set $__stack_pointer
   (local.tee $4
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 16)
    )
   )
  )
  (i32.store offset=12
   (local.tee $5
    (call $GC_allocate
     (i32.const 1)
     (i32.const 4)
    )
   )
   (local.get $2)
  )
  (i32.store offset=8
   (local.get $5)
   (i32.const 11)
  )
  (i64.store align=4
   (local.get $5)
   (i64.const 562956932743172)
  )
  (local.set $1
   (i32.load
    (i32.add
     (i32.add
      (i32.load offset=8728
       (i32.const 0)
      )
      (i32.shl
       (local.get $1)
       (i32.const 2)
      )
     )
     (i32.const 8)
    )
   )
  )
  (i32.store offset=8
   (local.get $4)
   (local.get $5)
  )
  (i32.store offset=12
   (local.get $4)
   (local.get $3)
  )
  (local.set $5
   (call $Utils_apply
    (i32.load
     (i32.add
      (local.get $1)
      (select
       (i32.const 20)
       (i32.const 24)
       (local.get $0)
      )
     )
    )
    (i32.const 2)
    (i32.add
     (local.get $4)
     (i32.const 8)
    )
   )
  )
  (global.set $__stack_pointer
   (i32.add
    (local.get $4)
    (i32.const 16)
   )
  )
  (local.get $5)
 )
 (func $Platform_insert (param $0 i32) (param $1 i32) (param $2 i32) (result i32)
  (local $3 i32)
  (local $4 i32)
  (block $label$1
   (br_if $label$1
    (local.get $2)
   )
   (i32.store offset=12
    (local.tee $2
     (call $GC_allocate
      (i32.const 1)
      (i32.const 4)
     )
    )
    (i32.const 8512)
   )
   (i32.store offset=8
    (local.get $2)
    (i32.const 8512)
   )
   (i64.store align=4
    (local.get $2)
    (i64.const 4398065570021380)
   )
  )
  (block $label$2
   (br_if $label$2
    (i32.eqz
     (local.get $0)
    )
   )
   (local.set $3
    (i32.load offset=8
     (local.get $2)
    )
   )
   (i32.store offset=8
    (local.tee $0
     (call $GC_allocate
      (i32.const 1)
      (i32.const 3)
     )
    )
    (local.get $3)
   )
   (i32.store offset=4
    (local.get $0)
    (local.get $1)
   )
   (i32.store
    (local.get $0)
    (i32.const 1073741827)
   )
   (i32.store offset=8
    (local.get $2)
    (local.get $0)
   )
   (return
    (local.get $2)
   )
  )
  (local.set $4
   (i32.load
    (local.tee $3
     (i32.add
      (local.get $2)
      (i32.const 12)
     )
    )
   )
  )
  (i32.store offset=8
   (local.tee $0
    (call $GC_allocate
     (i32.const 1)
     (i32.const 3)
    )
   )
   (local.get $4)
  )
  (i32.store offset=4
   (local.get $0)
   (local.get $1)
  )
  (i32.store
   (local.get $0)
   (i32.const 1073741827)
  )
  (i32.store
   (local.get $3)
   (local.get $0)
  )
  (local.get $2)
 )
 (func $safe_vprintf (param $0 i32) (param $1 i32)
  (local $2 i32)
  (global.set $__stack_pointer
   (local.tee $2
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 1600)
    )
   )
  )
  (i64.store offset=1076 align=4
   (local.get $2)
   (i64.const 1024)
  )
  (i32.store offset=1072
   (local.get $2)
   (i32.add
    (local.get $2)
    (i32.const 48)
   )
  )
  (drop
   (call $stbsp_vsprintfcb
    (i32.const 2)
    (i32.add
     (local.get $2)
     (i32.const 1072)
    )
    (i32.add
     (local.get $2)
     (i32.const 48)
    )
    (local.get $0)
    (local.get $1)
   )
  )
  (i32.store8
   (i32.add
    (i32.add
     (local.get $2)
     (i32.const 48)
    )
    (select
     (local.tee $0
      (i32.sub
       (i32.load offset=1072
        (local.get $2)
       )
       (i32.add
        (local.get $2)
        (i32.const 48)
       )
      )
     )
     (i32.const 1023)
     (i32.lt_s
      (local.get $0)
      (i32.const 1023)
     )
    )
   )
   (i32.const 0)
  )
  (local.set $0
   (i32.load offset=1080
    (local.get $2)
   )
  )
  (block $label$1
   (br_if $label$1
    (i32.eq
     (local.get $0)
     (local.tee $1
      (call $write
       (i32.const 1)
       (i32.add
        (local.get $2)
        (i32.const 48)
       )
       (local.get $0)
      )
     )
    )
   )
   (i32.store offset=40
    (local.get $2)
    (i32.const 31)
   )
   (i32.store offset=36
    (local.get $2)
    (i32.const 3515)
   )
   (i32.store offset=32
    (local.get $2)
    (i32.const 2640)
   )
   (call $safe_printf
    (i32.const 5317)
    (i32.add
     (local.get $2)
     (i32.const 32)
    )
   )
   (i64.store offset=24
    (local.get $2)
    (i64.extend_i32_s
     (local.get $1)
    )
   )
   (i32.store offset=16
    (local.get $2)
    (i32.const 2219)
   )
   (call $safe_printf
    (i32.const 4798)
    (i32.add
     (local.get $2)
     (i32.const 16)
    )
   )
   (i64.store offset=8
    (local.get $2)
    (i64.extend_i32_s
     (local.get $0)
    )
   )
   (i32.store
    (local.get $2)
    (i32.const 1443)
   )
   (call $safe_printf
    (i32.const 4798)
    (local.get $2)
   )
   (call $abort)
  )
  (global.set $__stack_pointer
   (i32.add
    (local.get $2)
    (i32.const 1600)
   )
  )
 )
 (func $Platform_checkPortName (param $0 i32)
  (local $1 i32)
  (local $2 i32)
  (local $3 i32)
  (local $4 i32)
  (global.set $__stack_pointer
   (local.tee $1
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 16)
    )
   )
  )
  (block $label$1
   (br_if $label$1
    (i32.eqz
     (i32.load
      (i32.const 0)
     )
    )
   )
   (local.set $2
    (i32.const 8)
   )
   (local.set $3
    (i32.const 0)
   )
   (loop $label$2
    (block $label$3
     (br_if $label$3
      (i32.gt_u
       (i32.add
        (i32.load offset=4
         (local.tee $4
          (i32.load
           (i32.add
            (i32.load offset=8728
             (i32.const 0)
            )
            (local.get $2)
           )
          )
         )
        )
        (i32.const -1)
       )
       (i32.const 1)
      )
     )
     (i32.store offset=8
      (local.get $1)
      (local.get $0)
     )
     (i32.store offset=12
      (local.get $1)
      (i32.load offset=28
       (local.get $4)
      )
     )
     (br_if $label$3
      (i32.ne
       (call $Utils_apply
        (i32.const 8568)
        (i32.const 2)
        (i32.add
         (local.get $1)
         (i32.const 8)
        )
       )
       (i32.const 8532)
      )
     )
     (call $log_error
      (i32.const 2966)
      (i32.const 0)
     )
    )
    (local.set $2
     (i32.add
      (local.get $2)
      (i32.const 4)
     )
    )
    (br_if $label$2
     (i32.lt_u
      (local.tee $3
       (i32.add
        (local.get $3)
        (i32.const 1)
       )
      )
      (i32.load
       (i32.const 0)
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
 )
 (func $eval_Platform_outgoingPortMap (param $0 i32) (result i32)
  (i32.load offset=4
   (local.get $0)
  )
 )
 (func $Platform_outgoingPort (param $0 i32) (param $1 i32) (param $2 i32) (result i32)
  (local $3 i32)
  (local $4 i32)
  (local $5 i32)
  (local $6 i32)
  (global.set $__stack_pointer
   (local.tee $3
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 16)
    )
   )
  )
  (block $label$1
   (br_if $label$1
    (i32.eqz
     (i32.load
      (i32.const 0)
     )
    )
   )
   (local.set $4
    (i32.const 8)
   )
   (local.set $5
    (i32.const 0)
   )
   (loop $label$2
    (block $label$3
     (br_if $label$3
      (i32.gt_u
       (i32.add
        (i32.load offset=4
         (local.tee $6
          (i32.load
           (i32.add
            (i32.load offset=8728
             (i32.const 0)
            )
            (local.get $4)
           )
          )
         )
        )
        (i32.const -1)
       )
       (i32.const 1)
      )
     )
     (i32.store offset=8
      (local.get $3)
      (local.get $1)
     )
     (i32.store offset=12
      (local.get $3)
      (i32.load offset=28
       (local.get $6)
      )
     )
     (br_if $label$3
      (i32.ne
       (call $Utils_apply
        (i32.const 8568)
        (i32.const 2)
        (i32.add
         (local.get $3)
         (i32.const 8)
        )
       )
       (i32.const 8532)
      )
     )
     (call $log_error
      (i32.const 2966)
      (i32.const 0)
     )
    )
    (local.set $4
     (i32.add
      (local.get $4)
      (i32.const 4)
     )
    )
    (br_if $label$2
     (i32.lt_u
      (local.tee $5
       (i32.add
        (local.get $5)
        (i32.const 1)
       )
      )
      (i32.load
       (i32.const 0)
      )
     )
    )
   )
  )
  (i32.store offset=36
   (local.tee $4
    (call $GC_allocate
     (i32.const 1)
     (i32.const 10)
    )
   )
   (i32.const 0)
  )
  (i32.store offset=32
   (local.get $4)
   (local.get $2)
  )
  (i32.store offset=28
   (local.get $4)
   (local.get $1)
  )
  (i32.store offset=24
   (local.get $4)
   (i32.const 0)
  )
  (i32.store offset=20
   (local.get $4)
   (i32.const 8088)
  )
  (i32.store offset=16
   (local.get $4)
   (i32.const 0)
  )
  (i64.store offset=8 align=4
   (local.get $4)
   (i64.const 0)
  )
  (i64.store align=4
   (local.get $4)
   (i64.const 6174015498)
  )
  (i32.store
   (i32.add
    (i32.add
     (i32.load offset=8728
      (i32.const 0)
     )
     (i32.shl
      (local.get $0)
      (i32.const 2)
     )
    )
    (i32.const 8)
   )
   (local.get $4)
  )
  (f64.store offset=8
   (local.tee $5
    (call $GC_allocate
     (i32.const 1)
     (i32.const 4)
    )
   )
   (f64.convert_i32_s
    (local.get $0)
   )
  )
  (i32.store
   (local.get $5)
   (i32.const 4)
  )
  (i32.store offset=12
   (local.tee $4
    (call $GC_allocate
     (i32.const 1)
     (i32.const 4)
    )
   )
   (local.get $5)
  )
  (i32.store offset=8
   (local.get $4)
   (i32.const 12)
  )
  (i64.store align=4
   (local.get $4)
   (i64.const 562956932743172)
  )
  (global.set $__stack_pointer
   (i32.add
    (local.get $3)
    (i32.const 16)
   )
  )
  (local.get $4)
 )
 (func $eval_Platform_incomingPortMap (param $0 i32) (result i32)
  (local $1 i32)
  (local $2 i32)
  (global.set $__stack_pointer
   (local.tee $1
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 16)
    )
   )
  )
  (i32.store offset=8
   (local.get $1)
   (i32.load offset=8
    (local.get $0)
   )
  )
  (local.set $2
   (i32.load
    (local.get $0)
   )
  )
  (i32.store offset=12
   (local.get $1)
   (call $Utils_apply
    (i32.load offset=4
     (local.get $0)
    )
    (i32.const 1)
    (i32.add
     (local.get $1)
     (i32.const 8)
    )
   )
  )
  (local.set $0
   (call $Utils_apply
    (local.get $2)
    (i32.const 1)
    (i32.add
     (local.get $1)
     (i32.const 12)
    )
   )
  )
  (global.set $__stack_pointer
   (i32.add
    (local.get $1)
    (i32.const 16)
   )
  )
  (local.get $0)
 )
 (func $Platform_sendToIncomingPort (param $0 i32) (param $1 i32)
  (local $2 i32)
  (local $3 i32)
  (local $4 i32)
  (global.set $__stack_pointer
   (local.tee $2
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 32)
    )
   )
  )
  (i32.store offset=16
   (local.get $2)
   (local.tee $3
    (call $Json_runHelp
     (i32.load offset=32
      (local.tee $0
       (i32.load
        (i32.add
         (i32.add
          (i32.load offset=8728
           (i32.const 0)
          )
          (i32.shl
           (local.get $0)
           (i32.const 2)
          )
         )
         (i32.const 8)
        )
       )
      )
     )
     (local.get $1)
    )
   )
  )
  (block $label$1
   (block $label$2
    (br_if $label$2
     (i32.eq
      (call $Utils_apply
       (i32.const 0)
       (i32.const 1)
       (i32.add
        (local.get $2)
        (i32.const 16)
       )
      )
      (i32.const 8532)
     )
    )
    (call $log_error
     (i32.const 1381)
     (i32.const 0)
    )
    (br $label$1)
   )
   (br_if $label$1
    (i32.eq
     (local.tee $1
      (i32.load offset=36
       (local.get $0)
      )
     )
     (i32.const 8512)
    )
   )
   (local.set $4
    (i32.load offset=8
     (local.get $3)
    )
   )
   (loop $label$3
    (i32.store offset=12
     (local.get $2)
     (local.get $4)
    )
    (i32.store offset=24
     (local.get $2)
     (call $Utils_apply
      (i32.load offset=4
       (local.get $1)
      )
      (i32.const 1)
      (i32.add
       (local.get $2)
       (i32.const 12)
      )
     )
    )
    (i32.store offset=28
     (local.get $2)
     (i32.load offset=8712
      (i32.const 0)
     )
    )
    (i32.store offset=8712
     (i32.const 0)
     (i32.load offset=4
      (local.tee $0
       (call $Utils_apply
        (i32.load offset=8704
         (i32.const 0)
        )
        (i32.const 2)
        (i32.add
         (local.get $2)
         (i32.const 24)
        )
       )
      )
     )
    )
    (call $jsStepper
     (i32.const 0)
    )
    (i32.store offset=20
     (local.get $2)
     (i32.load offset=8712
      (i32.const 0)
     )
    )
    (local.set $0
     (i32.load offset=8
      (local.get $0)
     )
    )
    (local.set $3
     (call $Utils_apply
      (i32.load offset=8708
       (i32.const 0)
      )
      (i32.const 1)
      (i32.add
       (local.get $2)
       (i32.const 20)
      )
     )
    )
    (call $Platform_enqueueEffects
     (i32.load offset=8716
      (i32.const 0)
     )
     (local.get $0)
     (local.get $3)
    )
    (br_if $label$3
     (i32.ne
      (local.tee $1
       (i32.load offset=8
        (local.get $1)
       )
      )
      (i32.const 8512)
     )
    )
   )
  )
  (global.set $__stack_pointer
   (i32.add
    (local.get $2)
    (i32.const 32)
   )
  )
 )
 (func $Platform_incomingPort (param $0 i32) (param $1 i32) (param $2 i32) (result i32)
  (local $3 i32)
  (local $4 i32)
  (local $5 i32)
  (local $6 i32)
  (global.set $__stack_pointer
   (local.tee $3
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 16)
    )
   )
  )
  (block $label$1
   (br_if $label$1
    (i32.eqz
     (i32.load
      (i32.const 0)
     )
    )
   )
   (local.set $4
    (i32.const 8)
   )
   (local.set $5
    (i32.const 0)
   )
   (loop $label$2
    (block $label$3
     (br_if $label$3
      (i32.gt_u
       (i32.add
        (i32.load offset=4
         (local.tee $6
          (i32.load
           (i32.add
            (i32.load offset=8728
             (i32.const 0)
            )
            (local.get $4)
           )
          )
         )
        )
        (i32.const -1)
       )
       (i32.const 1)
      )
     )
     (i32.store offset=8
      (local.get $3)
      (local.get $1)
     )
     (i32.store offset=12
      (local.get $3)
      (i32.load offset=28
       (local.get $6)
      )
     )
     (br_if $label$3
      (i32.ne
       (call $Utils_apply
        (i32.const 8568)
        (i32.const 2)
        (i32.add
         (local.get $3)
         (i32.const 8)
        )
       )
       (i32.const 8532)
      )
     )
     (call $log_error
      (i32.const 2966)
      (i32.const 0)
     )
    )
    (local.set $4
     (i32.add
      (local.get $4)
      (i32.const 4)
     )
    )
    (br_if $label$2
     (i32.lt_u
      (local.tee $5
       (i32.add
        (local.get $5)
        (i32.const 1)
       )
      )
      (i32.load
       (i32.const 0)
      )
     )
    )
   )
  )
  (i32.store offset=36
   (local.tee $4
    (call $GC_allocate
     (i32.const 1)
     (i32.const 10)
    )
   )
   (i32.const 0)
  )
  (i32.store offset=32
   (local.get $4)
   (local.get $2)
  )
  (i32.store offset=28
   (local.get $4)
   (local.get $1)
  )
  (i32.store offset=24
   (local.get $4)
   (i32.const 8100)
  )
  (i64.store offset=16 align=4
   (local.get $4)
   (i64.const 0)
  )
  (i64.store offset=8 align=4
   (local.get $4)
   (i64.const 0)
  )
  (i64.store align=4
   (local.get $4)
   (i64.const 10468982794)
  )
  (i32.store
   (i32.add
    (i32.add
     (i32.load offset=8728
      (i32.const 0)
     )
     (i32.shl
      (local.get $0)
      (i32.const 2)
     )
    )
    (i32.const 8)
   )
   (local.get $4)
  )
  (f64.store offset=8
   (local.tee $5
    (call $GC_allocate
     (i32.const 1)
     (i32.const 4)
    )
   )
   (f64.convert_i32_s
    (local.get $0)
   )
  )
  (i32.store
   (local.get $5)
   (i32.const 4)
  )
  (i32.store offset=12
   (local.tee $4
    (call $GC_allocate
     (i32.const 1)
     (i32.const 4)
    )
   )
   (local.get $5)
  )
  (i32.store offset=8
   (local.get $4)
   (i32.const 12)
  )
  (i64.store align=4
   (local.get $4)
   (i64.const 562956932743172)
  )
  (global.set $__stack_pointer
   (i32.add
    (local.get $3)
    (i32.const 16)
   )
  )
  (local.get $4)
 )
 (func $newJsRef (param $0 i32) (result i32)
  (local $1 i32)
  (i32.store offset=4
   (local.tee $1
    (call $GC_allocate
     (i32.const 1)
     (i32.const 2)
    )
   )
   (local.get $0)
  )
  (i32.store
   (local.get $1)
   (i32.const -1342177278)
  )
  (local.get $1)
 )
 (func $eval_Process_sleep (param $0 i32) (result i32)
  (call $Wrapper_sleep
   (f64.load offset=8
    (i32.load
     (local.get $0)
    )
   )
  )
 )
 (func $newTask (param $0 i32) (param $1 i32) (param $2 i32) (param $3 i32) (param $4 i32) (result i32)
  (local $5 i32)
  (i32.store offset=20
   (local.tee $5
    (call $GC_allocate
     (i32.const 1)
     (i32.const 6)
    )
   )
   (local.get $4)
  )
  (i32.store offset=16
   (local.get $5)
   (local.get $3)
  )
  (i32.store offset=12
   (local.get $5)
   (local.get $2)
  )
  (i32.store offset=8
   (local.get $5)
   (local.get $1)
  )
  (i32.store offset=4
   (local.get $5)
   (local.get $0)
  )
  (i32.store
   (local.get $5)
   (i32.const -805306362)
  )
  (local.get $5)
 )
 (func $eval_Scheduler_fail (param $0 i32) (result i32)
  (local $1 i32)
  (local.set $1
   (i32.load
    (local.get $0)
   )
  )
  (i32.store offset=20
   (local.tee $0
    (call $GC_allocate
     (i32.const 1)
     (i32.const 6)
    )
   )
   (i32.const 0)
  )
  (i64.store offset=12 align=4
   (local.get $0)
   (i64.const 0)
  )
  (i32.store offset=8
   (local.get $0)
   (local.get $1)
  )
  (i64.store align=4
   (local.get $0)
   (i64.const 7784628230)
  )
  (local.get $0)
 )
 (func $eval_Scheduler_onError (param $0 i32) (result i32)
  (local $1 i32)
  (local $2 i32)
  (local.set $1
   (i32.load
    (local.get $0)
   )
  )
  (local.set $2
   (i32.load offset=4
    (local.get $0)
   )
  )
  (i32.store offset=20
   (local.tee $0
    (call $GC_allocate
     (i32.const 1)
     (i32.const 6)
    )
   )
   (local.get $2)
  )
  (i32.store offset=16
   (local.get $0)
   (i32.const 0)
  )
  (i32.store offset=12
   (local.get $0)
   (local.get $1)
  )
  (i32.store offset=8
   (local.get $0)
   (i32.const 0)
  )
  (i64.store align=4
   (local.get $0)
   (i64.const 20669530118)
  )
  (local.get $0)
 )
 (func $eval_Scheduler_step_lambda (param $0 i32) (result i32)
  (local $1 i32)
  (i32.store offset=8
   (local.tee $1
    (i32.load
     (local.get $0)
    )
   )
   (i32.load offset=4
    (local.get $0)
   )
  )
  (call $Scheduler_enqueue
   (local.get $1)
  )
  (i32.const 0)
 )
 (func $eval_Scheduler_spawn_lambda (param $0 i32) (result i32)
  (local $1 i32)
  (local $2 i32)
  (local $3 i32)
  (global.set $__stack_pointer
   (local.tee $1
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 16)
    )
   )
  )
  (i32.store offset=12
   (local.get $1)
   (i32.load
    (local.get $0)
   )
  )
  (local.set $2
   (i32.load offset=4
    (local.get $0)
   )
  )
  (local.set $3
   (call $eval_Scheduler_rawSpawn
    (i32.add
     (local.get $1)
     (i32.const 12)
    )
   )
  )
  (i32.store offset=20
   (local.tee $0
    (call $GC_allocate
     (i32.const 1)
     (i32.const 6)
    )
   )
   (i32.const 0)
  )
  (i64.store offset=12 align=4
   (local.get $0)
   (i64.const 0)
  )
  (i32.store offset=8
   (local.get $0)
   (local.get $3)
  )
  (i64.store align=4
   (local.get $0)
   (i64.const 3489660934)
  )
  (i32.store offset=8
   (local.get $1)
   (local.get $0)
  )
  (drop
   (call $Utils_apply
    (local.get $2)
    (i32.const 1)
    (i32.add
     (local.get $1)
     (i32.const 8)
    )
   )
  )
  (global.set $__stack_pointer
   (i32.add
    (local.get $1)
    (i32.const 16)
   )
  )
  (i32.const 0)
 )
 (func $eval_Scheduler_spawn (param $0 i32) (result i32)
  (local $1 i32)
  (i32.store offset=8
   (local.tee $1
    (call $GC_allocate
     (i32.const 1)
     (i32.const 4)
    )
   )
   (i32.const 13)
  )
  (i64.store align=4
   (local.get $1)
   (i64.const 562956932743172)
  )
  (block $label$1
   (br_if $label$1
    (i32.eqz
     (local.get $0)
    )
   )
   (i32.store offset=12
    (local.get $1)
    (i32.load
     (local.get $0)
    )
   )
  )
  (i64.store offset=16 align=4
   (local.tee $0
    (call $GC_allocate
     (i32.const 1)
     (i32.const 6)
    )
   )
   (i64.const 0)
  )
  (i32.store offset=12
   (local.get $0)
   (local.get $1)
  )
  (i32.store offset=8
   (local.get $0)
   (i32.const 0)
  )
  (i64.store align=4
   (local.get $0)
   (i64.const 12079595526)
  )
  (local.get $0)
 )
 (func $eval_Scheduler_kill_lambda (param $0 i32) (result i32)
  (local $1 i32)
  (local $2 i32)
  (local $3 i32)
  (global.set $__stack_pointer
   (local.tee $1
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 16)
    )
   )
  )
  (local.set $2
   (i32.load offset=4
    (local.get $0)
   )
  )
  (block $label$1
   (br_if $label$1
    (i32.ne
     (i32.load offset=4
      (local.tee $3
       (i32.load offset=8
        (local.tee $0
         (i32.load
          (local.get $0)
         )
        )
       )
      )
     )
     (i32.const 2)
    )
   )
   (br_if $label$1
    (i32.eqz
     (local.tee $3
      (i32.load offset=16
       (local.get $3)
      )
     )
    )
   )
   (br_if $label$1
    (i32.ne
     (i32.and
      (i32.load
       (local.get $3)
      )
      (i32.const -268435456)
     )
     (i32.const -1610612736)
    )
   )
   (drop
    (call $Utils_apply
     (local.get $3)
     (i32.const 0)
     (i32.const 0)
    )
   )
  )
  (i32.store offset=8
   (local.get $0)
   (i32.const 0)
  )
  (local.set $3
   (i32.load offset=8016
    (i32.const 0)
   )
  )
  (i32.store offset=20
   (local.tee $0
    (call $GC_allocate
     (i32.const 1)
     (i32.const 6)
    )
   )
   (i32.const 0)
  )
  (i64.store offset=12 align=4
   (local.get $0)
   (i64.const 0)
  )
  (i32.store offset=8
   (local.get $0)
   (local.get $3)
  )
  (i64.store align=4
   (local.get $0)
   (i64.const 3489660934)
  )
  (i32.store offset=12
   (local.get $1)
   (local.get $0)
  )
  (drop
   (call $Utils_apply
    (local.get $2)
    (i32.const 1)
    (i32.add
     (local.get $1)
     (i32.const 12)
    )
   )
  )
  (global.set $__stack_pointer
   (i32.add
    (local.get $1)
    (i32.const 16)
   )
  )
  (i32.const 0)
 )
 (func $eval_Scheduler_kill (param $0 i32) (result i32)
  (local $1 i32)
  (i32.store offset=8
   (local.tee $1
    (call $GC_allocate
     (i32.const 1)
     (i32.const 4)
    )
   )
   (i32.const 14)
  )
  (i64.store align=4
   (local.get $1)
   (i64.const 562956932743172)
  )
  (block $label$1
   (br_if $label$1
    (i32.eqz
     (local.get $0)
    )
   )
   (i32.store offset=12
    (local.get $1)
    (i32.load
     (local.get $0)
    )
   )
  )
  (i64.store offset=16 align=4
   (local.tee $0
    (call $GC_allocate
     (i32.const 1)
     (i32.const 6)
    )
   )
   (i64.const 0)
  )
  (i32.store offset=12
   (local.get $0)
   (local.get $1)
  )
  (i32.store offset=8
   (local.get $0)
   (i32.const 0)
  )
  (i64.store align=4
   (local.get $0)
   (i64.const 12079595526)
  )
  (local.get $0)
 )
 (func $code_units (param $0 i32) (result i32)
  (local $1 i32)
  (local $2 i32)
  (local $3 i32)
  (local $4 i32)
  (local.set $1
   (i32.add
    (local.get $0)
    (i32.const 4)
   )
  )
  (local.set $2
   (i32.add
    (i32.shl
     (i32.and
      (i32.load
       (local.get $0)
      )
      (i32.const 268435455)
     )
     (i32.const 2)
    )
    (i32.const -2)
   )
  )
  (block $label$1
   (loop $label$2
    (local.set $3
     (i32.add
      (local.get $2)
      (i32.const -2)
     )
    )
    (br_if $label$1
     (i32.load16_u
      (local.tee $4
       (i32.add
        (local.get $0)
        (local.get $2)
       )
      )
     )
    )
    (local.set $2
     (local.get $3)
    )
    (br_if $label$2
     (i32.ge_u
      (local.get $4)
      (local.get $1)
     )
    )
   )
  )
  (i32.shr_s
   (local.get $3)
   (i32.const 1)
  )
 )
 (func $String_copy (param $0 i32) (param $1 i32) (result i32)
  (local $2 i32)
  (local $3 i32)
  (local $4 i32)
  (local $5 i32)
  (local $6 i64)
  (local.set $2
   (i32.add
    (local.get $1)
    (i32.const 4)
   )
  )
  (local.set $3
   (i32.add
    (i32.shl
     (i32.and
      (i32.load
       (local.get $1)
      )
      (i32.const 268435455)
     )
     (i32.const 2)
    )
    (i32.const -2)
   )
  )
  (block $label$1
   (loop $label$2
    (local.set $4
     (i32.add
      (local.get $3)
      (i32.const -2)
     )
    )
    (br_if $label$1
     (i32.load16_u
      (local.tee $5
       (i32.add
        (local.get $1)
        (local.get $3)
       )
      )
     )
    )
    (local.set $3
     (local.get $4)
    )
    (br_if $label$2
     (i32.ge_u
      (local.get $5)
      (local.get $2)
     )
    )
   )
  )
  (local.set $5
   (i32.add
    (i32.add
     (local.get $1)
     (local.get $4)
    )
    (i32.const 4)
   )
  )
  (block $label$3
   (br_if $label$3
    (i32.eqz
     (i32.and
      (local.get $0)
      (i32.const 7)
     )
    )
   )
   (br_if $label$3
    (i32.lt_s
     (local.get $4)
     (i32.const 1)
    )
   )
   (local.set $3
    (i32.add
     (local.get $0)
     (i32.const 2)
    )
   )
   (loop $label$4
    (br_if $label$3
     (i32.eqz
      (local.tee $4
       (i32.load16_u
        (local.get $2)
       )
      )
     )
    )
    (i32.store16
     (local.get $0)
     (local.get $4)
    )
    (local.set $2
     (i32.add
      (local.get $2)
      (i32.const 2)
     )
    )
    (local.set $0
     (i32.add
      (local.get $0)
      (i32.const 2)
     )
    )
    (br_if $label$3
     (i32.eqz
      (i32.and
       (local.get $3)
       (i32.const 7)
      )
     )
    )
    (local.set $3
     (i32.add
      (local.get $3)
      (i32.const 2)
     )
    )
    (br_if $label$4
     (i32.lt_u
      (local.get $2)
      (local.get $5)
     )
    )
   )
  )
  (block $label$5
   (br_if $label$5
    (i32.le_u
     (local.tee $3
      (i32.add
       (local.get $2)
       (i32.shl
        (i32.div_s
         (i32.shr_s
          (i32.sub
           (local.get $5)
           (local.get $2)
          )
          (i32.const 1)
         )
         (i32.const 4)
        )
        (i32.const 3)
       )
      )
     )
     (local.get $2)
    )
   )
   (loop $label$6
    (br_if $label$5
     (i64.eqz
      (local.tee $6
       (i64.load
        (local.get $2)
       )
      )
     )
    )
    (i64.store
     (local.get $0)
     (local.get $6)
    )
    (local.set $0
     (i32.add
      (local.get $0)
      (i32.const 8)
     )
    )
    (br_if $label$6
     (i32.lt_u
      (local.tee $2
       (i32.add
        (local.get $2)
        (i32.const 8)
       )
      )
      (local.get $3)
     )
    )
   )
  )
  (block $label$7
   (br_if $label$7
    (i32.le_u
     (local.get $5)
     (local.get $2)
    )
   )
   (loop $label$8
    (br_if $label$7
     (i32.eqz
      (local.tee $3
       (i32.load16_u
        (local.get $2)
       )
      )
     )
    )
    (i32.store16
     (local.get $0)
     (local.get $3)
    )
    (local.set $0
     (i32.add
      (local.get $0)
      (i32.const 2)
     )
    )
    (br_if $label$8
     (i32.lt_u
      (local.tee $2
       (i32.add
        (local.get $2)
        (i32.const 2)
       )
      )
      (local.get $5)
     )
    )
   )
  )
  (local.get $0)
 )
 (func $find_reverse (param $0 i32) (param $1 i32) (param $2 i32) (param $3 i32) (result i32)
  (local $4 i32)
  (local $5 i32)
  (local $6 i32)
  (local $7 i32)
  (local $8 i32)
  (local $9 i32)
  (local $10 i32)
  (local $11 i32)
  (local.set $4
   (i32.add
    (local.get $1)
    (i32.const -2)
   )
  )
  (local.set $5
   (i32.add
    (i32.add
     (i32.shl
      (local.get $2)
      (i32.const 1)
     )
     (local.get $0)
    )
    (i32.const -4)
   )
  )
  (local.set $7
   (i32.add
    (local.get $0)
    (i32.shl
     (local.tee $6
      (i32.add
       (local.get $2)
       (i32.const -1)
      )
     )
     (i32.const 1)
    )
   )
  )
  (loop $label$1
   (block $label$2
    (block $label$3
     (br_if $label$3
      (i32.ge_s
       (i32.or
        (local.get $3)
        (local.get $6)
       )
       (i32.const 0)
      )
     )
     (local.set $0
      (local.get $3)
     )
     (br $label$2)
    )
    (local.set $2
     (i32.add
      (local.get $1)
      (i32.shl
       (local.get $3)
       (i32.const 1)
      )
     )
    )
    (local.set $8
     (i32.load16_u
      (local.get $7)
     )
    )
    (local.set $0
     (local.get $3)
    )
    (loop $label$4
     (br_if $label$2
      (i32.eq
       (i32.load16_u
        (local.get $2)
       )
       (i32.and
        (local.get $8)
        (i32.const 65535)
       )
      )
     )
     (local.set $2
      (i32.add
       (local.get $2)
       (i32.const -2)
      )
     )
     (br_if $label$4
      (i32.gt_s
       (i32.or
        (local.tee $0
         (i32.add
          (local.get $0)
          (i32.const -1)
         )
        )
        (local.get $6)
       )
       (i32.const -1)
      )
     )
    )
   )
   (block $label$5
    (br_if $label$5
     (i32.ge_s
      (local.get $0)
      (i32.const 0)
     )
    )
    (return
     (i32.const -1)
    )
   )
   (local.set $3
    (i32.add
     (local.get $0)
     (i32.const -1)
    )
   )
   (local.set $8
    (i32.add
     (local.get $4)
     (i32.shl
      (local.get $0)
      (i32.const 1)
     )
    )
   )
   (local.set $9
    (local.get $5)
   )
   (local.set $2
    (local.get $6)
   )
   (block $label$6
    (loop $label$7
     (br_if $label$6
      (i32.eqz
       (local.get $0)
      )
     )
     (br_if $label$6
      (i32.lt_s
       (local.get $2)
       (i32.const 1)
      )
     )
     (local.set $2
      (i32.add
       (local.get $2)
       (i32.const -1)
      )
     )
     (local.set $0
      (i32.add
       (local.get $0)
       (i32.const -1)
      )
     )
     (local.set $10
      (i32.load16_u
       (local.get $9)
      )
     )
     (local.set $11
      (i32.load16_u
       (local.get $8)
      )
     )
     (local.set $9
      (i32.add
       (local.get $9)
       (i32.const -2)
      )
     )
     (local.set $8
      (i32.add
       (local.get $8)
       (i32.const -2)
      )
     )
     (br_if $label$1
      (i32.ne
       (local.get $11)
       (local.get $10)
      )
     )
     (br $label$7)
    )
   )
   (block $label$8
    (br_if $label$8
     (i32.lt_s
      (local.get $2)
      (i32.const 1)
     )
    )
    (br_if $label$1
     (local.get $0)
    )
   )
  )
  (select
   (local.get $0)
   (i32.const -1)
   (i32.lt_s
    (local.get $2)
    (i32.const 1)
   )
  )
 )
 (func $find_forward (param $0 i32) (param $1 i32) (param $2 i32) (param $3 i32) (result i32)
  (local $4 i32)
  (local $5 i32)
  (local $6 i32)
  (local $7 i32)
  (local $8 i32)
  (local $9 i32)
  (local $10 i32)
  (local $11 i32)
  (local $12 i32)
  (local $13 i32)
  (block $label$1
   (block $label$2
    (block $label$3
     (br_if $label$3
      (i32.eqz
       (local.get $2)
      )
     )
     (local.set $4
      (i32.add
       (local.get $0)
       (i32.const 2)
      )
     )
     (local.set $5
      (i32.add
       (local.get $1)
       (i32.const 2)
      )
     )
     (local.set $6
      (i32.const 0)
     )
     (loop $label$4
      (block $label$5
       (br_if $label$5
        (i32.ge_u
         (local.get $6)
         (local.get $3)
        )
       )
       (local.set $7
        (i32.add
         (local.get $1)
         (i32.shl
          (local.get $6)
          (i32.const 1)
         )
        )
       )
       (local.set $8
        (i32.load16_u
         (local.get $0)
        )
       )
       (loop $label$6
        (br_if $label$5
         (i32.eq
          (i32.load16_u
           (local.get $7)
          )
          (i32.and
           (local.get $8)
           (i32.const 65535)
          )
         )
        )
        (local.set $7
         (i32.add
          (local.get $7)
          (i32.const 2)
         )
        )
        (br_if $label$6
         (i32.ne
          (local.get $3)
          (local.tee $6
           (i32.add
            (local.get $6)
            (i32.const 1)
           )
          )
         )
        )
       )
       (return
        (i32.const -1)
       )
      )
      (local.set $9
       (i32.const -1)
      )
      (br_if $label$1
       (i32.ge_u
        (local.tee $10
         (local.get $6)
        )
        (local.get $3)
       )
      )
      (local.set $6
       (i32.add
        (local.get $10)
        (i32.const 1)
       )
      )
      (br_if $label$4
       (i32.ne
        (i32.load16_u
         (i32.add
          (local.get $1)
          (i32.shl
           (local.get $10)
           (i32.const 1)
          )
         )
        )
        (i32.load16_u
         (local.get $0)
        )
       )
      )
      (local.set $7
       (i32.const 1)
      )
      (local.set $8
       (i32.add
        (local.get $5)
        (i32.shl
         (local.get $10)
         (i32.const 1)
        )
       )
      )
      (local.set $11
       (local.get $4)
      )
      (block $label$7
       (loop $label$8
        (br_if $label$7
         (i32.ge_u
          (local.tee $12
           (i32.add
            (local.get $10)
            (local.get $7)
           )
          )
          (local.get $3)
         )
        )
        (br_if $label$7
         (i32.ge_u
          (local.get $7)
          (local.get $2)
         )
        )
        (local.set $7
         (i32.add
          (local.get $7)
          (i32.const 1)
         )
        )
        (local.set $12
         (i32.load16_u
          (local.get $11)
         )
        )
        (local.set $13
         (i32.load16_u
          (local.get $8)
         )
        )
        (local.set $11
         (i32.add
          (local.get $11)
          (i32.const 2)
         )
        )
        (local.set $8
         (i32.add
          (local.get $8)
          (i32.const 2)
         )
        )
        (br_if $label$4
         (i32.ne
          (local.get $13)
          (local.get $12)
         )
        )
        (br $label$8)
       )
      )
      (br_if $label$2
       (i32.ge_u
        (local.get $7)
        (local.get $2)
       )
      )
      (br_if $label$4
       (i32.lt_u
        (local.get $12)
        (local.get $3)
       )
      )
      (br $label$1)
     )
    )
    (local.set $12
     (i32.const 0)
    )
    (br_if $label$2
     (local.get $3)
    )
    (return
     (i32.const -1)
    )
   )
   (local.set $9
    (i32.sub
     (local.get $12)
     (local.get $2)
    )
   )
  )
  (local.get $9)
 )
 (func $eval_String_uncons (param $0 i32) (result i32)
  (local $1 i32)
  (local $2 i32)
  (local $3 i32)
  (local $4 i32)
  (local $5 i32)
  (local $6 i32)
  (local $7 i32)
  (local $8 i32)
  (local $9 i32)
  (local $10 i32)
  (local $11 i32)
  (local $12 i32)
  (local $13 i64)
  (global.set $__stack_pointer
   (local.tee $1
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 16)
    )
   )
  )
  (local.set $3
   (i32.add
    (local.tee $2
     (i32.load
      (local.get $0)
     )
    )
    (i32.const 4)
   )
  )
  (local.set $0
   (i32.add
    (i32.shl
     (i32.and
      (i32.load
       (local.get $2)
      )
      (i32.const 268435455)
     )
     (i32.const 2)
    )
    (i32.const -2)
   )
  )
  (block $label$1
   (loop $label$2
    (local.set $4
     (i32.add
      (local.get $0)
      (i32.const -2)
     )
    )
    (br_if $label$1
     (i32.load16_u
      (local.tee $5
       (i32.add
        (local.get $2)
        (local.get $0)
       )
      )
     )
    )
    (local.set $0
     (local.get $4)
    )
    (br_if $label$2
     (i32.ge_u
      (local.get $5)
      (local.get $3)
     )
    )
   )
  )
  (block $label$3
   (block $label$4
    (br_if $label$4
     (local.get $4)
    )
    (local.set $0
     (i32.const 0)
    )
    (br $label$3)
   )
   (local.set $6
    (i32.const 1)
   )
   (local.set $0
    (i32.shr_s
     (local.get $4)
     (i32.const 1)
    )
   )
   (block $label$5
    (br_if $label$5
     (i32.ne
      (i32.and
       (local.tee $4
        (i32.load16_u
         (local.get $3)
        )
       )
       (i32.const 64512)
      )
      (i32.const 55296)
     )
    )
    (local.set $4
     (i32.or
      (i32.shl
       (i32.load16_u
        (i32.add
         (local.get $2)
         (i32.const 6)
        )
       )
       (i32.const 16)
      )
      (local.get $4)
     )
    )
    (local.set $6
     (i32.const 2)
    )
   )
   (i32.store offset=4
    (local.tee $7
     (call $GC_allocate
      (i32.const 1)
      (i32.const 2)
     )
    )
    (local.get $4)
   )
   (i32.store
    (local.get $7)
    (i32.const 536870914)
   )
   (local.set $8
    (call $GC_allocate
     (i32.const 1)
     (local.tee $4
      (i32.shr_u
       (local.tee $3
        (i32.add
         (local.tee $5
          (i32.shl
           (i32.sub
            (local.get $0)
            (local.get $6)
           )
           (i32.const 1)
          )
         )
         (i32.const 7)
        )
       )
       (i32.const 2)
      )
     )
    )
   )
   (block $label$6
    (br_if $label$6
     (i32.eq
      (i32.and
       (local.get $3)
       (i32.const -4)
      )
      (i32.add
       (local.get $5)
       (i32.const 4)
      )
     )
    )
    (i32.store
     (i32.add
      (i32.add
       (i32.shl
        (local.get $4)
        (i32.const 2)
       )
       (local.get $8)
      )
      (i32.const -4)
     )
     (i32.const 0)
    )
   )
   (i32.store
    (local.get $8)
    (i32.or
     (local.get $4)
     (i32.const 805306368)
    )
   )
   (local.set $5
    (i32.add
     (local.tee $4
      (i32.add
       (local.get $2)
       (i32.const 4)
      )
     )
     (i32.shl
      (local.get $0)
      (i32.const 1)
     )
    )
   )
   (local.set $4
    (i32.add
     (local.get $4)
     (i32.shl
      (local.get $6)
      (i32.const 1)
     )
    )
   )
   (local.set $9
    (i32.add
     (local.get $8)
     (i32.const 4)
    )
   )
   (block $label$7
    (block $label$8
     (br_if $label$8
      (i32.gt_s
       (local.get $0)
       (local.get $6)
      )
     )
     (local.set $0
      (local.get $9)
     )
     (br $label$7)
    )
    (block $label$9
     (br_if $label$9
      (i32.and
       (local.get $9)
       (i32.const 7)
      )
     )
     (local.set $0
      (local.get $9)
     )
     (br $label$7)
    )
    (local.set $10
     (i32.add
      (local.get $8)
      (i32.const 6)
     )
    )
    (local.set $11
     (i32.add
      (local.get $2)
      (i32.shl
       (local.get $6)
       (i32.const 1)
      )
     )
    )
    (local.set $4
     (i32.const 0)
    )
    (block $label$10
     (loop $label$11
      (local.set $0
       (i32.add
        (local.get $9)
        (local.get $4)
       )
      )
      (br_if $label$10
       (i32.eqz
        (local.tee $3
         (i32.load16_u
          (i32.add
           (local.tee $12
            (i32.add
             (local.get $11)
             (local.get $4)
            )
           )
           (i32.const 4)
          )
         )
        )
       )
      )
      (i32.store16
       (local.get $0)
       (local.get $3)
      )
      (local.set $3
       (i32.add
        (local.get $4)
        (i32.const 2)
       )
      )
      (block $label$12
       (br_if $label$12
        (i32.eqz
         (i32.and
          (i32.add
           (local.get $10)
           (local.get $4)
          )
          (i32.const 7)
         )
        )
       )
       (local.set $4
        (local.get $3)
       )
       (br_if $label$11
        (i32.lt_u
         (i32.add
          (local.get $12)
          (i32.const 6)
         )
         (local.get $5)
        )
       )
      )
     )
     (local.set $0
      (i32.add
       (local.get $9)
       (local.get $3)
      )
     )
     (local.set $4
      (i32.add
       (i32.add
        (i32.add
         (local.get $2)
         (i32.shl
          (local.get $6)
          (i32.const 1)
         )
        )
        (local.get $3)
       )
       (i32.const 4)
      )
     )
     (br $label$7)
    )
    (local.set $4
     (i32.add
      (i32.add
       (i32.add
        (local.get $2)
        (i32.shl
         (local.get $6)
         (i32.const 1)
        )
       )
       (local.get $4)
      )
      (i32.const 4)
     )
    )
   )
   (block $label$13
    (br_if $label$13
     (i32.le_u
      (local.tee $2
       (i32.add
        (local.get $4)
        (i32.shl
         (i32.div_s
          (i32.shr_s
           (i32.sub
            (local.get $5)
            (local.get $4)
           )
           (i32.const 1)
          )
          (i32.const 4)
         )
         (i32.const 3)
        )
       )
      )
      (local.get $4)
     )
    )
    (loop $label$14
     (br_if $label$13
      (i64.eqz
       (local.tee $13
        (i64.load
         (local.get $4)
        )
       )
      )
     )
     (i64.store
      (local.get $0)
      (local.get $13)
     )
     (local.set $0
      (i32.add
       (local.get $0)
       (i32.const 8)
      )
     )
     (br_if $label$14
      (i32.lt_u
       (local.tee $4
        (i32.add
         (local.get $4)
         (i32.const 8)
        )
       )
       (local.get $2)
      )
     )
    )
   )
   (block $label$15
    (br_if $label$15
     (i32.le_u
      (local.get $5)
      (local.get $4)
     )
    )
    (loop $label$16
     (br_if $label$15
      (i32.eqz
       (local.tee $2
        (i32.load16_u
         (local.get $4)
        )
       )
      )
     )
     (i32.store16
      (local.get $0)
      (local.get $2)
     )
     (local.set $0
      (i32.add
       (local.get $0)
       (i32.const 2)
      )
     )
     (br_if $label$16
      (i32.lt_u
       (local.tee $4
        (i32.add
         (local.get $4)
         (i32.const 2)
        )
       )
       (local.get $5)
      )
     )
    )
   )
   (i32.store
    (local.tee $0
     (call $GC_allocate
      (i32.const 1)
      (i32.const 3)
     )
    )
    (i32.const 1342177283)
   )
   (i32.store offset=8
    (local.get $0)
    (local.get $8)
   )
   (i32.store offset=4
    (local.get $0)
    (local.get $7)
   )
   (i32.store offset=12
    (local.get $1)
    (local.get $0)
   )
   (local.set $0
    (call $Utils_apply
     (i32.const 0)
     (i32.const 1)
     (i32.add
      (local.get $1)
      (i32.const 12)
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
  (local.get $0)
 )
 (func $newElmChar (param $0 i32) (result i32)
  (local $1 i32)
  (i32.store offset=4
   (local.tee $1
    (call $GC_allocate
     (i32.const 1)
     (i32.const 2)
    )
   )
   (local.get $0)
  )
  (i32.store
   (local.get $1)
   (i32.const 536870914)
  )
  (local.get $1)
 )
 (func $newElmString (param $0 i32) (result i32)
  (local $1 i32)
  (local $2 i32)
  (local $3 i32)
  (local.set $0
   (call $GC_allocate
    (i32.const 1)
    (local.tee $3
     (i32.shr_u
      (local.tee $2
       (i32.add
        (local.tee $1
         (i32.shl
          (local.get $0)
          (i32.const 1)
         )
        )
        (i32.const 7)
       )
      )
      (i32.const 2)
     )
    )
   )
  )
  (block $label$1
   (br_if $label$1
    (i32.eq
     (i32.and
      (local.get $2)
      (i32.const -4)
     )
     (i32.add
      (local.get $1)
      (i32.const 4)
     )
    )
   )
   (i32.store
    (i32.add
     (i32.add
      (i32.shl
       (local.get $3)
       (i32.const 2)
      )
      (local.get $0)
     )
     (i32.const -4)
    )
    (i32.const 0)
   )
  )
  (i32.store
   (local.get $0)
   (i32.or
    (local.get $3)
    (i32.const 805306368)
   )
  )
  (local.get $0)
 )
 (func $eval_String_append (param $0 i32) (result i32)
  (local $1 i32)
  (local $2 i32)
  (local $3 i32)
  (local $4 i32)
  (local $5 i32)
  (local $6 i32)
  (local $7 i32)
  (local $8 i32)
  (local $9 i32)
  (local $10 i32)
  (local $11 i32)
  (local $12 i64)
  (local.set $2
   (i32.add
    (local.tee $1
     (i32.load
      (local.get $0)
     )
    )
    (i32.const 4)
   )
  )
  (local.set $3
   (i32.add
    (i32.shl
     (i32.and
      (i32.load
       (local.get $1)
      )
      (i32.const 268435455)
     )
     (i32.const 2)
    )
    (i32.const -2)
   )
  )
  (local.set $4
   (i32.load offset=4
    (local.get $0)
   )
  )
  (block $label$1
   (loop $label$2
    (local.set $5
     (i32.add
      (local.get $3)
      (i32.const -2)
     )
    )
    (br_if $label$1
     (i32.load16_u
      (local.tee $0
       (i32.add
        (local.get $1)
        (local.get $3)
       )
      )
     )
    )
    (local.set $3
     (local.get $5)
    )
    (br_if $label$2
     (i32.ge_u
      (local.get $0)
      (local.get $2)
     )
    )
   )
  )
  (local.set $3
   (i32.add
    (local.get $4)
    (i32.const 4)
   )
  )
  (local.set $0
   (i32.add
    (i32.shl
     (i32.and
      (i32.load
       (local.get $4)
      )
      (i32.const 268435455)
     )
     (i32.const 2)
    )
    (i32.const -2)
   )
  )
  (block $label$3
   (loop $label$4
    (local.set $6
     (i32.add
      (local.get $0)
      (i32.const -2)
     )
    )
    (br_if $label$3
     (i32.load16_u
      (local.tee $7
       (i32.add
        (local.get $4)
        (local.get $0)
       )
      )
     )
    )
    (local.set $0
     (local.get $6)
    )
    (br_if $label$4
     (i32.ge_u
      (local.get $7)
      (local.get $3)
     )
    )
   )
  )
  (local.set $11
   (call $GC_allocate
    (i32.const 1)
    (local.tee $0
     (i32.shr_u
      (local.tee $10
       (i32.add
        (local.tee $7
         (i32.shl
          (i32.add
           (local.tee $8
            (i32.shr_s
             (local.get $6)
             (i32.const 1)
            )
           )
           (local.tee $9
            (i32.shr_s
             (local.get $5)
             (i32.const 1)
            )
           )
          )
          (i32.const 1)
         )
        )
        (i32.const 7)
       )
      )
      (i32.const 2)
     )
    )
   )
  )
  (block $label$5
   (br_if $label$5
    (i32.eq
     (i32.and
      (local.get $10)
      (i32.const -4)
     )
     (i32.add
      (local.get $7)
      (i32.const 4)
     )
    )
   )
   (i32.store
    (i32.add
     (i32.add
      (i32.shl
       (local.get $0)
       (i32.const 2)
      )
      (local.get $11)
     )
     (i32.const -4)
    )
    (i32.const 0)
   )
  )
  (i32.store
   (local.get $11)
   (i32.or
    (local.get $0)
    (i32.const 805306368)
   )
  )
  (local.set $0
   (i32.add
    (local.get $11)
    (i32.const 4)
   )
  )
  (local.set $7
   (i32.add
    (i32.add
     (local.get $1)
     (i32.shl
      (local.get $9)
      (i32.const 1)
     )
    )
    (i32.const 4)
   )
  )
  (block $label$6
   (br_if $label$6
    (i32.lt_s
     (local.get $5)
     (i32.const 1)
    )
   )
   (br_if $label$6
    (i32.eqz
     (i32.and
      (local.get $0)
      (i32.const 7)
     )
    )
   )
   (local.set $5
    (i32.add
     (local.get $11)
     (i32.const 6)
    )
   )
   (loop $label$7
    (br_if $label$6
     (i32.eqz
      (local.tee $1
       (i32.load16_u
        (local.get $2)
       )
      )
     )
    )
    (i32.store16
     (local.get $0)
     (local.get $1)
    )
    (local.set $2
     (i32.add
      (local.get $2)
      (i32.const 2)
     )
    )
    (local.set $0
     (i32.add
      (local.get $0)
      (i32.const 2)
     )
    )
    (br_if $label$6
     (i32.eqz
      (i32.and
       (local.get $5)
       (i32.const 7)
      )
     )
    )
    (local.set $5
     (i32.add
      (local.get $5)
      (i32.const 2)
     )
    )
    (br_if $label$7
     (i32.lt_u
      (local.get $2)
      (local.get $7)
     )
    )
   )
  )
  (block $label$8
   (br_if $label$8
    (i32.le_u
     (local.tee $5
      (i32.add
       (local.get $2)
       (i32.shl
        (i32.div_s
         (i32.shr_s
          (i32.sub
           (local.get $7)
           (local.get $2)
          )
          (i32.const 1)
         )
         (i32.const 4)
        )
        (i32.const 3)
       )
      )
     )
     (local.get $2)
    )
   )
   (loop $label$9
    (br_if $label$8
     (i64.eqz
      (local.tee $12
       (i64.load
        (local.get $2)
       )
      )
     )
    )
    (i64.store
     (local.get $0)
     (local.get $12)
    )
    (local.set $0
     (i32.add
      (local.get $0)
      (i32.const 8)
     )
    )
    (br_if $label$9
     (i32.lt_u
      (local.tee $2
       (i32.add
        (local.get $2)
        (i32.const 8)
       )
      )
      (local.get $5)
     )
    )
   )
  )
  (block $label$10
   (br_if $label$10
    (i32.le_u
     (local.get $7)
     (local.get $2)
    )
   )
   (loop $label$11
    (br_if $label$10
     (i32.eqz
      (local.tee $5
       (i32.load16_u
        (local.get $2)
       )
      )
     )
    )
    (i32.store16
     (local.get $0)
     (local.get $5)
    )
    (local.set $0
     (i32.add
      (local.get $0)
      (i32.const 2)
     )
    )
    (br_if $label$11
     (i32.lt_u
      (local.tee $2
       (i32.add
        (local.get $2)
        (i32.const 2)
       )
      )
      (local.get $7)
     )
    )
   )
  )
  (local.set $5
   (i32.add
    (i32.add
     (local.get $4)
     (i32.shl
      (local.get $8)
      (i32.const 1)
     )
    )
    (i32.const 4)
   )
  )
  (local.set $2
   (i32.add
    (i32.add
     (local.get $11)
     (i32.shl
      (local.get $9)
      (i32.const 1)
     )
    )
    (i32.const 4)
   )
  )
  (block $label$12
   (br_if $label$12
    (i32.lt_s
     (local.get $6)
     (i32.const 1)
    )
   )
   (br_if $label$12
    (i32.eqz
     (i32.and
      (local.get $2)
      (i32.const 7)
     )
    )
   )
   (local.set $0
    (i32.add
     (i32.add
      (local.get $11)
      (i32.shl
       (local.get $9)
       (i32.const 1)
      )
     )
     (i32.const 6)
    )
   )
   (loop $label$13
    (br_if $label$12
     (i32.eqz
      (local.tee $6
       (i32.load16_u
        (local.get $3)
       )
      )
     )
    )
    (i32.store16
     (local.get $2)
     (local.get $6)
    )
    (local.set $3
     (i32.add
      (local.get $3)
      (i32.const 2)
     )
    )
    (local.set $2
     (i32.add
      (local.get $2)
      (i32.const 2)
     )
    )
    (br_if $label$12
     (i32.eqz
      (i32.and
       (local.get $0)
       (i32.const 7)
      )
     )
    )
    (local.set $0
     (i32.add
      (local.get $0)
      (i32.const 2)
     )
    )
    (br_if $label$13
     (i32.lt_u
      (local.get $3)
      (local.get $5)
     )
    )
   )
  )
  (block $label$14
   (br_if $label$14
    (i32.le_u
     (local.tee $0
      (i32.add
       (local.get $3)
       (i32.shl
        (i32.div_s
         (i32.shr_s
          (i32.sub
           (local.get $5)
           (local.get $3)
          )
          (i32.const 1)
         )
         (i32.const 4)
        )
        (i32.const 3)
       )
      )
     )
     (local.get $3)
    )
   )
   (loop $label$15
    (br_if $label$14
     (i64.eqz
      (local.tee $12
       (i64.load
        (local.get $3)
       )
      )
     )
    )
    (i64.store
     (local.get $2)
     (local.get $12)
    )
    (local.set $2
     (i32.add
      (local.get $2)
      (i32.const 8)
     )
    )
    (br_if $label$15
     (i32.lt_u
      (local.tee $3
       (i32.add
        (local.get $3)
        (i32.const 8)
       )
      )
      (local.get $0)
     )
    )
   )
  )
  (block $label$16
   (br_if $label$16
    (i32.le_u
     (local.get $5)
     (local.get $3)
    )
   )
   (loop $label$17
    (br_if $label$16
     (i32.eqz
      (local.tee $0
       (i32.load16_u
        (local.get $3)
       )
      )
     )
    )
    (i32.store16
     (local.get $2)
     (local.get $0)
    )
    (local.set $2
     (i32.add
      (local.get $2)
      (i32.const 2)
     )
    )
    (br_if $label$17
     (i32.lt_u
      (local.tee $3
       (i32.add
        (local.get $3)
        (i32.const 2)
       )
      )
      (local.get $5)
     )
    )
   )
  )
  (local.get $11)
 )
 (func $eval_String_length (param $0 i32) (result i32)
  (local $1 i32)
  (local $2 i32)
  (local $3 i32)
  (local $4 i32)
  (local.set $2
   (i32.add
    (local.tee $1
     (i32.load
      (local.get $0)
     )
    )
    (i32.const 4)
   )
  )
  (local.set $0
   (i32.add
    (i32.shl
     (i32.and
      (i32.load
       (local.get $1)
      )
      (i32.const 268435455)
     )
     (i32.const 2)
    )
    (i32.const -2)
   )
  )
  (block $label$1
   (loop $label$2
    (local.set $3
     (i32.add
      (local.get $0)
      (i32.const -2)
     )
    )
    (br_if $label$1
     (i32.load16_u
      (local.tee $4
       (i32.add
        (local.get $1)
        (local.get $0)
       )
      )
     )
    )
    (local.set $0
     (local.get $3)
    )
    (br_if $label$2
     (i32.ge_u
      (local.get $4)
      (local.get $2)
     )
    )
   )
  )
  (i32.store
   (local.tee $0
    (call $GC_allocate
     (i32.const 1)
     (i32.const 4)
    )
   )
   (i32.const 4)
  )
  (f64.store offset=8
   (local.get $0)
   (f64.convert_i32_s
    (i32.shr_s
     (local.get $3)
     (i32.const 1)
    )
   )
  )
  (local.get $0)
 )
 (func $eval_String_foldr (param $0 i32) (result i32)
  (local $1 i32)
  (local $2 i32)
  (local $3 i32)
  (local $4 i32)
  (local $5 i32)
  (local $6 i32)
  (local $7 i32)
  (global.set $__stack_pointer
   (local.tee $1
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 16)
    )
   )
  )
  (local.set $3
   (i32.add
    (local.tee $2
     (i32.load offset=8
      (local.get $0)
     )
    )
    (i32.const 4)
   )
  )
  (local.set $4
   (i32.add
    (i32.shl
     (i32.and
      (i32.load
       (local.get $2)
      )
      (i32.const 268435455)
     )
     (i32.const 2)
    )
    (i32.const -2)
   )
  )
  (local.set $5
   (i32.load offset=4
    (local.get $0)
   )
  )
  (local.set $6
   (i32.load
    (local.get $0)
   )
  )
  (block $label$1
   (loop $label$2
    (local.set $0
     (i32.add
      (local.get $4)
      (i32.const -2)
     )
    )
    (br_if $label$1
     (i32.load16_u
      (local.tee $7
       (i32.add
        (local.get $2)
        (local.get $4)
       )
      )
     )
    )
    (local.set $4
     (local.get $0)
    )
    (br_if $label$2
     (i32.ge_u
      (local.get $7)
      (local.get $3)
     )
    )
   )
  )
  (block $label$3
   (br_if $label$3
    (i32.eqz
     (local.get $0)
    )
   )
   (local.set $4
    (i32.shr_s
     (local.get $0)
     (i32.const 1)
    )
   )
   (loop $label$4
    (block $label$5
     (block $label$6
      (br_if $label$6
       (i32.eq
        (i32.and
         (local.tee $7
          (i32.load16_u
           (i32.add
            (i32.add
             (local.get $2)
             (i32.shl
              (local.tee $0
               (i32.add
                (local.get $4)
                (i32.const -1)
               )
              )
              (i32.const 1)
             )
            )
            (i32.const 4)
           )
          )
         )
         (i32.const 64512)
        )
        (i32.const 56320)
       )
      )
      (local.set $4
       (local.get $0)
      )
      (br $label$5)
     )
     (local.set $7
      (i32.or
       (i32.shl
        (local.get $7)
        (i32.const 16)
       )
       (i32.load16_u
        (i32.add
         (i32.add
          (local.get $2)
          (i32.shl
           (local.tee $4
            (i32.add
             (local.get $4)
             (i32.const -2)
            )
           )
           (i32.const 1)
          )
         )
         (i32.const 4)
        )
       )
      )
     )
    )
    (i32.store offset=4
     (local.tee $0
      (call $GC_allocate
       (i32.const 1)
       (i32.const 2)
      )
     )
     (local.get $7)
    )
    (i32.store
     (local.get $0)
     (i32.const 536870914)
    )
    (i32.store offset=12
     (local.get $1)
     (local.get $5)
    )
    (i32.store offset=8
     (local.get $1)
     (local.get $0)
    )
    (local.set $5
     (call $Utils_apply
      (local.get $6)
      (i32.const 2)
      (i32.add
       (local.get $1)
       (i32.const 8)
      )
     )
    )
    (br_if $label$4
     (local.get $4)
    )
   )
  )
  (global.set $__stack_pointer
   (i32.add
    (local.get $1)
    (i32.const 16)
   )
  )
  (local.get $5)
 )
 (func $eval_String_split (param $0 i32) (result i32)
  (local $1 i32)
  (local $2 i32)
  (local $3 i32)
  (local $4 i32)
  (local $5 i32)
  (local $6 i32)
  (local $7 i32)
  (local $8 i32)
  (local $9 i32)
  (local $10 i32)
  (local $11 i32)
  (local $12 i32)
  (local $13 i32)
  (local $14 i32)
  (local $15 i32)
  (local $16 i32)
  (local $17 i32)
  (local $18 i32)
  (local $19 i64)
  (local.set $2
   (i32.add
    (local.tee $1
     (i32.load
      (local.get $0)
     )
    )
    (i32.const 4)
   )
  )
  (local.set $3
   (i32.add
    (i32.shl
     (i32.and
      (i32.load
       (local.get $1)
      )
      (i32.const 268435455)
     )
     (i32.const 2)
    )
    (i32.const -2)
   )
  )
  (local.set $4
   (i32.load offset=4
    (local.get $0)
   )
  )
  (block $label$1
   (loop $label$2
    (local.set $0
     (i32.add
      (local.get $3)
      (i32.const -2)
     )
    )
    (br_if $label$1
     (i32.load16_u
      (local.tee $5
       (i32.add
        (local.get $1)
        (local.get $3)
       )
      )
     )
    )
    (local.set $3
     (local.get $0)
    )
    (br_if $label$2
     (i32.ge_u
      (local.get $5)
      (local.get $2)
     )
    )
   )
  )
  (local.set $6
   (i32.add
    (local.get $4)
    (i32.const 4)
   )
  )
  (local.set $3
   (i32.add
    (i32.shl
     (i32.and
      (i32.load
       (local.get $4)
      )
      (i32.const 268435455)
     )
     (i32.const 2)
    )
    (i32.const -2)
   )
  )
  (block $label$3
   (loop $label$4
    (local.set $5
     (i32.add
      (local.get $3)
      (i32.const -2)
     )
    )
    (br_if $label$3
     (i32.load16_u
      (local.tee $2
       (i32.add
        (local.get $4)
        (local.get $3)
       )
      )
     )
    )
    (local.set $3
     (local.get $5)
    )
    (br_if $label$4
     (i32.ge_u
      (local.get $2)
      (local.get $6)
     )
    )
   )
  )
  (local.set $7
   (i32.add
    (local.get $4)
    (i32.const 2)
   )
  )
  (local.set $6
   (i32.shr_s
    (local.get $5)
    (i32.const 1)
   )
  )
  (local.set $8
   (i32.add
    (local.get $1)
    (i32.and
     (local.get $0)
     (i32.const -2)
    )
   )
  )
  (local.set $11
   (i32.add
    (i32.add
     (local.get $1)
     (i32.shl
      (local.tee $10
       (i32.add
        (local.tee $9
         (i32.shr_s
          (local.get $0)
          (i32.const 1)
         )
        )
        (i32.const -1)
       )
      )
      (i32.const 1)
     )
    )
    (i32.const 4)
   )
  )
  (local.set $3
   (i32.const 8512)
  )
  (loop $label$5
   (local.set $12
    (local.get $3)
   )
   (local.set $2
    (local.tee $13
     (local.get $6)
    )
   )
   (block $label$6
    (block $label$7
     (block $label$8
      (loop $label$9
       (block $label$10
        (block $label$11
         (br_if $label$11
          (i32.ge_s
           (i32.or
            (local.tee $5
             (i32.add
              (local.get $2)
              (i32.const -1)
             )
            )
            (local.get $10)
           )
           (i32.const 0)
          )
         )
         (local.set $2
          (local.get $5)
         )
         (br $label$10)
        )
        (local.set $3
         (i32.add
          (local.get $7)
          (i32.shl
           (local.get $2)
           (i32.const 1)
          )
         )
        )
        (local.set $0
         (i32.load16_u
          (local.get $11)
         )
        )
        (local.set $2
         (local.get $5)
        )
        (loop $label$12
         (br_if $label$10
          (i32.eq
           (i32.load16_u
            (local.get $3)
           )
           (i32.and
            (local.get $0)
            (i32.const 65535)
           )
          )
         )
         (local.set $3
          (i32.add
           (local.get $3)
           (i32.const -2)
          )
         )
         (br_if $label$12
          (i32.gt_s
           (i32.or
            (local.tee $2
             (i32.add
              (local.get $2)
              (i32.const -1)
             )
            )
            (local.get $10)
           )
           (i32.const -1)
          )
         )
        )
       )
       (block $label$13
        (br_if $label$13
         (i32.ge_s
          (local.get $2)
          (i32.const 0)
         )
        )
        (local.set $6
         (i32.const -1)
        )
        (br $label$8)
       )
       (local.set $0
        (i32.add
         (local.get $7)
         (i32.shl
          (local.get $2)
          (i32.const 1)
         )
        )
       )
       (local.set $3
        (i32.const 0)
       )
       (local.set $5
        (local.get $8)
       )
       (block $label$14
        (loop $label$15
         (local.set $1
          (i32.add
           (local.get $10)
           (local.get $3)
          )
         )
         (br_if $label$14
          (i32.eqz
           (local.tee $6
            (i32.add
             (local.get $2)
             (local.get $3)
            )
           )
          )
         )
         (br_if $label$14
          (i32.lt_s
           (local.get $1)
           (i32.const 1)
          )
         )
         (local.set $3
          (i32.add
           (local.get $3)
           (i32.const -1)
          )
         )
         (local.set $1
          (i32.load16_u
           (local.get $5)
          )
         )
         (local.set $6
          (i32.load16_u
           (local.get $0)
          )
         )
         (local.set $5
          (i32.add
           (local.get $5)
           (i32.const -2)
          )
         )
         (local.set $0
          (i32.add
           (local.get $0)
           (i32.const -2)
          )
         )
         (br_if $label$9
          (i32.ne
           (local.get $6)
           (local.get $1)
          )
         )
         (br $label$15)
        )
       )
       (block $label$16
        (br_if $label$16
         (local.tee $3
          (i32.lt_s
           (local.get $1)
           (i32.const 1)
          )
         )
        )
        (br_if $label$9
         (local.get $6)
        )
       )
      )
      (br_if $label$7
       (i32.gt_s
        (local.tee $3
         (select
          (local.get $6)
          (i32.const -1)
          (local.get $3)
         )
        )
        (i32.const -1)
       )
      )
      (local.set $6
       (local.get $3)
      )
     )
     (local.set $14
      (i32.const 0)
     )
     (br $label$6)
    )
    (local.set $14
     (i32.add
      (local.get $3)
      (local.get $9)
     )
    )
   )
   (local.set $15
    (call $GC_allocate
     (i32.const 1)
     (local.tee $3
      (i32.shr_u
       (local.tee $5
        (i32.add
         (local.tee $0
          (i32.shl
           (i32.sub
            (local.get $13)
            (local.get $14)
           )
           (i32.const 1)
          )
         )
         (i32.const 7)
        )
       )
       (i32.const 2)
      )
     )
    )
   )
   (block $label$17
    (br_if $label$17
     (i32.eq
      (i32.and
       (local.get $5)
       (i32.const -4)
      )
      (i32.add
       (local.get $0)
       (i32.const 4)
      )
     )
    )
    (i32.store
     (i32.add
      (i32.add
       (i32.shl
        (local.get $3)
        (i32.const 2)
       )
       (local.get $15)
      )
      (i32.const -4)
     )
     (i32.const 0)
    )
   )
   (i32.store
    (local.get $15)
    (i32.or
     (local.get $3)
     (i32.const 805306368)
    )
   )
   (local.set $2
    (i32.add
     (local.tee $3
      (i32.add
       (local.get $4)
       (i32.const 4)
      )
     )
     (i32.shl
      (local.get $13)
      (i32.const 1)
     )
    )
   )
   (local.set $0
    (i32.add
     (local.get $3)
     (local.tee $5
      (i32.shl
       (local.get $14)
       (i32.const 1)
      )
     )
    )
   )
   (local.set $16
    (i32.add
     (local.get $15)
     (i32.const 4)
    )
   )
   (block $label$18
    (block $label$19
     (br_if $label$19
      (i32.gt_s
       (local.get $13)
       (local.get $14)
      )
     )
     (local.set $3
      (local.get $16)
     )
     (br $label$18)
    )
    (block $label$20
     (br_if $label$20
      (i32.and
       (local.get $16)
       (i32.const 7)
      )
     )
     (local.set $3
      (local.get $16)
     )
     (br $label$18)
    )
    (local.set $17
     (i32.add
      (local.get $15)
      (i32.const 6)
     )
    )
    (local.set $18
     (i32.add
      (local.get $4)
      (local.get $5)
     )
    )
    (local.set $5
     (i32.const 0)
    )
    (loop $label$21
     (local.set $3
      (i32.add
       (local.get $16)
       (local.get $5)
      )
     )
     (br_if $label$18
      (i32.eqz
       (local.tee $1
        (i32.load16_u
         (local.tee $0
          (i32.add
           (local.tee $13
            (i32.add
             (local.get $18)
             (local.get $5)
            )
           )
           (i32.const 4)
          )
         )
        )
       )
      )
     )
     (i32.store16
      (local.get $3)
      (local.get $1)
     )
     (local.set $0
      (i32.add
       (local.get $5)
       (i32.const 2)
      )
     )
     (block $label$22
      (br_if $label$22
       (i32.eqz
        (i32.and
         (i32.add
          (local.get $17)
          (local.get $5)
         )
         (i32.const 7)
        )
       )
      )
      (local.set $5
       (local.get $0)
      )
      (br_if $label$21
       (i32.lt_u
        (i32.add
         (local.get $13)
         (i32.const 6)
        )
        (local.get $2)
       )
      )
     )
    )
    (local.set $3
     (i32.add
      (local.get $16)
      (local.get $0)
     )
    )
    (local.set $0
     (i32.add
      (i32.add
       (local.get $18)
       (local.get $0)
      )
      (i32.const 4)
     )
    )
   )
   (block $label$23
    (br_if $label$23
     (i32.le_u
      (local.tee $5
       (i32.add
        (local.get $0)
        (i32.shl
         (i32.div_s
          (i32.shr_s
           (i32.sub
            (local.get $2)
            (local.get $0)
           )
           (i32.const 1)
          )
          (i32.const 4)
         )
         (i32.const 3)
        )
       )
      )
      (local.get $0)
     )
    )
    (loop $label$24
     (br_if $label$23
      (i64.eqz
       (local.tee $19
        (i64.load
         (local.get $0)
        )
       )
      )
     )
     (i64.store
      (local.get $3)
      (local.get $19)
     )
     (local.set $3
      (i32.add
       (local.get $3)
       (i32.const 8)
      )
     )
     (br_if $label$24
      (i32.lt_u
       (local.tee $0
        (i32.add
         (local.get $0)
         (i32.const 8)
        )
       )
       (local.get $5)
      )
     )
    )
   )
   (block $label$25
    (br_if $label$25
     (i32.le_u
      (local.get $2)
      (local.get $0)
     )
    )
    (loop $label$26
     (br_if $label$25
      (i32.eqz
       (local.tee $5
        (i32.load16_u
         (local.get $0)
        )
       )
      )
     )
     (i32.store16
      (local.get $3)
      (local.get $5)
     )
     (local.set $3
      (i32.add
       (local.get $3)
       (i32.const 2)
      )
     )
     (br_if $label$26
      (i32.lt_u
       (local.tee $0
        (i32.add
         (local.get $0)
         (i32.const 2)
        )
       )
       (local.get $2)
      )
     )
    )
   )
   (i32.store offset=8
    (local.tee $3
     (call $GC_allocate
      (i32.const 1)
      (i32.const 3)
     )
    )
    (local.get $12)
   )
   (i32.store offset=4
    (local.get $3)
    (local.get $15)
   )
   (i32.store
    (local.get $3)
    (i32.const 1073741827)
   )
   (br_if $label$5
    (i32.gt_s
     (local.get $14)
     (i32.const 0)
    )
   )
  )
  (local.get $3)
 )
 (func $eval_String_join (param $0 i32) (result i32)
  (local $1 i32)
  (local $2 i32)
  (local $3 i32)
  (local $4 i32)
  (local $5 i32)
  (local $6 i32)
  (local $7 i32)
  (local $8 i32)
  (local $9 i32)
  (local $10 i32)
  (local $11 i32)
  (local $12 i32)
  (local $13 i64)
  (global.set $__stack_pointer
   (local.tee $1
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 48)
    )
   )
  )
  (block $label$1
   (block $label$2
    (br_if $label$2
     (i32.ne
      (local.tee $2
       (i32.load offset=4
        (local.get $0)
       )
      )
      (i32.const 8512)
     )
    )
    (i32.store
     (local.tee $3
      (call $GC_allocate
       (i32.const 1)
       (i32.const 1)
      )
     )
     (i32.const 805306369)
    )
    (br $label$1)
   )
   (local.set $5
    (i32.add
     (local.tee $4
      (i32.load
       (local.get $0)
      )
     )
     (i32.const 4)
    )
   )
   (local.set $0
    (i32.add
     (i32.shl
      (i32.and
       (i32.load
        (local.get $4)
       )
       (i32.const 268435455)
      )
      (i32.const 2)
     )
     (i32.const -2)
    )
   )
   (block $label$3
    (loop $label$4
     (local.set $6
      (i32.add
       (local.get $0)
       (i32.const -2)
      )
     )
     (br_if $label$3
      (i32.load16_u
       (local.tee $7
        (i32.add
         (local.get $4)
         (local.get $0)
        )
       )
      )
     )
     (local.set $0
      (local.get $6)
     )
     (br_if $label$4
      (i32.ge_u
       (local.get $7)
       (local.get $5)
      )
     )
    )
   )
   (local.set $3
    (i32.shr_s
     (local.get $6)
     (i32.const 1)
    )
   )
   (local.set $8
    (i32.load offset=7844
     (i32.const 0)
    )
   )
   (local.set $9
    (i32.const 0)
   )
   (local.set $10
    (local.get $2)
   )
   (loop $label$5
    (local.set $12
     (i32.add
      (local.tee $11
       (i32.load offset=4
        (local.get $10)
       )
      )
      (i32.const 4)
     )
    )
    (local.set $0
     (i32.add
      (i32.shl
       (i32.and
        (i32.load
         (local.get $11)
        )
        (i32.const 268435455)
       )
       (i32.const 2)
      )
      (i32.const -2)
     )
    )
    (block $label$6
     (loop $label$7
      (local.set $6
       (i32.add
        (local.get $0)
        (i32.const -2)
       )
      )
      (br_if $label$6
       (i32.load16_u
        (local.tee $7
         (i32.add
          (local.get $11)
          (local.get $0)
         )
        )
       )
      )
      (local.set $0
       (local.get $6)
      )
      (br_if $label$7
       (i32.ge_u
        (local.get $7)
        (local.get $12)
       )
      )
     )
    )
    (local.set $9
     (i32.add
      (i32.add
       (i32.shr_s
        (local.get $6)
        (i32.const 1)
       )
       (local.get $9)
      )
      (select
       (i32.const 0)
       (local.get $3)
       (i32.eq
        (local.tee $10
         (i32.load offset=8
          (local.get $10)
         )
        )
        (local.get $8)
       )
      )
     )
    )
    (br_if $label$5
     (i32.ne
      (local.get $10)
      (i32.const 8512)
     )
    )
   )
   (local.set $3
    (call $GC_allocate
     (i32.const 1)
     (local.tee $0
      (i32.shr_u
       (local.tee $7
        (i32.add
         (local.tee $6
          (i32.shl
           (local.get $9)
           (i32.const 1)
          )
         )
         (i32.const 7)
        )
       )
       (i32.const 2)
      )
     )
    )
   )
   (block $label$8
    (br_if $label$8
     (i32.eq
      (i32.and
       (local.get $7)
       (i32.const -4)
      )
      (i32.add
       (local.get $6)
       (i32.const 4)
      )
     )
    )
    (i32.store
     (i32.add
      (i32.add
       (i32.shl
        (local.get $0)
        (i32.const 2)
       )
       (local.get $3)
      )
      (i32.const -4)
     )
     (i32.const 0)
    )
   )
   (i32.store
    (local.get $3)
    (i32.or
     (local.get $0)
     (i32.const 805306368)
    )
   )
   (local.set $0
    (i32.add
     (local.get $3)
     (i32.const 4)
    )
   )
   (loop $label$9
    (local.set $6
     (i32.add
      (local.tee $10
       (i32.load offset=4
        (local.get $2)
       )
      )
      (i32.const 4)
     )
    )
    (local.set $7
     (i32.add
      (i32.shl
       (i32.and
        (i32.load
         (local.get $10)
        )
        (i32.const 268435455)
       )
       (i32.const 2)
      )
      (i32.const -2)
     )
    )
    (block $label$10
     (loop $label$11
      (local.set $11
       (i32.add
        (local.get $7)
        (i32.const -2)
       )
      )
      (br_if $label$10
       (i32.load16_u
        (local.tee $12
         (i32.add
          (local.get $10)
          (local.get $7)
         )
        )
       )
      )
      (local.set $7
       (local.get $11)
      )
      (br_if $label$11
       (i32.ge_u
        (local.get $12)
        (local.get $6)
       )
      )
     )
    )
    (local.set $12
     (i32.add
      (i32.add
       (local.get $10)
       (local.get $11)
      )
      (i32.const 4)
     )
    )
    (block $label$12
     (br_if $label$12
      (i32.eqz
       (i32.and
        (local.get $0)
        (i32.const 7)
       )
      )
     )
     (br_if $label$12
      (i32.lt_s
       (local.get $11)
       (i32.const 1)
      )
     )
     (local.set $7
      (i32.add
       (local.get $0)
       (i32.const 2)
      )
     )
     (loop $label$13
      (br_if $label$12
       (i32.eqz
        (local.tee $11
         (i32.load16_u
          (local.get $6)
         )
        )
       )
      )
      (i32.store16
       (local.get $0)
       (local.get $11)
      )
      (local.set $6
       (i32.add
        (local.get $6)
        (i32.const 2)
       )
      )
      (local.set $0
       (i32.add
        (local.get $0)
        (i32.const 2)
       )
      )
      (br_if $label$12
       (i32.eqz
        (i32.and
         (local.get $7)
         (i32.const 7)
        )
       )
      )
      (local.set $7
       (i32.add
        (local.get $7)
        (i32.const 2)
       )
      )
      (br_if $label$13
       (i32.lt_u
        (local.get $6)
        (local.get $12)
       )
      )
     )
    )
    (block $label$14
     (br_if $label$14
      (i32.le_u
       (local.tee $7
        (i32.add
         (local.get $6)
         (i32.shl
          (i32.div_s
           (i32.shr_s
            (i32.sub
             (local.get $12)
             (local.get $6)
            )
            (i32.const 1)
           )
           (i32.const 4)
          )
          (i32.const 3)
         )
        )
       )
       (local.get $6)
      )
     )
     (loop $label$15
      (br_if $label$14
       (i64.eqz
        (local.tee $13
         (i64.load
          (local.get $6)
         )
        )
       )
      )
      (i64.store
       (local.get $0)
       (local.get $13)
      )
      (local.set $0
       (i32.add
        (local.get $0)
        (i32.const 8)
       )
      )
      (br_if $label$15
       (i32.lt_u
        (local.tee $6
         (i32.add
          (local.get $6)
          (i32.const 8)
         )
        )
        (local.get $7)
       )
      )
     )
    )
    (block $label$16
     (br_if $label$16
      (i32.le_u
       (local.get $12)
       (local.get $6)
      )
     )
     (loop $label$17
      (br_if $label$16
       (i32.eqz
        (local.tee $7
         (i32.load16_u
          (local.get $6)
         )
        )
       )
      )
      (i32.store16
       (local.get $0)
       (local.get $7)
      )
      (local.set $0
       (i32.add
        (local.get $0)
        (i32.const 2)
       )
      )
      (br_if $label$17
       (i32.lt_u
        (local.tee $6
         (i32.add
          (local.get $6)
          (i32.const 2)
         )
        )
        (local.get $12)
       )
      )
     )
    )
    (block $label$18
     (br_if $label$18
      (local.tee $10
       (i32.eq
        (local.tee $2
         (i32.load offset=8
          (local.get $2)
         )
        )
        (i32.const 8512)
       )
      )
     )
     (local.set $6
      (i32.add
       (i32.shl
        (i32.and
         (i32.load
          (local.get $4)
         )
         (i32.const 268435455)
        )
        (i32.const 2)
       )
       (i32.const -2)
      )
     )
     (block $label$19
      (loop $label$20
       (local.set $7
        (i32.add
         (local.get $6)
         (i32.const -2)
        )
       )
       (br_if $label$19
        (i32.load16_u
         (local.tee $11
          (i32.add
           (local.get $4)
           (local.get $6)
          )
         )
        )
       )
       (local.set $6
        (local.get $7)
       )
       (br_if $label$20
        (i32.ge_u
         (local.get $11)
         (local.get $5)
        )
       )
      )
     )
     (local.set $11
      (i32.add
       (i32.add
        (local.get $4)
        (local.get $7)
       )
       (i32.const 4)
      )
     )
     (block $label$21
      (block $label$22
       (br_if $label$22
        (i32.and
         (local.get $0)
         (i32.const 7)
        )
       )
       (local.set $6
        (local.get $5)
       )
       (br $label$21)
      )
      (block $label$23
       (br_if $label$23
        (i32.ge_s
         (local.get $7)
         (i32.const 1)
        )
       )
       (local.set $6
        (local.get $5)
       )
       (br $label$21)
      )
      (local.set $7
       (i32.add
        (local.get $0)
        (i32.const 2)
       )
      )
      (local.set $6
       (local.get $5)
      )
      (loop $label$24
       (br_if $label$21
        (i32.eqz
         (local.tee $12
          (i32.load16_u
           (local.get $6)
          )
         )
        )
       )
       (i32.store16
        (local.get $0)
        (local.get $12)
       )
       (local.set $6
        (i32.add
         (local.get $6)
         (i32.const 2)
        )
       )
       (local.set $0
        (i32.add
         (local.get $0)
         (i32.const 2)
        )
       )
       (br_if $label$21
        (i32.eqz
         (i32.and
          (local.get $7)
          (i32.const 7)
         )
        )
       )
       (local.set $7
        (i32.add
         (local.get $7)
         (i32.const 2)
        )
       )
       (br_if $label$24
        (i32.lt_u
         (local.get $6)
         (local.get $11)
        )
       )
      )
     )
     (block $label$25
      (br_if $label$25
       (i32.le_u
        (local.tee $7
         (i32.add
          (local.get $6)
          (i32.shl
           (i32.div_s
            (i32.shr_s
             (i32.sub
              (local.get $11)
              (local.get $6)
             )
             (i32.const 1)
            )
            (i32.const 4)
           )
           (i32.const 3)
          )
         )
        )
        (local.get $6)
       )
      )
      (loop $label$26
       (br_if $label$25
        (i64.eqz
         (local.tee $13
          (i64.load
           (local.get $6)
          )
         )
        )
       )
       (i64.store
        (local.get $0)
        (local.get $13)
       )
       (local.set $0
        (i32.add
         (local.get $0)
         (i32.const 8)
        )
       )
       (br_if $label$26
        (i32.lt_u
         (local.tee $6
          (i32.add
           (local.get $6)
           (i32.const 8)
          )
         )
         (local.get $7)
        )
       )
      )
     )
     (block $label$27
      (br_if $label$27
       (i32.le_u
        (local.get $11)
        (local.get $6)
       )
      )
      (loop $label$28
       (br_if $label$27
        (i32.eqz
         (local.tee $7
          (i32.load16_u
           (local.get $6)
          )
         )
        )
       )
       (i32.store16
        (local.get $0)
        (local.get $7)
       )
       (local.set $0
        (i32.add
         (local.get $0)
         (i32.const 2)
        )
       )
       (br_if $label$28
        (i32.lt_u
         (local.tee $6
          (i32.add
           (local.get $6)
           (i32.const 2)
          )
         )
         (local.get $11)
        )
       )
      )
     )
     (br_if $label$9
      (i32.eqz
       (local.get $10)
      )
     )
    )
   )
   (br_if $label$1
    (i32.eq
     (local.get $0)
     (local.tee $6
      (i32.add
       (i32.add
        (local.get $3)
        (i32.shl
         (local.get $9)
         (i32.const 1)
        )
       )
       (i32.const 4)
      )
     )
    )
   )
   (i32.store offset=40
    (local.get $1)
    (i32.const 280)
   )
   (i32.store offset=36
    (local.get $1)
    (i32.const 3545)
   )
   (i32.store offset=32
    (local.get $1)
    (i32.const 2202)
   )
   (call $safe_printf
    (i32.const 5317)
    (i32.add
     (local.get $1)
     (i32.const 32)
    )
   )
   (i64.store offset=24
    (local.get $1)
    (i64.extend_i32_u
     (local.get $0)
    )
   )
   (i32.store offset=16
    (local.get $1)
    (i32.const 1837)
   )
   (call $safe_printf
    (i32.const 4798)
    (i32.add
     (local.get $1)
     (i32.const 16)
    )
   )
   (i64.store offset=8
    (local.get $1)
    (i64.extend_i32_u
     (local.get $6)
    )
   )
   (i32.store
    (local.get $1)
    (i32.const 4016)
   )
   (call $safe_printf
    (i32.const 4798)
    (local.get $1)
   )
   (call $abort)
  )
  (global.set $__stack_pointer
   (i32.add
    (local.get $1)
    (i32.const 48)
   )
  )
  (local.get $3)
 )
 (func $Debug_assert_equal (param $0 i32) (param $1 i32) (param $2 i32) (param $3 i32) (param $4 i32) (param $5 i64) (param $6 i64)
  (local $7 i32)
  (global.set $__stack_pointer
   (local.tee $7
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 48)
    )
   )
  )
  (block $label$1
   (br_if $label$1
    (i64.eq
     (local.get $5)
     (local.get $6)
    )
   )
   (i32.store offset=40
    (local.get $7)
    (local.get $1)
   )
   (i32.store offset=36
    (local.get $7)
    (local.get $0)
   )
   (i32.store offset=32
    (local.get $7)
    (local.get $2)
   )
   (call $safe_printf
    (i32.const 5317)
    (i32.add
     (local.get $7)
     (i32.const 32)
    )
   )
   (i64.store offset=24
    (local.get $7)
    (local.get $5)
   )
   (i32.store offset=16
    (local.get $7)
    (local.get $3)
   )
   (call $safe_printf
    (i32.const 4798)
    (i32.add
     (local.get $7)
     (i32.const 16)
    )
   )
   (i64.store offset=8
    (local.get $7)
    (local.get $6)
   )
   (i32.store
    (local.get $7)
    (local.get $4)
   )
   (call $safe_printf
    (i32.const 4798)
    (local.get $7)
   )
   (call $abort)
  )
  (global.set $__stack_pointer
   (i32.add
    (local.get $7)
    (i32.const 48)
   )
  )
 )
 (func $eval_String_slice (param $0 i32) (result i32)
  (local $1 i32)
  (local $2 i32)
  (local $3 i32)
  (local $4 i32)
  (local $5 i32)
  (local $6 i32)
  (local $7 i32)
  (local $8 i32)
  (local $9 i32)
  (local $10 i32)
  (local $11 f64)
  (local $12 i64)
  (local.set $2
   (i32.add
    (local.tee $1
     (i32.load offset=8
      (local.get $0)
     )
    )
    (i32.const 4)
   )
  )
  (local.set $3
   (i32.add
    (i32.shl
     (i32.and
      (i32.load
       (local.get $1)
      )
      (i32.const 268435455)
     )
     (i32.const 2)
    )
    (i32.const -2)
   )
  )
  (local.set $4
   (i32.load offset=4
    (local.get $0)
   )
  )
  (local.set $5
   (i32.load
    (local.get $0)
   )
  )
  (block $label$1
   (loop $label$2
    (local.set $0
     (i32.add
      (local.get $3)
      (i32.const -2)
     )
    )
    (br_if $label$1
     (i32.load16_u
      (local.tee $6
       (i32.add
        (local.get $1)
        (local.get $3)
       )
      )
     )
    )
    (local.set $3
     (local.get $0)
    )
    (br_if $label$2
     (i32.ge_u
      (local.get $6)
      (local.get $2)
     )
    )
   )
  )
  (local.set $7
   (i32.const 0)
  )
  (local.set $6
   (i32.sub
    (i32.const 0)
    (local.tee $2
     (i32.shr_s
      (local.get $0)
      (i32.const 1)
     )
    )
   )
  )
  (block $label$3
   (block $label$4
    (br_if $label$4
     (i32.eqz
      (f64.lt
       (f64.abs
        (local.tee $11
         (f64.load offset=8
          (local.get $5)
         )
        )
       )
       (f64.const 2147483648)
      )
     )
    )
    (local.set $3
     (i32.trunc_f64_s
      (local.get $11)
     )
    )
    (br $label$3)
   )
   (local.set $3
    (i32.const -2147483648)
   )
  )
  (block $label$5
   (br_if $label$5
    (i32.ge_s
     (local.get $6)
     (local.get $3)
    )
   )
   (block $label$6
    (br_if $label$6
     (i32.gt_s
      (local.get $3)
      (i32.const -1)
     )
    )
    (local.set $7
     (i32.add
      (local.get $2)
      (local.get $3)
     )
    )
    (br $label$5)
   )
   (local.set $7
    (select
     (local.get $2)
     (local.get $3)
     (i32.lt_s
      (local.get $2)
      (local.get $3)
     )
    )
   )
  )
  (block $label$7
   (block $label$8
    (br_if $label$8
     (i32.eqz
      (f64.lt
       (f64.abs
        (local.tee $11
         (f64.load offset=8
          (local.get $4)
         )
        )
       )
       (f64.const 2147483648)
      )
     )
    )
    (local.set $0
     (i32.trunc_f64_s
      (local.get $11)
     )
    )
    (br $label$7)
   )
   (local.set $0
    (i32.const -2147483648)
   )
  )
  (local.set $3
   (i32.const 0)
  )
  (block $label$9
   (br_if $label$9
    (i32.ge_s
     (local.get $6)
     (local.get $0)
    )
   )
   (block $label$10
    (br_if $label$10
     (i32.gt_s
      (local.get $0)
      (i32.const -1)
     )
    )
    (local.set $3
     (i32.add
      (local.get $2)
      (local.get $0)
     )
    )
    (br $label$9)
   )
   (local.set $3
    (select
     (local.get $2)
     (local.get $0)
     (i32.lt_s
      (local.get $2)
      (local.get $0)
     )
    )
   )
  )
  (block $label$11
   (br_if $label$11
    (i32.ge_s
     (local.get $3)
     (local.get $7)
    )
   )
   (i32.store
    (local.tee $3
     (call $GC_allocate
      (i32.const 1)
      (i32.const 1)
     )
    )
    (i32.const 805306369)
   )
   (return
    (local.get $3)
   )
  )
  (local.set $8
   (call $GC_allocate
    (i32.const 1)
    (local.tee $0
     (i32.shr_u
      (local.tee $2
       (i32.add
        (local.tee $6
         (i32.shl
          (i32.sub
           (local.get $3)
           (local.get $7)
          )
          (i32.const 1)
         )
        )
        (i32.const 7)
       )
      )
      (i32.const 2)
     )
    )
   )
  )
  (block $label$12
   (br_if $label$12
    (i32.eq
     (i32.and
      (local.get $2)
      (i32.const -4)
     )
     (i32.add
      (local.get $6)
      (i32.const 4)
     )
    )
   )
   (i32.store
    (i32.add
     (i32.add
      (i32.shl
       (local.get $0)
       (i32.const 2)
      )
      (local.get $8)
     )
     (i32.const -4)
    )
    (i32.const 0)
   )
  )
  (i32.store
   (local.get $8)
   (i32.or
    (local.get $0)
    (i32.const 805306368)
   )
  )
  (local.set $6
   (i32.add
    (local.tee $0
     (i32.add
      (local.get $1)
      (i32.const 4)
     )
    )
    (i32.shl
     (local.get $3)
     (i32.const 1)
    )
   )
  )
  (local.set $0
   (i32.add
    (local.get $0)
    (i32.shl
     (local.get $7)
     (i32.const 1)
    )
   )
  )
  (local.set $5
   (i32.add
    (local.get $8)
    (i32.const 4)
   )
  )
  (block $label$13
   (block $label$14
    (br_if $label$14
     (i32.gt_s
      (local.get $3)
      (local.get $7)
     )
    )
    (local.set $3
     (local.get $5)
    )
    (br $label$13)
   )
   (block $label$15
    (br_if $label$15
     (i32.and
      (local.get $5)
      (i32.const 7)
     )
    )
    (local.set $3
     (local.get $5)
    )
    (br $label$13)
   )
   (local.set $9
    (i32.add
     (local.get $8)
     (i32.const 6)
    )
   )
   (local.set $10
    (i32.add
     (local.get $1)
     (i32.shl
      (local.get $7)
      (i32.const 1)
     )
    )
   )
   (local.set $0
    (i32.const 0)
   )
   (block $label$16
    (loop $label$17
     (local.set $3
      (i32.add
       (local.get $5)
       (local.get $0)
      )
     )
     (br_if $label$16
      (i32.eqz
       (local.tee $2
        (i32.load16_u
         (i32.add
          (local.tee $4
           (i32.add
            (local.get $10)
            (local.get $0)
           )
          )
          (i32.const 4)
         )
        )
       )
      )
     )
     (i32.store16
      (local.get $3)
      (local.get $2)
     )
     (local.set $2
      (i32.add
       (local.get $0)
       (i32.const 2)
      )
     )
     (block $label$18
      (br_if $label$18
       (i32.eqz
        (i32.and
         (i32.add
          (local.get $9)
          (local.get $0)
         )
         (i32.const 7)
        )
       )
      )
      (local.set $0
       (local.get $2)
      )
      (br_if $label$17
       (i32.lt_u
        (i32.add
         (local.get $4)
         (i32.const 6)
        )
        (local.get $6)
       )
      )
     )
    )
    (local.set $3
     (i32.add
      (local.get $5)
      (local.get $2)
     )
    )
    (local.set $0
     (i32.add
      (i32.add
       (i32.add
        (local.get $1)
        (i32.shl
         (local.get $7)
         (i32.const 1)
        )
       )
       (local.get $2)
      )
      (i32.const 4)
     )
    )
    (br $label$13)
   )
   (local.set $0
    (i32.add
     (i32.add
      (i32.add
       (local.get $1)
       (i32.shl
        (local.get $7)
        (i32.const 1)
       )
      )
      (local.get $0)
     )
     (i32.const 4)
    )
   )
  )
  (block $label$19
   (br_if $label$19
    (i32.le_u
     (local.tee $1
      (i32.add
       (local.get $0)
       (i32.shl
        (i32.div_s
         (i32.shr_s
          (i32.sub
           (local.get $6)
           (local.get $0)
          )
          (i32.const 1)
         )
         (i32.const 4)
        )
        (i32.const 3)
       )
      )
     )
     (local.get $0)
    )
   )
   (loop $label$20
    (br_if $label$19
     (i64.eqz
      (local.tee $12
       (i64.load
        (local.get $0)
       )
      )
     )
    )
    (i64.store
     (local.get $3)
     (local.get $12)
    )
    (local.set $3
     (i32.add
      (local.get $3)
      (i32.const 8)
     )
    )
    (br_if $label$20
     (i32.lt_u
      (local.tee $0
       (i32.add
        (local.get $0)
        (i32.const 8)
       )
      )
      (local.get $1)
     )
    )
   )
  )
  (block $label$21
   (br_if $label$21
    (i32.le_u
     (local.get $6)
     (local.get $0)
    )
   )
   (loop $label$22
    (br_if $label$21
     (i32.eqz
      (local.tee $1
       (i32.load16_u
        (local.get $0)
       )
      )
     )
    )
    (i32.store16
     (local.get $3)
     (local.get $1)
    )
    (local.set $3
     (i32.add
      (local.get $3)
      (i32.const 2)
     )
    )
    (br_if $label$22
     (i32.lt_u
      (local.tee $0
       (i32.add
        (local.get $0)
        (i32.const 2)
       )
      )
      (local.get $6)
     )
    )
   )
  )
  (local.get $8)
 )
 (func $is_whitespace (param $0 i32) (result i32)
  (local $1 i32)
  (block $label$1
   (block $label$2
    (block $label$3
     (br_if $label$3
      (i32.gt_u
       (local.get $0)
       (i32.const 255)
      )
     )
     (br_if $label$2
      (i32.lt_u
       (local.get $0)
       (i32.const 33)
      )
     )
     (return
      (i32.eq
       (local.get $0)
       (i32.const 160)
      )
     )
    )
    (block $label$4
     (br_if $label$4
      (i32.ne
       (i32.and
        (local.get $0)
        (i32.const 65280)
       )
       (i32.const 8192)
      )
     )
     (local.set $1
      (i32.const 0)
     )
     (br_if $label$1
      (i32.gt_u
       (local.get $0)
       (i32.const 8287)
      )
     )
     (block $label$5
      (br_if $label$5
       (i32.lt_u
        (local.get $0)
        (i32.const 8234)
       )
      )
      (return
       (i32.or
        (i32.eq
         (local.get $0)
         (i32.const 8239)
        )
        (i32.eq
         (local.get $0)
         (i32.const 8287)
        )
       )
      )
     )
     (return
      (i32.or
       (i32.lt_u
        (local.get $0)
        (i32.const 8203)
       )
       (i32.eq
        (i32.and
         (local.get $0)
         (i32.const 65534)
        )
        (i32.const 8232)
       )
      )
     )
    )
    (local.set $1
     (i32.const 1)
    )
    (br_if $label$1
     (i32.eq
      (local.get $0)
      (i32.const 5760)
     )
    )
    (br_if $label$1
     (i32.eq
      (local.get $0)
      (i32.const 12288)
     )
    )
    (br_if $label$1
     (i32.eq
      (local.get $0)
      (i32.const 65279)
     )
    )
    (return
     (i32.const 0)
    )
   )
   (local.set $1
    (i32.const 0)
   )
   (br_if $label$1
    (i32.ge_u
     (local.tee $0
      (i32.and
       (i32.add
        (local.get $0)
        (i32.const -9)
       )
       (i32.const 65535)
      )
     )
     (i32.const 24)
    )
   )
   (local.set $1
    (i32.and
     (i32.shr_u
      (i32.const 8388639)
      (local.get $0)
     )
     (i32.const 1)
    )
   )
  )
  (local.get $1)
 )
 (func $eval_String_trim (param $0 i32) (result i32)
  (local $1 i32)
  (local $2 i32)
  (local $3 i32)
  (local $4 i32)
  (local $5 i32)
  (local $6 i32)
  (local $7 i32)
  (local $8 i32)
  (local $9 i32)
  (local $10 i32)
  (local $11 i32)
  (local $12 i32)
  (local $13 i64)
  (local.set $2
   (i32.add
    (local.tee $1
     (i32.load
      (local.get $0)
     )
    )
    (i32.const 4)
   )
  )
  (local.set $0
   (i32.add
    (i32.shl
     (i32.and
      (i32.load
       (local.get $1)
      )
      (i32.const 268435455)
     )
     (i32.const 2)
    )
    (i32.const -2)
   )
  )
  (block $label$1
   (loop $label$2
    (local.set $3
     (i32.add
      (local.get $0)
      (i32.const -2)
     )
    )
    (br_if $label$1
     (i32.load16_u
      (local.tee $4
       (i32.add
        (local.get $1)
        (local.get $0)
       )
      )
     )
    )
    (local.set $0
     (local.get $3)
    )
    (br_if $label$2
     (i32.ge_u
      (local.get $4)
      (local.get $2)
     )
    )
   )
  )
  (local.set $6
   (i32.add
    (i32.add
     (local.tee $5
      (i32.add
       (local.get $1)
       (i32.const 4)
      )
     )
     (i32.and
      (local.get $3)
      (i32.const -2)
     )
    )
    (i32.const -2)
   )
  )
  (local.set $7
   (i32.shr_s
    (local.get $3)
    (i32.const 1)
   )
  )
  (local.set $0
   (i32.const 0)
  )
  (block $label$3
   (loop $label$4
    (block $label$5
     (block $label$6
      (block $label$7
       (br_if $label$7
        (i32.gt_u
         (local.tee $0
          (i32.load16_u
           (local.tee $4
            (i32.add
             (local.get $5)
             (local.tee $3
              (local.get $0)
             )
            )
           )
          )
         )
         (i32.const 255)
        )
       )
       (br_if $label$6
        (i32.lt_u
         (local.get $0)
         (i32.const 33)
        )
       )
       (local.set $8
        (i32.eq
         (local.get $0)
         (i32.const 160)
        )
       )
       (br $label$5)
      )
      (block $label$8
       (br_if $label$8
        (i32.ne
         (i32.and
          (local.get $0)
          (i32.const 65280)
         )
         (i32.const 8192)
        )
       )
       (br_if $label$3
        (i32.gt_u
         (local.get $0)
         (i32.const 8287)
        )
       )
       (block $label$9
        (br_if $label$9
         (i32.lt_u
          (local.get $0)
          (i32.const 8234)
         )
        )
        (local.set $8
         (i32.or
          (i32.eq
           (local.get $0)
           (i32.const 8239)
          )
          (i32.eq
           (local.get $0)
           (i32.const 8287)
          )
         )
        )
        (br $label$5)
       )
       (local.set $8
        (i32.or
         (i32.lt_u
          (local.get $0)
          (i32.const 8203)
         )
         (i32.eq
          (i32.and
           (local.get $0)
           (i32.const 65534)
          )
          (i32.const 8232)
         )
        )
       )
       (br $label$5)
      )
      (local.set $8
       (i32.const 1)
      )
      (br_if $label$5
       (i32.eq
        (local.get $0)
        (i32.const 5760)
       )
      )
      (br_if $label$5
       (i32.eq
        (local.get $0)
        (i32.const 12288)
       )
      )
      (br_if $label$5
       (i32.eq
        (local.get $0)
        (i32.const 65279)
       )
      )
      (br $label$3)
     )
     (br_if $label$3
      (i32.ge_u
       (local.tee $0
        (i32.and
         (i32.add
          (local.get $0)
          (i32.const -9)
         )
         (i32.const 65535)
        )
       )
       (i32.const 24)
      )
     )
     (local.set $8
      (i32.const 1)
     )
     (br_if $label$3
      (i32.eqz
       (i32.and
        (i32.shr_u
         (i32.const 8388639)
         (local.get $0)
        )
        (i32.const 1)
       )
      )
     )
    )
    (br_if $label$3
     (i32.eqz
      (local.get $8)
     )
    )
    (local.set $0
     (i32.add
      (local.get $3)
      (i32.const 2)
     )
    )
    (br_if $label$4
     (i32.le_u
      (local.get $4)
      (local.get $6)
     )
    )
   )
  )
  (local.set $2
   (i32.sub
    (i32.const 0)
    (local.get $2)
   )
  )
  (local.set $6
   (i32.shl
    (local.get $7)
    (i32.const 1)
   )
  )
  (local.set $4
   (i32.add
    (local.tee $9
     (i32.add
      (local.get $1)
      (local.get $3)
     )
    )
    (i32.const 4)
   )
  )
  (block $label$10
   (loop $label$11
    (block $label$12
     (block $label$13
      (block $label$14
       (br_if $label$14
        (i32.gt_u
         (local.tee $0
          (i32.load16_u
           (local.tee $8
            (i32.add
             (i32.add
              (local.get $1)
              (local.get $6)
             )
             (i32.const 2)
            )
           )
          )
         )
         (i32.const 255)
        )
       )
       (br_if $label$13
        (i32.lt_u
         (local.get $0)
         (i32.const 33)
        )
       )
       (local.set $5
        (i32.eq
         (local.get $0)
         (i32.const 160)
        )
       )
       (br $label$12)
      )
      (block $label$15
       (br_if $label$15
        (i32.ne
         (i32.and
          (local.get $0)
          (i32.const 65280)
         )
         (i32.const 8192)
        )
       )
       (br_if $label$10
        (i32.gt_u
         (local.get $0)
         (i32.const 8287)
        )
       )
       (block $label$16
        (br_if $label$16
         (i32.lt_u
          (local.get $0)
          (i32.const 8234)
         )
        )
        (local.set $5
         (i32.or
          (i32.eq
           (local.get $0)
           (i32.const 8239)
          )
          (i32.eq
           (local.get $0)
           (i32.const 8287)
          )
         )
        )
        (br $label$12)
       )
       (local.set $5
        (i32.or
         (i32.lt_u
          (local.get $0)
          (i32.const 8203)
         )
         (i32.eq
          (i32.and
           (local.get $0)
           (i32.const 65534)
          )
          (i32.const 8232)
         )
        )
       )
       (br $label$12)
      )
      (local.set $5
       (i32.const 1)
      )
      (br_if $label$12
       (i32.eq
        (local.get $0)
        (i32.const 5760)
       )
      )
      (br_if $label$12
       (i32.eq
        (local.get $0)
        (i32.const 12288)
       )
      )
      (br_if $label$12
       (i32.eq
        (local.get $0)
        (i32.const 65279)
       )
      )
      (br $label$10)
     )
     (br_if $label$10
      (i32.ge_u
       (local.tee $0
        (i32.and
         (i32.add
          (local.get $0)
          (i32.const -9)
         )
         (i32.const 65535)
        )
       )
       (i32.const 24)
      )
     )
     (local.set $5
      (i32.const 1)
     )
     (br_if $label$10
      (i32.eqz
       (i32.and
        (i32.shr_u
         (i32.const 8388639)
         (local.get $0)
        )
        (i32.const 1)
       )
      )
     )
    )
    (br_if $label$10
     (i32.le_u
      (local.get $8)
      (local.get $4)
     )
    )
    (br_if $label$10
     (i32.eqz
      (local.get $5)
     )
    )
    (local.set $3
     (i32.add
      (local.get $3)
      (i32.const 2)
     )
    )
    (local.set $2
     (i32.add
      (local.get $2)
      (i32.const 2)
     )
    )
    (local.set $1
     (i32.add
      (local.get $1)
      (i32.const -2)
     )
    )
    (br $label$11)
   )
  )
  (local.set $10
   (call $GC_allocate
    (i32.const 1)
    (local.tee $0
     (i32.shr_u
      (local.tee $3
       (i32.add
        (local.tee $8
         (i32.sub
          (local.tee $5
           (i32.shl
            (local.get $7)
            (i32.const 1)
           )
          )
          (local.get $3)
         )
        )
        (i32.const 7)
       )
      )
      (i32.const 2)
     )
    )
   )
  )
  (block $label$17
   (br_if $label$17
    (i32.eq
     (i32.add
      (local.get $8)
      (i32.const 4)
     )
     (i32.and
      (local.get $3)
      (i32.const -4)
     )
    )
   )
   (i32.store
    (i32.add
     (i32.add
      (i32.shl
       (local.get $0)
       (i32.const 2)
      )
      (local.get $10)
     )
     (i32.const -4)
    )
    (i32.const 0)
   )
  )
  (i32.store
   (local.get $10)
   (i32.or
    (local.get $0)
    (i32.const 805306368)
   )
  )
  (block $label$18
   (br_if $label$18
    (i32.lt_s
     (local.get $8)
     (i32.const 1)
    )
   )
   (local.set $3
    (i32.add
     (local.tee $0
      (i32.add
       (local.get $1)
       (local.get $5)
      )
     )
     (i32.const 2)
    )
   )
   (local.set $5
    (i32.add
     (local.get $10)
     (i32.const 4)
    )
   )
   (block $label$19
    (block $label$20
     (br_if $label$20
      (i32.lt_u
       (local.get $4)
       (local.tee $11
        (i32.add
         (local.get $0)
         (i32.const 4)
        )
       )
      )
     )
     (local.set $0
      (local.get $5)
     )
     (br $label$19)
    )
    (block $label$21
     (br_if $label$21
      (i32.and
       (local.get $5)
       (i32.const 7)
      )
     )
     (local.set $0
      (local.get $5)
     )
     (br $label$19)
    )
    (local.set $12
     (i32.add
      (local.get $10)
      (i32.const 6)
     )
    )
    (local.set $6
     (i32.add
      (local.get $9)
      (i32.const 4)
     )
    )
    (local.set $1
     (i32.const 0)
    )
    (block $label$22
     (block $label$23
      (loop $label$24
       (local.set $0
        (i32.add
         (local.get $5)
         (local.get $1)
        )
       )
       (br_if $label$23
        (i32.eqz
         (local.tee $4
          (i32.load16_u
           (local.tee $8
            (i32.add
             (local.get $6)
             (local.get $1)
            )
           )
          )
         )
        )
       )
       (i32.store16
        (local.get $0)
        (local.get $4)
       )
       (local.set $4
        (i32.add
         (local.get $1)
         (i32.const 2)
        )
       )
       (block $label$25
        (br_if $label$25
         (i32.ge_u
          (local.get $8)
          (local.get $3)
         )
        )
        (local.set $0
         (i32.add
          (local.get $12)
          (local.get $1)
         )
        )
        (local.set $1
         (local.get $4)
        )
        (br_if $label$24
         (i32.and
          (local.get $0)
          (i32.const 7)
         )
        )
       )
      )
      (local.set $0
       (i32.add
        (local.get $5)
        (local.get $4)
       )
      )
      (local.set $4
       (i32.add
        (i32.add
         (local.get $9)
         (local.get $4)
        )
        (i32.const 4)
       )
      )
      (br $label$22)
     )
     (local.set $4
      (i32.add
       (i32.add
        (local.get $9)
        (local.get $1)
       )
       (i32.const 4)
      )
     )
    )
    (local.set $8
     (i32.sub
      (i32.sub
       (i32.shl
        (local.get $7)
        (i32.const 1)
       )
       (local.get $4)
      )
      (local.get $2)
     )
    )
   )
   (block $label$26
    (br_if $label$26
     (i32.le_u
      (local.tee $1
       (i32.add
        (local.get $4)
        (i32.shl
         (i32.div_s
          (i32.shr_s
           (local.get $8)
           (i32.const 1)
          )
          (i32.const 4)
         )
         (i32.const 3)
        )
       )
      )
      (local.get $4)
     )
    )
    (loop $label$27
     (br_if $label$26
      (i64.eqz
       (local.tee $13
        (i64.load
         (local.get $4)
        )
       )
      )
     )
     (i64.store
      (local.get $0)
      (local.get $13)
     )
     (local.set $0
      (i32.add
       (local.get $0)
       (i32.const 8)
      )
     )
     (br_if $label$27
      (i32.lt_u
       (local.tee $4
        (i32.add
         (local.get $4)
         (i32.const 8)
        )
       )
       (local.get $1)
      )
     )
    )
   )
   (br_if $label$18
    (i32.le_u
     (local.get $11)
     (local.get $4)
    )
   )
   (local.set $1
    (i32.add
     (local.get $4)
     (i32.const -2)
    )
   )
   (loop $label$28
    (br_if $label$18
     (i32.eqz
      (local.tee $4
       (i32.load16_u
        (local.tee $1
         (i32.add
          (local.get $1)
          (i32.const 2)
         )
        )
       )
      )
     )
    )
    (i32.store16
     (local.get $0)
     (local.get $4)
    )
    (local.set $0
     (i32.add
      (local.get $0)
      (i32.const 2)
     )
    )
    (br_if $label$28
     (i32.lt_u
      (local.get $1)
      (local.get $3)
     )
    )
   )
  )
  (local.get $10)
 )
 (func $eval_String_trimLeft (param $0 i32) (result i32)
  (local $1 i32)
  (local $2 i32)
  (local $3 i32)
  (local $4 i32)
  (local $5 i32)
  (local $6 i64)
  (local.set $0
   (i32.add
    (local.tee $1
     (i32.load
      (local.get $0)
     )
    )
    (i32.const 4)
   )
  )
  (local.set $2
   (i32.add
    (i32.shl
     (i32.and
      (i32.load
       (local.get $1)
      )
      (i32.const 268435455)
     )
     (i32.const 2)
    )
    (i32.const -2)
   )
  )
  (block $label$1
   (loop $label$2
    (local.set $3
     (i32.add
      (local.get $2)
      (i32.const -2)
     )
    )
    (br_if $label$1
     (i32.load16_u
      (local.tee $4
       (i32.add
        (local.get $1)
        (local.get $2)
       )
      )
     )
    )
    (local.set $2
     (local.get $3)
    )
    (br_if $label$2
     (i32.ge_u
      (local.get $4)
      (local.get $0)
     )
    )
   )
  )
  (local.set $1
   (i32.add
    (local.tee $2
     (i32.add
      (local.get $1)
      (local.tee $3
       (i32.and
        (local.get $3)
        (i32.const -2)
       )
      )
     )
    )
    (i32.const 2)
   )
  )
  (local.set $5
   (i32.add
    (local.get $2)
    (i32.const 4)
   )
  )
  (block $label$3
   (loop $label$4
    (block $label$5
     (block $label$6
      (block $label$7
       (br_if $label$7
        (i32.gt_u
         (local.tee $2
          (i32.load16_u
           (local.get $0)
          )
         )
         (i32.const 255)
        )
       )
       (br_if $label$6
        (i32.lt_u
         (local.get $2)
         (i32.const 33)
        )
       )
       (local.set $4
        (i32.eq
         (local.get $2)
         (i32.const 160)
        )
       )
       (br $label$5)
      )
      (block $label$8
       (br_if $label$8
        (i32.ne
         (i32.and
          (local.get $2)
          (i32.const 65280)
         )
         (i32.const 8192)
        )
       )
       (br_if $label$3
        (i32.gt_u
         (local.get $2)
         (i32.const 8287)
        )
       )
       (block $label$9
        (br_if $label$9
         (i32.lt_u
          (local.get $2)
          (i32.const 8234)
         )
        )
        (local.set $4
         (i32.or
          (i32.eq
           (local.get $2)
           (i32.const 8239)
          )
          (i32.eq
           (local.get $2)
           (i32.const 8287)
          )
         )
        )
        (br $label$5)
       )
       (local.set $4
        (i32.or
         (i32.lt_u
          (local.get $2)
          (i32.const 8203)
         )
         (i32.eq
          (i32.and
           (local.get $2)
           (i32.const 65534)
          )
          (i32.const 8232)
         )
        )
       )
       (br $label$5)
      )
      (local.set $4
       (i32.const 1)
      )
      (br_if $label$5
       (i32.eq
        (local.get $2)
        (i32.const 5760)
       )
      )
      (br_if $label$5
       (i32.eq
        (local.get $2)
        (i32.const 12288)
       )
      )
      (br_if $label$5
       (i32.eq
        (local.get $2)
        (i32.const 65279)
       )
      )
      (br $label$3)
     )
     (br_if $label$3
      (i32.ge_u
       (local.tee $2
        (i32.and
         (i32.add
          (local.get $2)
          (i32.const -9)
         )
         (i32.const 65535)
        )
       )
       (i32.const 24)
      )
     )
     (local.set $4
      (i32.const 1)
     )
     (br_if $label$3
      (i32.eqz
       (i32.and
        (i32.shr_u
         (i32.const 8388639)
         (local.get $2)
        )
        (i32.const 1)
       )
      )
     )
    )
    (br_if $label$3
     (i32.eqz
      (local.get $4)
     )
    )
    (br_if $label$3
     (i32.gt_u
      (local.get $0)
      (local.get $1)
     )
    )
    (local.set $3
     (i32.add
      (local.get $3)
      (i32.const -2)
     )
    )
    (local.set $0
     (i32.add
      (local.get $0)
      (i32.const 2)
     )
    )
    (br $label$4)
   )
  )
  (local.set $1
   (call $GC_allocate
    (i32.const 1)
    (local.tee $2
     (i32.shr_u
      (local.tee $4
       (i32.add
        (local.get $3)
        (i32.const 7)
       )
      )
      (i32.const 2)
     )
    )
   )
  )
  (block $label$10
   (br_if $label$10
    (i32.eq
     (i32.add
      (local.get $3)
      (i32.const 4)
     )
     (i32.and
      (local.get $4)
      (i32.const -4)
     )
    )
   )
   (i32.store
    (i32.add
     (i32.add
      (i32.shl
       (local.get $2)
       (i32.const 2)
      )
      (local.get $1)
     )
     (i32.const -4)
    )
    (i32.const 0)
   )
  )
  (i32.store
   (local.get $1)
   (i32.or
    (local.get $2)
    (i32.const 805306368)
   )
  )
  (block $label$11
   (br_if $label$11
    (i32.lt_s
     (local.get $3)
     (i32.const 1)
    )
   )
   (local.set $2
    (i32.add
     (local.get $1)
     (i32.const 4)
    )
   )
   (block $label$12
    (br_if $label$12
     (i32.ge_u
      (local.get $0)
      (local.get $5)
     )
    )
    (br_if $label$12
     (i32.eqz
      (i32.and
       (local.get $2)
       (i32.const 7)
      )
     )
    )
    (local.set $3
     (i32.add
      (local.get $1)
      (i32.const 6)
     )
    )
    (block $label$13
     (loop $label$14
      (br_if $label$13
       (i32.eqz
        (local.tee $4
         (i32.load16_u
          (local.get $0)
         )
        )
       )
      )
      (i32.store16
       (local.get $2)
       (local.get $4)
      )
      (local.set $0
       (i32.add
        (local.get $0)
        (i32.const 2)
       )
      )
      (local.set $2
       (i32.add
        (local.get $2)
        (i32.const 2)
       )
      )
      (br_if $label$13
       (i32.eqz
        (i32.and
         (local.get $3)
         (i32.const 7)
        )
       )
      )
      (local.set $3
       (i32.add
        (local.get $3)
        (i32.const 2)
       )
      )
      (br_if $label$14
       (i32.lt_u
        (local.get $0)
        (local.get $5)
       )
      )
     )
    )
    (local.set $3
     (i32.sub
      (local.get $5)
      (local.get $0)
     )
    )
   )
   (block $label$15
    (br_if $label$15
     (i32.le_u
      (local.tee $3
       (i32.add
        (local.get $0)
        (i32.shl
         (i32.div_s
          (i32.shr_s
           (local.get $3)
           (i32.const 1)
          )
          (i32.const 4)
         )
         (i32.const 3)
        )
       )
      )
      (local.get $0)
     )
    )
    (loop $label$16
     (br_if $label$15
      (i64.eqz
       (local.tee $6
        (i64.load
         (local.get $0)
        )
       )
      )
     )
     (i64.store
      (local.get $2)
      (local.get $6)
     )
     (local.set $2
      (i32.add
       (local.get $2)
       (i32.const 8)
      )
     )
     (br_if $label$16
      (i32.lt_u
       (local.tee $0
        (i32.add
         (local.get $0)
         (i32.const 8)
        )
       )
       (local.get $3)
      )
     )
    )
   )
   (br_if $label$11
    (i32.le_u
     (local.get $5)
     (local.get $0)
    )
   )
   (loop $label$17
    (br_if $label$11
     (i32.eqz
      (local.tee $3
       (i32.load16_u
        (local.get $0)
       )
      )
     )
    )
    (i32.store16
     (local.get $2)
     (local.get $3)
    )
    (local.set $2
     (i32.add
      (local.get $2)
      (i32.const 2)
     )
    )
    (br_if $label$17
     (i32.lt_u
      (local.tee $0
       (i32.add
        (local.get $0)
        (i32.const 2)
       )
      )
      (local.get $5)
     )
    )
   )
  )
  (local.get $1)
 )
 (func $eval_String_trimRight (param $0 i32) (result i32)
  (local $1 i32)
  (local $2 i32)
  (local $3 i32)
  (local $4 i32)
  (local $5 i32)
  (local $6 i32)
  (local $7 i32)
  (local $8 i64)
  (local.set $2
   (i32.add
    (local.tee $1
     (i32.load
      (local.get $0)
     )
    )
    (i32.const 4)
   )
  )
  (local.set $0
   (i32.add
    (i32.shl
     (i32.and
      (i32.load
       (local.get $1)
      )
      (i32.const 268435455)
     )
     (i32.const 2)
    )
    (i32.const -2)
   )
  )
  (block $label$1
   (loop $label$2
    (local.set $3
     (i32.add
      (local.get $0)
      (i32.const -2)
     )
    )
    (br_if $label$1
     (i32.load16_u
      (local.tee $4
       (i32.add
        (local.get $1)
        (local.get $0)
       )
      )
     )
    )
    (local.set $0
     (local.get $3)
    )
    (br_if $label$2
     (i32.ge_u
      (local.get $4)
      (local.get $2)
     )
    )
   )
  )
  (local.set $0
   (i32.and
    (local.get $3)
    (i32.const -2)
   )
  )
  (block $label$3
   (loop $label$4
    (block $label$5
     (block $label$6
      (block $label$7
       (br_if $label$7
        (i32.gt_u
         (local.tee $0
          (i32.load16_u
           (local.tee $3
            (i32.add
             (local.tee $5
              (i32.add
               (local.get $1)
               (local.tee $4
                (local.get $0)
               )
              )
             )
             (i32.const 2)
            )
           )
          )
         )
         (i32.const 255)
        )
       )
       (br_if $label$6
        (i32.lt_u
         (local.get $0)
         (i32.const 33)
        )
       )
       (local.set $6
        (i32.eq
         (local.get $0)
         (i32.const 160)
        )
       )
       (br $label$5)
      )
      (block $label$8
       (br_if $label$8
        (i32.ne
         (i32.and
          (local.get $0)
          (i32.const 65280)
         )
         (i32.const 8192)
        )
       )
       (br_if $label$3
        (i32.gt_u
         (local.get $0)
         (i32.const 8287)
        )
       )
       (block $label$9
        (br_if $label$9
         (i32.lt_u
          (local.get $0)
          (i32.const 8234)
         )
        )
        (local.set $6
         (i32.or
          (i32.eq
           (local.get $0)
           (i32.const 8239)
          )
          (i32.eq
           (local.get $0)
           (i32.const 8287)
          )
         )
        )
        (br $label$5)
       )
       (local.set $6
        (i32.or
         (i32.lt_u
          (local.get $0)
          (i32.const 8203)
         )
         (i32.eq
          (i32.and
           (local.get $0)
           (i32.const 65534)
          )
          (i32.const 8232)
         )
        )
       )
       (br $label$5)
      )
      (local.set $6
       (i32.const 1)
      )
      (br_if $label$5
       (i32.eq
        (local.get $0)
        (i32.const 5760)
       )
      )
      (br_if $label$5
       (i32.eq
        (local.get $0)
        (i32.const 12288)
       )
      )
      (br_if $label$5
       (i32.eq
        (local.get $0)
        (i32.const 65279)
       )
      )
      (br $label$3)
     )
     (br_if $label$3
      (i32.ge_u
       (local.tee $0
        (i32.and
         (i32.add
          (local.get $0)
          (i32.const -9)
         )
         (i32.const 65535)
        )
       )
       (i32.const 24)
      )
     )
     (local.set $6
      (i32.const 1)
     )
     (br_if $label$3
      (i32.eqz
       (i32.and
        (i32.shr_u
         (i32.const 8388639)
         (local.get $0)
        )
        (i32.const 1)
       )
      )
     )
    )
    (br_if $label$3
     (i32.eqz
      (local.get $6)
     )
    )
    (local.set $0
     (i32.add
      (local.get $4)
      (i32.const -2)
     )
    )
    (br_if $label$4
     (i32.ge_u
      (local.get $3)
      (local.get $2)
     )
    )
   )
  )
  (local.set $7
   (call $GC_allocate
    (i32.const 1)
    (local.tee $0
     (i32.shr_u
      (local.tee $3
       (i32.add
        (local.get $4)
        (i32.const 7)
       )
      )
      (i32.const 2)
     )
    )
   )
  )
  (block $label$10
   (br_if $label$10
    (i32.eq
     (i32.add
      (local.get $4)
      (i32.const 4)
     )
     (i32.and
      (local.get $3)
      (i32.const -4)
     )
    )
   )
   (i32.store
    (i32.add
     (i32.add
      (i32.shl
       (local.get $0)
       (i32.const 2)
      )
      (local.get $7)
     )
     (i32.const -4)
    )
    (i32.const 0)
   )
  )
  (i32.store
   (local.get $7)
   (i32.or
    (local.get $0)
    (i32.const 805306368)
   )
  )
  (block $label$11
   (br_if $label$11
    (i32.lt_s
     (local.get $4)
     (i32.const 1)
    )
   )
   (local.set $3
    (i32.add
     (local.get $7)
     (i32.const 4)
    )
   )
   (block $label$12
    (block $label$13
     (br_if $label$13
      (i32.lt_u
       (local.get $2)
       (local.tee $6
        (i32.add
         (local.get $5)
         (i32.const 4)
        )
       )
      )
     )
     (local.set $0
      (local.get $2)
     )
     (br $label$12)
    )
    (block $label$14
     (br_if $label$14
      (i32.and
       (local.get $3)
       (i32.const 7)
      )
     )
     (local.set $0
      (local.get $2)
     )
     (br $label$12)
    )
    (local.set $1
     (i32.add
      (local.get $7)
      (i32.const 6)
     )
    )
    (local.set $0
     (local.get $2)
    )
    (block $label$15
     (loop $label$16
      (br_if $label$15
       (i32.eqz
        (local.tee $5
         (i32.load16_u
          (local.get $0)
         )
        )
       )
      )
      (i32.store16
       (local.get $3)
       (local.get $5)
      )
      (local.set $0
       (i32.add
        (local.get $0)
        (i32.const 2)
       )
      )
      (local.set $3
       (i32.add
        (local.get $3)
        (i32.const 2)
       )
      )
      (br_if $label$15
       (i32.eqz
        (i32.and
         (local.get $1)
         (i32.const 7)
        )
       )
      )
      (local.set $1
       (i32.add
        (local.get $1)
        (i32.const 2)
       )
      )
      (br_if $label$16
       (i32.lt_u
        (local.get $0)
        (local.get $6)
       )
      )
     )
    )
    (local.set $4
     (i32.add
      (i32.sub
       (local.get $2)
       (local.get $0)
      )
      (local.get $4)
     )
    )
   )
   (block $label$17
    (br_if $label$17
     (i32.le_u
      (local.tee $4
       (i32.add
        (local.get $0)
        (i32.shl
         (i32.div_s
          (i32.shr_s
           (local.get $4)
           (i32.const 1)
          )
          (i32.const 4)
         )
         (i32.const 3)
        )
       )
      )
      (local.get $0)
     )
    )
    (loop $label$18
     (br_if $label$17
      (i64.eqz
       (local.tee $8
        (i64.load
         (local.get $0)
        )
       )
      )
     )
     (i64.store
      (local.get $3)
      (local.get $8)
     )
     (local.set $3
      (i32.add
       (local.get $3)
       (i32.const 8)
      )
     )
     (br_if $label$18
      (i32.lt_u
       (local.tee $0
        (i32.add
         (local.get $0)
         (i32.const 8)
        )
       )
       (local.get $4)
      )
     )
    )
   )
   (br_if $label$11
    (i32.le_u
     (local.get $6)
     (local.get $0)
    )
   )
   (loop $label$19
    (br_if $label$11
     (i32.eqz
      (local.tee $4
       (i32.load16_u
        (local.get $0)
       )
      )
     )
    )
    (i32.store16
     (local.get $3)
     (local.get $4)
    )
    (local.set $3
     (i32.add
      (local.get $3)
      (i32.const 2)
     )
    )
    (br_if $label$19
     (i32.lt_u
      (local.tee $0
       (i32.add
        (local.get $0)
        (i32.const 2)
       )
      )
      (local.get $6)
     )
    )
   )
  )
  (local.get $7)
 )
 (func $eval_String_all (param $0 i32) (result i32)
  (local $1 i32)
  (local $2 i32)
  (local $3 i32)
  (local $4 i32)
  (local $5 i32)
  (local $6 i32)
  (global.set $__stack_pointer
   (local.tee $1
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 16)
    )
   )
  )
  (local.set $3
   (i32.add
    (local.tee $2
     (i32.load offset=4
      (local.get $0)
     )
    )
    (i32.const 4)
   )
  )
  (local.set $4
   (i32.add
    (i32.shl
     (i32.and
      (i32.load
       (local.get $2)
      )
      (i32.const 268435455)
     )
     (i32.const 2)
    )
    (i32.const -2)
   )
  )
  (local.set $5
   (i32.load
    (local.get $0)
   )
  )
  (block $label$1
   (loop $label$2
    (local.set $0
     (i32.add
      (local.get $4)
      (i32.const -2)
     )
    )
    (br_if $label$1
     (i32.load16_u
      (local.tee $6
       (i32.add
        (local.get $2)
        (local.get $4)
       )
      )
     )
    )
    (local.set $4
     (local.get $0)
    )
    (br_if $label$2
     (i32.ge_u
      (local.get $6)
      (local.get $3)
     )
    )
   )
  )
  (i64.store align=4
   (local.tee $6
    (call $GC_allocate
     (i32.const 1)
     (i32.const 2)
    )
   )
   (i64.const 536870914)
  )
  (block $label$3
   (block $label$4
    (br_if $label$4
     (local.get $0)
    )
    (local.set $0
     (i32.const 8532)
    )
    (br $label$3)
   )
   (local.set $3
    (i32.shr_s
     (local.get $0)
     (i32.const 1)
    )
   )
   (local.set $4
    (i32.const 0)
   )
   (loop $label$5
    (block $label$6
     (br_if $label$6
      (i32.ne
       (i32.and
        (local.tee $0
         (i32.load16_u
          (i32.add
           (i32.add
            (local.get $2)
            (i32.shl
             (local.get $4)
             (i32.const 1)
            )
           )
           (i32.const 4)
          )
         )
        )
        (i32.const 64512)
       )
       (i32.const 55296)
      )
     )
     (local.set $0
      (i32.or
       (i32.shl
        (i32.load16_u
         (i32.add
          (i32.add
           (local.get $2)
           (i32.shl
            (local.tee $4
             (i32.add
              (local.get $4)
              (i32.const 1)
             )
            )
            (i32.const 1)
           )
          )
          (i32.const 4)
         )
        )
        (i32.const 16)
       )
       (local.get $0)
      )
     )
    )
    (i32.store offset=4
     (local.get $6)
     (local.get $0)
    )
    (i32.store offset=12
     (local.get $1)
     (local.get $6)
    )
    (local.set $0
     (i32.const 8540)
    )
    (br_if $label$3
     (i32.eq
      (call $Utils_apply
       (local.get $5)
       (i32.const 1)
       (i32.add
        (local.get $1)
        (i32.const 12)
       )
      )
      (i32.const 8540)
     )
    )
    (br_if $label$5
     (i32.lt_u
      (local.tee $4
       (i32.add
        (local.get $4)
        (i32.const 1)
       )
      )
      (local.get $3)
     )
    )
   )
   (local.set $0
    (i32.const 8532)
   )
  )
  (global.set $__stack_pointer
   (i32.add
    (local.get $1)
    (i32.const 16)
   )
  )
  (local.get $0)
 )
 (func $eval_String_contains (param $0 i32) (result i32)
  (local $1 i32)
  (local $2 i32)
  (local $3 i32)
  (local $4 i32)
  (local $5 i32)
  (local $6 i32)
  (local $7 i32)
  (local $8 i32)
  (local $9 i32)
  (local $10 i32)
  (local $11 i32)
  (local $12 i32)
  (local $13 i32)
  (local $14 i32)
  (local $15 i32)
  (local.set $2
   (i32.add
    (local.tee $1
     (i32.load
      (local.get $0)
     )
    )
    (i32.const 4)
   )
  )
  (local.set $3
   (i32.add
    (i32.shl
     (i32.and
      (i32.load
       (local.get $1)
      )
      (i32.const 268435455)
     )
     (i32.const 2)
    )
    (i32.const -2)
   )
  )
  (local.set $4
   (i32.load offset=4
    (local.get $0)
   )
  )
  (block $label$1
   (loop $label$2
    (local.set $0
     (i32.add
      (local.get $3)
      (i32.const -2)
     )
    )
    (br_if $label$1
     (i32.load16_u
      (local.tee $5
       (i32.add
        (local.get $1)
        (local.get $3)
       )
      )
     )
    )
    (local.set $3
     (local.get $0)
    )
    (br_if $label$2
     (i32.ge_u
      (local.get $5)
      (local.get $2)
     )
    )
   )
  )
  (local.set $6
   (i32.const 8532)
  )
  (block $label$3
   (br_if $label$3
    (i32.eqz
     (local.get $0)
    )
   )
   (local.set $7
    (i32.shr_s
     (local.get $0)
     (i32.const 1)
    )
   )
   (local.set $8
    (i32.add
     (local.get $4)
     (i32.const 4)
    )
   )
   (local.set $3
    (i32.add
     (i32.shl
      (i32.and
       (i32.load
        (local.get $4)
       )
       (i32.const 268435455)
      )
      (i32.const 2)
     )
     (i32.const -2)
    )
   )
   (block $label$4
    (loop $label$5
     (local.set $0
      (i32.add
       (local.get $3)
       (i32.const -2)
      )
     )
     (br_if $label$4
      (i32.load16_u
       (local.tee $5
        (i32.add
         (local.get $4)
         (local.get $3)
        )
       )
      )
     )
     (local.set $3
      (local.get $0)
     )
     (br_if $label$5
      (i32.ge_u
       (local.get $5)
       (local.get $8)
      )
     )
    )
   )
   (block $label$6
    (br_if $label$6
     (i32.gt_u
      (local.get $7)
      (local.tee $9
       (i32.shr_s
        (local.get $0)
        (i32.const 1)
       )
      )
     )
    )
    (local.set $10
     (i32.add
      (local.get $1)
      (i32.const 6)
     )
    )
    (local.set $11
     (i32.add
      (local.get $4)
      (i32.const 6)
     )
    )
    (local.set $12
     (i32.add
      (local.get $4)
      (i32.const 4)
     )
    )
    (local.set $3
     (i32.const 0)
    )
    (loop $label$7
     (block $label$8
      (br_if $label$8
       (i32.ge_u
        (local.get $3)
        (local.get $9)
       )
      )
      (local.set $0
       (i32.add
        (local.get $12)
        (i32.shl
         (local.get $3)
         (i32.const 1)
        )
       )
      )
      (local.set $5
       (i32.load16_u
        (local.get $2)
       )
      )
      (loop $label$9
       (br_if $label$8
        (i32.eq
         (i32.load16_u
          (local.get $0)
         )
         (i32.and
          (local.get $5)
          (i32.const 65535)
         )
        )
       )
       (local.set $0
        (i32.add
         (local.get $0)
         (i32.const 2)
        )
       )
       (br_if $label$6
        (i32.eq
         (local.get $9)
         (local.tee $3
          (i32.add
           (local.get $3)
           (i32.const 1)
          )
         )
        )
       )
       (br $label$9)
      )
     )
     (br_if $label$6
      (i32.ge_u
       (local.tee $13
        (local.get $3)
       )
       (local.get $9)
      )
     )
     (local.set $3
      (i32.add
       (local.get $13)
       (i32.const 1)
      )
     )
     (br_if $label$7
      (i32.ne
       (i32.load16_u
        (i32.add
         (i32.add
          (local.get $4)
          (local.tee $0
           (i32.shl
            (local.get $13)
            (i32.const 1)
           )
          )
         )
         (i32.const 4)
        )
       )
       (i32.load16_u
        (local.get $2)
       )
      )
     )
     (local.set $1
      (i32.add
       (local.get $11)
       (local.get $0)
      )
     )
     (local.set $0
      (i32.const 0)
     )
     (local.set $8
      (local.get $10)
     )
     (block $label$10
      (loop $label$11
       (local.set $5
        (i32.add
         (local.get $0)
         (i32.const 1)
        )
       )
       (br_if $label$10
        (i32.ge_u
         (local.tee $14
          (i32.add
           (local.get $3)
           (local.get $0)
          )
         )
         (local.get $9)
        )
       )
       (br_if $label$10
        (i32.ge_u
         (local.get $5)
         (local.get $7)
        )
       )
       (local.set $14
        (i32.load16_u
         (local.get $8)
        )
       )
       (local.set $15
        (i32.load16_u
         (local.get $1)
        )
       )
       (local.set $8
        (i32.add
         (local.get $8)
         (i32.const 2)
        )
       )
       (local.set $1
        (i32.add
         (local.get $1)
         (i32.const 2)
        )
       )
       (local.set $0
        (local.get $5)
       )
       (br_if $label$7
        (i32.ne
         (local.get $15)
         (local.get $14)
        )
       )
       (br $label$11)
      )
     )
     (block $label$12
      (br_if $label$12
       (i32.ge_u
        (local.get $5)
        (local.get $7)
       )
      )
      (br_if $label$7
       (i32.lt_u
        (local.get $14)
        (local.get $9)
       )
      )
      (br $label$6)
     )
    )
    (br_if $label$3
     (i32.ne
      (i32.add
       (i32.sub
        (local.get $7)
        (local.get $13)
       )
       (i32.const -2)
      )
      (local.get $0)
     )
    )
   )
   (local.set $6
    (i32.const 8540)
   )
  )
  (local.get $6)
 )
 (func $eval_String_startsWith (param $0 i32) (result i32)
  (local $1 i32)
  (local $2 i32)
  (local $3 i32)
  (local $4 i32)
  (local $5 i32)
  (local $6 i32)
  (local $7 i32)
  (local.set $2
   (i32.add
    (local.tee $1
     (i32.load
      (local.get $0)
     )
    )
    (i32.const 4)
   )
  )
  (local.set $3
   (i32.add
    (i32.shl
     (i32.and
      (i32.load
       (local.get $1)
      )
      (i32.const 268435455)
     )
     (i32.const 2)
    )
    (i32.const -2)
   )
  )
  (local.set $4
   (i32.load offset=4
    (local.get $0)
   )
  )
  (block $label$1
   (loop $label$2
    (local.set $0
     (i32.add
      (local.get $3)
      (i32.const -2)
     )
    )
    (br_if $label$1
     (i32.load16_u
      (local.tee $5
       (i32.add
        (local.get $1)
        (local.get $3)
       )
      )
     )
    )
    (local.set $3
     (local.get $0)
    )
    (br_if $label$2
     (i32.ge_u
      (local.get $5)
      (local.get $2)
     )
    )
   )
  )
  (local.set $6
   (i32.const 8532)
  )
  (block $label$3
   (br_if $label$3
    (i32.eqz
     (local.get $0)
    )
   )
   (local.set $7
    (i32.shr_s
     (local.get $0)
     (i32.const 1)
    )
   )
   (local.set $2
    (i32.add
     (local.get $4)
     (i32.const 4)
    )
   )
   (local.set $3
    (i32.add
     (i32.shl
      (i32.and
       (i32.load
        (local.get $4)
       )
       (i32.const 268435455)
      )
      (i32.const 2)
     )
     (i32.const -2)
    )
   )
   (block $label$4
    (loop $label$5
     (local.set $0
      (i32.add
       (local.get $3)
       (i32.const -2)
      )
     )
     (br_if $label$4
      (i32.load16_u
       (local.tee $5
        (i32.add
         (local.get $4)
         (local.get $3)
        )
       )
      )
     )
     (local.set $3
      (local.get $0)
     )
     (br_if $label$5
      (i32.ge_u
       (local.get $5)
       (local.get $2)
      )
     )
    )
   )
   (block $label$6
    (br_if $label$6
     (i32.gt_u
      (local.get $7)
      (i32.shr_s
       (local.get $0)
       (i32.const 1)
      )
     )
    )
    (local.set $5
     (select
      (local.get $7)
      (i32.const 1)
      (i32.gt_u
       (local.get $7)
       (i32.const 1)
      )
     )
    )
    (local.set $3
     (i32.add
      (local.get $1)
      (i32.const 4)
     )
    )
    (local.set $0
     (i32.add
      (local.get $4)
      (i32.const 4)
     )
    )
    (loop $label$7
     (br_if $label$6
      (i32.ne
       (i32.load16_u
        (local.get $0)
       )
       (i32.load16_u
        (local.get $3)
       )
      )
     )
     (local.set $3
      (i32.add
       (local.get $3)
       (i32.const 2)
      )
     )
     (local.set $0
      (i32.add
       (local.get $0)
       (i32.const 2)
      )
     )
     (br_if $label$3
      (i32.eqz
       (local.tee $5
        (i32.add
         (local.get $5)
         (i32.const -1)
        )
       )
      )
     )
     (br $label$7)
    )
   )
   (local.set $6
    (i32.const 8540)
   )
  )
  (local.get $6)
 )
 (func $eval_String_endsWith (param $0 i32) (result i32)
  (local $1 i32)
  (local $2 i32)
  (local $3 i32)
  (local $4 i32)
  (local $5 i32)
  (local $6 i32)
  (local $7 i32)
  (local.set $2
   (i32.add
    (local.tee $1
     (i32.load
      (local.get $0)
     )
    )
    (i32.const 4)
   )
  )
  (local.set $3
   (i32.add
    (i32.shl
     (i32.and
      (i32.load
       (local.get $1)
      )
      (i32.const 268435455)
     )
     (i32.const 2)
    )
    (i32.const -2)
   )
  )
  (local.set $4
   (i32.load offset=4
    (local.get $0)
   )
  )
  (block $label$1
   (loop $label$2
    (local.set $0
     (i32.add
      (local.get $3)
      (i32.const -2)
     )
    )
    (br_if $label$1
     (i32.load16_u
      (local.tee $5
       (i32.add
        (local.get $1)
        (local.get $3)
       )
      )
     )
    )
    (local.set $3
     (local.get $0)
    )
    (br_if $label$2
     (i32.ge_u
      (local.get $5)
      (local.get $2)
     )
    )
   )
  )
  (local.set $6
   (i32.const 8532)
  )
  (block $label$3
   (br_if $label$3
    (i32.eqz
     (local.get $0)
    )
   )
   (local.set $7
    (i32.shr_s
     (local.get $0)
     (i32.const 1)
    )
   )
   (local.set $2
    (i32.add
     (local.get $4)
     (i32.const 4)
    )
   )
   (local.set $3
    (i32.add
     (i32.shl
      (i32.and
       (i32.load
        (local.get $4)
       )
       (i32.const 268435455)
      )
      (i32.const 2)
     )
     (i32.const -2)
    )
   )
   (block $label$4
    (loop $label$5
     (local.set $0
      (i32.add
       (local.get $3)
       (i32.const -2)
      )
     )
     (br_if $label$4
      (i32.load16_u
       (local.tee $5
        (i32.add
         (local.get $4)
         (local.get $3)
        )
       )
      )
     )
     (local.set $3
      (local.get $0)
     )
     (br_if $label$5
      (i32.ge_u
       (local.get $5)
       (local.get $2)
      )
     )
    )
   )
   (block $label$6
    (br_if $label$6
     (i32.gt_u
      (local.get $7)
      (local.tee $3
       (i32.shr_s
        (local.get $0)
        (i32.const 1)
       )
      )
     )
    )
    (local.set $5
     (select
      (local.get $7)
      (i32.const 1)
      (i32.gt_u
       (local.get $7)
       (i32.const 1)
      )
     )
    )
    (local.set $3
     (i32.add
      (i32.add
       (i32.shl
        (local.get $3)
        (i32.const 1)
       )
       (local.get $4)
      )
      (i32.const 2)
     )
    )
    (local.set $0
     (i32.add
      (i32.add
       (i32.shl
        (local.get $7)
        (i32.const 1)
       )
       (local.get $1)
      )
      (i32.const 2)
     )
    )
    (loop $label$7
     (br_if $label$6
      (i32.ne
       (i32.load16_u
        (local.get $3)
       )
       (i32.load16_u
        (local.get $0)
       )
      )
     )
     (local.set $3
      (i32.add
       (local.get $3)
       (i32.const -2)
      )
     )
     (local.set $0
      (i32.add
       (local.get $0)
       (i32.const -2)
      )
     )
     (br_if $label$3
      (i32.eqz
       (local.tee $5
        (i32.add
         (local.get $5)
         (i32.const -1)
        )
       )
      )
     )
     (br $label$7)
    )
   )
   (local.set $6
    (i32.const 8540)
   )
  )
  (local.get $6)
 )
 (func $eval_String_indexes (param $0 i32) (result i32)
  (local $1 i32)
  (local $2 i32)
  (local $3 i32)
  (local $4 i32)
  (local $5 i32)
  (local $6 i32)
  (local $7 i32)
  (local $8 i32)
  (local $9 i32)
  (local $10 i32)
  (local.set $2
   (i32.add
    (local.tee $1
     (i32.load
      (local.get $0)
     )
    )
    (i32.const 4)
   )
  )
  (local.set $3
   (i32.add
    (i32.shl
     (i32.and
      (i32.load
       (local.get $1)
      )
      (i32.const 268435455)
     )
     (i32.const 2)
    )
    (i32.const -2)
   )
  )
  (local.set $4
   (i32.load offset=4
    (local.get $0)
   )
  )
  (block $label$1
   (loop $label$2
    (local.set $0
     (i32.add
      (local.get $3)
      (i32.const -2)
     )
    )
    (br_if $label$1
     (i32.load16_u
      (local.tee $5
       (i32.add
        (local.get $1)
        (local.get $3)
       )
      )
     )
    )
    (local.set $3
     (local.get $0)
    )
    (br_if $label$2
     (i32.ge_u
      (local.get $5)
      (local.get $2)
     )
    )
   )
  )
  (block $label$3
   (block $label$4
    (br_if $label$4
     (local.get $0)
    )
    (local.set $6
     (i32.const 8512)
    )
    (br $label$3)
   )
   (local.set $7
    (i32.shr_s
     (local.get $0)
     (i32.const 1)
    )
   )
   (local.set $2
    (i32.add
     (local.get $4)
     (i32.const 4)
    )
   )
   (local.set $3
    (i32.add
     (i32.shl
      (i32.and
       (i32.load
        (local.get $4)
       )
       (i32.const 268435455)
      )
      (i32.const 2)
     )
     (i32.const -2)
    )
   )
   (block $label$5
    (loop $label$6
     (local.set $0
      (i32.add
       (local.get $3)
       (i32.const -2)
      )
     )
     (br_if $label$5
      (i32.load16_u
       (local.tee $5
        (i32.add
         (local.get $4)
         (local.get $3)
        )
       )
      )
     )
     (local.set $3
      (local.get $0)
     )
     (br_if $label$6
      (i32.ge_u
       (local.get $5)
       (local.get $2)
      )
     )
    )
   )
   (local.set $8
    (i32.add
     (local.get $4)
     (i32.const 2)
    )
   )
   (local.set $2
    (i32.shr_s
     (local.get $0)
     (i32.const 1)
    )
   )
   (local.set $9
    (i32.add
     (local.get $1)
     (i32.shl
      (local.get $7)
      (i32.const 1)
     )
    )
   )
   (local.set $10
    (i32.add
     (i32.add
      (local.get $1)
      (i32.shl
       (local.tee $7
        (i32.add
         (local.get $7)
         (i32.const -1)
        )
       )
       (i32.const 1)
      )
     )
     (i32.const 4)
    )
   )
   (local.set $6
    (i32.const 8512)
   )
   (loop $label$7
    (block $label$8
     (block $label$9
      (br_if $label$9
       (i32.ge_s
        (i32.or
         (local.tee $5
          (i32.add
           (local.get $2)
           (i32.const -1)
          )
         )
         (local.get $7)
        )
        (i32.const 0)
       )
      )
      (local.set $2
       (local.get $5)
      )
      (br $label$8)
     )
     (local.set $3
      (i32.add
       (local.get $8)
       (i32.shl
        (local.get $2)
        (i32.const 1)
       )
      )
     )
     (local.set $0
      (i32.load16_u
       (local.get $10)
      )
     )
     (local.set $2
      (local.get $5)
     )
     (loop $label$10
      (br_if $label$8
       (i32.eq
        (i32.load16_u
         (local.get $3)
        )
        (i32.and
         (local.get $0)
         (i32.const 65535)
        )
       )
      )
      (local.set $3
       (i32.add
        (local.get $3)
        (i32.const -2)
       )
      )
      (br_if $label$10
       (i32.gt_s
        (i32.or
         (local.tee $2
          (i32.add
           (local.get $2)
           (i32.const -1)
          )
         )
         (local.get $7)
        )
        (i32.const -1)
       )
      )
     )
    )
    (br_if $label$3
     (i32.lt_s
      (local.get $2)
      (i32.const 0)
     )
    )
    (local.set $0
     (i32.add
      (local.get $8)
      (i32.shl
       (local.get $2)
       (i32.const 1)
      )
     )
    )
    (local.set $3
     (i32.const 0)
    )
    (local.set $5
     (local.get $9)
    )
    (block $label$11
     (loop $label$12
      (local.set $1
       (i32.add
        (local.get $7)
        (local.get $3)
       )
      )
      (br_if $label$11
       (i32.eqz
        (local.tee $4
         (i32.add
          (local.get $2)
          (local.get $3)
         )
        )
       )
      )
      (br_if $label$11
       (i32.lt_s
        (local.get $1)
        (i32.const 1)
       )
      )
      (local.set $3
       (i32.add
        (local.get $3)
        (i32.const -1)
       )
      )
      (local.set $1
       (i32.load16_u
        (local.get $5)
       )
      )
      (local.set $4
       (i32.load16_u
        (local.get $0)
       )
      )
      (local.set $5
       (i32.add
        (local.get $5)
        (i32.const -2)
       )
      )
      (local.set $0
       (i32.add
        (local.get $0)
        (i32.const -2)
       )
      )
      (br_if $label$7
       (i32.ne
        (local.get $4)
        (local.get $1)
       )
      )
      (br $label$12)
     )
    )
    (block $label$13
     (br_if $label$13
      (local.tee $3
       (i32.lt_s
        (local.get $1)
        (i32.const 1)
       )
      )
     )
     (br_if $label$7
      (local.get $4)
     )
    )
    (br_if $label$3
     (i32.lt_s
      (local.tee $3
       (select
        (local.get $4)
        (i32.const -1)
        (local.get $3)
       )
      )
      (i32.const 0)
     )
    )
    (f64.store offset=8
     (local.tee $0
      (call $GC_allocate
       (i32.const 1)
       (i32.const 4)
      )
     )
     (f64.convert_i32_s
      (local.get $3)
     )
    )
    (i32.store
     (local.get $0)
     (i32.const 4)
    )
    (i32.store offset=8
     (local.tee $3
      (call $GC_allocate
       (i32.const 1)
       (i32.const 3)
      )
     )
     (local.get $6)
    )
    (i32.store offset=4
     (local.get $3)
     (local.get $0)
    )
    (i32.store
     (local.get $3)
     (i32.const 1073741827)
    )
    (local.set $6
     (local.get $3)
    )
    (local.set $2
     (local.get $4)
    )
    (br $label$7)
   )
  )
  (local.get $6)
 )
 (func $String_fromNumber_eval (param $0 i32) (result i32)
  (local $1 i32)
  (local $2 i32)
  (local $3 i32)
  (local $4 i32)
  (local $5 i32)
  (local $6 i32)
  (local $7 f64)
  (local $8 i64)
  (global.set $__stack_pointer
   (local.tee $1
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 64)
    )
   )
  )
  (local.set $7
   (f64.load offset=8
    (local.tee $0
     (i32.load
      (local.get $0)
     )
    )
   )
  )
  (block $label$1
   (block $label$2
    (br_if $label$2
     (i32.gt_u
      (i32.load
       (local.get $0)
      )
      (i32.const 268435455)
     )
    )
    (block $label$3
     (block $label$4
      (br_if $label$4
       (i32.eqz
        (f64.lt
         (f64.abs
          (local.get $7)
         )
         (f64.const 9223372036854775808)
        )
       )
      )
      (local.set $8
       (i64.trunc_f64_s
        (local.get $7)
       )
      )
      (br $label$3)
     )
     (local.set $8
      (i64.const -9223372036854775808)
     )
    )
    (i64.store
     (local.get $1)
     (local.get $8)
    )
    (local.set $2
     (call $stbsp_snprintf
      (i32.add
       (local.get $1)
       (i32.const 32)
      )
      (i32.const 25)
      (i32.const 3245)
      (local.get $1)
     )
    )
    (br $label$1)
   )
   (f64.store offset=16
    (local.get $1)
    (local.get $7)
   )
   (local.set $2
    (call $stbsp_snprintf
     (i32.add
      (local.get $1)
      (i32.const 32)
     )
     (i32.const 25)
     (i32.const 2634)
     (i32.add
      (local.get $1)
      (i32.const 16)
     )
    )
   )
  )
  (local.set $5
   (call $GC_allocate
    (i32.const 1)
    (local.tee $0
     (i32.shr_u
      (local.tee $4
       (i32.add
        (local.tee $3
         (i32.shl
          (local.get $2)
          (i32.const 1)
         )
        )
        (i32.const 7)
       )
      )
      (i32.const 2)
     )
    )
   )
  )
  (block $label$5
   (br_if $label$5
    (i32.eq
     (i32.and
      (local.get $4)
      (i32.const -4)
     )
     (i32.add
      (local.get $3)
      (i32.const 4)
     )
    )
   )
   (i32.store
    (i32.add
     (i32.add
      (i32.shl
       (local.get $0)
       (i32.const 2)
      )
      (local.get $5)
     )
     (i32.const -4)
    )
    (i32.const 0)
   )
  )
  (i32.store
   (local.get $5)
   (i32.or
    (local.get $0)
    (i32.const 805306368)
   )
  )
  (block $label$6
   (br_if $label$6
    (i32.lt_s
     (local.get $2)
     (i32.const 1)
    )
   )
   (local.set $4
    (i32.and
     (local.get $2)
     (i32.const 3)
    )
   )
   (local.set $3
    (i32.const 0)
   )
   (block $label$7
    (br_if $label$7
     (i32.lt_u
      (i32.add
       (local.get $2)
       (i32.const -1)
      )
      (i32.const 3)
     )
    )
    (local.set $0
     (i32.add
      (local.get $5)
      (i32.const 6)
     )
    )
    (local.set $6
     (i32.and
      (local.get $2)
      (i32.const -4)
     )
    )
    (local.set $3
     (i32.const 0)
    )
    (loop $label$8
     (i32.store16
      (i32.add
       (local.get $0)
       (i32.const -2)
      )
      (i32.load8_s
       (local.tee $2
        (i32.add
         (i32.add
          (local.get $1)
          (i32.const 32)
         )
         (local.get $3)
        )
       )
      )
     )
     (i32.store16
      (local.get $0)
      (i32.load8_s
       (i32.add
        (local.get $2)
        (i32.const 1)
       )
      )
     )
     (i32.store16
      (i32.add
       (local.get $0)
       (i32.const 2)
      )
      (i32.load8_s
       (i32.add
        (local.get $2)
        (i32.const 2)
       )
      )
     )
     (i32.store16
      (i32.add
       (local.get $0)
       (i32.const 4)
      )
      (i32.load8_s
       (i32.add
        (local.get $2)
        (i32.const 3)
       )
      )
     )
     (local.set $0
      (i32.add
       (local.get $0)
       (i32.const 8)
      )
     )
     (br_if $label$8
      (i32.ne
       (local.get $6)
       (local.tee $3
        (i32.add
         (local.get $3)
         (i32.const 4)
        )
       )
      )
     )
    )
   )
   (br_if $label$6
    (i32.eqz
     (local.get $4)
    )
   )
   (local.set $0
    (i32.add
     (i32.add
      (i32.shl
       (local.get $3)
       (i32.const 1)
      )
      (local.get $5)
     )
     (i32.const 4)
    )
   )
   (local.set $2
    (i32.add
     (i32.add
      (local.get $1)
      (i32.const 32)
     )
     (local.get $3)
    )
   )
   (loop $label$9
    (i32.store16
     (local.get $0)
     (i32.load8_s
      (local.get $2)
     )
    )
    (local.set $2
     (i32.add
      (local.get $2)
      (i32.const 1)
     )
    )
    (local.set $0
     (i32.add
      (local.get $0)
      (i32.const 2)
     )
    )
    (br_if $label$9
     (local.tee $4
      (i32.add
       (local.get $4)
       (i32.const -1)
      )
     )
    )
   )
  )
  (global.set $__stack_pointer
   (i32.add
    (local.get $1)
    (i32.const 64)
   )
  )
  (local.get $5)
 )
 (func $eval_String_toInt (param $0 i32) (result i32)
  (local $1 i32)
  (local $2 i32)
  (local $3 i32)
  (local $4 i32)
  (local $5 i32)
  (local $6 i32)
  (local $7 i32)
  (local $8 i32)
  (global.set $__stack_pointer
   (local.tee $1
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 16)
    )
   )
  )
  (local.set $3
   (i32.add
    (local.tee $2
     (i32.load
      (local.get $0)
     )
    )
    (i32.const 4)
   )
  )
  (local.set $0
   (i32.add
    (i32.shl
     (i32.and
      (i32.load
       (local.get $2)
      )
      (i32.const 268435455)
     )
     (i32.const 2)
    )
    (i32.const -2)
   )
  )
  (block $label$1
   (loop $label$2
    (local.set $4
     (i32.add
      (local.get $0)
      (i32.const -2)
     )
    )
    (br_if $label$1
     (i32.load16_u
      (local.tee $5
       (i32.add
        (local.get $2)
        (local.get $0)
       )
      )
     )
    )
    (local.set $0
     (local.get $4)
    )
    (br_if $label$2
     (i32.ge_u
      (local.get $5)
      (local.get $3)
     )
    )
   )
  )
  (local.set $6
   (i32.const 0)
  )
  (block $label$3
   (br_if $label$3
    (i32.le_u
     (local.tee $7
      (i32.shr_s
       (local.get $4)
       (i32.const 1)
      )
     )
     (local.tee $3
      (i32.or
       (i32.eq
        (local.tee $8
         (i32.load16_u
          (local.get $3)
         )
        )
        (i32.const 43)
       )
       (i32.eq
        (local.get $8)
        (i32.const 45)
       )
      )
     )
    )
   )
   (local.set $0
    (i32.add
     (i32.add
      (i32.shl
       (local.get $3)
       (i32.const 1)
      )
      (local.get $2)
     )
     (i32.const 4)
    )
   )
   (local.set $4
    (i32.const 0)
   )
   (local.set $5
    (local.get $3)
   )
   (loop $label$4
    (br_if $label$3
     (i32.lt_u
      (i32.and
       (i32.add
        (local.tee $2
         (i32.load16_u
          (local.get $0)
         )
        )
        (i32.const -58)
       )
       (i32.const 65535)
      )
      (i32.const 65526)
     )
    )
    (local.set $0
     (i32.add
      (local.get $0)
      (i32.const 2)
     )
    )
    (local.set $4
     (i32.add
      (i32.add
       (i32.mul
        (local.get $4)
        (i32.const 10)
       )
       (local.get $2)
      )
      (i32.const -48)
     )
    )
    (br_if $label$4
     (i32.ne
      (local.get $7)
      (local.tee $5
       (i32.add
        (local.get $5)
        (i32.const 1)
       )
      )
     )
    )
   )
   (br_if $label$3
    (i32.eq
     (local.get $7)
     (local.get $3)
    )
   )
   (i32.store
    (local.tee $0
     (call $GC_allocate
      (i32.const 1)
      (i32.const 4)
     )
    )
    (i32.const 4)
   )
   (f64.store offset=8
    (local.get $0)
    (f64.convert_i32_s
     (select
      (i32.sub
       (i32.const 0)
       (local.get $4)
      )
      (local.get $4)
      (i32.eq
       (local.get $8)
       (i32.const 45)
      )
     )
    )
   )
   (i32.store offset=12
    (local.get $1)
    (local.get $0)
   )
   (local.set $6
    (call $Utils_apply
     (i32.const 0)
     (i32.const 1)
     (i32.add
      (local.get $1)
      (i32.const 12)
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
  (local.get $6)
 )
 (func $eval_String_toFloat (param $0 i32) (result i32)
  (local $1 i32)
  (local $2 i32)
  (local $3 i32)
  (local $4 i32)
  (local $5 i32)
  (local $6 f64)
  (global.set $__stack_pointer
   (local.tee $1
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 16)
    )
   )
  )
  (local.set $3
   (i32.add
    (local.tee $2
     (i32.load
      (local.get $0)
     )
    )
    (i32.const 4)
   )
  )
  (local.set $0
   (i32.add
    (i32.shl
     (i32.and
      (i32.load
       (local.get $2)
      )
      (i32.const 268435455)
     )
     (i32.const 2)
    )
    (i32.const -2)
   )
  )
  (block $label$1
   (loop $label$2
    (local.set $4
     (i32.add
      (local.get $0)
      (i32.const -2)
     )
    )
    (br_if $label$1
     (i32.load16_u
      (local.tee $5
       (i32.add
        (local.get $2)
        (local.get $0)
       )
      )
     )
    )
    (local.set $0
     (local.get $4)
    )
    (br_if $label$2
     (i32.ge_u
      (local.get $5)
      (local.get $3)
     )
    )
   )
  )
  (local.set $0
   (i32.const 0)
  )
  (block $label$3
   (br_if $label$3
    (call $isnan
     (local.tee $6
      (call $parseFloat
       (local.get $3)
       (select
        (local.tee $4
         (i32.shr_s
          (local.get $4)
          (i32.const 1)
         )
        )
        (i32.const 24)
        (i32.lt_u
         (local.get $4)
         (i32.const 24)
        )
       )
      )
     )
    )
   )
   (i32.store
    (local.tee $0
     (call $GC_allocate
      (i32.const 1)
      (i32.const 4)
     )
    )
    (i32.const 268435460)
   )
   (f64.store offset=8
    (local.get $0)
    (local.get $6)
   )
   (i32.store offset=12
    (local.get $1)
    (local.get $0)
   )
   (local.set $0
    (call $Utils_apply
     (i32.const 0)
     (i32.const 1)
     (i32.add
      (local.get $1)
      (i32.const 12)
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
  (local.get $0)
 )
 (func $Debug_is_target_in_range (param $0 i32) (param $1 i32) (result i32)
  (i32.const 0)
 )
 (func $Debug_pretty (param $0 i32) (param $1 i32)
  (local $2 i32)
  (global.set $__stack_pointer
   (local.tee $2
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 80)
    )
   )
  )
  (i32.store8 offset=56
   (local.get $2)
   (i32.const 0)
  )
  (i64.store offset=48
   (local.get $2)
   (i64.const 3255307777713450285)
  )
  (i32.store offset=32
   (local.get $2)
   (i32.add
    (local.get $2)
    (i32.const 48)
   )
  )
  (call $safe_printf
   (i32.const 4182)
   (i32.add
    (local.get $2)
    (i32.const 32)
   )
  )
  (i32.store offset=20
   (local.get $2)
   (local.get $1)
  )
  (i32.store offset=16
   (local.get $2)
   (local.get $0)
  )
  (call $safe_printf
   (i32.const 5861)
   (i32.add
    (local.get $2)
    (i32.const 16)
   )
  )
  (i32.store
   (local.get $2)
   (local.get $1)
  )
  (call $safe_printf
   (i32.const 2058)
   (local.get $2)
  )
  (call $safe_printf
   (i32.const 4290)
   (i32.const 0)
  )
  (call $safe_printf
   (i32.const 4290)
   (i32.const 0)
  )
  (call $Debug_prettyHelp
   (i32.const 2)
   (local.get $1)
  )
  (global.set $__stack_pointer
   (i32.add
    (local.get $2)
    (i32.const 80)
   )
  )
 )
 (func $Debug_prettyHelp (param $0 i32) (param $1 i32)
  (local $2 i32)
  (local $3 i32)
  (local $4 i32)
  (local $5 i32)
  (local $6 i32)
  (local $7 i32)
  (local $8 i32)
  (local $9 i32)
  (local $10 i32)
  (local $11 i32)
  (global.set $__stack_pointer
   (local.tee $2
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 560)
    )
   )
  )
  (block $label$1
   (block $label$2
    (br_if $label$2
     (local.get $1)
    )
    (call $safe_printf
     (i32.const 5600)
     (i32.const 0)
    )
    (br $label$1)
   )
   (block $label$3
    (br_if $label$3
     (i32.lt_s
      (local.get $0)
      (i32.const 21)
     )
    )
    (call $safe_printf
     (i32.const 5619)
     (i32.const 0)
    )
    (br $label$1)
   )
   (block $label$4
    (br_if $label$4
     (i32.ge_u
      (i32.load offset=8768
       (i32.const 0)
      )
      (local.get $1)
     )
    )
    (i32.store
     (local.get $2)
     (local.get $1)
    )
    (call $safe_printf
     (i32.const 5185)
     (local.get $2)
    )
    (br $label$1)
   )
   (block $label$5
    (br_if $label$5
     (i32.ne
      (local.get $1)
      (i32.const 8532)
     )
    )
    (call $safe_printf
     (i32.const 5226)
     (i32.const 0)
    )
    (br $label$1)
   )
   (block $label$6
    (br_if $label$6
     (i32.ne
      (local.get $1)
      (i32.const 8540)
     )
    )
    (call $safe_printf
     (i32.const 5277)
     (i32.const 0)
    )
    (br $label$1)
   )
   (block $label$7
    (br_if $label$7
     (i32.ne
      (local.get $1)
      (i32.const 8524)
     )
    )
    (call $safe_printf
     (i32.const 6015)
     (i32.const 0)
    )
    (br $label$1)
   )
   (block $label$8
    (br_if $label$8
     (i32.ne
      (local.get $1)
      (i32.const 0)
     )
    )
    (call $safe_printf
     (i32.const 5205)
     (i32.const 0)
    )
    (br $label$1)
   )
   (local.set $3
    (i32.add
     (local.get $0)
     (i32.const 4)
    )
   )
   (local.set $4
    (i32.add
     (local.get $0)
     (i32.const 2)
    )
   )
   (block $label$9
    (block $label$10
     (block $label$11
      (block $label$12
       (block $label$13
        (block $label$14
         (block $label$15
          (block $label$16
           (block $label$17
            (block $label$18
             (block $label$19
              (block $label$20
               (block $label$21
                (block $label$22
                 (block $label$23
                  (block $label$24
                   (block $label$25
                    (br_table $label$25 $label$24 $label$23 $label$22 $label$21 $label$20 $label$19 $label$18 $label$10 $label$11 $label$12 $label$13 $label$14 $label$15 $label$16
                     (local.tee $6
                      (i32.shr_u
                       (local.tee $5
                        (i32.load
                         (local.get $1)
                        )
                       )
                       (i32.const 28)
                      )
                     )
                    )
                   )
                   (f64.store offset=32
                    (local.get $2)
                    (f64.load offset=8
                     (local.get $1)
                    )
                   )
                   (call $safe_printf
                    (i32.const 5436)
                    (i32.add
                     (local.get $2)
                     (i32.const 32)
                    )
                   )
                   (br $label$1)
                  )
                  (f64.store offset=48
                   (local.get $2)
                   (f64.load offset=8
                    (local.get $1)
                   )
                  )
                  (call $safe_printf
                   (i32.const 5216)
                   (i32.add
                    (local.get $2)
                    (i32.const 48)
                   )
                  )
                  (br $label$1)
                 )
                 (i32.store offset=64
                  (local.get $2)
                  (i32.load offset=4
                   (local.get $1)
                  )
                 )
                 (call $safe_printf
                  (i32.const 4831)
                  (i32.add
                   (local.get $2)
                   (i32.const 64)
                  )
                 )
                 (br $label$1)
                )
                (local.set $3
                 (i32.add
                  (local.get $1)
                  (i32.const 4)
                 )
                )
                (local.set $7
                 (i32.add
                  (i32.shl
                   (i32.and
                    (local.get $5)
                    (i32.const 268435455)
                   )
                   (i32.const 2)
                  )
                  (i32.const -2)
                 )
                )
                (local.set $6
                 (i32.const 0)
                )
                (loop $label$26
                 (local.set $0
                  (local.get $7)
                 )
                 (block $label$27
                  (loop $label$28
                   (local.set $4
                    (i32.add
                     (local.get $0)
                     (i32.const -2)
                    )
                   )
                   (br_if $label$27
                    (i32.load16_u
                     (local.tee $5
                      (i32.add
                       (local.get $1)
                       (local.get $0)
                      )
                     )
                    )
                   )
                   (local.set $0
                    (local.get $4)
                   )
                   (br_if $label$28
                    (i32.ge_u
                     (local.get $5)
                     (local.get $3)
                    )
                   )
                  )
                 )
                 (block $label$29
                  (br_if $label$29
                   (i32.gt_u
                    (local.get $6)
                    (i32.const 98)
                   )
                  )
                  (br_if $label$29
                   (i32.ge_u
                    (local.get $6)
                    (i32.shr_s
                     (local.get $4)
                     (i32.const 1)
                    )
                   )
                  )
                  (block $label$30
                   (br_if $label$30
                    (i32.eqz
                     (local.tee $0
                      (i32.load16_u
                       (i32.add
                        (local.get $3)
                        (i32.shl
                         (local.get $6)
                         (i32.const 1)
                        )
                       )
                      )
                     )
                    )
                   )
                   (i32.store8
                    (i32.add
                     (i32.add
                      (local.get $2)
                      (i32.const 448)
                     )
                     (local.get $6)
                    )
                    (select
                     (local.get $0)
                     (i32.const 35)
                     (i32.lt_u
                      (local.get $0)
                      (i32.const 128)
                     )
                    )
                   )
                  )
                  (local.set $6
                   (i32.add
                    (local.get $6)
                    (i32.const 1)
                   )
                  )
                  (br $label$26)
                 )
                )
                (i32.store8
                 (i32.add
                  (i32.add
                   (local.get $2)
                   (i32.const 448)
                  )
                  (local.get $6)
                 )
                 (i32.const 0)
                )
                (i32.store offset=80
                 (local.get $2)
                 (i32.add
                  (local.get $2)
                  (i32.const 448)
                 )
                )
                (call $safe_printf
                 (i32.const 6022)
                 (i32.add
                  (local.get $2)
                  (i32.const 80)
                 )
                )
                (br $label$1)
               )
               (block $label$31
                (br_if $label$31
                 (i32.ne
                  (i32.load offset=7844
                   (i32.const 0)
                  )
                  (local.get $1)
                 )
                )
                (call $safe_printf
                 (i32.const 5593)
                 (i32.const 0)
                )
                (br $label$1)
               )
               (call $safe_printf
                (i32.const 5597)
                (i32.const 0)
               )
               (br_if $label$9
                (i32.eq
                 (local.get $1)
                 (i32.const 8512)
                )
               )
               (call $pretty_print_child
                (local.get $4)
                (i32.load offset=4
                 (local.get $1)
                )
               )
               (br_if $label$9
                (i32.eq
                 (local.tee $1
                  (i32.load offset=8
                   (local.get $1)
                  )
                 )
                 (i32.const 8512)
                )
               )
               (call $pretty_print_child
                (local.get $4)
                (i32.load offset=4
                 (local.get $1)
                )
               )
               (br_if $label$9
                (i32.eq
                 (local.tee $1
                  (i32.load offset=8
                   (local.get $1)
                  )
                 )
                 (i32.const 8512)
                )
               )
               (call $pretty_print_child
                (local.get $4)
                (i32.load offset=4
                 (local.get $1)
                )
               )
               (br_if $label$9
                (i32.eq
                 (local.tee $1
                  (i32.load offset=8
                   (local.get $1)
                  )
                 )
                 (i32.const 8512)
                )
               )
               (call $pretty_print_child
                (local.get $4)
                (i32.load offset=4
                 (local.get $1)
                )
               )
               (br_if $label$9
                (i32.eq
                 (local.tee $1
                  (i32.load offset=8
                   (local.get $1)
                  )
                 )
                 (i32.const 8512)
                )
               )
               (call $pretty_print_child
                (local.get $4)
                (i32.load offset=4
                 (local.get $1)
                )
               )
               (br_if $label$9
                (i32.eq
                 (local.tee $1
                  (i32.load offset=8
                   (local.get $1)
                  )
                 )
                 (i32.const 8512)
                )
               )
               (call $pretty_print_child
                (local.get $4)
                (i32.load offset=4
                 (local.get $1)
                )
               )
               (br_if $label$9
                (i32.eq
                 (local.tee $1
                  (i32.load offset=8
                   (local.get $1)
                  )
                 )
                 (i32.const 8512)
                )
               )
               (call $pretty_print_child
                (local.get $4)
                (i32.load offset=4
                 (local.get $1)
                )
               )
               (br_if $label$9
                (i32.eq
                 (local.tee $1
                  (i32.load offset=8
                   (local.get $1)
                  )
                 )
                 (i32.const 8512)
                )
               )
               (call $pretty_print_child
                (local.get $4)
                (i32.load offset=4
                 (local.get $1)
                )
               )
               (br_if $label$9
                (i32.eq
                 (local.tee $1
                  (i32.load offset=8
                   (local.get $1)
                  )
                 )
                 (i32.const 8512)
                )
               )
               (call $pretty_print_child
                (local.get $4)
                (i32.load offset=4
                 (local.get $1)
                )
               )
               (br_if $label$9
                (i32.eq
                 (local.tee $1
                  (i32.load offset=8
                   (local.get $1)
                  )
                 )
                 (i32.const 8512)
                )
               )
               (call $pretty_print_child
                (local.get $4)
                (i32.load offset=4
                 (local.get $1)
                )
               )
               (br_if $label$9
                (i32.eq
                 (local.tee $1
                  (i32.load offset=8
                   (local.get $1)
                  )
                 )
                 (i32.const 8512)
                )
               )
               (call $pretty_print_child
                (local.get $4)
                (i32.load offset=4
                 (local.get $1)
                )
               )
               (br_if $label$17
                (i32.ne
                 (local.tee $1
                  (i32.load offset=8
                   (local.get $1)
                  )
                 )
                 (i32.const 8512)
                )
               )
               (br $label$9)
              )
              (call $safe_printf
               (i32.const 6019)
               (i32.const 0)
              )
              (call $pretty_print_child
               (local.get $4)
               (i32.load offset=4
                (local.get $1)
               )
              )
              (call $pretty_print_child
               (local.get $4)
               (i32.load offset=8
                (local.get $1)
               )
              )
              (block $label$32
               (br_if $label$32
                (i32.lt_s
                 (local.get $0)
                 (i32.const -7)
                )
               )
               (local.set $0
                (i32.add
                 (local.get $0)
                 (i32.const 8)
                )
               )
               (loop $label$33
                (call $safe_printf
                 (i32.const 4290)
                 (i32.const 0)
                )
                (br_if $label$33
                 (local.tee $0
                  (i32.add
                   (local.get $0)
                   (i32.const -1)
                  )
                 )
                )
               )
              )
              (call $safe_printf
               (i32.const 6016)
               (i32.const 0)
              )
              (br $label$1)
             )
             (call $safe_printf
              (i32.const 6019)
              (i32.const 0)
             )
             (call $pretty_print_child
              (local.get $4)
              (i32.load offset=4
               (local.get $1)
              )
             )
             (call $pretty_print_child
              (local.get $4)
              (i32.load offset=8
               (local.get $1)
              )
             )
             (call $pretty_print_child
              (local.get $4)
              (i32.load offset=12
               (local.get $1)
              )
             )
             (block $label$34
              (br_if $label$34
               (i32.lt_s
                (local.get $0)
                (i32.const -7)
               )
              )
              (local.set $0
               (i32.add
                (local.get $0)
                (i32.const 8)
               )
              )
              (loop $label$35
               (call $safe_printf
                (i32.const 4290)
                (i32.const 0)
               )
               (br_if $label$35
                (local.tee $0
                 (i32.add
                  (local.get $0)
                  (i32.const -1)
                 )
                )
               )
              )
             )
             (call $safe_printf
              (i32.const 6016)
              (i32.const 0)
             )
             (br $label$1)
            )
            (block $label$36
             (block $label$37
              (br_if $label$37
               (i32.ge_u
                (local.tee $5
                 (i32.load offset=4
                  (local.get $1)
                 )
                )
                (i32.load
                 (i32.const 0)
                )
               )
              )
              (i32.store offset=112
               (local.get $2)
               (i32.add
                (i32.load
                 (i32.add
                  (i32.const 0)
                  (i32.shl
                   (local.get $5)
                   (i32.const 2)
                  )
                 )
                )
                (i32.const 5)
               )
              )
              (call $safe_printf
               (i32.const 4972)
               (i32.add
                (local.get $2)
                (i32.const 112)
               )
              )
              (br $label$36)
             )
             (block $label$38
              (block $label$39
               (block $label$40
                (br_table $label$40 $label$39 $label$38
                 (i32.add
                  (local.get $5)
                  (i32.const -81920002)
                 )
                )
               )
               (call $safe_printf
                (i32.const 5708)
                (i32.const 0)
               )
               (br $label$36)
              )
              (call $safe_printf
               (i32.const 5694)
               (i32.const 0)
              )
              (br $label$36)
             )
             (i32.store offset=128
              (local.get $2)
              (local.get $5)
             )
             (call $safe_printf
              (i32.const 5921)
              (i32.add
               (local.get $2)
               (i32.const 128)
              )
             )
            )
            (br_if $label$1
             (i32.eq
              (i32.and
               (i32.load
                (local.get $1)
               )
               (i32.const 268435455)
              )
              (i32.const 2)
             )
            )
            (local.set $7
             (select
              (local.get $4)
              (i32.const 1)
              (i32.gt_s
               (local.get $4)
               (i32.const 1)
              )
             )
            )
            (local.set $8
             (i32.add
              (local.get $1)
              (i32.const 8)
             )
            )
            (local.set $3
             (i32.lt_s
              (local.get $0)
              (i32.const 19)
             )
            )
            (local.set $9
             (i32.lt_s
              (local.get $0)
              (i32.const -1)
             )
            )
            (local.set $5
             (i32.const 0)
            )
            (loop $label$41
             (block $label$42
              (block $label$43
               (br_if $label$43
                (local.get $3)
               )
               (call $safe_printf
                (i32.const 5619)
                (i32.const 0)
               )
               (br $label$42)
              )
              (i32.store offset=96
               (local.get $2)
               (local.tee $6
                (i32.load
                 (i32.add
                  (local.get $8)
                  (i32.shl
                   (local.get $5)
                   (i32.const 2)
                  )
                 )
                )
               )
              )
              (call $safe_printf
               (i32.const 2058)
               (i32.add
                (local.get $2)
                (i32.const 96)
               )
              )
              (local.set $0
               (local.get $7)
              )
              (block $label$44
               (br_if $label$44
                (local.get $9)
               )
               (loop $label$45
                (call $safe_printf
                 (i32.const 4290)
                 (i32.const 0)
                )
                (br_if $label$45
                 (local.tee $0
                  (i32.add
                   (local.get $0)
                   (i32.const -1)
                  )
                 )
                )
               )
              )
              (call $Debug_prettyHelp
               (local.get $4)
               (local.get $6)
              )
             )
             (br_if $label$1
              (i32.gt_u
               (local.get $5)
               (i32.const 8)
              )
             )
             (br_if $label$41
              (i32.lt_u
               (local.tee $5
                (i32.add
                 (local.get $5)
                 (i32.const 1)
                )
               )
               (i32.add
                (i32.and
                 (i32.load
                  (local.get $1)
                 )
                 (i32.const 268435455)
                )
                (i32.const -2)
               )
              )
             )
             (br $label$1)
            )
           )
           (call $pretty_print_child
            (local.get $4)
            (i32.load offset=4
             (local.get $1)
            )
           )
           (call $safe_printf
            (i32.const 5625)
            (i32.const 0)
           )
           (br $label$9)
          )
          (i32.store offset=16
           (local.get $2)
           (local.get $6)
          )
          (i32.store offset=20
           (local.get $2)
           (i32.and
            (local.get $5)
            (i32.const 268435455)
           )
          )
          (call $safe_printf
           (i32.const 5565)
           (i32.add
            (local.get $2)
            (i32.const 16)
           )
          )
          (br $label$1)
         )
         (i32.store offset=432
          (local.get $2)
          (i32.load
           (i32.add
            (i32.shl
             (i32.load offset=4
              (local.get $1)
             )
             (i32.const 2)
            )
            (i32.const 7440)
           )
          )
         )
         (call $safe_printf
          (i32.const 4936)
          (i32.add
           (local.get $2)
           (i32.const 432)
          )
         )
         (i32.store offset=416
          (local.get $2)
          (i32.load offset=8
           (local.get $1)
          )
         )
         (call $safe_printf
          (i32.const 2058)
          (i32.add
           (local.get $2)
           (i32.const 416)
          )
         )
         (block $label$46
          (br_if $label$46
           (local.tee $6
            (i32.lt_s
             (local.get $0)
             (i32.const -1)
            )
           )
          )
          (local.set $5
           (local.get $4)
          )
          (loop $label$47
           (call $safe_printf
            (i32.const 4290)
            (i32.const 0)
           )
           (br_if $label$47
            (local.tee $5
             (i32.add
              (local.get $5)
              (i32.const -1)
             )
            )
           )
          )
         )
         (i32.store offset=400
          (local.get $2)
          (i32.const 2851)
         )
         (call $safe_printf
          (i32.const 4219)
          (i32.add
           (local.get $2)
           (i32.const 400)
          )
         )
         (call $Debug_prettyHelp
          (local.get $3)
          (i32.load offset=8
           (local.get $1)
          )
         )
         (i32.store offset=384
          (local.get $2)
          (i32.load offset=12
           (local.get $1)
          )
         )
         (call $safe_printf
          (i32.const 2058)
          (i32.add
           (local.get $2)
           (i32.const 384)
          )
         )
         (block $label$48
          (br_if $label$48
           (local.get $6)
          )
          (local.set $5
           (local.get $4)
          )
          (loop $label$49
           (call $safe_printf
            (i32.const 4290)
            (i32.const 0)
           )
           (br_if $label$49
            (local.tee $5
             (i32.add
              (local.get $5)
              (i32.const -1)
             )
            )
           )
          )
         )
         (i32.store offset=368
          (local.get $2)
          (i32.const 2419)
         )
         (call $safe_printf
          (i32.const 4219)
          (i32.add
           (local.get $2)
           (i32.const 368)
          )
         )
         (call $Debug_prettyHelp
          (local.get $3)
          (i32.load offset=12
           (local.get $1)
          )
         )
         (i32.store offset=352
          (local.get $2)
          (i32.load offset=16
           (local.get $1)
          )
         )
         (call $safe_printf
          (i32.const 2058)
          (i32.add
           (local.get $2)
           (i32.const 352)
          )
         )
         (block $label$50
          (br_if $label$50
           (local.tee $5
            (i32.lt_s
             (local.get $0)
             (i32.const -1)
            )
           )
          )
          (local.set $0
           (local.get $4)
          )
          (loop $label$51
           (call $safe_printf
            (i32.const 4290)
            (i32.const 0)
           )
           (br_if $label$51
            (local.tee $0
             (i32.add
              (local.get $0)
              (i32.const -1)
             )
            )
           )
          )
         )
         (i32.store offset=336
          (local.get $2)
          (i32.const 2305)
         )
         (call $safe_printf
          (i32.const 4219)
          (i32.add
           (local.get $2)
           (i32.const 336)
          )
         )
         (call $Debug_prettyHelp
          (local.get $3)
          (i32.load offset=16
           (local.get $1)
          )
         )
         (i32.store offset=320
          (local.get $2)
          (i32.load offset=20
           (local.get $1)
          )
         )
         (call $safe_printf
          (i32.const 2058)
          (i32.add
           (local.get $2)
           (i32.const 320)
          )
         )
         (block $label$52
          (br_if $label$52
           (local.get $5)
          )
          (loop $label$53
           (call $safe_printf
            (i32.const 4290)
            (i32.const 0)
           )
           (br_if $label$53
            (local.tee $4
             (i32.add
              (local.get $4)
              (i32.const -1)
             )
            )
           )
          )
         )
         (i32.store offset=304
          (local.get $2)
          (i32.const 2391)
         )
         (call $safe_printf
          (i32.const 4219)
          (i32.add
           (local.get $2)
           (i32.const 304)
          )
         )
         (call $Debug_prettyHelp
          (local.get $3)
          (i32.load offset=20
           (local.get $1)
          )
         )
         (br $label$1)
        )
        (local.set $5
         (i32.const 0)
        )
        (local.set $3
         (i32.const 0)
        )
        (block $label$54
         (br_if $label$54
          (i32.eqz
           (local.tee $6
            (i32.load offset=12
             (local.get $1)
            )
           )
          )
         )
         (local.set $3
          (i32.const 0)
         )
         (loop $label$55
          (local.set $3
           (i32.add
            (local.get $3)
            (i32.const 1)
           )
          )
          (br_if $label$55
           (local.tee $6
            (i32.load offset=12
             (local.get $6)
            )
           )
          )
         )
        )
        (block $label$56
         (br_if $label$56
          (i32.eq
           (local.tee $6
            (i32.load offset=16
             (local.get $1)
            )
           )
           (i32.const 8512)
          )
         )
         (local.set $5
          (i32.const 0)
         )
         (loop $label$57
          (local.set $5
           (i32.add
            (local.get $5)
            (i32.const 1)
           )
          )
          (br_if $label$57
           (i32.ne
            (local.tee $6
             (i32.load offset=8
              (local.get $6)
             )
            )
            (i32.const 8512)
           )
          )
         )
        )
        (local.set $6
         (i32.load offset=4
          (local.get $1)
         )
        )
        (i32.store offset=296
         (local.get $2)
         (local.get $5)
        )
        (i32.store offset=292
         (local.get $2)
         (local.get $3)
        )
        (i32.store offset=288
         (local.get $2)
         (local.get $6)
        )
        (call $safe_printf
         (i32.const 5518)
         (i32.add
          (local.get $2)
          (i32.const 288)
         )
        )
        (br_if $label$1
         (i32.eq
          (i32.and
           (i32.load
            (local.get $1)
           )
           (i32.const 268435455)
          )
          (i32.const 2)
         )
        )
        (local.set $7
         (select
          (local.get $4)
          (i32.const 1)
          (i32.gt_s
           (local.get $4)
           (i32.const 1)
          )
         )
        )
        (local.set $8
         (i32.add
          (local.get $1)
          (i32.const 8)
         )
        )
        (local.set $3
         (i32.lt_s
          (local.get $0)
          (i32.const 19)
         )
        )
        (local.set $9
         (i32.lt_s
          (local.get $0)
          (i32.const -1)
         )
        )
        (local.set $5
         (i32.const 0)
        )
        (loop $label$58
         (block $label$59
          (block $label$60
           (br_if $label$60
            (local.get $3)
           )
           (call $safe_printf
            (i32.const 5619)
            (i32.const 0)
           )
           (br $label$59)
          )
          (i32.store offset=272
           (local.get $2)
           (local.tee $6
            (i32.load
             (i32.add
              (local.get $8)
              (i32.shl
               (local.get $5)
               (i32.const 2)
              )
             )
            )
           )
          )
          (call $safe_printf
           (i32.const 2058)
           (i32.add
            (local.get $2)
            (i32.const 272)
           )
          )
          (local.set $0
           (local.get $7)
          )
          (block $label$61
           (br_if $label$61
            (local.get $9)
           )
           (loop $label$62
            (call $safe_printf
             (i32.const 4290)
             (i32.const 0)
            )
            (br_if $label$62
             (local.tee $0
              (i32.add
               (local.get $0)
               (i32.const -1)
              )
             )
            )
           )
          )
          (call $Debug_prettyHelp
           (local.get $4)
           (local.get $6)
          )
         )
         (br_if $label$1
          (i32.gt_u
           (local.get $5)
           (i32.const 8)
          )
         )
         (br_if $label$58
          (i32.lt_u
           (local.tee $5
            (i32.add
             (local.get $5)
             (i32.const 1)
            )
           )
           (i32.add
            (i32.and
             (i32.load
              (local.get $1)
             )
             (i32.const 268435455)
            )
            (i32.const -2)
           )
          )
         )
         (br $label$1)
        )
       )
       (i32.store offset=256
        (local.get $2)
        (i32.load offset=4
         (local.get $1)
        )
       )
       (call $safe_printf
        (i32.const 5412)
        (i32.add
         (local.get $2)
         (i32.const 256)
        )
       )
       (br $label$1)
      )
      (i32.store offset=240
       (local.get $2)
       (call $Debug_evaluator_name
        (i32.load offset=8
         (local.get $1)
        )
       )
      )
      (call $safe_printf
       (i32.const 4945)
       (i32.add
        (local.get $2)
        (i32.const 240)
       )
      )
      (br_if $label$1
       (i32.eqz
        (i32.load16_u offset=4
         (local.get $1)
        )
       )
      )
      (local.set $7
       (select
        (local.get $4)
        (i32.const 1)
        (i32.gt_s
         (local.get $4)
         (i32.const 1)
        )
       )
      )
      (local.set $8
       (i32.add
        (local.get $1)
        (i32.const 12)
       )
      )
      (local.set $3
       (i32.lt_s
        (local.get $0)
        (i32.const 19)
       )
      )
      (local.set $9
       (i32.lt_s
        (local.get $0)
        (i32.const -1)
       )
      )
      (local.set $5
       (i32.const 0)
      )
      (loop $label$63
       (block $label$64
        (block $label$65
         (br_if $label$65
          (local.get $3)
         )
         (call $safe_printf
          (i32.const 5619)
          (i32.const 0)
         )
         (br $label$64)
        )
        (i32.store offset=224
         (local.get $2)
         (local.tee $6
          (i32.load
           (i32.add
            (local.get $8)
            (i32.shl
             (local.get $5)
             (i32.const 2)
            )
           )
          )
         )
        )
        (call $safe_printf
         (i32.const 2058)
         (i32.add
          (local.get $2)
          (i32.const 224)
         )
        )
        (local.set $0
         (local.get $7)
        )
        (block $label$66
         (br_if $label$66
          (local.get $9)
         )
         (loop $label$67
          (call $safe_printf
           (i32.const 4290)
           (i32.const 0)
          )
          (br_if $label$67
           (local.tee $0
            (i32.add
             (local.get $0)
             (i32.const -1)
            )
           )
          )
         )
        )
        (call $Debug_prettyHelp
         (local.get $4)
         (local.get $6)
        )
       )
       (br_if $label$1
        (i32.gt_u
         (local.get $5)
         (i32.const 8)
        )
       )
       (br_if $label$63
        (i32.lt_u
         (local.tee $5
          (i32.add
           (local.get $5)
           (i32.const 1)
          )
         )
         (i32.load16_u offset=4
          (local.get $1)
         )
        )
       )
       (br $label$1)
      )
     )
     (call $safe_printf
      (i32.const 4996)
      (i32.const 0)
     )
     (br_if $label$1
      (i32.eqz
       (local.tee $5
        (i32.load offset=4
         (local.get $1)
        )
       )
      )
     )
     (local.set $3
      (select
       (local.tee $5
        (i32.add
         (local.get $5)
         (i32.const -1)
        )
       )
       (i32.const 9)
       (i32.lt_u
        (local.get $5)
        (i32.const 9)
       )
      )
     )
     (local.set $6
      (i32.add
       (local.get $1)
       (i32.const 8)
      )
     )
     (local.set $5
      (i32.const 0)
     )
     (loop $label$68
      (block $label$69
       (br_if $label$69
        (i32.lt_s
         (local.get $0)
         (i32.const -1)
        )
       )
       (local.set $1
        (local.get $4)
       )
       (loop $label$70
        (call $safe_printf
         (i32.const 4290)
         (i32.const 0)
        )
        (br_if $label$70
         (local.tee $1
          (i32.add
           (local.get $1)
           (i32.const -1)
          )
         )
        )
       )
      )
      (block $label$71
       (block $label$72
        (br_if $label$72
         (i32.ge_u
          (local.tee $1
           (i32.load
            (i32.add
             (local.get $6)
             (i32.shl
              (local.get $5)
              (i32.const 2)
             )
            )
           )
          )
          (i32.load
           (i32.const 0)
          )
         )
        )
        (i32.store offset=192
         (local.get $2)
         (i32.add
          (i32.load
           (i32.add
            (i32.const 0)
            (i32.shl
             (local.get $1)
             (i32.const 2)
            )
           )
          )
          (i32.const 6)
         )
        )
        (call $safe_printf
         (i32.const 4972)
         (i32.add
          (local.get $2)
          (i32.const 192)
         )
        )
        (br $label$71)
       )
       (i32.store offset=208
        (local.get $2)
        (local.get $1)
       )
       (call $safe_printf
        (i32.const 5589)
        (i32.add
         (local.get $2)
         (i32.const 208)
        )
       )
      )
      (local.set $1
       (i32.eq
        (local.get $5)
        (local.get $3)
       )
      )
      (local.set $5
       (i32.add
        (local.get $5)
        (i32.const 1)
       )
      )
      (br_if $label$68
       (i32.eqz
        (local.get $1)
       )
      )
      (br $label$1)
     )
    )
    (call $safe_printf
     (i32.const 4776)
     (i32.const 0)
    )
    (block $label$73
     (br_if $label$73
      (i32.eq
       (local.tee $5
        (i32.and
         (i32.load
          (local.get $1)
         )
         (i32.const 268435455)
        )
       )
       (i32.const 2)
      )
     )
     (local.set $8
      (i32.load offset=4
       (local.get $1)
      )
     )
     (local.set $9
      (select
       (local.tee $5
        (i32.add
         (local.get $5)
         (i32.const -3)
        )
       )
       (i32.const 9)
       (i32.lt_u
        (local.get $5)
        (i32.const 9)
       )
      )
     )
     (local.set $10
      (i32.add
       (local.get $1)
       (i32.const 8)
      )
     )
     (local.set $11
      (i32.lt_s
       (local.get $0)
       (i32.const -1)
      )
     )
     (local.set $5
      (i32.const 0)
     )
     (loop $label$74
      (i32.store offset=176
       (local.get $2)
       (local.tee $7
        (i32.load
         (i32.add
          (local.get $10)
          (local.tee $6
           (i32.shl
            (local.get $5)
            (i32.const 2)
           )
          )
         )
        )
       )
      )
      (call $safe_printf
       (i32.const 2058)
       (i32.add
        (local.get $2)
        (i32.const 176)
       )
      )
      (block $label$75
       (br_if $label$75
        (local.get $11)
       )
       (local.set $1
        (local.get $4)
       )
       (loop $label$76
        (call $safe_printf
         (i32.const 4290)
         (i32.const 0)
        )
        (br_if $label$76
         (local.tee $1
          (i32.add
           (local.get $1)
           (i32.const -1)
          )
         )
        )
       )
      )
      (block $label$77
       (block $label$78
        (br_if $label$78
         (i32.ge_u
          (local.tee $1
           (i32.load
            (i32.add
             (i32.add
              (local.get $8)
              (local.get $6)
             )
             (i32.const 8)
            )
           )
          )
          (i32.load
           (i32.const 0)
          )
         )
        )
        (i32.store offset=144
         (local.get $2)
         (i32.add
          (i32.load
           (i32.add
            (i32.const 0)
            (i32.shl
             (local.get $1)
             (i32.const 2)
            )
           )
          )
          (i32.const 6)
         )
        )
        (call $safe_printf
         (i32.const 4219)
         (i32.add
          (local.get $2)
          (i32.const 144)
         )
        )
        (br $label$77)
       )
       (i32.store offset=160
        (local.get $2)
        (local.get $1)
       )
       (call $safe_printf
        (i32.const 4225)
        (i32.add
         (local.get $2)
         (i32.const 160)
        )
       )
      )
      (call $Debug_prettyHelp
       (local.get $3)
       (local.get $7)
      )
      (local.set $1
       (i32.eq
        (local.get $5)
        (local.get $9)
       )
      )
      (local.set $5
       (i32.add
        (local.get $5)
        (i32.const 1)
       )
      )
      (br_if $label$74
       (i32.eqz
        (local.get $1)
       )
      )
     )
    )
    (block $label$79
     (br_if $label$79
      (i32.lt_s
       (local.get $0)
       (i32.const -7)
      )
     )
     (local.set $0
      (i32.add
       (local.get $0)
       (i32.const 8)
      )
     )
     (loop $label$80
      (call $safe_printf
       (i32.const 4290)
       (i32.const 0)
      )
      (br_if $label$80
       (local.tee $0
        (i32.add
         (local.get $0)
         (i32.const -1)
        )
       )
      )
     )
    )
    (call $safe_printf
     (i32.const 4723)
     (i32.const 0)
    )
    (br $label$1)
   )
   (block $label$81
    (br_if $label$81
     (i32.lt_s
      (local.get $0)
      (i32.const -7)
     )
    )
    (local.set $0
     (i32.add
      (local.get $0)
      (i32.const 8)
     )
    )
    (loop $label$82
     (call $safe_printf
      (i32.const 4290)
      (i32.const 0)
     )
     (br_if $label$82
      (local.tee $0
       (i32.add
        (local.get $0)
        (i32.const -1)
       )
      )
     )
    )
   )
   (call $safe_printf
    (i32.const 5594)
    (i32.const 0)
   )
  )
  (global.set $__stack_pointer
   (i32.add
    (local.get $2)
    (i32.const 560)
   )
  )
 )
 (func $newRecord (param $0 i32) (param $1 i32) (param $2 i32) (result i32)
  (local $3 i32)
  (local $4 i32)
  (local $5 i32)
  (local $6 i32)
  (local $7 i32)
  (i32.store offset=4
   (local.tee $4
    (call $GC_allocate
     (i32.const 1)
     (i32.and
      (local.tee $3
       (i32.add
        (local.get $1)
        (i32.const 2)
       )
      )
      (i32.const 1073741823)
     )
    )
   )
   (local.get $0)
  )
  (i32.store
   (local.get $4)
   (i32.or
    (i32.and
     (local.get $3)
     (i32.const 268435455)
    )
    (i32.const -2147483648)
   )
  )
  (block $label$1
   (br_if $label$1
    (i32.eqz
     (local.get $1)
    )
   )
   (local.set $5
    (i32.and
     (local.get $1)
     (i32.const 3)
    )
   )
   (local.set $6
    (i32.const 0)
   )
   (block $label$2
    (br_if $label$2
     (i32.lt_u
      (i32.add
       (local.get $1)
       (i32.const -1)
      )
      (i32.const 3)
     )
    )
    (local.set $7
     (i32.and
      (local.get $1)
      (i32.const -4)
     )
    )
    (local.set $1
     (i32.const 0)
    )
    (local.set $6
     (i32.const 0)
    )
    (loop $label$3
     (i32.store
      (i32.add
       (local.tee $0
        (i32.add
         (local.get $4)
         (local.get $1)
        )
       )
       (i32.const 8)
      )
      (i32.load
       (local.tee $3
        (i32.add
         (local.get $2)
         (local.get $1)
        )
       )
      )
     )
     (i32.store
      (i32.add
       (local.get $0)
       (i32.const 12)
      )
      (i32.load
       (i32.add
        (local.get $3)
        (i32.const 4)
       )
      )
     )
     (i32.store
      (i32.add
       (local.get $0)
       (i32.const 16)
      )
      (i32.load
       (i32.add
        (local.get $3)
        (i32.const 8)
       )
      )
     )
     (i32.store
      (i32.add
       (local.get $0)
       (i32.const 20)
      )
      (i32.load
       (i32.add
        (local.get $3)
        (i32.const 12)
       )
      )
     )
     (local.set $1
      (i32.add
       (local.get $1)
       (i32.const 16)
      )
     )
     (br_if $label$3
      (i32.ne
       (local.get $7)
       (local.tee $6
        (i32.add
         (local.get $6)
         (i32.const 4)
        )
       )
      )
     )
    )
   )
   (br_if $label$1
    (i32.eqz
     (local.get $5)
    )
   )
   (local.set $1
    (i32.add
     (local.get $2)
     (local.tee $0
      (i32.shl
       (local.get $6)
       (i32.const 2)
      )
     )
    )
   )
   (local.set $0
    (i32.add
     (i32.add
      (local.get $0)
      (local.get $4)
     )
     (i32.const 8)
    )
   )
   (loop $label$4
    (i32.store
     (local.get $0)
     (i32.load
      (local.get $1)
     )
    )
    (local.set $1
     (i32.add
      (local.get $1)
      (i32.const 4)
     )
    )
    (local.set $0
     (i32.add
      (local.get $0)
      (i32.const 4)
     )
    )
    (br_if $label$4
     (local.tee $5
      (i32.add
       (local.get $5)
       (i32.const -1)
      )
     )
    )
   )
  )
  (local.get $4)
 )
 (func $Utils_destruct_index (param $0 i32) (param $1 i32) (result i32)
  (block $label$1
   (block $label$2
    (block $label$3
     (block $label$4
      (block $label$5
       (br_table $label$4 $label$3 $label$2 $label$5 $label$2
        (i32.add
         (i32.shr_u
          (i32.load
           (local.get $0)
          )
          (i32.const 28)
         )
         (i32.const -4)
        )
       )
      )
      (local.set $0
       (i32.add
        (local.get $0)
        (i32.const 8)
       )
      )
      (br $label$1)
     )
     (local.set $0
      (i32.add
       (local.get $0)
       (i32.const 4)
      )
     )
     (br $label$1)
    )
    (local.set $0
     (i32.add
      (local.get $0)
      (i32.const 4)
     )
    )
    (br $label$1)
   )
   (local.set $0
    (i32.add
     (local.get $0)
     (i32.const 4)
    )
   )
  )
  (i32.load
   (i32.add
    (local.get $0)
    (i32.shl
     (local.get $1)
     (i32.const 2)
    )
   )
  )
 )
 (func $Utils_access_eval (param $0 i32) (result i32)
  (local $1 i32)
  (local $2 i32)
  (local $3 i32)
  (local $4 i32)
  (local $5 i32)
  (local $6 i32)
  (local $7 i32)
  (global.set $__stack_pointer
   (local.tee $1
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 64)
    )
   )
  )
  (local.set $2
   (i32.load
    (local.get $0)
   )
  )
  (block $label$1
   (br_if $label$1
    (i32.ne
     (i32.and
      (i32.load
       (local.tee $3
        (i32.load offset=4
         (local.get $0)
        )
       )
      )
      (i32.const -268435456)
     )
     (i32.const -1342177280)
    )
   )
   (local.set $3
    (call $jsRefToWasmRecord
     (i32.load offset=4
      (local.get $3)
     )
    )
   )
  )
  (block $label$2
   (br_if $label$2
    (i32.eq
     (local.tee $0
      (i32.shr_u
       (i32.load
        (local.get $3)
       )
       (i32.const 28)
      )
     )
     (i32.const 8)
    )
   )
   (i32.store offset=56
    (local.get $1)
    (i32.const 73)
   )
   (i32.store offset=52
    (local.get $1)
    (i32.const 3382)
   )
   (i32.store offset=48
    (local.get $1)
    (i32.const 2364)
   )
   (call $safe_printf
    (i32.const 5317)
    (i32.add
     (local.get $1)
     (i32.const 48)
    )
   )
   (i64.store offset=40
    (local.get $1)
    (i64.extend_i32_u
     (local.get $0)
    )
   )
   (i32.store offset=32
    (local.get $1)
    (i32.const 2596)
   )
   (call $safe_printf
    (i32.const 4798)
    (i32.add
     (local.get $1)
     (i32.const 32)
    )
   )
   (i64.store offset=24
    (local.get $1)
    (i64.const 8)
   )
   (i32.store offset=16
    (local.get $1)
    (i32.const 3063)
   )
   (call $safe_printf
    (i32.const 4798)
    (i32.add
     (local.get $1)
     (i32.const 16)
    )
   )
   (call $abort)
  )
  (local.set $5
   (i32.add
    (i32.load offset=4
     (local.tee $4
      (i32.load offset=4
       (local.get $3)
      )
     )
    )
    (i32.const -1)
   )
  )
  (local.set $6
   (i32.const 0)
  )
  (block $label$3
   (loop $label$4
    (br_if $label$3
     (i32.eq
      (local.tee $7
       (i32.load
        (i32.add
         (i32.add
          (local.get $4)
          (i32.shl
           (local.tee $0
            (i32.shr_u
             (i32.add
              (local.get $5)
              (local.get $6)
             )
             (i32.const 1)
            )
           )
           (i32.const 2)
          )
         )
         (i32.const 8)
        )
       )
      )
      (local.get $2)
     )
    )
    (br_if $label$4
     (i32.le_u
      (local.tee $6
       (select
        (i32.add
         (local.get $0)
         (i32.const 1)
        )
        (local.get $6)
        (local.tee $7
         (i32.lt_u
          (local.get $7)
          (local.get $2)
         )
        )
       )
      )
      (local.tee $5
       (select
        (local.get $5)
        (i32.add
         (local.get $0)
         (i32.const -1)
        )
        (local.get $7)
       )
      )
     )
    )
   )
   (i32.store offset=4
    (local.get $1)
    (local.get $3)
   )
   (i32.store
    (local.get $1)
    (local.get $2)
   )
   (call $log_error
    (i32.const 5008)
    (local.get $1)
   )
   (local.set $0
    (i32.const -1)
   )
  )
  (local.set $0
   (i32.load
    (i32.add
     (i32.add
      (local.get $3)
      (i32.shl
       (local.get $0)
       (i32.const 2)
      )
     )
     (i32.const 8)
    )
   )
  )
  (global.set $__stack_pointer
   (i32.add
    (local.get $1)
    (i32.const 64)
   )
  )
  (local.get $0)
 )
 (func $Utils_update (param $0 i32) (param $1 i32) (param $2 i32) (param $3 i32) (result i32)
  (local $4 i32)
  (local $5 i32)
  (local $6 i32)
  (local $7 i32)
  (local $8 i32)
  (local $9 i32)
  (local $10 i32)
  (local $11 i32)
  (local $12 i32)
  (local $13 i32)
  (local $14 i32)
  (global.set $__stack_pointer
   (local.tee $4
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 16)
    )
   )
  )
  (block $label$1
   (br_if $label$1
    (i32.ne
     (i32.and
      (i32.load
       (local.get $0)
      )
      (i32.const -268435456)
     )
     (i32.const -1342177280)
    )
   )
   (local.set $0
    (call $jsRefToWasmRecord
     (i32.load offset=4
      (local.get $0)
     )
    )
   )
  )
  (block $label$2
   (br_if $label$2
    (i32.eq
     (i32.load offset=7844
      (i32.const 0)
     )
     (local.get $0)
    )
   )
   (br_if $label$2
    (i32.eq
     (local.tee $5
      (i32.load
       (local.get $0)
      )
     )
     (i32.const 1879048194)
    )
   )
   (local.set $6
    (call $GC_allocate
     (i32.const 1)
     (i32.and
      (local.get $5)
      (i32.const 268435455)
     )
    )
   )
   (local.set $7
    (i32.and
     (i32.shl
      (local.tee $5
       (i32.load
        (local.get $0)
       )
      )
      (i32.const 2)
     )
     (i32.const 1073741820)
    )
   )
   (block $label$3
    (block $label$4
     (br_if $label$4
      (i32.and
       (local.get $6)
       (i32.const 7)
      )
     )
     (local.set $8
      (local.get $6)
     )
     (br $label$3)
    )
    (i32.store
     (local.get $6)
     (local.get $5)
    )
    (local.set $8
     (i32.add
      (local.get $6)
      (i32.const 4)
     )
    )
    (local.set $0
     (i32.add
      (local.get $0)
      (i32.const 4)
     )
    )
    (local.set $7
     (i32.add
      (local.get $7)
      (i32.const -4)
     )
    )
   )
   (local.set $9
    (i32.const 0)
   )
   (block $label$5
    (br_if $label$5
     (i32.lt_u
      (local.get $7)
      (i32.const 8)
     )
    )
    (local.set $10
     (i32.and
      (local.tee $9
       (i32.shr_u
        (local.get $7)
        (i32.const 3)
       )
      )
      (i32.const 3)
     )
    )
    (local.set $11
     (i32.const 0)
    )
    (block $label$6
     (br_if $label$6
      (i32.lt_u
       (i32.add
        (local.get $9)
        (i32.const -1)
       )
       (i32.const 3)
      )
     )
     (local.set $12
      (i32.and
       (local.get $9)
       (i32.const 536870908)
      )
     )
     (local.set $5
      (i32.const 0)
     )
     (local.set $11
      (i32.const 0)
     )
     (loop $label$7
      (i64.store
       (local.tee $13
        (i32.add
         (local.get $8)
         (local.get $5)
        )
       )
       (i64.load
        (local.tee $14
         (i32.add
          (local.get $0)
          (local.get $5)
         )
        )
       )
      )
      (i64.store
       (i32.add
        (local.get $13)
        (i32.const 8)
       )
       (i64.load
        (i32.add
         (local.get $14)
         (i32.const 8)
        )
       )
      )
      (i64.store
       (i32.add
        (local.get $13)
        (i32.const 16)
       )
       (i64.load
        (i32.add
         (local.get $14)
         (i32.const 16)
        )
       )
      )
      (i64.store
       (i32.add
        (local.get $13)
        (i32.const 24)
       )
       (i64.load
        (i32.add
         (local.get $14)
         (i32.const 24)
        )
       )
      )
      (local.set $5
       (i32.add
        (local.get $5)
        (i32.const 32)
       )
      )
      (br_if $label$7
       (i32.ne
        (local.get $12)
        (local.tee $11
         (i32.add
          (local.get $11)
          (i32.const 4)
         )
        )
       )
      )
     )
    )
    (br_if $label$5
     (i32.eqz
      (local.get $10)
     )
    )
    (local.set $5
     (i32.add
      (local.get $0)
      (local.tee $13
       (i32.shl
        (local.get $11)
        (i32.const 3)
       )
      )
     )
    )
    (local.set $13
     (i32.add
      (local.get $8)
      (local.get $13)
     )
    )
    (loop $label$8
     (i64.store
      (local.get $13)
      (i64.load
       (local.get $5)
      )
     )
     (local.set $5
      (i32.add
       (local.get $5)
       (i32.const 8)
      )
     )
     (local.set $13
      (i32.add
       (local.get $13)
       (i32.const 8)
      )
     )
     (br_if $label$8
      (local.tee $10
       (i32.add
        (local.get $10)
        (i32.const -1)
       )
      )
     )
    )
   )
   (block $label$9
    (br_if $label$9
     (i32.eqz
      (i32.and
       (local.get $7)
       (i32.const 7)
      )
     )
    )
    (i32.store
     (i32.add
      (local.get $8)
      (local.tee $5
       (i32.shl
        (local.get $9)
        (i32.const 3)
       )
      )
     )
     (i32.load
      (i32.add
       (local.get $0)
       (local.get $5)
      )
     )
    )
   )
   (local.set $0
    (local.get $6)
   )
  )
  (block $label$10
   (br_if $label$10
    (i32.eqz
     (local.get $1)
    )
   )
   (local.set $6
    (i32.add
     (local.get $0)
     (i32.const 8)
    )
   )
   (local.set $12
    (i32.const 0)
   )
   (loop $label$11
    (local.set $13
     (i32.add
      (i32.load offset=4
       (local.tee $8
        (i32.load offset=4
         (local.get $0)
        )
       )
      )
      (i32.const -1)
     )
    )
    (local.set $10
     (i32.load
      (i32.add
       (local.get $2)
       (local.tee $7
        (i32.shl
         (local.get $12)
         (i32.const 2)
        )
       )
      )
     )
    )
    (local.set $14
     (i32.const 0)
    )
    (block $label$12
     (loop $label$13
      (br_if $label$12
       (i32.eq
        (local.tee $11
         (i32.load
          (i32.add
           (i32.add
            (local.get $8)
            (i32.shl
             (local.tee $5
              (i32.shr_u
               (i32.add
                (local.get $13)
                (local.get $14)
               )
               (i32.const 1)
              )
             )
             (i32.const 2)
            )
           )
           (i32.const 8)
          )
         )
        )
        (local.get $10)
       )
      )
      (br_if $label$13
       (i32.le_u
        (local.tee $14
         (select
          (i32.add
           (local.get $5)
           (i32.const 1)
          )
          (local.get $14)
          (local.tee $11
           (i32.lt_u
            (local.get $11)
            (local.get $10)
           )
          )
         )
        )
        (local.tee $13
         (select
          (local.get $13)
          (i32.add
           (local.get $5)
           (i32.const -1)
          )
          (local.get $11)
         )
        )
       )
      )
     )
     (i32.store offset=4
      (local.get $4)
      (local.get $0)
     )
     (i32.store
      (local.get $4)
      (local.get $10)
     )
     (call $log_error
      (i32.const 5056)
      (local.get $4)
     )
     (local.set $5
      (i32.const -1)
     )
    )
    (i32.store
     (i32.add
      (local.get $6)
      (i32.shl
       (local.get $5)
       (i32.const 2)
      )
     )
     (i32.load
      (i32.add
       (local.get $3)
       (local.get $7)
      )
     )
    )
    (br_if $label$11
     (i32.ne
      (local.tee $12
       (i32.add
        (local.get $12)
        (i32.const 1)
       )
      )
      (local.get $1)
     )
    )
   )
  )
  (global.set $__stack_pointer
   (i32.add
    (local.get $4)
    (i32.const 16)
   )
  )
  (local.get $0)
 )
 (func $eval_Utils_append (param $0 i32) (result i32)
  (local $1 i32)
  (local $2 i32)
  (local $3 i32)
  (block $label$1
   (block $label$2
    (br_if $label$2
     (i32.ne
      (i32.and
       (i32.load
        (local.tee $1
         (i32.load
          (local.get $0)
         )
        )
       )
       (i32.const -268435456)
      )
      (i32.const 1073741824)
     )
    )
    (local.set $2
     (i32.load offset=4
      (local.get $0)
     )
    )
    (block $label$3
     (br_if $label$3
      (i32.ne
       (local.get $1)
       (i32.const 8512)
      )
     )
     (return
      (local.get $2)
     )
    )
    (br_if $label$1
     (i32.eq
      (local.get $2)
      (i32.const 8512)
     )
    )
    (local.set $3
     (local.get $1)
    )
    (loop $label$4
     (i32.store offset=8
      (local.tee $0
       (call $GC_allocate
        (i32.const 1)
        (i32.const 3)
       )
      )
      (local.get $2)
     )
     (i64.store align=4
      (local.get $0)
      (i64.const 1073741827)
     )
     (local.set $2
      (local.get $0)
     )
     (br_if $label$4
      (i32.ne
       (local.tee $3
        (i32.load offset=8
         (local.get $3)
        )
       )
       (i32.const 8512)
      )
     )
    )
    (local.set $2
     (local.get $0)
    )
    (loop $label$5
     (i32.store offset=4
      (local.get $2)
      (i32.load offset=4
       (local.get $1)
      )
     )
     (local.set $2
      (i32.load offset=8
       (local.get $2)
      )
     )
     (br_if $label$5
      (i32.ne
       (local.tee $1
        (i32.load offset=8
         (local.get $1)
        )
       )
       (i32.const 8512)
      )
     )
    )
    (return
     (local.get $0)
    )
   )
   (local.set $1
    (call $eval_String_append
     (local.get $0)
    )
   )
  )
  (local.get $1)
 )
 (func $GC_stack_push_frame (param $0 i32) (param $1 i32) (result i32)
  (local $2 i32)
  (local $3 i32)
  (local.set $2
   (i32.load16_u offset=8792
    (i32.const 0)
   )
  )
  (i32.store16 offset=8792
   (i32.const 0)
   (local.tee $3
    (i32.load16_u offset=8794
     (i32.const 0)
    )
   )
  )
  (i32.store8
   (i32.add
    (local.get $3)
    (i32.const 49760)
   )
   (i32.const 70)
  )
  (i32.store16 offset=8794
   (i32.const 0)
   (i32.add
    (local.get $3)
    (i32.const 2)
   )
  )
  (i32.store
   (i32.add
    (i32.shl
     (local.get $3)
     (i32.const 2)
    )
    (i32.const 8800)
   )
   (local.get $2)
  )
  (i32.store8
   (i32.add
    (local.tee $2
     (i32.and
      (i32.add
       (local.get $3)
       (i32.const 1)
      )
      (i32.const 65535)
     )
    )
    (i32.const 49760)
   )
   (local.get $0)
  )
  (i32.store
   (i32.add
    (i32.shl
     (local.get $2)
     (i32.const 2)
    )
    (i32.const 8800)
   )
   (local.get $1)
  )
  (local.get $3)
 )
 (func $Debug_assert_sanity (param $0 i32) (param $1 i32) (param $2 i32) (param $3 i32) (param $4 i32)
  (local $5 i32)
  (local $6 i32)
  (global.set $__stack_pointer
   (local.tee $5
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 16)
    )
   )
  )
  (block $label$1
   (br_if $label$1
    (i32.eqz
     (local.get $4)
    )
   )
   (block $label$2
    (block $label$3
     (block $label$4
      (block $label$5
       (block $label$6
        (block $label$7
         (block $label$8
          (block $label$9
           (block $label$10
            (block $label$11
             (block $label$12
              (block $label$13
               (block $label$14
                (block $label$15
                 (block $label$16
                  (br_table $label$3 $label$16 $label$15 $label$14 $label$13 $label$12 $label$11 $label$10 $label$9 $label$8 $label$7 $label$6 $label$5 $label$4 $label$2
                   (i32.shr_u
                    (local.tee $6
                     (i32.load
                      (local.get $4)
                     )
                    )
                    (i32.const 28)
                   )
                  )
                 )
                 (br_if $label$2
                  (i32.ne
                   (i32.and
                    (local.get $6)
                    (i32.const 268435455)
                   )
                   (i32.const 4)
                  )
                 )
                 (br $label$1)
                )
                (br_if $label$2
                 (i32.ne
                  (i32.and
                   (local.get $6)
                   (i32.const 268435455)
                  )
                  (i32.const 2)
                 )
                )
                (br $label$1)
               )
               (br_if $label$2
                (i32.and
                 (local.get $6)
                 (i32.const 268419072)
                )
               )
               (br $label$1)
              )
              (br_if $label$2
               (i32.ne
                (i32.and
                 (local.get $6)
                 (i32.const 268435455)
                )
                (i32.const 3)
               )
              )
              (br $label$1)
             )
             (br_if $label$2
              (i32.ne
               (i32.and
                (local.get $6)
                (i32.const 268435455)
               )
               (i32.const 3)
              )
             )
             (br $label$1)
            )
            (br_if $label$2
             (i32.ne
              (i32.and
               (local.get $6)
               (i32.const 268435455)
              )
              (i32.const 4)
             )
            )
            (br $label$1)
           )
           (br_if $label$2
            (i32.ge_u
             (i32.add
              (i32.and
               (local.get $6)
               (i32.const 268435455)
              )
              (i32.const -2)
             )
             (i32.const 512)
            )
           )
           (br $label$1)
          )
          (br_if $label$2
           (i32.ge_u
            (i32.add
             (i32.and
              (local.get $6)
              (i32.const 268435455)
             )
             (i32.const -2)
            )
            (i32.const 512)
           )
          )
          (br $label$1)
         )
         (br_if $label$2
          (i32.ge_u
           (i32.add
            (i32.and
             (local.get $6)
             (i32.const 268435455)
            )
            (i32.const -2)
           )
           (i32.const 512)
          )
         )
         (br $label$1)
        )
        (br_if $label$2
         (i32.ge_u
          (i32.add
           (i32.and
            (local.get $6)
            (i32.const 268435455)
           )
           (i32.const -3)
          )
          (i32.const 512)
         )
        )
        (br $label$1)
       )
       (br_if $label$2
        (i32.ne
         (i32.and
          (local.get $6)
          (i32.const 268435455)
         )
         (i32.const 2)
        )
       )
       (br $label$1)
      )
      (br_if $label$2
       (i32.ne
        (i32.and
         (local.get $6)
         (i32.const 268435455)
        )
        (i32.const 6)
       )
      )
      (br $label$1)
     )
     (br_if $label$2
      (i32.ne
       (i32.and
        (local.get $6)
        (i32.const 268435455)
       )
       (i32.const 6)
      )
     )
     (br $label$1)
    )
    (br_if $label$1
     (i32.eq
      (i32.and
       (local.get $6)
       (i32.const 268435455)
      )
      (i32.const 4)
     )
    )
   )
   (i32.store offset=12
    (local.get $5)
    (local.get $1)
   )
   (i32.store offset=8
    (local.get $5)
    (local.get $0)
   )
   (i32.store offset=4
    (local.get $5)
    (local.get $2)
   )
   (i32.store
    (local.get $5)
    (local.get $3)
   )
   (call $safe_printf
    (i32.const 5356)
    (local.get $5)
   )
   (call $print_heap_range
    (local.get $4)
    (i32.add
     (local.get $4)
     (i32.shl
      (select
       (local.tee $6
        (select
         (local.tee $6
          (i32.and
           (local.get $6)
           (i32.const 268435455)
          )
         )
         (i32.const 4)
         (i32.gt_u
          (local.get $6)
          (i32.const 4)
         )
        )
       )
       (i32.const 16)
       (i32.lt_u
        (local.get $6)
        (i32.const 16)
       )
      )
      (i32.const 2)
     )
    )
   )
   (call $safe_printf
    (i32.const 6063)
    (i32.const 0)
   )
   (call $abort)
  )
  (global.set $__stack_pointer
   (i32.add
    (local.get $5)
    (i32.const 16)
   )
  )
 )
 (func $eq_eval (param $0 i32) (result i32)
  (local $1 i32)
  (local $2 i32)
  (global.set $__stack_pointer
   (local.tee $1
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 16)
    )
   )
  )
  (i32.store offset=12
   (local.get $1)
   (i32.const 8512)
  )
  (local.set $2
   (i32.ne
    (local.tee $0
     (call $eq_help
      (i32.load
       (local.get $0)
      )
      (i32.load offset=4
       (local.get $0)
      )
      (i32.const 0)
      (i32.add
       (local.get $1)
       (i32.const 12)
      )
     )
    )
    (i32.const 0)
   )
  )
  (block $label$1
   (br_if $label$1
    (i32.eqz
     (local.get $0)
    )
   )
   (br_if $label$1
    (i32.eq
     (local.tee $0
      (i32.load offset=12
       (local.get $1)
      )
     )
     (i32.const 8512)
    )
   )
   (loop $label$2
    (i32.store offset=12
     (local.get $1)
     (i32.load offset=8
      (local.get $0)
     )
    )
    (local.set $2
     (i32.ne
      (local.tee $0
       (call $eq_help
        (i32.load offset=4
         (local.tee $0
          (i32.load offset=4
           (local.get $0)
          )
         )
        )
        (i32.load offset=8
         (local.get $0)
        )
        (i32.const 0)
        (i32.add
         (local.get $1)
         (i32.const 12)
        )
       )
      )
      (i32.const 0)
     )
    )
    (br_if $label$1
     (i32.eqz
      (local.get $0)
     )
    )
    (br_if $label$2
     (i32.ne
      (local.tee $0
       (i32.load offset=12
        (local.get $1)
       )
      )
      (i32.const 8512)
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
  (select
   (i32.const 8532)
   (i32.const 8540)
   (local.get $2)
  )
 )
 (func $eq_help (param $0 i32) (param $1 i32) (param $2 i32) (param $3 i32) (result i32)
  (local $4 i32)
  (local $5 i32)
  (local $6 i32)
  (local $7 i32)
  (local $8 i32)
  (local $9 i32)
  (block $label$1
   (br_if $label$1
    (i32.lt_u
     (local.get $2)
     (i32.const 101)
    )
   )
   (i32.store offset=8
    (local.tee $2
     (call $GC_allocate
      (i32.const 1)
      (i32.const 3)
     )
    )
    (local.get $1)
   )
   (i32.store offset=4
    (local.get $2)
    (local.get $0)
   )
   (i32.store
    (local.get $2)
    (i32.const 1342177283)
   )
   (local.set $1
    (i32.load
     (local.get $3)
    )
   )
   (i32.store offset=8
    (local.tee $0
     (call $GC_allocate
      (i32.const 1)
      (i32.const 3)
     )
    )
    (local.get $1)
   )
   (i32.store offset=4
    (local.get $0)
    (local.get $2)
   )
   (i32.store
    (local.get $0)
    (i32.const 1073741827)
   )
   (i32.store
    (local.get $3)
    (local.get $0)
   )
   (return
    (i32.const 1)
   )
  )
  (local.set $4
   (i32.const 1)
  )
  (block $label$2
   (br_if $label$2
    (i32.eq
     (local.get $0)
     (local.get $1)
    )
   )
   (block $label$3
    (br_if $label$3
     (i32.ne
      (local.tee $5
       (i32.load
        (local.get $0)
       )
      )
      (i32.load
       (local.get $1)
      )
     )
    )
    (block $label$4
     (block $label$5
      (block $label$6
       (block $label$7
        (block $label$8
         (block $label$9
          (block $label$10
           (block $label$11
            (block $label$12
             (block $label$13
              (block $label$14
               (br_table $label$13 $label$12 $label$11 $label$14 $label$10 $label$9 $label$8 $label$7 $label$6 $label$2 $label$5 $label$4 $label$3 $label$7 $label$3
                (i32.shr_u
                 (local.get $5)
                 (i32.const 28)
                )
               )
              )
              (br_if $label$2
               (i32.eqz
                (local.tee $6
                 (i32.and
                  (local.get $5)
                  (i32.const 268435455)
                 )
                )
               )
              )
              (local.set $1
               (i32.add
                (local.get $1)
                (i32.const 4)
               )
              )
              (local.set $0
               (i32.add
                (local.get $0)
                (i32.const 4)
               )
              )
              (local.set $3
               (i32.const 1)
              )
              (block $label$15
               (loop $label$16
                (br_if $label$15
                 (i32.eq
                  (local.get $6)
                  (local.tee $2
                   (local.get $3)
                  )
                 )
                )
                (local.set $3
                 (i32.add
                  (local.get $2)
                  (i32.const 1)
                 )
                )
                (local.set $4
                 (i32.load
                  (local.get $1)
                 )
                )
                (local.set $5
                 (i32.load
                  (local.get $0)
                 )
                )
                (local.set $1
                 (i32.add
                  (local.get $1)
                  (i32.const 4)
                 )
                )
                (local.set $0
                 (i32.add
                  (local.get $0)
                  (i32.const 4)
                 )
                )
                (br_if $label$16
                 (i32.eq
                  (local.get $5)
                  (local.get $4)
                 )
                )
               )
              )
              (return
               (i32.ge_u
                (local.get $2)
                (local.get $6)
               )
              )
             )
             (return
              (f64.eq
               (f64.load offset=8
                (local.get $0)
               )
               (f64.load offset=8
                (local.get $1)
               )
              )
             )
            )
            (return
             (f64.eq
              (f64.load offset=8
               (local.get $0)
              )
              (f64.load offset=8
               (local.get $1)
              )
             )
            )
           )
           (return
            (i32.eq
             (i32.load offset=4
              (local.get $0)
             )
             (i32.load offset=4
              (local.get $1)
             )
            )
           )
          )
          (local.set $4
           (i32.const 0)
          )
          (br_if $label$2
           (i32.eq
            (local.tee $5
             (i32.load offset=7844
              (i32.const 0)
             )
            )
            (local.get $0)
           )
          )
          (br_if $label$2
           (i32.eq
            (local.get $5)
            (local.get $1)
           )
          )
          (br_if $label$2
           (i32.eqz
            (call $eq_help
             (i32.load offset=4
              (local.get $0)
             )
             (i32.load offset=4
              (local.get $1)
             )
             (local.tee $2
              (i32.add
               (local.get $2)
               (i32.const 1)
              )
             )
             (local.get $3)
            )
           )
          )
          (return
           (i32.ne
            (call $eq_help
             (i32.load offset=8
              (local.get $0)
             )
             (i32.load offset=8
              (local.get $1)
             )
             (local.get $2)
             (local.get $3)
            )
            (i32.const 0)
           )
          )
         )
         (local.set $4
          (i32.const 0)
         )
         (br_if $label$2
          (i32.eqz
           (call $eq_help
            (i32.load offset=4
             (local.get $0)
            )
            (i32.load offset=4
             (local.get $1)
            )
            (local.tee $2
             (i32.add
              (local.get $2)
              (i32.const 1)
             )
            )
            (local.get $3)
           )
          )
         )
         (return
          (i32.ne
           (call $eq_help
            (i32.load offset=8
             (local.get $0)
            )
            (i32.load offset=8
             (local.get $1)
            )
            (local.get $2)
            (local.get $3)
           )
           (i32.const 0)
          )
         )
        )
        (br_if $label$3
         (i32.eqz
          (call $eq_help
           (i32.load offset=4
            (local.get $0)
           )
           (i32.load offset=4
            (local.get $1)
           )
           (local.tee $2
            (i32.add
             (local.get $2)
             (i32.const 1)
            )
           )
           (local.get $3)
          )
         )
        )
        (local.set $4
         (i32.const 0)
        )
        (br_if $label$2
         (i32.eqz
          (call $eq_help
           (i32.load offset=8
            (local.get $0)
           )
           (i32.load offset=8
            (local.get $1)
           )
           (local.get $2)
           (local.get $3)
          )
         )
        )
        (return
         (i32.ne
          (call $eq_help
           (i32.load offset=12
            (local.get $0)
           )
           (i32.load offset=12
            (local.get $1)
           )
           (local.get $2)
           (local.get $3)
          )
          (i32.const 0)
         )
        )
       )
       (br_if $label$3
        (i32.ne
         (i32.load offset=4
          (local.get $0)
         )
         (i32.load offset=4
          (local.get $1)
         )
        )
       )
       (br_if $label$2
        (i32.eqz
         (local.tee $8
          (i32.add
           (local.tee $7
            (i32.and
             (local.get $5)
             (i32.const 268435455)
            )
           )
           (i32.const -2)
          )
         )
        )
       )
       (local.set $4
        (i32.const 0)
       )
       (br_if $label$2
        (i32.eqz
         (call $eq_help
          (i32.load offset=8
           (local.get $0)
          )
          (i32.load offset=8
           (local.get $1)
          )
          (local.tee $9
           (i32.add
            (local.get $2)
            (i32.const 1)
           )
          )
          (local.get $3)
         )
        )
       )
       (local.set $1
        (i32.add
         (local.get $1)
         (i32.const 12)
        )
       )
       (local.set $0
        (i32.add
         (local.get $0)
         (i32.const 12)
        )
       )
       (local.set $2
        (i32.const 3)
       )
       (block $label$17
        (loop $label$18
         (br_if $label$17
          (i32.eq
           (local.get $7)
           (local.tee $4
            (local.get $2)
           )
          )
         )
         (local.set $2
          (i32.add
           (local.get $4)
           (i32.const 1)
          )
         )
         (local.set $5
          (i32.load
           (local.get $1)
          )
         )
         (local.set $6
          (i32.load
           (local.get $0)
          )
         )
         (local.set $1
          (i32.add
           (local.get $1)
           (i32.const 4)
          )
         )
         (local.set $0
          (i32.add
           (local.get $0)
           (i32.const 4)
          )
         )
         (br_if $label$18
          (call $eq_help
           (local.get $6)
           (local.get $5)
           (local.get $9)
           (local.get $3)
          )
         )
        )
       )
       (return
        (i32.ge_u
         (i32.add
          (local.get $4)
          (i32.const -2)
         )
         (local.get $8)
        )
       )
      )
      (br_if $label$2
       (i32.eqz
        (local.tee $8
         (i32.add
          (local.tee $7
           (i32.and
            (local.get $5)
            (i32.const 268435455)
           )
          )
          (i32.const -2)
         )
        )
       )
      )
      (local.set $4
       (i32.const 0)
      )
      (br_if $label$2
       (i32.eqz
        (call $eq_help
         (i32.load offset=8
          (local.get $0)
         )
         (i32.load offset=8
          (local.get $1)
         )
         (local.tee $9
          (i32.add
           (local.get $2)
           (i32.const 1)
          )
         )
         (local.get $3)
        )
       )
      )
      (local.set $1
       (i32.add
        (local.get $1)
        (i32.const 12)
       )
      )
      (local.set $0
       (i32.add
        (local.get $0)
        (i32.const 12)
       )
      )
      (local.set $2
       (i32.const 3)
      )
      (block $label$19
       (loop $label$20
        (br_if $label$19
         (i32.eq
          (local.get $7)
          (local.tee $4
           (local.get $2)
          )
         )
        )
        (local.set $2
         (i32.add
          (local.get $4)
          (i32.const 1)
         )
        )
        (local.set $5
         (i32.load
          (local.get $1)
         )
        )
        (local.set $6
         (i32.load
          (local.get $0)
         )
        )
        (local.set $1
         (i32.add
          (local.get $1)
          (i32.const 4)
         )
        )
        (local.set $0
         (i32.add
          (local.get $0)
          (i32.const 4)
         )
        )
        (br_if $label$20
         (call $eq_help
          (local.get $6)
          (local.get $5)
          (local.get $9)
          (local.get $3)
         )
        )
       )
      )
      (return
       (i32.ge_u
        (i32.add
         (local.get $4)
         (i32.const -2)
        )
        (local.get $8)
       )
      )
     )
     (br_if $label$3
      (i32.ne
       (i32.load offset=8
        (local.get $0)
       )
       (i32.load offset=8
        (local.get $1)
       )
      )
     )
     (br_if $label$2
      (i32.eqz
       (local.tee $7
        (i32.load16_u offset=4
         (local.get $0)
        )
       )
      )
     )
     (local.set $4
      (i32.const 0)
     )
     (br_if $label$2
      (i32.eqz
       (call $eq_help
        (i32.load offset=12
         (local.get $0)
        )
        (i32.load offset=12
         (local.get $1)
        )
        (local.tee $9
         (i32.add
          (local.get $2)
          (i32.const 1)
         )
        )
        (local.get $3)
       )
      )
     )
     (local.set $0
      (i32.add
       (local.get $0)
       (i32.const 16)
      )
     )
     (local.set $1
      (i32.add
       (local.get $1)
       (i32.const 16)
      )
     )
     (local.set $2
      (i32.const 1)
     )
     (block $label$21
      (loop $label$22
       (br_if $label$21
        (i32.eq
         (local.get $7)
         (local.tee $4
          (local.get $2)
         )
        )
       )
       (local.set $2
        (i32.add
         (local.get $4)
         (i32.const 1)
        )
       )
       (local.set $5
        (i32.load
         (local.get $1)
        )
       )
       (local.set $6
        (i32.load
         (local.get $0)
        )
       )
       (local.set $0
        (i32.add
         (local.get $0)
         (i32.const 4)
        )
       )
       (local.set $1
        (i32.add
         (local.get $1)
         (i32.const 4)
        )
       )
       (br_if $label$22
        (call $eq_help
         (local.get $6)
         (local.get $5)
         (local.get $9)
         (local.get $3)
        )
       )
      )
     )
     (return
      (i32.ge_u
       (local.get $4)
       (local.get $7)
      )
     )
    )
    (return
     (i32.eq
      (i32.load offset=4
       (local.get $0)
      )
      (i32.load offset=4
       (local.get $1)
      )
     )
    )
   )
   (local.set $4
    (i32.const 0)
   )
  )
  (local.get $4)
 )
 (func $eval_notEqual (param $0 i32) (result i32)
  (local $1 i32)
  (local $2 i32)
  (global.set $__stack_pointer
   (local.tee $1
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 16)
    )
   )
  )
  (i32.store offset=12
   (local.get $1)
   (i32.const 8512)
  )
  (local.set $2
   (i32.ne
    (local.tee $0
     (call $eq_help
      (i32.load
       (local.get $0)
      )
      (i32.load offset=4
       (local.get $0)
      )
      (i32.const 0)
      (i32.add
       (local.get $1)
       (i32.const 12)
      )
     )
    )
    (i32.const 0)
   )
  )
  (block $label$1
   (br_if $label$1
    (i32.eqz
     (local.get $0)
    )
   )
   (br_if $label$1
    (i32.eq
     (local.tee $0
      (i32.load offset=12
       (local.get $1)
      )
     )
     (i32.const 8512)
    )
   )
   (loop $label$2
    (i32.store offset=12
     (local.get $1)
     (i32.load offset=8
      (local.get $0)
     )
    )
    (local.set $2
     (i32.ne
      (local.tee $0
       (call $eq_help
        (i32.load offset=4
         (local.tee $0
          (i32.load offset=4
           (local.get $0)
          )
         )
        )
        (i32.load offset=8
         (local.get $0)
        )
        (i32.const 0)
        (i32.add
         (local.get $1)
         (i32.const 12)
        )
       )
      )
      (i32.const 0)
     )
    )
    (br_if $label$1
     (i32.eqz
      (local.get $0)
     )
    )
    (br_if $label$2
     (i32.ne
      (local.tee $0
       (i32.load offset=12
        (local.get $1)
       )
      )
      (i32.const 8512)
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
  (select
   (i32.const 8540)
   (i32.const 8532)
   (local.get $2)
  )
 )
 (func $compare_eval (param $0 i32) (result i32)
  (call $compare_help
   (i32.load
    (local.get $0)
   )
   (i32.load offset=4
    (local.get $0)
   )
  )
 )
 (func $compare_help (param $0 i32) (param $1 i32) (result i32)
  (local $2 i32)
  (local $3 i32)
  (local $4 i32)
  (local $5 i32)
  (local $6 i32)
  (local $7 i32)
  (local $8 i32)
  (local $9 f64)
  (local $10 f64)
  (block $label$1
   (br_if $label$1
    (i32.ne
     (local.get $0)
     (local.get $1)
    )
   )
   (return
    (i32.const 0)
   )
  )
  (local.set $2
   (i32.load offset=7844
    (i32.const 0)
   )
  )
  (block $label$2
   (block $label$3
    (block $label$4
     (loop $label$5
      (local.set $3
       (i32.const 0)
      )
      (block $label$6
       (block $label$7
        (block $label$8
         (block $label$9
          (block $label$10
           (block $label$11
            (block $label$12
             (block $label$13
              (br_table $label$13 $label$12 $label$11 $label$10 $label$9 $label$8 $label$7 $label$2
               (i32.shr_u
                (local.tee $4
                 (i32.load
                  (local.get $0)
                 )
                )
                (i32.const 28)
               )
              )
             )
             (local.set $3
              (i32.const 0)
             )
             (br_if $label$2
              (f64.eq
               (local.tee $9
                (f64.load offset=8
                 (local.get $0)
                )
               )
               (local.tee $10
                (f64.load offset=8
                 (local.get $1)
                )
               )
              )
             )
             (return
              (select
               (i32.const 0)
               (i32.const 0)
               (f64.lt
                (local.get $9)
                (local.get $10)
               )
              )
             )
            )
            (local.set $3
             (i32.const 0)
            )
            (br_if $label$2
             (f64.eq
              (local.tee $9
               (f64.load offset=8
                (local.get $0)
               )
              )
              (local.tee $10
               (f64.load offset=8
                (local.get $1)
               )
              )
             )
            )
            (return
             (select
              (i32.const 0)
              (i32.const 0)
              (f64.lt
               (local.get $9)
               (local.get $10)
              )
             )
            )
           )
           (local.set $3
            (i32.const 0)
           )
           (br_if $label$2
            (i32.eq
             (local.tee $0
              (i32.load offset=4
               (local.get $0)
              )
             )
             (local.tee $1
              (i32.load offset=4
               (local.get $1)
              )
             )
            )
           )
           (local.set $3
            (select
             (i32.const 0)
             (i32.const 0)
             (i32.lt_u
              (local.get $0)
              (local.get $1)
             )
            )
           )
           (br $label$2)
          )
          (local.set $5
           (i32.add
            (local.get $0)
            (i32.const 4)
           )
          )
          (local.set $2
           (i32.add
            (i32.shl
             (i32.and
              (local.get $4)
              (i32.const 268435455)
             )
             (i32.const 2)
            )
            (i32.const -2)
           )
          )
          (block $label$14
           (loop $label$15
            (local.set $3
             (i32.add
              (local.get $2)
              (i32.const -2)
             )
            )
            (br_if $label$14
             (i32.load16_u
              (local.tee $4
               (i32.add
                (local.get $0)
                (local.get $2)
               )
              )
             )
            )
            (local.set $2
             (local.get $3)
            )
            (br_if $label$15
             (i32.ge_u
              (local.get $4)
              (local.get $5)
             )
            )
           )
          )
          (local.set $6
           (i32.add
            (local.get $1)
            (i32.const 4)
           )
          )
          (local.set $2
           (i32.add
            (i32.shl
             (i32.and
              (i32.load
               (local.get $1)
              )
              (i32.const 268435455)
             )
             (i32.const 2)
            )
            (i32.const -2)
           )
          )
          (block $label$16
           (loop $label$17
            (local.set $4
             (i32.add
              (local.get $2)
              (i32.const -2)
             )
            )
            (br_if $label$16
             (i32.load16_u
              (local.tee $5
               (i32.add
                (local.get $1)
                (local.get $2)
               )
              )
             )
            )
            (local.set $2
             (local.get $4)
            )
            (br_if $label$17
             (i32.ge_u
              (local.get $5)
              (local.get $6)
             )
            )
           )
          )
          (block $label$18
           (br_if $label$18
            (local.tee $3
             (select
              (local.tee $6
               (i32.shr_s
                (local.get $3)
                (i32.const 1)
               )
              )
              (local.tee $7
               (i32.shr_s
                (local.get $4)
                (i32.const 1)
               )
              )
              (local.tee $8
               (i32.lt_u
                (local.get $6)
                (local.get $7)
               )
              )
             )
            )
           )
           (local.set $2
            (i32.const 0)
           )
           (br $label$4)
          )
          (local.set $0
           (i32.add
            (local.get $0)
            (i32.const 4)
           )
          )
          (local.set $1
           (i32.add
            (local.get $1)
            (i32.const 4)
           )
          )
          (local.set $2
           (i32.const 0)
          )
          (loop $label$19
           (br_if $label$4
            (i32.ne
             (local.tee $4
              (i32.load16_u
               (local.get $0)
              )
             )
             (local.tee $5
              (i32.load16_u
               (local.get $1)
              )
             )
            )
           )
           (local.set $0
            (i32.add
             (local.get $0)
             (i32.const 2)
            )
           )
           (local.set $1
            (i32.add
             (local.get $1)
             (i32.const 2)
            )
           )
           (br_if $label$19
            (i32.ne
             (local.get $3)
             (local.tee $2
              (i32.add
               (local.get $2)
               (i32.const 1)
              )
             )
            )
           )
           (br $label$3)
          )
         )
         (block $label$20
          (br_if $label$20
           (i32.ne
            (local.get $2)
            (local.get $1)
           )
          )
          (return
           (i32.const 0)
          )
         )
         (block $label$21
          (br_if $label$21
           (i32.ne
            (local.get $2)
            (local.get $0)
           )
          )
          (return
           (i32.const 0)
          )
         )
         (loop $label$22
          (br_if $label$2
           (i32.ne
            (local.tee $3
             (call $compare_help
              (i32.load offset=4
               (local.get $0)
              )
              (i32.load offset=4
               (local.get $1)
              )
             )
            )
            (i32.const 0)
           )
          )
          (local.set $1
           (i32.load offset=8
            (local.get $1)
           )
          )
          (br_if $label$6
           (i32.eq
            (local.tee $0
             (i32.load offset=8
              (local.get $0)
             )
            )
            (local.get $2)
           )
          )
          (br_if $label$22
           (i32.ne
            (local.get $1)
            (local.get $2)
           )
          )
          (br $label$6)
         )
        )
        (br_if $label$2
         (i32.ne
          (local.tee $3
           (call $compare_help
            (i32.load offset=4
             (local.get $0)
            )
            (i32.load offset=4
             (local.get $1)
            )
           )
          )
          (i32.const 0)
         )
        )
        (local.set $1
         (i32.load offset=8
          (local.get $1)
         )
        )
        (local.set $0
         (i32.load offset=8
          (local.get $0)
         )
        )
        (br $label$6)
       )
       (br_if $label$2
        (i32.ne
         (local.tee $3
          (call $compare_help
           (i32.load offset=4
            (local.get $0)
           )
           (i32.load offset=4
            (local.get $1)
           )
          )
         )
         (i32.const 0)
        )
       )
       (br_if $label$2
        (i32.ne
         (local.tee $3
          (call $compare_help
           (i32.load offset=8
            (local.get $0)
           )
           (i32.load offset=8
            (local.get $1)
           )
          )
         )
         (i32.const 0)
        )
       )
       (local.set $1
        (i32.load offset=12
         (local.get $1)
        )
       )
       (local.set $0
        (i32.load offset=12
         (local.get $0)
        )
       )
      )
      (br_if $label$5
       (i32.ne
        (local.get $0)
        (local.get $1)
       )
      )
     )
     (return
      (i32.const 0)
     )
    )
    (br_if $label$3
     (i32.eq
      (local.get $2)
      (local.get $3)
     )
    )
    (return
     (select
      (i32.const 0)
      (i32.const 0)
      (i32.lt_u
       (i32.and
        (local.get $4)
        (i32.const 65535)
       )
       (i32.and
        (local.get $5)
        (i32.const 65535)
       )
      )
     )
    )
   )
   (return
    (select
     (i32.const 0)
     (select
      (i32.const 0)
      (i32.const 0)
      (local.get $8)
     )
     (i32.eq
      (local.get $6)
      (local.get $7)
     )
    )
   )
  )
  (local.get $3)
 )
 (func $lt_eval (param $0 i32) (result i32)
  (select
   (i32.const 8532)
   (i32.const 8540)
   (i32.eq
    (call $compare_help
     (i32.load
      (local.get $0)
     )
     (i32.load offset=4
      (local.get $0)
     )
    )
    (i32.const 0)
   )
  )
 )
 (func $le_eval (param $0 i32) (result i32)
  (select
   (i32.const 8540)
   (i32.const 8532)
   (i32.eq
    (call $compare_help
     (i32.load
      (local.get $0)
     )
     (i32.load offset=4
      (local.get $0)
     )
    )
    (i32.const 0)
   )
  )
 )
 (func $gt_eval (param $0 i32) (result i32)
  (select
   (i32.const 8532)
   (i32.const 8540)
   (i32.eq
    (call $compare_help
     (i32.load
      (local.get $0)
     )
     (i32.load offset=4
      (local.get $0)
     )
    )
    (i32.const 0)
   )
  )
 )
 (func $ge_eval (param $0 i32) (result i32)
  (select
   (i32.const 8540)
   (i32.const 8532)
   (i32.eq
    (call $compare_help
     (i32.load
      (local.get $0)
     )
     (i32.load offset=4
      (local.get $0)
     )
    )
    (i32.const 0)
   )
  )
 )
 (func $Debug_pause
 )
 (func $log_debug (param $0 i32) (param $1 i32)
 )
 (func $print_heap_range (param $0 i32) (param $1 i32)
  (local $2 i32)
  (local $3 i32)
  (local $4 i32)
  (local $5 i32)
  (local $6 i64)
  (global.set $__stack_pointer
   (local.tee $2
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 48)
    )
   )
  )
  (call $safe_printf
   (i32.const 5232)
   (i32.const 0)
  )
  (call $safe_printf
   (i32.const 5649)
   (i32.const 0)
  )
  (block $label$1
   (br_if $label$1
    (i32.ge_u
     (local.get $0)
     (local.get $1)
    )
   )
   (local.set $3
    (local.get $0)
   )
   (loop $label$2
    (block $label$3
     (block $label$4
      (block $label$5
       (br_if $label$5
        (i32.ne
         (local.get $3)
         (local.get $0)
        )
       )
       (block $label$6
        (br_if $label$6
         (local.tee $4
          (i32.load
           (local.get $0)
          )
         )
        )
        (local.set $3
         (i32.const 0)
        )
        (loop $label$7
         (local.set $4
          (i32.add
           (local.get $0)
           (local.get $3)
          )
         )
         (local.set $3
          (local.tee $5
           (i32.add
            (local.get $3)
            (i32.const 4)
           )
          )
         )
         (br_if $label$7
          (i32.eqz
           (i32.load
            (i32.add
             (local.get $4)
             (i32.const 4)
            )
           )
          )
         )
        )
        (i32.store offset=20
         (local.get $2)
         (i32.const 0)
        )
        (i32.store offset=24
         (local.get $2)
         (i32.shr_s
          (local.get $5)
          (i32.const 2)
         )
        )
        (i32.store offset=16
         (local.get $2)
         (local.get $0)
        )
        (call $safe_printf
         (i32.const 5723)
         (i32.add
          (local.get $2)
          (i32.const 16)
         )
        )
        (br_if $label$1
         (i32.ge_u
          (local.tee $0
           (i32.add
            (local.get $0)
            (local.get $5)
           )
          )
          (local.get $1)
         )
        )
        (local.set $4
         (i32.load
          (local.get $0)
         )
        )
       )
       (local.set $6
        (i64.load
         (i32.add
          (i32.load offset=8752
           (i32.const 0)
          )
          (i32.and
           (i32.shr_u
            (local.tee $5
             (i32.shr_s
              (i32.sub
               (local.get $0)
               (i32.load offset=8744
                (i32.const 0)
               )
              )
              (i32.const 2)
             )
            )
            (i32.const 3)
           )
           (i32.const 536870904)
          )
         )
        )
       )
       (i32.store
        (local.get $2)
        (local.tee $3
         (local.get $0)
        )
       )
       (i32.store offset=4
        (local.get $2)
        (local.get $4)
       )
       (i32.store offset=12
        (local.get $2)
        (i32.and
         (local.get $4)
         (i32.const 268435455)
        )
       )
       (i32.store offset=8
        (local.get $2)
        (select
         (i32.const 32)
         (i32.const 88)
         (i64.eqz
          (i64.and
           (i64.shr_u
            (local.get $6)
            (i64.extend_i32_u
             (i32.and
              (local.get $5)
              (i32.const 63)
             )
            )
           )
           (i64.const 1)
          )
         )
        )
       )
       (call $safe_printf
        (i32.const 4145)
        (local.get $2)
       )
       (call $print_value
        (local.get $3)
       )
       (call $safe_printf
        (i32.const 6063)
        (i32.const 0)
       )
       (block $label$8
        (block $label$9
         (block $label$10
          (block $label$11
           (block $label$12
            (block $label$13
             (block $label$14
              (block $label$15
               (block $label$16
                (block $label$17
                 (block $label$18
                  (block $label$19
                   (block $label$20
                    (block $label$21
                     (block $label$22
                      (br_table $label$10 $label$9 $label$22 $label$21 $label$20 $label$19 $label$18 $label$17 $label$16 $label$15 $label$14 $label$13 $label$12 $label$11 $label$8
                       (i32.shr_u
                        (local.tee $4
                         (i32.load
                          (local.get $3)
                         )
                        )
                        (i32.const 28)
                       )
                      )
                     )
                     (local.set $0
                      (i32.const 2)
                     )
                     (br_if $label$4
                      (i32.eq
                       (i32.and
                        (local.get $4)
                        (i32.const 268435455)
                       )
                       (i32.const 2)
                      )
                     )
                     (br $label$8)
                    )
                    (br_if $label$8
                     (i32.and
                      (local.get $4)
                      (i32.const 268419072)
                     )
                    )
                    (local.set $0
                     (i32.and
                      (local.get $4)
                      (i32.const 268435455)
                     )
                    )
                    (br $label$4)
                   )
                   (local.set $0
                    (i32.const 3)
                   )
                   (br_if $label$4
                    (i32.eq
                     (i32.and
                      (local.get $4)
                      (i32.const 268435455)
                     )
                     (i32.const 3)
                    )
                   )
                   (br $label$8)
                  )
                  (local.set $0
                   (i32.const 3)
                  )
                  (br_if $label$4
                   (i32.eq
                    (i32.and
                     (local.get $4)
                     (i32.const 268435455)
                    )
                    (i32.const 3)
                   )
                  )
                  (br $label$8)
                 )
                 (local.set $0
                  (i32.const 4)
                 )
                 (br_if $label$4
                  (i32.eq
                   (i32.and
                    (local.get $4)
                    (i32.const 268435455)
                   )
                   (i32.const 4)
                  )
                 )
                 (br $label$8)
                )
                (br_if $label$4
                 (i32.lt_u
                  (i32.add
                   (local.tee $0
                    (i32.and
                     (local.get $4)
                     (i32.const 268435455)
                    )
                   )
                   (i32.const -2)
                  )
                  (i32.const 512)
                 )
                )
                (br $label$8)
               )
               (br_if $label$4
                (i32.lt_u
                 (i32.add
                  (local.tee $0
                   (i32.and
                    (local.get $4)
                    (i32.const 268435455)
                   )
                  )
                  (i32.const -2)
                 )
                 (i32.const 512)
                )
               )
               (br $label$8)
              )
              (br_if $label$4
               (i32.lt_u
                (i32.add
                 (local.tee $0
                  (i32.and
                   (local.get $4)
                   (i32.const 268435455)
                  )
                 )
                 (i32.const -2)
                )
                (i32.const 512)
               )
              )
              (br $label$8)
             )
             (br_if $label$4
              (i32.lt_u
               (i32.add
                (local.tee $0
                 (i32.and
                  (local.get $4)
                  (i32.const 268435455)
                 )
                )
                (i32.const -3)
               )
               (i32.const 512)
              )
             )
             (br $label$8)
            )
            (local.set $0
             (i32.const 2)
            )
            (br_if $label$4
             (i32.eq
              (i32.and
               (local.get $4)
               (i32.const 268435455)
              )
              (i32.const 2)
             )
            )
            (br $label$8)
           )
           (local.set $0
            (i32.const 6)
           )
           (br_if $label$4
            (i32.eq
             (i32.and
              (local.get $4)
              (i32.const 268435455)
             )
             (i32.const 6)
            )
           )
           (br $label$8)
          )
          (local.set $0
           (i32.const 6)
          )
          (br_if $label$4
           (i32.eq
            (i32.and
             (local.get $4)
             (i32.const 268435455)
            )
            (i32.const 6)
           )
          )
          (br $label$8)
         )
         (local.set $0
          (i32.const 4)
         )
         (br_if $label$8
          (i32.ne
           (i32.and
            (local.get $4)
            (i32.const 268435455)
           )
           (i32.const 4)
          )
         )
         (br $label$4)
        )
        (local.set $0
         (i32.const 4)
        )
        (br_if $label$4
         (i32.eq
          (i32.and
           (local.get $4)
           (i32.const 268435455)
          )
          (i32.const 4)
         )
        )
       )
       (local.set $0
        (i32.add
         (local.get $3)
         (i32.const 4)
        )
       )
       (br $label$3)
      )
      (local.set $6
       (i64.load
        (i32.add
         (i32.load offset=8752
          (i32.const 0)
         )
         (i32.and
          (i32.shr_u
           (local.tee $4
            (i32.shr_s
             (i32.sub
              (local.get $3)
              (i32.load offset=8744
               (i32.const 0)
              )
             )
             (i32.const 2)
            )
           )
           (i32.const 3)
          )
          (i32.const 536870904)
         )
        )
       )
      )
      (local.set $5
       (i32.load
        (local.get $3)
       )
      )
      (i32.store offset=32
       (local.get $2)
       (local.get $3)
      )
      (i32.store offset=36
       (local.get $2)
       (local.get $5)
      )
      (i32.store offset=40
       (local.get $2)
       (select
        (i32.const 32)
        (i32.const 88)
        (i64.eqz
         (i64.and
          (i64.shr_u
           (local.get $6)
           (i64.extend_i32_u
            (i32.and
             (local.get $4)
             (i32.const 63)
            )
           )
          )
          (i64.const 1)
         )
        )
       )
      )
      (call $safe_printf
       (i32.const 4744)
       (i32.add
        (local.get $2)
        (i32.const 32)
       )
      )
      (br $label$3)
     )
     (local.set $0
      (i32.add
       (local.get $3)
       (i32.shl
        (local.get $0)
        (i32.const 2)
       )
      )
     )
    )
    (br_if $label$2
     (i32.lt_u
      (local.tee $3
       (i32.add
        (local.get $3)
        (i32.const 4)
       )
      )
      (local.get $1)
     )
    )
   )
  )
  (global.set $__stack_pointer
   (i32.add
    (local.get $2)
    (i32.const 48)
   )
  )
 )
 (func $sanity_check (param $0 i32) (result i32)
  (local $1 i32)
  (block $label$1
   (br_if $label$1
    (local.get $0)
   )
   (return
    (i32.const 1)
   )
  )
  (local.set $1
   (i32.const 0)
  )
  (block $label$2
   (block $label$3
    (block $label$4
     (block $label$5
      (block $label$6
       (block $label$7
        (block $label$8
         (block $label$9
          (block $label$10
           (block $label$11
            (block $label$12
             (block $label$13
              (block $label$14
               (block $label$15
                (block $label$16
                 (br_table $label$16 $label$15 $label$14 $label$13 $label$12 $label$11 $label$10 $label$9 $label$8 $label$7 $label$6 $label$5 $label$4 $label$3 $label$2
                  (i32.shr_u
                   (local.tee $0
                    (i32.load
                     (local.get $0)
                    )
                   )
                   (i32.const 28)
                  )
                 )
                )
                (return
                 (i32.eq
                  (i32.and
                   (local.get $0)
                   (i32.const 268435455)
                  )
                  (i32.const 4)
                 )
                )
               )
               (return
                (i32.eq
                 (i32.and
                  (local.get $0)
                  (i32.const 268435455)
                 )
                 (i32.const 4)
                )
               )
              )
              (return
               (i32.eq
                (i32.and
                 (local.get $0)
                 (i32.const 268435455)
                )
                (i32.const 2)
               )
              )
             )
             (return
              (i32.eqz
               (i32.and
                (local.get $0)
                (i32.const 268419072)
               )
              )
             )
            )
            (return
             (i32.eq
              (i32.and
               (local.get $0)
               (i32.const 268435455)
              )
              (i32.const 3)
             )
            )
           )
           (return
            (i32.eq
             (i32.and
              (local.get $0)
              (i32.const 268435455)
             )
             (i32.const 3)
            )
           )
          )
          (return
           (i32.eq
            (i32.and
             (local.get $0)
             (i32.const 268435455)
            )
            (i32.const 4)
           )
          )
         )
         (return
          (i32.lt_u
           (i32.add
            (i32.and
             (local.get $0)
             (i32.const 268435455)
            )
            (i32.const -2)
           )
           (i32.const 512)
          )
         )
        )
        (return
         (i32.lt_u
          (i32.add
           (i32.and
            (local.get $0)
            (i32.const 268435455)
           )
           (i32.const -2)
          )
          (i32.const 512)
         )
        )
       )
       (return
        (i32.lt_u
         (i32.add
          (i32.and
           (local.get $0)
           (i32.const 268435455)
          )
          (i32.const -2)
         )
         (i32.const 512)
        )
       )
      )
      (return
       (i32.lt_u
        (i32.add
         (i32.and
          (local.get $0)
          (i32.const 268435455)
         )
         (i32.const -3)
        )
        (i32.const 512)
       )
      )
     )
     (return
      (i32.eq
       (i32.and
        (local.get $0)
        (i32.const 268435455)
       )
       (i32.const 2)
      )
     )
    )
    (return
     (i32.eq
      (i32.and
       (local.get $0)
       (i32.const 268435455)
      )
      (i32.const 6)
     )
    )
   )
   (local.set $1
    (i32.eq
     (i32.and
      (local.get $0)
      (i32.const 268435455)
     )
     (i32.const 6)
    )
   )
  )
  (local.get $1)
 )
 (func $print_value (param $0 i32)
  (local $1 i32)
  (local $2 i32)
  (local $3 i32)
  (local $4 i32)
  (local $5 i32)
  (local $6 f64)
  (local $7 i64)
  (global.set $__stack_pointer
   (local.tee $1
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 416)
    )
   )
  )
  (block $label$1
   (block $label$2
    (br_if $label$2
     (local.get $0)
    )
    (call $safe_printf
     (i32.const 3840)
     (i32.const 0)
    )
    (br $label$1)
   )
   (block $label$3
    (block $label$4
     (block $label$5
      (block $label$6
       (block $label$7
        (block $label$8
         (block $label$9
          (block $label$10
           (block $label$11
            (block $label$12
             (block $label$13
              (block $label$14
               (block $label$15
                (block $label$16
                 (block $label$17
                  (br_table $label$17 $label$16 $label$15 $label$14 $label$13 $label$12 $label$11 $label$10 $label$9 $label$8 $label$7 $label$6 $label$5 $label$4 $label$3
                   (i32.shr_u
                    (local.tee $2
                     (i32.load
                      (local.get $0)
                     )
                    )
                    (i32.const 28)
                   )
                  )
                 )
                 (br_if $label$3
                  (i32.ne
                   (i32.and
                    (local.get $2)
                    (i32.const 268435455)
                   )
                   (i32.const 4)
                  )
                 )
                 (block $label$18
                  (block $label$19
                   (br_if $label$19
                    (i32.eqz
                     (f64.lt
                      (f64.abs
                       (local.tee $6
                        (f64.load offset=8
                         (local.get $0)
                        )
                       )
                      )
                      (f64.const 2147483648)
                     )
                    )
                   )
                   (local.set $0
                    (i32.trunc_f64_s
                     (local.get $6)
                    )
                   )
                   (br $label$18)
                  )
                  (local.set $0
                   (i32.const -2147483648)
                  )
                 )
                 (i32.store offset=16
                  (local.get $1)
                  (local.get $0)
                 )
                 (call $safe_printf
                  (i32.const 3284)
                  (i32.add
                   (local.get $1)
                   (i32.const 16)
                  )
                 )
                 (br $label$1)
                )
                (br_if $label$3
                 (i32.ne
                  (i32.and
                   (local.get $2)
                   (i32.const 268435455)
                  )
                  (i32.const 4)
                 )
                )
                (f64.store offset=32
                 (local.get $1)
                 (f64.load offset=8
                  (local.get $0)
                 )
                )
                (call $safe_printf
                 (i32.const 2702)
                 (i32.add
                  (local.get $1)
                  (i32.const 32)
                 )
                )
                (br $label$1)
               )
               (br_if $label$3
                (i32.ne
                 (i32.and
                  (local.get $2)
                  (i32.const 268435455)
                 )
                 (i32.const 2)
                )
               )
               (i32.store offset=64
                (local.get $1)
                (i32.load offset=4
                 (local.get $0)
                )
               )
               (call $safe_printf
                (i32.const 1305)
                (i32.add
                 (local.get $1)
                 (i32.const 64)
                )
               )
               (br_if $label$1
                (i32.gt_u
                 (local.tee $0
                  (i32.load offset=4
                   (local.get $0)
                  )
                 )
                 (i32.const 127)
                )
               )
               (i32.store offset=48
                (local.get $1)
                (local.get $0)
               )
               (call $safe_printf
                (i32.const 4105)
                (i32.add
                 (local.get $1)
                 (i32.const 48)
                )
               )
               (br $label$1)
              )
              (br_if $label$3
               (i32.and
                (local.get $2)
                (i32.const 268419072)
               )
              )
              (local.set $3
               (i32.add
                (local.get $0)
                (i32.const 4)
               )
              )
              (local.set $2
               (i32.add
                (i32.shl
                 (i32.and
                  (local.get $2)
                  (i32.const 268435455)
                 )
                 (i32.const 2)
                )
                (i32.const -2)
               )
              )
              (block $label$20
               (loop $label$21
                (local.set $4
                 (i32.add
                  (local.get $2)
                  (i32.const -2)
                 )
                )
                (br_if $label$20
                 (i32.load16_u
                  (local.tee $5
                   (i32.add
                    (local.get $0)
                    (local.get $2)
                   )
                  )
                 )
                )
                (local.set $2
                 (local.get $4)
                )
                (br_if $label$21
                 (i32.ge_u
                  (local.get $5)
                  (local.get $3)
                 )
                )
               )
              )
              (local.set $2
               (i32.const 0)
              )
              (block $label$22
               (br_if $label$22
                (i32.eqz
                 (local.get $4)
                )
               )
               (local.set $5
                (i32.shr_s
                 (local.get $4)
                 (i32.const 1)
                )
               )
               (local.set $0
                (i32.const 0)
               )
               (loop $label$23
                (i32.store8
                 (i32.add
                  (i32.add
                   (local.get $1)
                   (i32.const 288)
                  )
                  (local.get $0)
                 )
                 (i32.load8_u
                  (local.get $3)
                 )
                )
                (br_if $label$22
                 (i32.ge_u
                  (local.tee $2
                   (i32.add
                    (local.get $0)
                    (i32.const 1)
                   )
                  )
                  (local.get $5)
                 )
                )
                (local.set $3
                 (i32.add
                  (local.get $3)
                  (i32.const 2)
                 )
                )
                (local.set $4
                 (i32.lt_u
                  (local.get $0)
                  (i32.const 127)
                 )
                )
                (local.set $0
                 (local.get $2)
                )
                (br_if $label$23
                 (local.get $4)
                )
               )
              )
              (i32.store8
               (i32.add
                (i32.add
                 (local.get $1)
                 (i32.const 288)
                )
                (local.get $2)
               )
               (i32.const 0)
              )
              (i32.store offset=80
               (local.get $1)
               (i32.add
                (local.get $1)
                (i32.const 288)
               )
              )
              (call $safe_printf
               (i32.const 4115)
               (i32.add
                (local.get $1)
                (i32.const 80)
               )
              )
              (br $label$1)
             )
             (br_if $label$3
              (i32.ne
               (i32.and
                (local.get $2)
                (i32.const 268435455)
               )
               (i32.const 3)
              )
             )
             (block $label$24
              (br_if $label$24
               (i32.ne
                (i32.load offset=7844
                 (i32.const 0)
                )
                (local.get $0)
               )
              )
              (call $safe_printf
               (i32.const 2346)
               (i32.const 0)
              )
              (br $label$1)
             )
             (i64.store offset=96
              (local.get $1)
              (i64.load offset=4 align=4
               (local.get $0)
              )
             )
             (call $safe_printf
              (i32.const 2062)
              (i32.add
               (local.get $1)
               (i32.const 96)
              )
             )
             (br $label$1)
            )
            (br_if $label$3
             (i32.ne
              (i32.and
               (local.get $2)
               (i32.const 268435455)
              )
              (i32.const 3)
             )
            )
            (i64.store offset=112
             (local.get $1)
             (i64.load offset=4 align=4
              (local.get $0)
             )
            )
            (call $safe_printf
             (i32.const 2110)
             (i32.add
              (local.get $1)
              (i32.const 112)
             )
            )
            (br $label$1)
           )
           (br_if $label$3
            (i32.ne
             (i32.and
              (local.get $2)
              (i32.const 268435455)
             )
             (i32.const 4)
            )
           )
           (local.set $7
            (i64.load offset=4 align=4
             (local.get $0)
            )
           )
           (i32.store offset=136
            (local.get $1)
            (i32.load offset=12
             (local.get $0)
            )
           )
           (i64.store offset=128
            (local.get $1)
            (local.get $7)
           )
           (call $safe_printf
            (i32.const 2085)
            (i32.add
             (local.get $1)
             (i32.const 128)
            )
           )
           (br $label$1)
          )
          (br_if $label$3
           (i32.ge_u
            (i32.add
             (i32.and
              (local.get $2)
              (i32.const 268435455)
             )
             (i32.const -2)
            )
            (i32.const 512)
           )
          )
          (block $label$25
           (br_if $label$25
            (i32.ne
             (i32.load offset=8548
              (i32.const 0)
             )
             (local.get $0)
            )
           )
           (call $safe_printf
            (i32.const 2821)
            (i32.const 0)
           )
           (br $label$1)
          )
          (block $label$26
           (br_if $label$26
            (i32.ne
             (i32.load offset=8552
              (i32.const 0)
             )
             (local.get $0)
            )
           )
           (call $safe_printf
            (i32.const 2870)
            (i32.const 0)
           )
           (br $label$1)
          )
          (block $label$27
           (br_if $label$27
            (i32.ne
             (i32.load offset=8016
              (i32.const 0)
             )
             (local.get $0)
            )
           )
           (call $safe_printf
            (i32.const 1488)
            (i32.const 0)
           )
           (br $label$1)
          )
          (block $label$28
           (block $label$29
            (br_if $label$29
             (i32.ge_u
              (local.tee $2
               (i32.load offset=4
                (local.get $0)
               )
              )
              (i32.load
               (i32.const 0)
              )
             )
            )
            (i32.store offset=160
             (local.get $1)
             (i32.add
              (i32.load
               (i32.add
                (i32.const 0)
                (i32.shl
                 (local.get $2)
                 (i32.const 2)
                )
               )
              )
              (i32.const 5)
             )
            )
            (call $safe_printf
             (i32.const 4175)
             (i32.add
              (local.get $1)
              (i32.const 160)
             )
            )
            (br $label$28)
           )
           (i32.store offset=176
            (local.get $1)
            (local.get $2)
           )
           (call $safe_printf
            (i32.const 4202)
            (i32.add
             (local.get $1)
             (i32.const 176)
            )
           )
          )
          (br_if $label$1
           (i32.eq
            (i32.and
             (i32.load
              (local.get $0)
             )
             (i32.const 268435455)
            )
            (i32.const 2)
           )
          )
          (local.set $2
           (i32.add
            (local.get $0)
            (i32.const 8)
           )
          )
          (local.set $3
           (i32.const 0)
          )
          (loop $label$30
           (i32.store offset=144
            (local.get $1)
            (i32.load
             (local.get $2)
            )
           )
           (call $safe_printf
            (i32.const 4198)
            (i32.add
             (local.get $1)
             (i32.const 144)
            )
           )
           (local.set $2
            (i32.add
             (local.get $2)
             (i32.const 4)
            )
           )
           (br_if $label$30
            (i32.lt_u
             (local.tee $3
              (i32.add
               (local.get $3)
               (i32.const 1)
              )
             )
             (i32.add
              (i32.and
               (i32.load
                (local.get $0)
               )
               (i32.const 268435455)
              )
              (i32.const -2)
             )
            )
           )
           (br $label$1)
          )
         )
         (br_if $label$3
          (i32.ge_u
           (i32.add
            (i32.and
             (local.get $2)
             (i32.const 268435455)
            )
            (i32.const -2)
           )
           (i32.const 512)
          )
         )
         (call $safe_printf
          (i32.const 4096)
          (i32.const 0)
         )
         (call $print_value
          (i32.load offset=4
           (local.get $0)
          )
         )
         (call $safe_printf
          (i32.const 4281)
          (i32.const 0)
         )
         (br_if $label$1
          (i32.eqz
           (local.tee $2
            (i32.add
             (i32.and
              (i32.load
               (local.get $0)
              )
              (i32.const 268435455)
             )
             (i32.const -2)
            )
           )
          )
         )
         (local.set $0
          (i32.add
           (local.get $0)
           (i32.const 8)
          )
         )
         (loop $label$31
          (i32.store offset=192
           (local.get $1)
           (i32.load
            (local.get $0)
           )
          )
          (call $safe_printf
           (i32.const 4198)
           (i32.add
            (local.get $1)
            (i32.const 192)
           )
          )
          (local.set $0
           (i32.add
            (local.get $0)
            (i32.const 4)
           )
          )
          (br_if $label$31
           (local.tee $2
            (i32.add
             (local.get $2)
             (i32.const -1)
            )
           )
          )
          (br $label$1)
         )
        )
        (br_if $label$3
         (i32.ge_u
          (i32.add
           (i32.and
            (local.get $2)
            (i32.const 268435455)
           )
           (i32.const -2)
          )
          (i32.const 512)
         )
        )
        (local.set $3
         (i32.const 0)
        )
        (call $safe_printf
         (i32.const 4186)
         (i32.const 0)
        )
        (br_if $label$1
         (i32.eqz
          (i32.load offset=4
           (local.get $0)
          )
         )
        )
        (local.set $2
         (i32.add
          (local.get $0)
          (i32.const 8)
         )
        )
        (loop $label$32
         (i32.store offset=208
          (local.get $1)
          (i32.add
           (i32.load
            (i32.add
             (i32.const 0)
             (i32.shl
              (i32.load
               (local.get $2)
              )
              (i32.const 2)
             )
            )
           )
           (i32.const 6)
          )
         )
         (call $safe_printf
          (i32.const 4182)
          (i32.add
           (local.get $1)
           (i32.const 208)
          )
         )
         (local.set $2
          (i32.add
           (local.get $2)
           (i32.const 4)
          )
         )
         (br_if $label$32
          (i32.lt_u
           (local.tee $3
            (i32.add
             (local.get $3)
             (i32.const 1)
            )
           )
           (i32.load offset=4
            (local.get $0)
           )
          )
         )
         (br $label$1)
        )
       )
       (br_if $label$3
        (i32.ge_u
         (i32.add
          (i32.and
           (local.get $2)
           (i32.const 268435455)
          )
          (i32.const -3)
         )
         (i32.const 512)
        )
       )
       (local.set $2
        (call $Debug_evaluator_name
         (i32.load offset=8
          (local.get $0)
         )
        )
       )
       (local.set $3
        (i32.load16_u offset=4
         (local.get $0)
        )
       )
       (i32.store offset=248
        (local.get $1)
        (i32.load16_u offset=6
         (local.get $0)
        )
       )
       (i32.store offset=244
        (local.get $1)
        (local.get $3)
       )
       (i32.store offset=240
        (local.get $1)
        (local.get $2)
       )
       (call $safe_printf
        (i32.const 4231)
        (i32.add
         (local.get $1)
         (i32.const 240)
        )
       )
       (br_if $label$1
        (i32.eqz
         (local.tee $2
          (i32.add
           (i32.and
            (i32.load
             (local.get $0)
            )
            (i32.const 268435455)
           )
           (i32.const -3)
          )
         )
        )
       )
       (local.set $0
        (i32.add
         (local.get $0)
         (i32.const 12)
        )
       )
       (loop $label$33
        (i32.store offset=224
         (local.get $1)
         (i32.load
          (local.get $0)
         )
        )
        (call $safe_printf
         (i32.const 4198)
         (i32.add
          (local.get $1)
          (i32.const 224)
         )
        )
        (local.set $0
         (i32.add
          (local.get $0)
          (i32.const 4)
         )
        )
        (br_if $label$33
         (local.tee $2
          (i32.add
           (local.get $2)
           (i32.const -1)
          )
         )
        )
        (br $label$1)
       )
      )
      (br_if $label$3
       (i32.ne
        (i32.and
         (local.get $2)
         (i32.const 268435455)
        )
        (i32.const 2)
       )
      )
      (i32.store offset=256
       (local.get $1)
       (i32.load offset=4
        (local.get $0)
       )
      )
      (call $safe_printf
       (i32.const 3291)
       (i32.add
        (local.get $1)
        (i32.const 256)
       )
      )
      (br $label$1)
     )
     (br_if $label$3
      (i32.ne
       (i32.and
        (local.get $2)
        (i32.const 268435455)
       )
       (i32.const 6)
      )
     )
     (local.set $2
      (i32.const 0)
     )
     (local.set $3
      (i32.const 0)
     )
     (block $label$34
      (br_if $label$34
       (i32.eqz
        (local.tee $4
         (i32.load offset=12
          (local.get $0)
         )
        )
       )
      )
      (local.set $3
       (i32.const 0)
      )
      (loop $label$35
       (local.set $3
        (i32.add
         (local.get $3)
         (i32.const 1)
        )
       )
       (br_if $label$35
        (local.tee $4
         (i32.load offset=12
          (local.get $4)
         )
        )
       )
      )
     )
     (block $label$36
      (br_if $label$36
       (i32.eq
        (local.tee $4
         (i32.load offset=16
          (local.get $0)
         )
        )
        (i32.const 8512)
       )
      )
      (local.set $2
       (i32.const 0)
      )
      (loop $label$37
       (local.set $2
        (i32.add
         (local.get $2)
         (i32.const 1)
        )
       )
       (br_if $label$37
        (i32.ne
         (local.tee $4
          (i32.load offset=8
           (local.get $4)
          )
         )
         (i32.const 8512)
        )
       )
      )
     )
     (local.set $0
      (i32.load offset=4
       (local.get $0)
      )
     )
     (i32.store offset=280
      (local.get $1)
      (local.get $2)
     )
     (i32.store offset=276
      (local.get $1)
      (local.get $3)
     )
     (i32.store offset=272
      (local.get $1)
      (local.get $0)
     )
     (call $safe_printf
      (i32.const 3300)
      (i32.add
       (local.get $1)
       (i32.const 272)
      )
     )
     (br $label$1)
    )
    (br_if $label$3
     (i32.ne
      (i32.and
       (local.get $2)
       (i32.const 268435455)
      )
      (i32.const 6)
     )
    )
    (call $safe_printf
     (i32.const 2396)
     (i32.const 0)
    )
    (br $label$1)
   )
   (i32.store
    (local.get $1)
    (local.get $2)
   )
   (call $safe_printf
    (i32.const 4067)
    (local.get $1)
   )
  )
  (global.set $__stack_pointer
   (i32.add
    (local.get $1)
    (i32.const 416)
   )
  )
 )
 (func $Debug_print_offset (param $0 i32) (param $1 i32)
  (local $2 i32)
  (global.set $__stack_pointer
   (local.tee $2
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 16)
    )
   )
  )
  (i32.store
   (local.get $2)
   (local.get $0)
  )
  (i32.store offset=4
   (local.get $2)
   (i32.sub
    (local.get $1)
    (i32.load offset=8744
     (i32.const 0)
    )
   )
  )
  (call $safe_printf
   (i32.const 4779)
   (local.get $2)
  )
  (global.set $__stack_pointer
   (i32.add
    (local.get $2)
    (i32.const 16)
   )
  )
 )
 (func $Debug_is_target_addr (param $0 i32) (result i32)
  (i32.const 0)
 )
 (func $is_marked (param $0 i32) (result i32)
  (i32.and
   (i32.wrap_i64
    (i64.shr_u
     (i64.load
      (i32.add
       (i32.load offset=8752
        (i32.const 0)
       )
       (i32.and
        (i32.shr_u
         (local.tee $0
          (i32.shr_s
           (i32.sub
            (local.get $0)
            (i32.load offset=8744
             (i32.const 0)
            )
           )
           (i32.const 2)
          )
         )
         (i32.const 3)
        )
        (i32.const 536870904)
       )
      )
     )
     (i64.extend_i32_u
      (i32.and
       (local.get $0)
       (i32.const 63)
      )
     )
    )
   )
   (i32.const 1)
  )
 )
 (func $ptr_to_bitmap_iter (param $0 i32) (param $1 i32) (param $2 i32)
  (i32.store offset=8
   (local.get $0)
   (i32.shr_u
    (local.tee $2
     (i32.shr_s
      (i32.sub
       (local.get $2)
       (i32.load
        (local.get $1)
       )
      )
      (i32.const 2)
     )
    )
    (i32.const 6)
   )
  )
  (i64.store
   (local.get $0)
   (i64.shl
    (i64.const 1)
    (i64.extend_i32_u
     (i32.and
      (local.get $2)
      (i32.const 63)
     )
    )
   )
  )
 )
 (func $print_value_line (param $0 i32)
  (local $1 i32)
  (local $2 i32)
  (local $3 i32)
  (local $4 i64)
  (global.set $__stack_pointer
   (local.tee $1
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 16)
    )
   )
  )
  (local.set $4
   (i64.load
    (i32.add
     (i32.load offset=8752
      (i32.const 0)
     )
     (i32.and
      (i32.shr_u
       (local.tee $2
        (i32.shr_s
         (i32.sub
          (local.get $0)
          (i32.load offset=8744
           (i32.const 0)
          )
         )
         (i32.const 2)
        )
       )
       (i32.const 3)
      )
      (i32.const 536870904)
     )
    )
   )
  )
  (local.set $3
   (i32.load
    (local.get $0)
   )
  )
  (i32.store
   (local.get $1)
   (local.get $0)
  )
  (i32.store offset=4
   (local.get $1)
   (local.get $3)
  )
  (i32.store offset=12
   (local.get $1)
   (i32.and
    (local.get $3)
    (i32.const 268435455)
   )
  )
  (i32.store offset=8
   (local.get $1)
   (select
    (i32.const 32)
    (i32.const 88)
    (i64.eqz
     (i64.and
      (i64.shr_u
       (local.get $4)
       (i64.extend_i32_u
        (i32.and
         (local.get $2)
         (i32.const 63)
        )
       )
      )
      (i64.const 1)
     )
    )
   )
  )
  (call $safe_printf
   (i32.const 4145)
   (local.get $1)
  )
  (call $print_value
   (local.get $0)
  )
  (call $safe_printf
   (i32.const 6063)
   (i32.const 0)
  )
  (global.set $__stack_pointer
   (i32.add
    (local.get $1)
    (i32.const 16)
   )
  )
 )
 (func $print_value_full (param $0 i32)
  (local $1 i32)
  (local $2 i32)
  (local.set $1
   (i32.load
    (local.get $0)
   )
  )
  (block $label$1
   (block $label$2
    (br_if $label$2
     (i32.eqz
      (local.get $0)
     )
    )
    (local.set $2
     (i32.const 4)
    )
    (block $label$3
     (block $label$4
      (block $label$5
       (block $label$6
        (block $label$7
         (block $label$8
          (block $label$9
           (block $label$10
            (block $label$11
             (block $label$12
              (block $label$13
               (block $label$14
                (block $label$15
                 (block $label$16
                  (br_table $label$3 $label$16 $label$15 $label$14 $label$13 $label$12 $label$11 $label$10 $label$9 $label$8 $label$7 $label$6 $label$5 $label$4 $label$1
                   (i32.shr_u
                    (local.get $1)
                    (i32.const 28)
                   )
                  )
                 )
                 (local.set $2
                  (i32.const 4)
                 )
                 (br_if $label$2
                  (i32.eq
                   (i32.and
                    (local.get $1)
                    (i32.const 268435455)
                   )
                   (i32.const 4)
                  )
                 )
                 (br $label$1)
                )
                (br_if $label$2
                 (i32.eq
                  (i32.and
                   (local.get $1)
                   (i32.const 268435455)
                  )
                  (i32.const 2)
                 )
                )
                (br $label$1)
               )
               (br_if $label$2
                (i32.eqz
                 (i32.and
                  (local.get $1)
                  (i32.const 268419072)
                 )
                )
               )
               (br $label$1)
              )
              (br_if $label$2
               (i32.eq
                (i32.and
                 (local.get $1)
                 (i32.const 268435455)
                )
                (i32.const 3)
               )
              )
              (br $label$1)
             )
             (br_if $label$2
              (i32.eq
               (i32.and
                (local.get $1)
                (i32.const 268435455)
               )
               (i32.const 3)
              )
             )
             (br $label$1)
            )
            (local.set $2
             (i32.const 4)
            )
            (br_if $label$2
             (i32.eq
              (i32.and
               (local.get $1)
               (i32.const 268435455)
              )
              (i32.const 4)
             )
            )
            (br $label$1)
           )
           (br_if $label$2
            (i32.lt_u
             (i32.add
              (i32.and
               (local.get $1)
               (i32.const 268435455)
              )
              (i32.const -2)
             )
             (i32.const 512)
            )
           )
           (br $label$1)
          )
          (br_if $label$2
           (i32.lt_u
            (i32.add
             (i32.and
              (local.get $1)
              (i32.const 268435455)
             )
             (i32.const -2)
            )
            (i32.const 512)
           )
          )
          (br $label$1)
         )
         (br_if $label$2
          (i32.lt_u
           (i32.add
            (i32.and
             (local.get $1)
             (i32.const 268435455)
            )
            (i32.const -2)
           )
           (i32.const 512)
          )
         )
         (br $label$1)
        )
        (br_if $label$2
         (i32.lt_u
          (i32.add
           (i32.and
            (local.get $1)
            (i32.const 268435455)
           )
           (i32.const -3)
          )
          (i32.const 512)
         )
        )
        (br $label$1)
       )
       (br_if $label$2
        (i32.eq
         (i32.and
          (local.get $1)
          (i32.const 268435455)
         )
         (i32.const 2)
        )
       )
       (br $label$1)
      )
      (br_if $label$2
       (i32.eq
        (i32.and
         (local.get $1)
         (i32.const 268435455)
        )
        (i32.const 6)
       )
      )
      (br $label$1)
     )
     (br_if $label$2
      (i32.eq
       (i32.and
        (local.get $1)
        (i32.const 268435455)
       )
       (i32.const 6)
      )
     )
     (br $label$1)
    )
    (local.set $2
     (i32.const 4)
    )
    (br_if $label$1
     (i32.ne
      (i32.and
       (local.get $1)
       (i32.const 268435455)
      )
      (i32.const 4)
     )
    )
   )
   (local.set $2
    (i32.and
     (local.get $1)
     (i32.const 268435455)
    )
   )
  )
  (call $print_heap_range
   (local.get $0)
   (i32.add
    (local.get $0)
    (i32.shl
     (local.get $2)
     (i32.const 2)
    )
   )
  )
 )
 (func $print_heap
  (call $print_heap_range
   (i32.load offset=8744
    (i32.const 0)
   )
   (i32.load offset=8772
    (i32.const 0)
   )
  )
 )
 (func $print_bitmap (param $0 i32) (param $1 i32) (param $2 i32)
  (local $3 i32)
  (local $4 i32)
  (local $5 i32)
  (local $6 i32)
  (local $7 i32)
  (local $8 i32)
  (local $9 i32)
  (local $10 i32)
  (local $11 i64)
  (local $12 i64)
  (global.set $__stack_pointer
   (local.tee $3
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 112)
    )
   )
  )
  (local.set $6
   (i32.add
    (i32.add
     (i32.shl
      (local.tee $4
       (i32.load offset=8756
        (i32.const 0)
       )
      )
      (i32.const 3)
     )
     (local.tee $5
      (i32.load offset=8752
       (i32.const 0)
      )
     )
    )
    (i32.const -8)
   )
  )
  (block $label$1
   (loop $label$2
    (local.set $7
     (i32.add
      (local.get $4)
      (i32.const -1)
     )
    )
    (br_if $label$1
     (i64.ne
      (i64.load
       (local.get $6)
      )
      (i64.const 0)
     )
    )
    (local.set $6
     (i32.add
      (local.get $6)
      (i32.const -8)
     )
    )
    (local.set $8
     (i32.ne
      (local.get $4)
      (i32.const 1)
     )
    )
    (local.set $4
     (local.get $7)
    )
    (br_if $label$2
     (local.get $8)
    )
   )
  )
  (i32.store offset=24
   (local.get $3)
   (local.get $0)
  )
  (i32.store offset=20
   (local.get $3)
   (local.get $2)
  )
  (i32.store offset=16
   (local.get $3)
   (local.get $1)
  )
  (call $safe_printf
   (i32.const 5761)
   (i32.add
    (local.get $3)
    (i32.const 16)
   )
  )
  (local.set $9
   (i32.const 1)
  )
  (local.set $2
   (i32.const 0)
  )
  (loop $label$3
   (local.set $4
    (i32.add
     (local.tee $6
      (i32.load offset=8744
       (i32.const 0)
      )
     )
     (i32.shl
      (local.get $9)
      (i32.const 2)
     )
    )
   )
   (local.set $10
    (i32.add
     (local.get $6)
     (i32.shl
      (local.get $2)
      (i32.const 8)
     )
    )
   )
   (local.set $11
    (i64.load
     (i32.add
      (local.get $5)
      (i32.shl
       (local.get $2)
       (i32.const 3)
      )
     )
    )
   )
   (local.set $0
    (i32.load offset=8748
     (i32.const 0)
    )
   )
   (local.set $6
    (i32.const 1)
   )
   (local.set $12
    (i64.const 1)
   )
   (block $label$4
    (block $label$5
     (block $label$6
      (loop $label$7
       (br_if $label$6
        (i32.eq
         (local.tee $1
          (i32.add
           (local.get $4)
           (i32.const -4)
          )
         )
         (local.get $0)
        )
       )
       (local.set $8
        (i32.const 88)
       )
       (block $label$8
        (br_if $label$8
         (i64.ne
          (i64.and
           (local.get $12)
           (local.get $11)
          )
          (i64.const 0)
         )
        )
        (local.set $8
         (select
          (i32.const 124)
          (i32.const 45)
          (i32.load
           (local.get $1)
          )
         )
        )
       )
       (i32.store8
        (i32.add
         (local.tee $1
          (i32.add
           (i32.add
            (local.get $3)
            (i32.const 32)
           )
           (local.get $6)
          )
         )
         (i32.const -1)
        )
        (local.get $8)
       )
       (br_if $label$5
        (i32.eq
         (local.get $4)
         (local.get $0)
        )
       )
       (local.set $8
        (i32.const 88)
       )
       (block $label$9
        (br_if $label$9
         (i64.ne
          (i64.and
           (i64.shl
            (local.get $12)
            (i64.const 1)
           )
           (local.get $11)
          )
          (i64.const 0)
         )
        )
        (local.set $8
         (select
          (i32.const 124)
          (i32.const 45)
          (i32.load
           (local.get $4)
          )
         )
        )
       )
       (i32.store8
        (local.get $1)
        (local.get $8)
       )
       (local.set $4
        (i32.add
         (local.get $4)
         (i32.const 8)
        )
       )
       (local.set $12
        (i64.shl
         (local.get $12)
         (i64.const 2)
        )
       )
       (br_if $label$7
        (i32.ne
         (local.tee $6
          (i32.add
           (local.get $6)
           (i32.const 2)
          )
         )
         (i32.const 65)
        )
       )
       (br $label$4)
      )
     )
     (local.set $6
      (i32.add
       (local.get $6)
       (i32.const -1)
      )
     )
    )
    (i32.store8
     (i32.add
      (i32.add
       (local.get $3)
       (i32.const 32)
      )
      (local.get $6)
     )
     (i32.const 0)
    )
   )
   (i32.store8 offset=96
    (local.get $3)
    (i32.const 0)
   )
   (i32.store offset=4
    (local.get $3)
    (local.get $10)
   )
   (i32.store offset=8
    (local.get $3)
    (i32.add
     (local.get $3)
     (i32.const 32)
    )
   )
   (i32.store
    (local.get $3)
    (local.get $2)
   )
   (call $safe_printf
    (i32.const 4921)
    (local.get $3)
   )
   (local.set $9
    (i32.add
     (local.get $9)
     (i32.const 64)
    )
   )
   (br_if $label$3
    (i32.le_u
     (local.tee $2
      (i32.add
       (local.get $2)
       (i32.const 1)
      )
     )
     (local.get $7)
    )
   )
  )
  (call $safe_printf
   (i32.const 6063)
   (i32.const 0)
  )
  (global.set $__stack_pointer
   (i32.add
    (local.get $3)
    (i32.const 112)
   )
  )
 )
 (func $print_stack_map
  (local $0 i32)
  (local $1 i32)
  (local $2 i32)
  (local $3 i32)
  (local $4 i32)
  (local $5 i32)
  (global.set $__stack_pointer
   (local.tee $0
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 160)
    )
   )
  )
  (call $safe_printf
   (i32.const 6063)
   (i32.const 0)
  )
  (call $safe_printf
   (i32.const 5606)
   (i32.const 0)
  )
  (call $safe_printf
   (i32.const 6063)
   (i32.const 0)
  )
  (block $label$1
   (br_if $label$1
    (i32.eqz
     (local.tee $1
      (i32.load16_u offset=8794
       (i32.const 0)
      )
     )
    )
   )
   (local.set $2
    (i32.const 0)
   )
   (loop $label$2
    (local.set $3
     (i32.load
      (i32.add
       (i32.shl
        (local.get $2)
        (i32.const 2)
       )
       (i32.const 8800)
      )
     )
    )
    (block $label$3
     (block $label$4
      (br_if $label$4
       (i32.ne
        (local.tee $4
         (i32.load8_s
          (i32.add
           (local.get $2)
           (i32.const 49760)
          )
         )
        )
        (i32.const 70)
       )
      )
      (call $safe_printf
       (i32.const 5630)
       (i32.const 0)
      )
      (i32.store offset=136
       (local.get $0)
       (local.get $3)
      )
      (i32.store offset=132
       (local.get $0)
       (i32.const 70)
      )
      (i32.store offset=128
       (local.get $0)
       (local.get $2)
      )
      (call $safe_printf
       (i32.const 4726)
       (i32.add
        (local.get $0)
        (i32.const 128)
       )
      )
      (local.set $3
       (i32.load8_s
        (i32.add
         (local.get $2)
         (i32.const 49761)
        )
       )
      )
      (block $label$5
       (block $label$6
        (br_if $label$6
         (local.tee $4
          (i32.load
           (i32.add
            (i32.shl
             (local.tee $2
              (i32.add
               (local.get $2)
               (i32.const 1)
              )
             )
             (i32.const 2)
            )
            (i32.const 8800)
           )
          )
         )
        )
        (i32.store offset=104
         (local.get $0)
         (i32.const 0)
        )
        (i32.store offset=100
         (local.get $0)
         (local.get $3)
        )
        (i32.store offset=96
         (local.get $0)
         (local.get $2)
        )
        (call $safe_printf
         (i32.const 4127)
         (i32.add
          (local.get $0)
          (i32.const 96)
         )
        )
        (local.set $5
         (i32.const 3840)
        )
        (br $label$5)
       )
       (local.set $5
        (call $Debug_evaluator_name
         (local.get $4)
        )
       )
       (i32.store offset=120
        (local.get $0)
        (local.get $4)
       )
       (i32.store offset=116
        (local.get $0)
        (local.get $3)
       )
       (i32.store offset=112
        (local.get $0)
        (local.get $2)
       )
       (call $safe_printf
        (i32.const 4127)
        (i32.add
         (local.get $0)
         (i32.const 112)
        )
       )
      )
      (block $label$7
       (block $label$8
        (block $label$9
         (block $label$10
          (block $label$11
           (br_table $label$10 $label$7 $label$7 $label$7 $label$7 $label$7 $label$9 $label$11 $label$7 $label$7 $label$7 $label$7 $label$7 $label$7 $label$7 $label$7 $label$7 $label$7 $label$7 $label$7 $label$8 $label$7
            (i32.add
             (local.get $3)
             (i32.const -67)
            )
           )
          )
          (i32.store offset=48
           (local.get $0)
           (i32.load offset=4
            (local.get $4)
           )
          )
          (call $safe_printf
           (i32.const 5508)
           (i32.add
            (local.get $0)
            (i32.const 48)
           )
          )
          (br $label$3)
         )
         (i32.store offset=64
          (local.get $0)
          (local.get $5)
         )
         (call $safe_printf
          (i32.const 4945)
          (i32.add
           (local.get $0)
           (i32.const 64)
          )
         )
         (br $label$3)
        )
        (call $safe_printf
         (i32.const 4976)
         (i32.const 0)
        )
        (br $label$3)
       )
       (i32.store offset=80
        (local.get $0)
        (local.get $5)
       )
       (call $safe_printf
        (i32.const 4904)
        (i32.add
         (local.get $0)
         (i32.const 80)
        )
       )
       (br $label$3)
      )
      (i32.store offset=40
       (local.get $0)
       (i32.const 355)
      )
      (i32.store offset=36
       (local.get $0)
       (i32.const 3594)
      )
      (i32.store offset=32
       (local.get $0)
       (i32.const 2023)
      )
      (call $safe_printf
       (i32.const 5284)
       (i32.add
        (local.get $0)
        (i32.const 32)
       )
      )
      (i32.store offset=16
       (local.get $0)
       (i32.const 2864)
      )
      (call $safe_printf
       (i32.const 4957)
       (i32.add
        (local.get $0)
        (i32.const 16)
       )
      )
      (i64.store offset=8
       (local.get $0)
       (i64.extend_i32_s
        (local.get $3)
       )
      )
      (i32.store
       (local.get $0)
       (i32.const 2629)
      )
      (call $safe_printf
       (i32.const 6035)
       (local.get $0)
      )
      (call $abort)
      (br $label$3)
     )
     (i32.store offset=152
      (local.get $0)
      (local.get $3)
     )
     (i32.store offset=148
      (local.get $0)
      (local.get $4)
     )
     (i32.store offset=144
      (local.get $0)
      (local.get $2)
     )
     (call $safe_printf
      (i32.const 4127)
      (i32.add
       (local.get $0)
       (i32.const 144)
      )
     )
     (call $print_value
      (local.get $3)
     )
     (call $safe_printf
      (i32.const 6063)
      (i32.const 0)
     )
    )
    (br_if $label$2
     (i32.lt_u
      (local.tee $2
       (i32.add
        (local.get $2)
        (i32.const 1)
       )
      )
      (local.get $1)
     )
    )
   )
  )
  (global.set $__stack_pointer
   (i32.add
    (local.get $0)
    (i32.const 160)
   )
  )
 )
 (func $print_state
  (local $0 i32)
  (local $1 i32)
  (local $2 i32)
  (local $3 i32)
  (local $4 i32)
  (local $5 i32)
  (local $6 i32)
  (local $7 i32)
  (local $8 i32)
  (global.set $__stack_pointer
   (local.tee $0
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 144)
    )
   )
  )
  (local.set $1
   (i32.load offset=8780
    (i32.const 0)
   )
  )
  (local.set $2
   (i32.load offset=8772
    (i32.const 0)
   )
  )
  (local.set $3
   (i32.load offset=8748
    (i32.const 0)
   )
  )
  (local.set $4
   (i32.load offset=8744
    (i32.const 0)
   )
  )
  (local.set $5
   (i32.load offset=8768
    (i32.const 0)
   )
  )
  (local.set $6
   (i32.const 0)
  )
  (block $label$1
   (br_if $label$1
    (i32.eq
     (local.tee $7
      (i32.load offset=8788
       (i32.const 0)
      )
     )
     (local.tee $8
      (i32.load offset=7844
       (i32.const 0)
      )
     )
    )
   )
   (local.set $6
    (i32.const 0)
   )
   (loop $label$2
    (local.set $6
     (i32.add
      (local.get $6)
      (i32.const 1)
     )
    )
    (br_if $label$2
     (i32.ne
      (local.tee $7
       (i32.load offset=8
        (local.get $7)
       )
      )
      (local.get $8)
     )
    )
   )
  )
  (call $safe_printf
   (i32.const 6063)
   (i32.const 0)
  )
  (i32.store offset=128
   (local.get $0)
   (i32.load offset=8744
    (i32.const 0)
   )
  )
  (call $safe_printf
   (i32.const 4843)
   (i32.add
    (local.get $0)
    (i32.const 128)
   )
  )
  (i32.store offset=116
   (local.get $0)
   (i32.div_s
    (i32.add
     (i32.sub
      (local.get $5)
      (local.get $4)
     )
     (i32.const 512)
    )
    (i32.const 1024)
   )
  )
  (i32.store offset=112
   (local.get $0)
   (i32.load offset=8768
    (i32.const 0)
   )
  )
  (call $safe_printf
   (i32.const 5821)
   (i32.add
    (local.get $0)
    (i32.const 112)
   )
  )
  (i32.store offset=100
   (local.get $0)
   (i32.div_s
    (i32.add
     (local.tee $7
      (i32.sub
       (i32.const 512)
       (local.get $4)
      )
     )
     (local.get $3)
    )
    (i32.const 1024)
   )
  )
  (i32.store offset=96
   (local.get $0)
   (i32.load offset=8748
    (i32.const 0)
   )
  )
  (call $safe_printf
   (i32.const 5783)
   (i32.add
    (local.get $0)
    (i32.const 96)
   )
  )
  (i32.store offset=84
   (local.get $0)
   (i32.div_s
    (i32.add
     (local.get $7)
     (local.get $2)
    )
    (i32.const 1024)
   )
  )
  (i32.store offset=80
   (local.get $0)
   (i32.load offset=8772
    (i32.const 0)
   )
  )
  (call $safe_printf
   (i32.const 5872)
   (i32.add
    (local.get $0)
    (i32.const 80)
   )
  )
  (i32.store offset=68
   (local.get $0)
   (i32.div_s
    (i32.add
     (local.get $7)
     (local.get $1)
    )
    (i32.const 1024)
   )
  )
  (i32.store offset=64
   (local.get $0)
   (i32.load offset=8780
    (i32.const 0)
   )
  )
  (call $safe_printf
   (i32.const 5986)
   (i32.add
    (local.get $0)
    (i32.const 64)
   )
  )
  (call $safe_printf
   (i32.const 6063)
   (i32.const 0)
  )
  (i32.store offset=56
   (local.get $0)
   (i32.const 32)
  )
  (i64.store offset=48
   (local.get $0)
   (i64.load offset=8760 align=4
    (i32.const 0)
   )
  )
  (call $safe_printf
   (i32.const 5939)
   (i32.add
    (local.get $0)
    (i32.const 48)
   )
  )
  (i32.store offset=40
   (local.get $0)
   (i32.const 64)
  )
  (i64.store offset=32
   (local.get $0)
   (i64.load offset=8752 align=4
    (i32.const 0)
   )
  )
  (call $safe_printf
   (i32.const 5963)
   (i32.add
    (local.get $0)
    (i32.const 32)
   )
  )
  (i32.store offset=20
   (local.get $0)
   (local.get $6)
  )
  (i32.store offset=16
   (local.get $0)
   (i32.load offset=8788
    (i32.const 0)
   )
  )
  (call $safe_printf
   (i32.const 5906)
   (i32.add
    (local.get $0)
    (i32.const 16)
   )
  )
  (i32.store
   (local.get $0)
   (i32.load16_u offset=8794
    (i32.const 0)
   )
  )
  (call $safe_printf
   (i32.const 4814)
   (local.get $0)
  )
  (call $safe_printf
   (i32.const 6063)
   (i32.const 0)
  )
  (global.set $__stack_pointer
   (i32.add
    (local.get $0)
    (i32.const 144)
   )
  )
 )
 (func $format_ptr_diff_size (param $0 i32) (param $1 i32) (param $2 i32) (param $3 i32)
  (local $4 i32)
  (local $5 f32)
  (global.set $__stack_pointer
   (local.tee $4
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
      (local.tee $3
       (i32.and
        (i32.sub
         (local.get $3)
         (local.get $2)
        )
        (i32.const -4)
       )
      )
      (i32.const 1023)
     )
    )
    (local.set $5
     (f32.convert_i32_u
      (local.get $3)
     )
    )
    (local.set $3
     (i32.const 3908)
    )
    (br $label$1)
   )
   (local.set $5
    (f32.convert_i32_u
     (local.get $3)
    )
   )
   (block $label$3
    (br_if $label$3
     (i32.gt_u
      (local.get $3)
      (i32.const 1048575)
     )
    )
    (local.set $5
     (f32.mul
      (local.get $5)
      (f32.const 0.0009765625)
     )
    )
    (local.set $3
     (i32.const 3904)
    )
    (br $label$1)
   )
   (local.set $5
    (f32.mul
     (local.get $5)
     (f32.const 9.5367431640625e-07)
    )
   )
   (local.set $3
    (i32.const 3907)
   )
  )
  (i32.store offset=8
   (local.get $4)
   (local.get $3)
  )
  (f64.store
   (local.get $4)
   (f64.promote_f32
    (local.get $5)
   )
  )
  (drop
   (call $stbsp_snprintf
    (local.get $0)
    (local.get $1)
    (select
     (i32.const 1808)
     (i32.const 1816)
     (f32.lt
      (local.get $5)
      (f32.const 10)
     )
    )
    (local.get $4)
   )
  )
  (global.set $__stack_pointer
   (i32.add
    (local.get $4)
    (i32.const 16)
   )
  )
 )
 (func $format_mem_size (param $0 i32) (param $1 i32) (param $2 i32)
  (local $3 i32)
  (local $4 f32)
  (global.set $__stack_pointer
   (local.tee $3
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
       (i32.shl
        (local.get $2)
        (i32.const 2)
       )
      )
      (i32.const 1023)
     )
    )
    (local.set $4
     (f32.convert_i32_u
      (local.get $2)
     )
    )
    (local.set $2
     (i32.const 3908)
    )
    (br $label$1)
   )
   (local.set $4
    (f32.convert_i32_u
     (local.get $2)
    )
   )
   (block $label$3
    (br_if $label$3
     (i32.gt_u
      (local.get $2)
      (i32.const 1048575)
     )
    )
    (local.set $4
     (f32.mul
      (local.get $4)
      (f32.const 0.0009765625)
     )
    )
    (local.set $2
     (i32.const 3904)
    )
    (br $label$1)
   )
   (local.set $4
    (f32.mul
     (local.get $4)
     (f32.const 9.5367431640625e-07)
    )
   )
   (local.set $2
    (i32.const 3907)
   )
  )
  (i32.store offset=8
   (local.get $3)
   (local.get $2)
  )
  (f64.store
   (local.get $3)
   (f64.promote_f32
    (local.get $4)
   )
  )
  (drop
   (call $stbsp_snprintf
    (local.get $0)
    (local.get $1)
    (select
     (i32.const 1808)
     (i32.const 1816)
     (f32.lt
      (local.get $4)
      (f32.const 10)
     )
    )
    (local.get $3)
   )
  )
  (global.set $__stack_pointer
   (i32.add
    (local.get $3)
    (i32.const 16)
   )
  )
 )
 (func $print_ptr_diff_size (param $0 i32) (param $1 i32)
  (local $2 i32)
  (local $3 f32)
  (global.set $__stack_pointer
   (local.tee $2
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 144)
    )
   )
  )
  (block $label$1
   (block $label$2
    (br_if $label$2
     (i32.gt_u
      (local.tee $1
       (i32.and
        (i32.sub
         (local.get $1)
         (local.get $0)
        )
        (i32.const -4)
       )
      )
      (i32.const 1023)
     )
    )
    (local.set $3
     (f32.convert_i32_u
      (local.get $1)
     )
    )
    (local.set $1
     (i32.const 3908)
    )
    (br $label$1)
   )
   (local.set $3
    (f32.convert_i32_u
     (local.get $1)
    )
   )
   (block $label$3
    (br_if $label$3
     (i32.gt_u
      (local.get $1)
      (i32.const 1048575)
     )
    )
    (local.set $3
     (f32.mul
      (local.get $3)
      (f32.const 0.0009765625)
     )
    )
    (local.set $1
     (i32.const 3904)
    )
    (br $label$1)
   )
   (local.set $3
    (f32.mul
     (local.get $3)
     (f32.const 9.5367431640625e-07)
    )
   )
   (local.set $1
    (i32.const 3907)
   )
  )
  (i32.store offset=24
   (local.get $2)
   (local.get $1)
  )
  (f64.store offset=16
   (local.get $2)
   (f64.promote_f32
    (local.get $3)
   )
  )
  (drop
   (call $stbsp_snprintf
    (i32.add
     (local.get $2)
     (i32.const 32)
    )
    (i32.const 100)
    (select
     (i32.const 1808)
     (i32.const 1816)
     (f32.lt
      (local.get $3)
      (f32.const 10)
     )
    )
    (i32.add
     (local.get $2)
     (i32.const 16)
    )
   )
  )
  (i32.store
   (local.get $2)
   (i32.add
    (local.get $2)
    (i32.const 32)
   )
  )
  (call $safe_printf
   (i32.const 1822)
   (local.get $2)
  )
  (global.set $__stack_pointer
   (i32.add
    (local.get $2)
    (i32.const 144)
   )
  )
 )
 (func $print_mem_size (param $0 i32)
  (local $1 i32)
  (local $2 f32)
  (global.set $__stack_pointer
   (local.tee $1
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 144)
    )
   )
  )
  (block $label$1
   (block $label$2
    (br_if $label$2
     (i32.gt_u
      (local.tee $0
       (i32.shl
        (local.get $0)
        (i32.const 2)
       )
      )
      (i32.const 1023)
     )
    )
    (local.set $2
     (f32.convert_i32_u
      (local.get $0)
     )
    )
    (local.set $0
     (i32.const 3908)
    )
    (br $label$1)
   )
   (local.set $2
    (f32.convert_i32_u
     (local.get $0)
    )
   )
   (block $label$3
    (br_if $label$3
     (i32.gt_u
      (local.get $0)
      (i32.const 1048575)
     )
    )
    (local.set $2
     (f32.mul
      (local.get $2)
      (f32.const 0.0009765625)
     )
    )
    (local.set $0
     (i32.const 3904)
    )
    (br $label$1)
   )
   (local.set $2
    (f32.mul
     (local.get $2)
     (f32.const 9.5367431640625e-07)
    )
   )
   (local.set $0
    (i32.const 3907)
   )
  )
  (i32.store offset=24
   (local.get $1)
   (local.get $0)
  )
  (f64.store offset=16
   (local.get $1)
   (f64.promote_f32
    (local.get $2)
   )
  )
  (drop
   (call $stbsp_snprintf
    (i32.add
     (local.get $1)
     (i32.const 32)
    )
    (i32.const 100)
    (select
     (i32.const 1808)
     (i32.const 1816)
     (f32.lt
      (local.get $2)
      (f32.const 10)
     )
    )
    (i32.add
     (local.get $1)
     (i32.const 16)
    )
   )
  )
  (i32.store
   (local.get $1)
   (i32.add
    (local.get $1)
    (i32.const 32)
   )
  )
  (call $safe_printf
   (i32.const 1822)
   (local.get $1)
  )
  (global.set $__stack_pointer
   (i32.add
    (local.get $1)
    (i32.const 144)
   )
  )
 )
 (func $pretty_print_child (param $0 i32) (param $1 i32)
  (local $2 i32)
  (local $3 i32)
  (global.set $__stack_pointer
   (local.tee $2
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 16)
    )
   )
  )
  (block $label$1
   (block $label$2
    (br_if $label$2
     (i32.lt_s
      (local.get $0)
      (i32.const 21)
     )
    )
    (call $safe_printf
     (i32.const 5619)
     (i32.const 0)
    )
    (br $label$1)
   )
   (i32.store
    (local.get $2)
    (local.get $1)
   )
   (call $safe_printf
    (i32.const 2058)
    (local.get $2)
   )
   (block $label$3
    (br_if $label$3
     (i32.lt_s
      (local.get $0)
      (i32.const 1)
     )
    )
    (local.set $3
     (local.get $0)
    )
    (loop $label$4
     (call $safe_printf
      (i32.const 4290)
      (i32.const 0)
     )
     (br_if $label$4
      (local.tee $3
       (i32.add
        (local.get $3)
        (i32.const -1)
       )
      )
     )
    )
   )
   (call $Debug_prettyHelp
    (local.get $0)
    (local.get $1)
   )
  )
  (global.set $__stack_pointer
   (i32.add
    (local.get $2)
    (i32.const 16)
   )
  )
 )
 (func $Debug_pretty_with_location (param $0 i32) (param $1 i32) (param $2 i32) (param $3 i32)
  (local $4 i32)
  (global.set $__stack_pointer
   (local.tee $4
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 80)
    )
   )
  )
  (i32.store8 offset=56
   (local.get $4)
   (i32.const 0)
  )
  (i64.store offset=48
   (local.get $4)
   (i64.const 3255307777713450285)
  )
  (i32.store offset=32
   (local.get $4)
   (i32.add
    (local.get $4)
    (i32.const 48)
   )
  )
  (call $safe_printf
   (i32.const 4182)
   (i32.add
    (local.get $4)
    (i32.const 32)
   )
  )
  (i32.store offset=24
   (local.get $4)
   (local.get $1)
  )
  (i32.store offset=20
   (local.get $4)
   (local.get $0)
  )
  (i32.store offset=16
   (local.get $4)
   (local.get $2)
  )
  (call $safe_printf
   (i32.const 5400)
   (i32.add
    (local.get $4)
    (i32.const 16)
   )
  )
  (i32.store
   (local.get $4)
   (local.get $3)
  )
  (call $safe_printf
   (i32.const 2058)
   (local.get $4)
  )
  (call $safe_printf
   (i32.const 4290)
   (i32.const 0)
  )
  (call $safe_printf
   (i32.const 4290)
   (i32.const 0)
  )
  (call $Debug_prettyHelp
   (i32.const 2)
   (local.get $3)
  )
  (global.set $__stack_pointer
   (i32.add
    (local.get $4)
    (i32.const 80)
   )
  )
 )
 (func $Debug_toStringHelp (param $0 i32) (param $1 i32) (param $2 i32)
  (local $3 i32)
  (local $4 i32)
  (local $5 i32)
  (local $6 i32)
  (local $7 i32)
  (local $8 i32)
  (local $9 i32)
  (local $10 f64)
  (local $11 i64)
  (global.set $__stack_pointer
   (local.tee $3
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 64)
    )
   )
  )
  (block $label$1
   (block $label$2
    (br_if $label$2
     (local.get $0)
    )
    (call $StringBuilder_copyAscii
     (local.get $2)
     (i32.const 4063)
    )
    (br $label$1)
   )
   (block $label$3
    (block $label$4
     (block $label$5
      (block $label$6
       (block $label$7
        (block $label$8
         (block $label$9
          (block $label$10
           (block $label$11
            (block $label$12
             (block $label$13
              (block $label$14
               (block $label$15
                (block $label$16
                 (block $label$17
                  (block $label$18
                   (block $label$19
                    (block $label$20
                     (br_table $label$20 $label$19 $label$18 $label$17 $label$16 $label$15 $label$14 $label$13 $label$12 $label$11 $label$10 $label$9 $label$8 $label$7 $label$6
                      (i32.shr_u
                       (local.tee $4
                        (i32.load
                         (local.get $1)
                        )
                       )
                       (i32.const 28)
                      )
                     )
                    )
                    (block $label$21
                     (block $label$22
                      (br_if $label$22
                       (i32.eqz
                        (f64.lt
                         (f64.abs
                          (local.tee $10
                           (f64.load offset=8
                            (local.get $1)
                           )
                          )
                         )
                         (f64.const 9223372036854775808)
                        )
                       )
                      )
                      (local.set $11
                       (i64.trunc_f64_s
                        (local.get $10)
                       )
                      )
                      (br $label$21)
                     )
                     (local.set $11
                      (i64.const -9223372036854775808)
                     )
                    )
                    (i64.store
                     (local.get $3)
                     (local.get $11)
                    )
                    (drop
                     (call $stbsp_snprintf
                      (i32.add
                       (local.get $3)
                       (i32.const 32)
                      )
                      (i32.const 25)
                      (i32.const 3209)
                      (local.get $3)
                     )
                    )
                    (call $StringBuilder_copyAscii
                     (local.get $2)
                     (i32.add
                      (local.get $3)
                      (i32.const 32)
                     )
                    )
                    (br $label$1)
                   )
                   (f64.store offset=16
                    (local.get $3)
                    (f64.load offset=8
                     (local.get $1)
                    )
                   )
                   (drop
                    (call $stbsp_snprintf
                     (i32.add
                      (local.get $3)
                      (i32.const 32)
                     )
                     (i32.const 25)
                     (i32.const 2634)
                     (i32.add
                      (local.get $3)
                      (i32.const 16)
                     )
                    )
                   )
                   (call $StringBuilder_copyAscii
                    (local.get $2)
                    (i32.add
                     (local.get $3)
                     (i32.const 32)
                    )
                   )
                   (br $label$1)
                  )
                  (local.set $5
                   (i32.load16_u offset=4
                    (local.get $1)
                   )
                  )
                  (call $StringBuilder_ensureSpace
                   (local.get $2)
                   (select
                    (i32.const 4)
                    (i32.const 3)
                    (local.tee $4
                     (i32.load16_u offset=6
                      (local.get $1)
                     )
                    )
                   )
                  )
                  (i32.store16 offset=2
                   (local.tee $1
                    (i32.load offset=8
                     (local.get $2)
                    )
                   )
                   (local.get $5)
                  )
                  (i32.store16
                   (local.get $1)
                   (i32.const 39)
                  )
                  (block $label$23
                   (block $label$24
                    (br_if $label$24
                     (local.get $4)
                    )
                    (local.set $1
                     (i32.add
                      (local.get $1)
                      (i32.const 4)
                     )
                    )
                    (br $label$23)
                   )
                   (i32.store16 offset=4
                    (local.get $1)
                    (local.get $4)
                   )
                   (local.set $1
                    (i32.add
                     (local.get $1)
                     (i32.const 6)
                    )
                   )
                  )
                  (i32.store16
                   (local.get $1)
                   (i32.const 39)
                  )
                  (i32.store offset=8
                   (local.get $2)
                   (i32.add
                    (local.get $1)
                    (i32.const 2)
                   )
                  )
                  (br $label$1)
                 )
                 (local.set $6
                  (i32.add
                   (local.get $1)
                   (i32.const 4)
                  )
                 )
                 (local.set $4
                  (i32.add
                   (i32.shl
                    (i32.and
                     (local.get $4)
                     (i32.const 268435455)
                    )
                    (i32.const 2)
                   )
                   (i32.const -2)
                  )
                 )
                 (block $label$25
                  (loop $label$26
                   (local.set $5
                    (i32.add
                     (local.get $4)
                     (i32.const -2)
                    )
                   )
                   (br_if $label$25
                    (i32.load16_u
                     (local.tee $0
                      (i32.add
                       (local.get $1)
                       (local.get $4)
                      )
                     )
                    )
                   )
                   (local.set $4
                    (local.get $5)
                   )
                   (br_if $label$26
                    (i32.ge_u
                     (local.get $0)
                     (local.get $6)
                    )
                   )
                  )
                 )
                 (call $StringBuilder_ensureSpace
                  (local.get $2)
                  (i32.add
                   (local.tee $0
                    (i32.shr_s
                     (local.get $5)
                     (i32.const 1)
                    )
                   )
                   (i32.const 2)
                  )
                 )
                 (i32.store16
                  (local.tee $7
                   (i32.load offset=8
                    (local.get $2)
                   )
                  )
                  (i32.const 34)
                 )
                 (local.set $4
                  (i32.add
                   (local.get $7)
                   (i32.const 2)
                  )
                 )
                 (br_if $label$3
                  (i32.eqz
                   (local.get $5)
                  )
                 )
                 (local.set $6
                  (i32.and
                   (local.tee $5
                    (select
                     (local.get $0)
                     (i32.const 1)
                     (i32.gt_u
                      (local.get $0)
                      (i32.const 1)
                     )
                    )
                   )
                   (i32.const 3)
                  )
                 )
                 (block $label$27
                  (br_if $label$27
                   (i32.ge_u
                    (i32.add
                     (local.get $5)
                     (i32.const -1)
                    )
                    (i32.const 3)
                   )
                  )
                  (local.set $8
                   (i32.const 0)
                  )
                  (br $label$4)
                 )
                 (local.set $9
                  (i32.and
                   (local.get $5)
                   (i32.const -4)
                  )
                 )
                 (local.set $4
                  (i32.const 0)
                 )
                 (local.set $8
                  (i32.const 0)
                 )
                 (loop $label$28
                  (i32.store16
                   (i32.add
                    (local.tee $5
                     (i32.add
                      (local.get $7)
                      (local.get $4)
                     )
                    )
                    (i32.const 2)
                   )
                   (i32.load16_u
                    (i32.add
                     (local.tee $0
                      (i32.add
                       (local.get $1)
                       (local.get $4)
                      )
                     )
                     (i32.const 4)
                    )
                   )
                  )
                  (i32.store16
                   (i32.add
                    (local.get $5)
                    (i32.const 4)
                   )
                   (i32.load16_u
                    (i32.add
                     (local.get $0)
                     (i32.const 6)
                    )
                   )
                  )
                  (i32.store16
                   (i32.add
                    (local.get $5)
                    (i32.const 6)
                   )
                   (i32.load16_u
                    (i32.add
                     (local.get $0)
                     (i32.const 8)
                    )
                   )
                  )
                  (i32.store16
                   (i32.add
                    (local.get $5)
                    (i32.const 8)
                   )
                   (i32.load16_u
                    (i32.add
                     (local.get $0)
                     (i32.const 10)
                    )
                   )
                  )
                  (local.set $4
                   (i32.add
                    (local.get $4)
                    (i32.const 8)
                   )
                  )
                  (br_if $label$28
                   (i32.ne
                    (local.get $9)
                    (local.tee $8
                     (i32.add
                      (local.get $8)
                      (i32.const 4)
                     )
                    )
                   )
                  )
                  (br $label$5)
                 )
                )
                (call $StringBuilder_writeChar
                 (local.get $2)
                 (i32.const 91)
                )
                (block $label$29
                 (br_if $label$29
                  (i32.eq
                   (i32.load offset=7844
                    (i32.const 0)
                   )
                   (local.get $1)
                  )
                 )
                 (local.set $0
                  (i32.add
                   (local.get $0)
                   (i32.const -1)
                  )
                 )
                 (loop $label$30
                  (call $Debug_toStringHelp
                   (local.get $0)
                   (i32.load offset=4
                    (local.get $1)
                   )
                   (local.get $2)
                  )
                  (block $label$31
                   (br_if $label$31
                    (i32.eq
                     (local.tee $4
                      (i32.load offset=8
                       (local.get $1)
                      )
                     )
                     (local.tee $5
                      (i32.load offset=7844
                       (i32.const 0)
                      )
                     )
                    )
                   )
                   (call $StringBuilder_writeChar
                    (local.get $2)
                    (i32.const 44)
                   )
                   (local.set $5
                    (i32.load offset=7844
                     (i32.const 0)
                    )
                   )
                   (local.set $4
                    (i32.load offset=8
                     (local.get $1)
                    )
                   )
                  )
                  (local.set $1
                   (local.get $4)
                  )
                  (br_if $label$30
                   (i32.ne
                    (local.get $5)
                    (local.get $4)
                   )
                  )
                 )
                )
                (call $StringBuilder_writeChar
                 (local.get $2)
                 (i32.const 93)
                )
                (br $label$1)
               )
               (call $StringBuilder_writeChar
                (local.get $2)
                (i32.const 40)
               )
               (call $Debug_toStringHelp
                (local.tee $4
                 (i32.add
                  (local.get $0)
                  (i32.const -1)
                 )
                )
                (i32.load offset=4
                 (local.get $1)
                )
                (local.get $2)
               )
               (call $StringBuilder_writeChar
                (local.get $2)
                (i32.const 44)
               )
               (call $Debug_toStringHelp
                (local.get $4)
                (i32.load offset=8
                 (local.get $1)
                )
                (local.get $2)
               )
               (call $StringBuilder_writeChar
                (local.get $2)
                (i32.const 41)
               )
               (br $label$1)
              )
              (call $StringBuilder_writeChar
               (local.get $2)
               (i32.const 40)
              )
              (call $Debug_toStringHelp
               (local.tee $4
                (i32.add
                 (local.get $0)
                 (i32.const -1)
                )
               )
               (i32.load offset=4
                (local.get $1)
               )
               (local.get $2)
              )
              (call $StringBuilder_writeChar
               (local.get $2)
               (i32.const 44)
              )
              (call $Debug_toStringHelp
               (local.get $4)
               (i32.load offset=8
                (local.get $1)
               )
               (local.get $2)
              )
              (call $StringBuilder_writeChar
               (local.get $2)
               (i32.const 44)
              )
              (call $Debug_toStringHelp
               (local.get $4)
               (i32.load offset=12
                (local.get $1)
               )
               (local.get $2)
              )
              (call $StringBuilder_writeChar
               (local.get $2)
               (i32.const 41)
              )
              (br $label$1)
             )
             (block $label$32
              (br_if $label$32
               (i32.ne
                (local.get $1)
                (i32.const 8532)
               )
              )
              (call $StringBuilder_copyAscii
               (local.get $2)
               (i32.const 2821)
              )
              (br $label$1)
             )
             (block $label$33
              (br_if $label$33
               (i32.ne
                (local.get $1)
                (i32.const 8540)
               )
              )
              (call $StringBuilder_copyAscii
               (local.get $2)
               (i32.const 2870)
              )
              (br $label$1)
             )
             (block $label$34
              (br_if $label$34
               (i32.ne
                (local.get $1)
                (i32.const 8524)
               )
              )
              (call $StringBuilder_copyAscii
               (local.get $2)
               (i32.const 4093)
              )
              (br $label$1)
             )
             (block $label$35
              (block $label$36
               (br_if $label$36
                (i32.ge_u
                 (local.tee $4
                  (i32.load offset=4
                   (local.get $1)
                  )
                 )
                 (i32.load
                  (i32.const 0)
                 )
                )
               )
               (local.set $4
                (i32.add
                 (i32.load
                  (i32.add
                   (i32.const 0)
                   (i32.shl
                    (local.get $4)
                    (i32.const 2)
                   )
                  )
                 )
                 (i32.const 5)
                )
               )
               (br $label$35)
              )
              (local.set $4
               (select
                (i32.const 3936)
                (select
                 (i32.const 3910)
                 (i32.const 3960)
                 (i32.eq
                  (local.get $4)
                  (i32.const 81920003)
                 )
                )
                (i32.eq
                 (local.get $4)
                 (i32.const 81920002)
                )
               )
              )
             )
             (call $StringBuilder_copyAscii
              (local.get $2)
              (local.get $4)
             )
             (call $StringBuilder_writeChar
              (local.get $2)
              (i32.const 32)
             )
             (br_if $label$1
              (i32.lt_u
               (local.tee $4
                (i32.and
                 (i32.load
                  (local.get $1)
                 )
                 (i32.const 268435455)
                )
               )
               (i32.const 3)
              )
             )
             (local.set $4
              (i32.sub
               (i32.const 3)
               (local.get $4)
              )
             )
             (local.set $1
              (i32.add
               (local.get $1)
               (i32.const 8)
              )
             )
             (local.set $5
              (i32.add
               (local.get $0)
               (i32.const -1)
              )
             )
             (loop $label$37
              (call $Debug_toStringHelp
               (local.get $5)
               (i32.load
                (local.get $1)
               )
               (local.get $2)
              )
              (block $label$38
               (br_if $label$38
                (i32.eqz
                 (local.get $4)
                )
               )
               (call $StringBuilder_writeChar
                (local.get $2)
                (i32.const 32)
               )
              )
              (local.set $1
               (i32.add
                (local.get $1)
                (i32.const 4)
               )
              )
              (br_if $label$37
               (i32.ne
                (local.tee $4
                 (i32.add
                  (local.get $4)
                  (i32.const 1)
                 )
                )
                (i32.const 1)
               )
              )
              (br $label$1)
             )
            )
            (local.set $4
             (i32.load offset=4
              (local.tee $5
               (i32.load offset=4
                (local.get $1)
               )
              )
             )
            )
            (call $StringBuilder_writeChar
             (local.get $2)
             (i32.const 123)
            )
            (br_if $label$1
             (i32.eqz
              (local.get $4)
             )
            )
            (local.set $5
             (i32.add
              (local.get $5)
              (i32.const 8)
             )
            )
            (local.set $1
             (i32.add
              (local.get $1)
              (i32.const 8)
             )
            )
            (local.set $0
             (i32.add
              (local.get $0)
              (i32.const -1)
             )
            )
            (loop $label$39
             (call $StringBuilder_copyAscii
              (local.get $2)
              (i32.load
               (i32.add
                (i32.const 0)
                (i32.shl
                 (i32.load
                  (local.get $5)
                 )
                 (i32.const 2)
                )
               )
              )
             )
             (call $StringBuilder_copyAscii
              (local.get $2)
              (i32.const 4289)
             )
             (call $Debug_toStringHelp
              (local.get $0)
              (i32.load
               (local.get $1)
              )
              (local.get $2)
             )
             (block $label$40
              (br_if $label$40
               (i32.eq
                (local.get $4)
                (i32.const 1)
               )
              )
              (call $StringBuilder_writeChar
               (local.get $2)
               (i32.const 44)
              )
             )
             (local.set $5
              (i32.add
               (local.get $5)
               (i32.const 4)
              )
             )
             (local.set $1
              (i32.add
               (local.get $1)
               (i32.const 4)
              )
             )
             (br_if $label$39
              (local.tee $4
               (i32.add
                (local.get $4)
                (i32.const -1)
               )
              )
             )
             (br $label$1)
            )
           )
           (call $StringBuilder_copyAscii
            (local.get $2)
            (i32.const 3975)
           )
           (br $label$1)
          )
          (call $StringBuilder_copyAscii
           (local.get $2)
           (i32.const 3998)
          )
          (br $label$1)
         )
         (call $StringBuilder_copyAscii
          (local.get $2)
          (i32.const 3923)
         )
         (br $label$1)
        )
        (call $StringBuilder_copyAscii
         (local.get $2)
         (i32.const 3950)
        )
        (br $label$1)
       )
       (call $StringBuilder_copyAscii
        (local.get $2)
        (i32.const 4009)
       )
       (br $label$1)
      )
      (call $StringBuilder_copyAscii
       (local.get $2)
       (i32.const 3988)
      )
      (br $label$1)
     )
     (local.set $4
      (i32.add
       (local.tee $7
        (i32.add
         (local.get $7)
         (local.get $4)
        )
       )
       (i32.const 2)
      )
     )
    )
    (br_if $label$3
     (i32.eqz
      (local.get $6)
     )
    )
    (local.set $1
     (i32.add
      (i32.add
       (i32.shl
        (local.get $8)
        (i32.const 1)
       )
       (local.get $1)
      )
      (i32.const 4)
     )
    )
    (loop $label$41
     (i32.store16
      (local.get $4)
      (i32.load16_u
       (local.get $1)
      )
     )
     (local.set $1
      (i32.add
       (local.get $1)
       (i32.const 2)
      )
     )
     (local.set $4
      (i32.add
       (local.get $4)
       (i32.const 2)
      )
     )
     (br_if $label$41
      (local.tee $6
       (i32.add
        (local.get $6)
        (i32.const -1)
       )
      )
     )
    )
    (local.set $7
     (i32.add
      (local.get $4)
      (i32.const -2)
     )
    )
   )
   (i32.store16
    (local.get $4)
    (i32.const 34)
   )
   (i32.store offset=8
    (local.get $2)
    (i32.add
     (local.get $7)
     (i32.const 4)
    )
   )
  )
  (global.set $__stack_pointer
   (i32.add
    (local.get $3)
    (i32.const 64)
   )
  )
 )
 (func $StringBuilder_copyAscii (param $0 i32) (param $1 i32)
  (local $2 i32)
  (local $3 i32)
  (local $4 i32)
  (local $5 i32)
  (local.set $2
   (i32.load offset=8
    (local.get $0)
   )
  )
  (block $label$1
   (br_if $label$1
    (local.tee $3
     (i32.load8_u
      (local.get $1)
     )
    )
   )
   (i32.store offset=8
    (local.get $0)
    (local.get $2)
   )
   (return)
  )
  (local.set $4
   (i32.load offset=12
    (local.get $0)
   )
  )
  (local.set $5
   (local.get $2)
  )
  (loop $label$2
   (block $label$3
    (br_if $label$3
     (i32.lt_u
      (local.get $5)
      (local.get $4)
     )
    )
    (i32.store
     (local.tee $3
      (i32.load offset=4
       (i32.load offset=4
        (local.get $0)
       )
      )
     )
     (i32.or
      (local.tee $4
       (i32.and
        (i32.shr_u
         (i32.add
          (local.tee $5
           (i32.sub
            (local.get $2)
            (local.get $3)
           )
          )
          (i32.const 3)
         )
         (i32.const 2)
        )
        (i32.const 268435455)
       )
      )
      (i32.and
       (i32.load
        (local.get $3)
       )
       (i32.const -268435456)
      )
     )
    )
    (local.set $2
     (i32.add
      (local.get $5)
      (i32.const -4)
     )
    )
    (block $label$4
     (br_if $label$4
      (i32.ge_u
       (local.tee $5
        (i32.load offset=8
         (local.get $0)
        )
       )
       (local.tee $3
        (i32.add
         (local.get $3)
         (i32.shl
          (local.get $4)
          (i32.const 2)
         )
        )
       )
      )
     )
     (loop $label$5
      (i32.store16
       (local.get $5)
       (i32.const 0)
      )
      (br_if $label$5
       (i32.lt_u
        (local.tee $5
         (i32.add
          (local.get $5)
          (i32.const 2)
         )
        )
        (local.get $3)
       )
      )
     )
    )
    (drop
     (call $GC_allocate
      (i32.const 0)
      (i32.sub
       (i32.const 1)
       (i32.shr_s
        (i32.sub
         (i32.load offset=12
          (local.get $0)
         )
         (local.get $3)
        )
        (i32.const 2)
       )
      )
     )
    )
    (i32.store offset=16
     (local.get $0)
     (i32.add
      (i32.load offset=16
       (local.get $0)
      )
      (i32.shr_s
       (local.get $2)
       (i32.const 1)
      )
     )
    )
    (i64.store align=4
     (local.tee $3
      (call $GC_allocate
       (i32.const 1)
       (i32.const 3)
      )
     )
     (i64.const 1073741827)
    )
    (i32.store offset=8
     (local.get $3)
     (i32.const 8512)
    )
    (i32.store offset=8
     (i32.load offset=4
      (local.get $0)
     )
     (local.get $3)
    )
    (i32.store
     (local.tee $5
      (call $GC_allocate
       (i32.const 1)
       (i32.const 1)
      )
     )
     (i32.const 805306369)
    )
    (drop
     (call $GC_allocate
      (i32.const 0)
      (i32.add
       (i32.shr_s
        (i32.sub
         (local.tee $4
          (i32.load offset=8776
           (i32.const 0)
          )
         )
         (i32.load offset=8772
          (i32.const 0)
         )
        )
        (i32.const 2)
       )
       (i32.const -1)
      )
     )
    )
    (i32.store
     (local.get $5)
     (i32.or
      (i32.and
       (i32.load
        (local.get $5)
       )
       (i32.const -268435456)
      )
      (i32.and
       (i32.shr_u
        (i32.sub
         (local.get $4)
         (local.get $5)
        )
        (i32.const 2)
       )
       (i32.const 268435455)
      )
     )
    )
    (i32.store offset=12
     (local.get $0)
     (local.get $4)
    )
    (i32.store offset=8
     (local.get $0)
     (local.tee $2
      (i32.add
       (local.get $5)
       (i32.const 4)
      )
     )
    )
    (i32.store offset=4
     (local.get $0)
     (local.get $3)
    )
    (i32.store offset=4
     (local.get $3)
     (local.get $5)
    )
    (local.set $3
     (i32.load8_u
      (local.get $1)
     )
    )
    (local.set $5
     (local.get $2)
    )
   )
   (i32.store16
    (local.get $5)
    (i32.shr_s
     (i32.shl
      (local.get $3)
      (i32.const 24)
     )
     (i32.const 24)
    )
   )
   (local.set $5
    (i32.add
     (local.get $5)
     (i32.const 2)
    )
   )
   (local.set $3
    (i32.load8_u offset=1
     (local.get $1)
    )
   )
   (local.set $1
    (i32.add
     (local.get $1)
     (i32.const 1)
    )
   )
   (br_if $label$2
    (local.get $3)
   )
  )
  (i32.store offset=8
   (local.get $0)
   (local.get $5)
  )
 )
 (func $StringBuilder_ensureSpace (param $0 i32) (param $1 i32)
  (local $2 i32)
  (local $3 i32)
  (local $4 i32)
  (local $5 i32)
  (block $label$1
   (br_if $label$1
    (i32.ge_u
     (i32.shr_s
      (i32.sub
       (i32.load offset=12
        (local.get $0)
       )
       (local.tee $2
        (i32.load offset=8
         (local.get $0)
        )
       )
      )
      (i32.const 1)
     )
     (local.get $1)
    )
   )
   (i32.store
    (local.tee $3
     (i32.load offset=4
      (i32.load offset=4
       (local.get $0)
      )
     )
    )
    (i32.or
     (local.tee $4
      (i32.and
       (i32.shr_u
        (i32.add
         (local.tee $2
          (i32.sub
           (local.get $2)
           (local.get $3)
          )
         )
         (i32.const 3)
        )
        (i32.const 2)
       )
       (i32.const 268435455)
      )
     )
     (i32.and
      (i32.load
       (local.get $3)
      )
      (i32.const -268435456)
     )
    )
   )
   (local.set $5
    (i32.add
     (local.get $2)
     (i32.const -4)
    )
   )
   (block $label$2
    (br_if $label$2
     (i32.ge_u
      (local.tee $2
       (i32.load offset=8
        (local.get $0)
       )
      )
      (local.tee $3
       (i32.add
        (local.get $3)
        (i32.shl
         (local.get $4)
         (i32.const 2)
        )
       )
      )
     )
    )
    (loop $label$3
     (i32.store16
      (local.get $2)
      (i32.const 0)
     )
     (br_if $label$3
      (i32.lt_u
       (local.tee $2
        (i32.add
         (local.get $2)
         (i32.const 2)
        )
       )
       (local.get $3)
      )
     )
    )
   )
   (drop
    (call $GC_allocate
     (i32.const 0)
     (i32.sub
      (i32.const 1)
      (i32.shr_s
       (i32.sub
        (i32.load offset=12
         (local.get $0)
        )
        (local.get $3)
       )
       (i32.const 2)
      )
     )
    )
   )
   (i32.store offset=16
    (local.get $0)
    (i32.add
     (i32.load offset=16
      (local.get $0)
     )
     (i32.shr_s
      (local.get $5)
      (i32.const 1)
     )
    )
   )
   (i64.store align=4
    (local.tee $3
     (call $GC_allocate
      (i32.const 1)
      (i32.const 3)
     )
    )
    (i64.const 1073741827)
   )
   (i32.store offset=8
    (local.get $3)
    (i32.const 8512)
   )
   (i32.store offset=8
    (i32.load offset=4
     (local.get $0)
    )
    (local.get $3)
   )
   (local.set $2
    (call $GC_allocate
     (i32.const 1)
     (local.tee $1
      (i32.shr_u
       (local.tee $5
        (i32.add
         (local.tee $4
          (i32.shl
           (select
            (local.get $1)
            (i32.const 512)
            (i32.gt_u
             (local.get $1)
             (i32.const 512)
            )
           )
           (i32.const 1)
          )
         )
         (i32.const 7)
        )
       )
       (i32.const 2)
      )
     )
    )
   )
   (block $label$4
    (br_if $label$4
     (i32.eq
      (i32.and
       (local.get $5)
       (i32.const -4)
      )
      (i32.add
       (local.get $4)
       (i32.const 4)
      )
     )
    )
    (i32.store
     (i32.add
      (i32.add
       (i32.shl
        (local.get $1)
        (i32.const 2)
       )
       (local.get $2)
      )
      (i32.const -4)
     )
     (i32.const 0)
    )
   )
   (i32.store
    (local.get $2)
    (i32.or
     (local.get $1)
     (i32.const 805306368)
    )
   )
   (drop
    (call $GC_allocate
     (i32.const 0)
     (i32.add
      (i32.shr_s
       (i32.sub
        (local.tee $1
         (i32.load offset=8776
          (i32.const 0)
         )
        )
        (i32.load offset=8772
         (i32.const 0)
        )
       )
       (i32.const 2)
      )
      (i32.const -1)
     )
    )
   )
   (i32.store
    (local.get $2)
    (i32.or
     (i32.and
      (i32.load
       (local.get $2)
      )
      (i32.const -268435456)
     )
     (i32.and
      (i32.shr_u
       (i32.sub
        (local.get $1)
        (local.get $2)
       )
       (i32.const 2)
      )
      (i32.const 268435455)
     )
    )
   )
   (i32.store offset=12
    (local.get $0)
    (local.get $1)
   )
   (i32.store offset=8
    (local.get $0)
    (i32.add
     (local.get $2)
     (i32.const 4)
    )
   )
   (i32.store offset=4
    (local.get $0)
    (local.get $3)
   )
   (i32.store offset=4
    (local.get $3)
    (local.get $2)
   )
  )
 )
 (func $StringBuilder_writeChar (param $0 i32) (param $1 i32)
  (local $2 i32)
  (local $3 i32)
  (local $4 i32)
  (local $5 i32)
  (block $label$1
   (br_if $label$1
    (i32.lt_u
     (local.tee $2
      (i32.load offset=8
       (local.get $0)
      )
     )
     (i32.load offset=12
      (local.get $0)
     )
    )
   )
   (i32.store
    (local.tee $3
     (i32.load offset=4
      (i32.load offset=4
       (local.get $0)
      )
     )
    )
    (i32.or
     (local.tee $4
      (i32.and
       (i32.shr_u
        (i32.add
         (local.tee $2
          (i32.sub
           (local.get $2)
           (local.get $3)
          )
         )
         (i32.const 3)
        )
        (i32.const 2)
       )
       (i32.const 268435455)
      )
     )
     (i32.and
      (i32.load
       (local.get $3)
      )
      (i32.const -268435456)
     )
    )
   )
   (local.set $5
    (i32.add
     (local.get $2)
     (i32.const -4)
    )
   )
   (block $label$2
    (br_if $label$2
     (i32.ge_u
      (local.tee $2
       (i32.load offset=8
        (local.get $0)
       )
      )
      (local.tee $3
       (i32.add
        (local.get $3)
        (i32.shl
         (local.get $4)
         (i32.const 2)
        )
       )
      )
     )
    )
    (loop $label$3
     (i32.store16
      (local.get $2)
      (i32.const 0)
     )
     (br_if $label$3
      (i32.lt_u
       (local.tee $2
        (i32.add
         (local.get $2)
         (i32.const 2)
        )
       )
       (local.get $3)
      )
     )
    )
   )
   (drop
    (call $GC_allocate
     (i32.const 0)
     (i32.sub
      (i32.const 1)
      (i32.shr_s
       (i32.sub
        (i32.load offset=12
         (local.get $0)
        )
        (local.get $3)
       )
       (i32.const 2)
      )
     )
    )
   )
   (i32.store offset=16
    (local.get $0)
    (i32.add
     (i32.load offset=16
      (local.get $0)
     )
     (i32.shr_s
      (local.get $5)
      (i32.const 1)
     )
    )
   )
   (i64.store align=4
    (local.tee $3
     (call $GC_allocate
      (i32.const 1)
      (i32.const 3)
     )
    )
    (i64.const 1073741827)
   )
   (i32.store offset=8
    (local.get $3)
    (i32.const 8512)
   )
   (i32.store offset=8
    (i32.load offset=4
     (local.get $0)
    )
    (local.get $3)
   )
   (i32.store
    (local.tee $2
     (call $GC_allocate
      (i32.const 1)
      (i32.const 1)
     )
    )
    (i32.const 805306369)
   )
   (drop
    (call $GC_allocate
     (i32.const 0)
     (i32.add
      (i32.shr_s
       (i32.sub
        (local.tee $4
         (i32.load offset=8776
          (i32.const 0)
         )
        )
        (i32.load offset=8772
         (i32.const 0)
        )
       )
       (i32.const 2)
      )
      (i32.const -1)
     )
    )
   )
   (i32.store
    (local.get $2)
    (i32.or
     (i32.and
      (i32.load
       (local.get $2)
      )
      (i32.const -268435456)
     )
     (i32.and
      (i32.shr_u
       (i32.sub
        (local.get $4)
        (local.get $2)
       )
       (i32.const 2)
      )
      (i32.const 268435455)
     )
    )
   )
   (i32.store offset=12
    (local.get $0)
    (local.get $4)
   )
   (i32.store offset=4
    (local.get $0)
    (local.get $3)
   )
   (i32.store offset=4
    (local.get $3)
    (local.get $2)
   )
   (local.set $2
    (i32.add
     (local.get $2)
     (i32.const 4)
    )
   )
  )
  (i32.store16
   (local.get $2)
   (local.get $1)
  )
  (i32.store offset=8
   (local.get $0)
   (i32.add
    (local.get $2)
    (i32.const 2)
   )
  )
 )
 (func $eval_Debug_toString (param $0 i32) (result i32)
  (local $1 i32)
  (local $2 i32)
  (local $3 i32)
  (local $4 i32)
  (global.set $__stack_pointer
   (local.tee $1
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 32)
    )
   )
  )
  (local.set $2
   (i32.load
    (local.get $0)
   )
  )
  (i32.store offset=8
   (local.tee $0
    (call $GC_allocate
     (i32.const 1)
     (i32.const 3)
    )
   )
   (i32.const 8512)
  )
  (i64.store align=4
   (local.get $0)
   (i64.const 1073741827)
  )
  (i32.store
   (i32.add
    (local.get $1)
    (i32.const 24)
   )
   (i32.const 0)
  )
  (i32.store offset=12
   (local.get $1)
   (local.get $0)
  )
  (i64.store align=4
   (local.tee $0
    (call $GC_allocate
     (i32.const 1)
     (i32.const 3)
    )
   )
   (i64.const 1073741827)
  )
  (i32.store offset=8
   (local.get $0)
   (i32.const 8512)
  )
  (i32.store offset=8
   (i32.load offset=12
    (local.get $1)
   )
   (local.get $0)
  )
  (i32.store
   (local.tee $3
    (call $GC_allocate
     (i32.const 1)
     (i32.const 257)
    )
   )
   (i32.const 805306625)
  )
  (drop
   (call $GC_allocate
    (i32.const 0)
    (i32.add
     (i32.shr_s
      (i32.sub
       (local.tee $4
        (i32.load offset=8776
         (i32.const 0)
        )
       )
       (i32.load offset=8772
        (i32.const 0)
       )
      )
      (i32.const 2)
     )
     (i32.const -1)
    )
   )
  )
  (i32.store
   (local.get $3)
   (i32.or
    (i32.and
     (i32.load
      (local.get $3)
     )
     (i32.const -268435456)
    )
    (i32.and
     (i32.shr_u
      (i32.sub
       (local.get $4)
       (local.get $3)
      )
      (i32.const 2)
     )
     (i32.const 268435455)
    )
   )
  )
  (i32.store offset=4
   (local.get $0)
   (local.get $3)
  )
  (i32.store offset=20
   (local.get $1)
   (local.get $4)
  )
  (i32.store offset=16
   (local.get $1)
   (i32.add
    (local.get $3)
    (i32.const 4)
   )
  )
  (i32.store offset=12
   (local.get $1)
   (local.get $0)
  )
  (i32.store offset=8
   (local.get $1)
   (local.get $0)
  )
  (call $Debug_toStringHelp
   (i32.const 5)
   (local.get $2)
   (i32.add
    (local.get $1)
    (i32.const 8)
   )
  )
  (local.set $0
   (call $StringBuilder_toString
    (i32.add
     (local.get $1)
     (i32.const 8)
    )
   )
  )
  (global.set $__stack_pointer
   (i32.add
    (local.get $1)
    (i32.const 32)
   )
  )
  (local.get $0)
 )
 (func $StringBuilder_toString (param $0 i32) (result i32)
  (local $1 i32)
  (local $2 i32)
  (local $3 i32)
  (local $4 i32)
  (local $5 i32)
  (local $6 i32)
  (local $7 i32)
  (local $8 i32)
  (local $9 i64)
  (i32.store
   (local.tee $1
    (i32.load offset=4
     (i32.load offset=4
      (local.get $0)
     )
    )
   )
   (i32.or
    (local.tee $3
     (i32.and
      (i32.shr_u
       (i32.add
        (local.tee $2
         (i32.sub
          (i32.load offset=8
           (local.get $0)
          )
          (local.get $1)
         )
        )
        (i32.const 3)
       )
       (i32.const 2)
      )
      (i32.const 268435455)
     )
    )
    (i32.and
     (i32.load
      (local.get $1)
     )
     (i32.const -268435456)
    )
   )
  )
  (local.set $4
   (i32.add
    (local.get $2)
    (i32.const -4)
   )
  )
  (block $label$1
   (br_if $label$1
    (i32.ge_u
     (local.tee $2
      (i32.load offset=8
       (local.get $0)
      )
     )
     (local.tee $1
      (i32.add
       (local.get $1)
       (i32.shl
        (local.get $3)
        (i32.const 2)
       )
      )
     )
    )
   )
   (loop $label$2
    (i32.store16
     (local.get $2)
     (i32.const 0)
    )
    (br_if $label$2
     (i32.lt_u
      (local.tee $2
       (i32.add
        (local.get $2)
        (i32.const 2)
       )
      )
      (local.get $1)
     )
    )
   )
  )
  (drop
   (call $GC_allocate
    (i32.const 0)
    (i32.sub
     (i32.const 1)
     (i32.shr_s
      (i32.sub
       (i32.load offset=12
        (local.get $0)
       )
       (local.get $1)
      )
      (i32.const 2)
     )
    )
   )
  )
  (i32.store offset=16
   (local.get $0)
   (local.tee $2
    (i32.add
     (i32.load offset=16
      (local.get $0)
     )
     (i32.shr_s
      (local.get $4)
      (i32.const 1)
     )
    )
   )
  )
  (block $label$3
   (br_if $label$3
    (i32.ne
     (local.tee $1
      (i32.load
       (local.get $0)
      )
     )
     (i32.load offset=4
      (local.get $0)
     )
    )
   )
   (return
    (i32.load offset=4
     (local.get $1)
    )
   )
  )
  (local.set $5
   (call $GC_allocate
    (i32.const 1)
    (local.tee $2
     (i32.shr_u
      (local.tee $3
       (i32.add
        (local.tee $1
         (i32.shl
          (local.get $2)
          (i32.const 1)
         )
        )
        (i32.const 7)
       )
      )
      (i32.const 2)
     )
    )
   )
  )
  (block $label$4
   (br_if $label$4
    (i32.eq
     (i32.and
      (local.get $3)
      (i32.const -4)
     )
     (i32.add
      (local.get $1)
      (i32.const 4)
     )
    )
   )
   (i32.store
    (i32.add
     (i32.add
      (i32.shl
       (local.get $2)
       (i32.const 2)
      )
      (local.get $5)
     )
     (i32.const -4)
    )
    (i32.const 0)
   )
  )
  (i32.store
   (local.get $5)
   (i32.or
    (local.get $2)
    (i32.const 805306368)
   )
  )
  (block $label$5
   (br_if $label$5
    (i32.eq
     (local.tee $6
      (i32.load
       (local.get $0)
      )
     )
     (local.tee $7
      (i32.load offset=7844
       (i32.const 0)
      )
     )
    )
   )
   (local.set $0
    (i32.add
     (local.get $5)
     (i32.const 4)
    )
   )
   (loop $label$6
    (local.set $2
     (i32.add
      (local.tee $8
       (i32.load offset=4
        (local.get $6)
       )
      )
      (i32.const 4)
     )
    )
    (local.set $1
     (i32.add
      (i32.shl
       (i32.and
        (i32.load
         (local.get $8)
        )
        (i32.const 268435455)
       )
       (i32.const 2)
      )
      (i32.const -2)
     )
    )
    (block $label$7
     (loop $label$8
      (local.set $3
       (i32.add
        (local.get $1)
        (i32.const -2)
       )
      )
      (br_if $label$7
       (i32.load16_u
        (local.tee $4
         (i32.add
          (local.get $8)
          (local.get $1)
         )
        )
       )
      )
      (local.set $1
       (local.get $3)
      )
      (br_if $label$8
       (i32.ge_u
        (local.get $4)
        (local.get $2)
       )
      )
     )
    )
    (local.set $4
     (i32.add
      (i32.add
       (local.get $8)
       (local.get $3)
      )
      (i32.const 4)
     )
    )
    (block $label$9
     (br_if $label$9
      (i32.eqz
       (i32.and
        (local.get $0)
        (i32.const 7)
       )
      )
     )
     (br_if $label$9
      (i32.lt_s
       (local.get $3)
       (i32.const 1)
      )
     )
     (local.set $1
      (i32.add
       (local.get $0)
       (i32.const 2)
      )
     )
     (loop $label$10
      (br_if $label$9
       (i32.eqz
        (local.tee $3
         (i32.load16_u
          (local.get $2)
         )
        )
       )
      )
      (i32.store16
       (local.get $0)
       (local.get $3)
      )
      (local.set $2
       (i32.add
        (local.get $2)
        (i32.const 2)
       )
      )
      (local.set $0
       (i32.add
        (local.get $0)
        (i32.const 2)
       )
      )
      (br_if $label$9
       (i32.eqz
        (i32.and
         (local.get $1)
         (i32.const 7)
        )
       )
      )
      (local.set $1
       (i32.add
        (local.get $1)
        (i32.const 2)
       )
      )
      (br_if $label$10
       (i32.lt_u
        (local.get $2)
        (local.get $4)
       )
      )
     )
    )
    (block $label$11
     (br_if $label$11
      (i32.le_u
       (local.tee $1
        (i32.add
         (local.get $2)
         (i32.shl
          (i32.div_s
           (i32.shr_s
            (i32.sub
             (local.get $4)
             (local.get $2)
            )
            (i32.const 1)
           )
           (i32.const 4)
          )
          (i32.const 3)
         )
        )
       )
       (local.get $2)
      )
     )
     (loop $label$12
      (br_if $label$11
       (i64.eqz
        (local.tee $9
         (i64.load
          (local.get $2)
         )
        )
       )
      )
      (i64.store
       (local.get $0)
       (local.get $9)
      )
      (local.set $0
       (i32.add
        (local.get $0)
        (i32.const 8)
       )
      )
      (br_if $label$12
       (i32.lt_u
        (local.tee $2
         (i32.add
          (local.get $2)
          (i32.const 8)
         )
        )
        (local.get $1)
       )
      )
     )
    )
    (block $label$13
     (br_if $label$13
      (i32.le_u
       (local.get $4)
       (local.get $2)
      )
     )
     (loop $label$14
      (br_if $label$13
       (i32.eqz
        (local.tee $1
         (i32.load16_u
          (local.get $2)
         )
        )
       )
      )
      (i32.store16
       (local.get $0)
       (local.get $1)
      )
      (local.set $0
       (i32.add
        (local.get $0)
        (i32.const 2)
       )
      )
      (br_if $label$14
       (i32.lt_u
        (local.tee $2
         (i32.add
          (local.get $2)
          (i32.const 2)
         )
        )
        (local.get $4)
       )
      )
     )
    )
    (br_if $label$6
     (i32.ne
      (local.tee $6
       (i32.load offset=8
        (local.get $6)
       )
      )
      (local.get $7)
     )
    )
   )
  )
  (local.get $5)
 )
 (func $StringBuilder_init (param $0 i32)
  (local $1 i32)
  (local $2 i32)
  (local $3 i32)
  (i32.store offset=8
   (local.tee $1
    (call $GC_allocate
     (i32.const 1)
     (i32.const 3)
    )
   )
   (i32.const 8512)
  )
  (i64.store align=4
   (local.get $1)
   (i64.const 1073741827)
  )
  (i64.store offset=8 align=4
   (local.get $0)
   (i64.const 0)
  )
  (i32.store offset=4
   (local.get $0)
   (local.get $1)
  )
  (i32.store
   (local.get $0)
   (i32.const 0)
  )
  (i32.store
   (i32.add
    (local.get $0)
    (i32.const 16)
   )
   (i32.const 0)
  )
  (i64.store align=4
   (local.tee $1
    (call $GC_allocate
     (i32.const 1)
     (i32.const 3)
    )
   )
   (i64.const 1073741827)
  )
  (i32.store offset=8
   (local.get $1)
   (i32.const 8512)
  )
  (i32.store offset=8
   (i32.load offset=4
    (local.get $0)
   )
   (local.get $1)
  )
  (i32.store
   (local.tee $2
    (call $GC_allocate
     (i32.const 1)
     (i32.const 257)
    )
   )
   (i32.const 805306625)
  )
  (drop
   (call $GC_allocate
    (i32.const 0)
    (i32.add
     (i32.shr_s
      (i32.sub
       (local.tee $3
        (i32.load offset=8776
         (i32.const 0)
        )
       )
       (i32.load offset=8772
        (i32.const 0)
       )
      )
      (i32.const 2)
     )
     (i32.const -1)
    )
   )
  )
  (i32.store
   (local.get $2)
   (i32.or
    (i32.and
     (i32.load
      (local.get $2)
     )
     (i32.const -268435456)
    )
    (i32.and
     (i32.shr_u
      (i32.sub
       (local.get $3)
       (local.get $2)
      )
      (i32.const 2)
     )
     (i32.const 268435455)
    )
   )
  )
  (i32.store offset=12
   (local.get $0)
   (local.get $3)
  )
  (i32.store offset=8
   (local.get $0)
   (i32.add
    (local.get $2)
    (i32.const 4)
   )
  )
  (i32.store offset=4
   (local.get $0)
   (local.get $1)
  )
  (i32.store offset=4
   (local.get $1)
   (local.get $2)
  )
  (i32.store
   (local.get $0)
   (local.get $1)
  )
 )
 (func $eval_Debug_log (param $0 i32) (result i32)
  (local $1 i32)
  (local $2 i32)
  (local $3 i32)
  (local $4 i32)
  (local $5 i32)
  (local $6 i32)
  (local $7 i32)
  (global.set $__stack_pointer
   (local.tee $1
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 32)
    )
   )
  )
  (local.set $3
   (i32.add
    (local.tee $2
     (i32.load
      (local.get $0)
     )
    )
    (i32.const 4)
   )
  )
  (local.set $4
   (i32.add
    (i32.shl
     (i32.and
      (i32.load
       (local.get $2)
      )
      (i32.const 268435455)
     )
     (i32.const 2)
    )
    (i32.const -2)
   )
  )
  (local.set $5
   (i32.load offset=4
    (local.get $0)
   )
  )
  (block $label$1
   (loop $label$2
    (local.set $6
     (i32.add
      (local.get $4)
      (i32.const -2)
     )
    )
    (br_if $label$1
     (i32.load16_u
      (local.tee $7
       (i32.add
        (local.get $2)
        (local.get $4)
       )
      )
     )
    )
    (local.set $4
     (local.get $6)
    )
    (br_if $label$2
     (i32.ge_u
      (local.get $7)
      (local.get $3)
     )
    )
   )
  )
  (block $label$3
   (br_if $label$3
    (i32.eqz
     (local.get $6)
    )
   )
   (local.set $6
    (select
     (local.tee $4
      (i32.shr_s
       (local.get $6)
       (i32.const 1)
      )
     )
     (i32.const 1)
     (i32.gt_u
      (local.get $4)
      (i32.const 1)
     )
    )
   )
   (local.set $4
    (i32.add
     (local.get $2)
     (i32.const 4)
    )
   )
   (loop $label$4
    (drop
     (call $putchar
      (i32.load16_u
       (local.get $4)
      )
     )
    )
    (local.set $4
     (i32.add
      (local.get $4)
      (i32.const 2)
     )
    )
    (br_if $label$4
     (local.tee $6
      (i32.add
       (local.get $6)
       (i32.const -1)
      )
     )
    )
   )
  )
  (drop
   (call $putchar
    (i32.const 58)
   )
  )
  (drop
   (call $putchar
    (i32.const 32)
   )
  )
  (local.set $2
   (i32.load offset=4
    (local.get $0)
   )
  )
  (i32.store offset=8
   (local.tee $4
    (call $GC_allocate
     (i32.const 1)
     (i32.const 3)
    )
   )
   (i32.const 8512)
  )
  (i64.store align=4
   (local.get $4)
   (i64.const 1073741827)
  )
  (i32.store
   (i32.add
    (local.get $1)
    (i32.const 24)
   )
   (i32.const 0)
  )
  (i32.store offset=12
   (local.get $1)
   (local.get $4)
  )
  (i64.store align=4
   (local.tee $4
    (call $GC_allocate
     (i32.const 1)
     (i32.const 3)
    )
   )
   (i64.const 1073741827)
  )
  (i32.store offset=8
   (local.get $4)
   (i32.const 8512)
  )
  (i32.store offset=8
   (i32.load offset=12
    (local.get $1)
   )
   (local.get $4)
  )
  (i32.store
   (local.tee $6
    (call $GC_allocate
     (i32.const 1)
     (i32.const 257)
    )
   )
   (i32.const 805306625)
  )
  (drop
   (call $GC_allocate
    (i32.const 0)
    (i32.add
     (i32.shr_s
      (i32.sub
       (local.tee $7
        (i32.load offset=8776
         (i32.const 0)
        )
       )
       (i32.load offset=8772
        (i32.const 0)
       )
      )
      (i32.const 2)
     )
     (i32.const -1)
    )
   )
  )
  (i32.store
   (local.get $6)
   (i32.or
    (i32.and
     (i32.load
      (local.get $6)
     )
     (i32.const -268435456)
    )
    (i32.and
     (i32.shr_u
      (i32.sub
       (local.get $7)
       (local.get $6)
      )
      (i32.const 2)
     )
     (i32.const 268435455)
    )
   )
  )
  (i32.store offset=4
   (local.get $4)
   (local.get $6)
  )
  (i32.store offset=20
   (local.get $1)
   (local.get $7)
  )
  (i32.store offset=16
   (local.get $1)
   (i32.add
    (local.get $6)
    (i32.const 4)
   )
  )
  (i32.store offset=12
   (local.get $1)
   (local.get $4)
  )
  (i32.store offset=8
   (local.get $1)
   (local.get $4)
  )
  (call $Debug_toStringHelp
   (i32.const 5)
   (local.get $2)
   (i32.add
    (local.get $1)
    (i32.const 8)
   )
  )
  (local.set $3
   (i32.add
    (local.tee $2
     (call $StringBuilder_toString
      (i32.add
       (local.get $1)
       (i32.const 8)
      )
     )
    )
    (i32.const 4)
   )
  )
  (local.set $4
   (i32.add
    (i32.shl
     (i32.and
      (i32.load
       (local.get $2)
      )
      (i32.const 268435455)
     )
     (i32.const 2)
    )
    (i32.const -2)
   )
  )
  (block $label$5
   (loop $label$6
    (local.set $6
     (i32.add
      (local.get $4)
      (i32.const -2)
     )
    )
    (br_if $label$5
     (i32.load16_u
      (local.tee $7
       (i32.add
        (local.get $2)
        (local.get $4)
       )
      )
     )
    )
    (local.set $4
     (local.get $6)
    )
    (br_if $label$6
     (i32.ge_u
      (local.get $7)
      (local.get $3)
     )
    )
   )
  )
  (block $label$7
   (br_if $label$7
    (i32.eqz
     (local.get $6)
    )
   )
   (local.set $6
    (select
     (local.tee $4
      (i32.shr_s
       (local.get $6)
       (i32.const 1)
      )
     )
     (i32.const 1)
     (i32.gt_u
      (local.get $4)
      (i32.const 1)
     )
    )
   )
   (local.set $4
    (i32.add
     (local.get $2)
     (i32.const 4)
    )
   )
   (loop $label$8
    (drop
     (call $putchar
      (i32.load16_u
       (local.get $4)
      )
     )
    )
    (local.set $4
     (i32.add
      (local.get $4)
      (i32.const 2)
     )
    )
    (br_if $label$8
     (local.tee $6
      (i32.add
       (local.get $6)
       (i32.const -1)
      )
     )
    )
   )
  )
  (drop
   (call $putchar
    (i32.const 10)
   )
  )
  (global.set $__stack_pointer
   (i32.add
    (local.get $1)
    (i32.const 32)
   )
  )
  (local.get $5)
 )
 (func $eval_Debug_todo (param $0 i32) (result i32)
  (local $1 i32)
  (local $2 i32)
  (local $3 i32)
  (local $4 i32)
  (local.set $2
   (i32.add
    (local.tee $1
     (i32.load
      (local.get $0)
     )
    )
    (i32.const 4)
   )
  )
  (local.set $0
   (i32.add
    (i32.shl
     (i32.and
      (i32.load
       (local.get $1)
      )
      (i32.const 268435455)
     )
     (i32.const 2)
    )
    (i32.const -2)
   )
  )
  (block $label$1
   (loop $label$2
    (local.set $3
     (i32.add
      (local.get $0)
      (i32.const -2)
     )
    )
    (br_if $label$1
     (i32.load16_u
      (local.tee $4
       (i32.add
        (local.get $1)
        (local.get $0)
       )
      )
     )
    )
    (local.set $0
     (local.get $3)
    )
    (br_if $label$2
     (i32.ge_u
      (local.get $4)
      (local.get $2)
     )
    )
   )
  )
  (block $label$3
   (br_if $label$3
    (i32.eqz
     (local.get $3)
    )
   )
   (local.set $3
    (select
     (local.tee $0
      (i32.shr_s
       (local.get $3)
       (i32.const 1)
      )
     )
     (i32.const 1)
     (i32.gt_u
      (local.get $0)
      (i32.const 1)
     )
    )
   )
   (local.set $0
    (i32.add
     (local.get $1)
     (i32.const 4)
    )
   )
   (loop $label$4
    (drop
     (call $putchar
      (i32.load16_u
       (local.get $0)
      )
     )
    )
    (local.set $0
     (i32.add
      (local.get $0)
      (i32.const 2)
     )
    )
    (br_if $label$4
     (local.tee $3
      (i32.add
       (local.get $3)
       (i32.const -1)
      )
     )
    )
   )
  )
  (drop
   (call $putchar
    (i32.const 10)
   )
  )
  (call $exit
   (i32.const -1)
  )
  (i32.const 0)
 )
 (func $Debug_evaluator_name_core (param $0 i32) (result i32)
  (block $label$1
   (br_if $label$1
    (i32.ne
     (local.get $0)
     (i32.const 15)
    )
   )
   (return
    (i32.const 2857)
   )
  )
  (block $label$2
   (br_if $label$2
    (i32.ne
     (local.get $0)
     (i32.const 16)
    )
   )
   (return
    (i32.const 3280)
   )
  )
  (block $label$3
   (br_if $label$3
    (i32.ne
     (local.get $0)
     (i32.const 17)
    )
   )
   (return
    (i32.const 3628)
   )
  )
  (block $label$4
   (br_if $label$4
    (i32.ne
     (local.get $0)
     (i32.const 18)
    )
   )
   (return
    (i32.const 2270)
   )
  )
  (block $label$5
   (br_if $label$5
    (i32.ne
     (local.get $0)
     (i32.const 19)
    )
   )
   (return
    (i32.const 1333)
   )
  )
  (block $label$6
   (br_if $label$6
    (i32.ne
     (local.get $0)
     (i32.const 20)
    )
   )
   (return
    (i32.const 1328)
   )
  )
  (block $label$7
   (br_if $label$7
    (i32.ne
     (local.get $0)
     (i32.const 21)
    )
   )
   (return
    (i32.const 1315)
   )
  )
  (block $label$8
   (br_if $label$8
    (i32.ne
     (local.get $0)
     (i32.const 22)
    )
   )
   (return
    (i32.const 1634)
   )
  )
  (block $label$9
   (br_if $label$9
    (i32.ne
     (local.get $0)
     (i32.const 23)
    )
   )
   (return
    (i32.const 3074)
   )
  )
  (block $label$10
   (br_if $label$10
    (i32.ne
     (local.get $0)
     (i32.const 24)
    )
   )
   (return
    (i32.const 1862)
   )
  )
  (block $label$11
   (br_if $label$11
    (i32.ne
     (local.get $0)
     (i32.const 25)
    )
   )
   (return
    (i32.const 2556)
   )
  )
  (block $label$12
   (br_if $label$12
    (i32.ne
     (local.get $0)
     (i32.const 26)
    )
   )
   (return
    (i32.const 1439)
   )
  )
  (block $label$13
   (br_if $label$13
    (i32.ne
     (local.get $0)
     (i32.const 27)
    )
   )
   (return
    (i32.const 3205)
   )
  )
  (block $label$14
   (br_if $label$14
    (i32.ne
     (local.get $0)
     (i32.const 28)
    )
   )
   (return
    (i32.const 1893)
   )
  )
  (block $label$15
   (br_if $label$15
    (i32.ne
     (local.get $0)
     (i32.const 29)
    )
   )
   (return
    (i32.const 1833)
   )
  )
  (block $label$16
   (br_if $label$16
    (i32.ne
     (local.get $0)
     (i32.const 30)
    )
   )
   (return
    (i32.const 1209)
   )
  )
  (block $label$17
   (br_if $label$17
    (i32.ne
     (local.get $0)
     (i32.const 31)
    )
   )
   (return
    (i32.const 1249)
   )
  )
  (block $label$18
   (br_if $label$18
    (i32.ne
     (local.get $0)
     (i32.const 32)
    )
   )
   (return
    (i32.const 2525)
   )
  )
  (block $label$19
   (br_if $label$19
    (i32.ne
     (local.get $0)
     (i32.const 33)
    )
   )
   (return
    (i32.const 1075)
   )
  )
  (block $label$20
   (br_if $label$20
    (i32.ne
     (local.get $0)
     (i32.const 34)
    )
   )
   (return
    (i32.const 3197)
   )
  )
  (block $label$21
   (br_if $label$21
    (i32.ne
     (local.get $0)
     (i32.const 35)
    )
   )
   (return
    (i32.const 1885)
   )
  )
  (block $label$22
   (br_if $label$22
    (i32.ne
     (local.get $0)
     (i32.const 36)
    )
   )
   (return
    (i32.const 1825)
   )
  )
  (block $label$23
   (br_if $label$23
    (i32.ne
     (local.get $0)
     (i32.const 37)
    )
   )
   (return
    (i32.const 1449)
   )
  )
  (block $label$24
   (br_if $label$24
    (i32.ne
     (local.get $0)
     (i32.const 38)
    )
   )
   (return
    (i32.const 1189)
   )
  )
  (block $label$25
   (br_if $label$25
    (i32.ne
     (local.get $0)
     (i32.const 39)
    )
   )
   (return
    (i32.const 1168)
   )
  )
  (block $label$26
   (br_if $label$26
    (i32.ne
     (local.get $0)
     (i32.const 40)
    )
   )
   (return
    (i32.const 1221)
   )
  )
  (block $label$27
   (br_if $label$27
    (i32.ne
     (local.get $0)
     (i32.const 41)
    )
   )
   (return
    (i32.const 3018)
   )
  )
  (block $label$28
   (br_if $label$28
    (i32.ne
     (local.get $0)
     (i32.const 42)
    )
   )
   (return
    (i32.const 2529)
   )
  )
  (block $label$29
   (br_if $label$29
    (i32.ne
     (local.get $0)
     (i32.const 43)
    )
   )
   (return
    (i32.const 2519)
   )
  )
  (block $label$30
   (br_if $label$30
    (i32.ne
     (local.get $0)
     (i32.const 44)
    )
   )
   (return
    (i32.const 2129)
   )
  )
  (block $label$31
   (br_if $label$31
    (i32.ne
     (local.get $0)
     (i32.const 45)
    )
   )
   (return
    (i32.const 2184)
   )
  )
  (block $label$32
   (br_if $label$32
    (i32.ne
     (local.get $0)
     (i32.const 46)
    )
   )
   (return
    (i32.const 2462)
   )
  )
  (block $label$33
   (br_if $label$33
    (i32.ne
     (local.get $0)
     (i32.const 47)
    )
   )
   (return
    (i32.const 2763)
   )
  )
  (block $label$34
   (br_if $label$34
    (i32.ne
     (local.get $0)
     (i32.const 48)
    )
   )
   (return
    (i32.const 1338)
   )
  )
  (block $label$35
   (br_if $label$35
    (i32.ne
     (local.get $0)
     (i32.const 49)
    )
   )
   (return
    (i32.const 1584)
   )
  )
  (block $label$36
   (br_if $label$36
    (i32.ne
     (local.get $0)
     (i32.const 50)
    )
   )
   (return
    (i32.const 1566)
   )
  )
  (block $label$37
   (br_if $label$37
    (i32.ne
     (local.get $0)
     (i32.const 51)
    )
   )
   (return
    (i32.const 2491)
   )
  )
  (block $label$38
   (br_if $label$38
    (i32.ne
     (local.get $0)
     (i32.const 52)
    )
   )
   (return
    (i32.const 2350)
   )
  )
  (block $label$39
   (br_if $label$39
    (i32.ne
     (local.get $0)
     (i32.const 53)
    )
   )
   (return
    (i32.const 1914)
   )
  )
  (block $label$40
   (br_if $label$40
    (i32.ne
     (local.get $0)
     (i32.const 54)
    )
   )
   (return
    (i32.const 1998)
   )
  )
  (block $label$41
   (br_if $label$41
    (i32.ne
     (local.get $0)
     (i32.const 55)
    )
   )
   (return
    (i32.const 2039)
   )
  )
  (block $label$42
   (br_if $label$42
    (i32.ne
     (local.get $0)
     (i32.const 56)
    )
   )
   (return
    (i32.const 3025)
   )
  )
  (block $label$43
   (br_if $label$43
    (i32.ne
     (local.get $0)
     (i32.const 57)
    )
   )
   (return
    (i32.const 3811)
   )
  )
  (block $label$44
   (br_if $label$44
    (i32.ne
     (local.get $0)
     (i32.const 58)
    )
   )
   (return
    (i32.const 1738)
   )
  )
  (block $label$45
   (br_if $label$45
    (i32.ne
     (local.get $0)
     (i32.const 59)
    )
   )
   (return
    (i32.const 3095)
   )
  )
  (block $label$46
   (br_if $label$46
    (i32.ne
     (local.get $0)
     (i32.const 60)
    )
   )
   (return
    (i32.const 4040)
   )
  )
  (block $label$47
   (br_if $label$47
    (i32.ne
     (local.get $0)
     (i32.const 61)
    )
   )
   (return
    (i32.const 1156)
   )
  )
  (block $label$48
   (br_if $label$48
    (i32.ne
     (local.get $0)
     (i32.const 3)
    )
   )
   (return
    (i32.const 1764)
   )
  )
  (block $label$49
   (br_if $label$49
    (i32.ne
     (local.get $0)
     (i32.const 7)
    )
   )
   (return
    (i32.const 2800)
   )
  )
  (block $label$50
   (br_if $label$50
    (i32.ne
     (local.get $0)
     (i32.const 6)
    )
   )
   (return
    (i32.const 1963)
   )
  )
  (block $label$51
   (br_if $label$51
    (i32.ne
     (local.get $0)
     (i32.const 9)
    )
   )
   (return
    (i32.const 3632)
   )
  )
  (block $label$52
   (br_if $label$52
    (i32.ne
     (local.get $0)
     (i32.const 62)
    )
   )
   (return
    (i32.const 1944)
   )
  )
  (block $label$53
   (br_if $label$53
    (i32.ne
     (local.get $0)
     (i32.const 63)
    )
   )
   (return
    (i32.const 2657)
   )
  )
  (block $label$54
   (br_if $label$54
    (i32.ne
     (local.get $0)
     (i32.const 12)
    )
   )
   (return
    (i32.const 2677)
   )
  )
  (block $label$55
   (br_if $label$55
    (i32.ne
     (local.get $0)
     (i32.const 64)
    )
   )
   (return
    (i32.const 2504)
   )
  )
  (block $label$56
   (br_if $label$56
    (i32.ne
     (local.get $0)
     (i32.const 65)
    )
   )
   (return
    (i32.const 2010)
   )
  )
  (block $label$57
   (br_if $label$57
    (i32.ne
     (local.get $0)
     (i32.const 11)
    )
   )
   (return
    (i32.const 1711)
   )
  )
  (block $label$58
   (br_if $label$58
    (i32.ne
     (local.get $0)
     (i32.const 66)
    )
   )
   (return
    (i32.const 3249)
   )
  )
  (block $label$59
   (br_if $label$59
    (i32.ne
     (local.get $0)
     (i32.const 67)
    )
   )
   (return
    (i32.const 2321)
   )
  )
  (block $label$60
   (br_if $label$60
    (i32.ne
     (local.get $0)
     (i32.const 68)
    )
   )
   (return
    (i32.const 2564)
   )
  )
  (block $label$61
   (br_if $label$61
    (i32.ne
     (local.get $0)
     (i32.const 69)
    )
   )
   (return
    (i32.const 2227)
   )
  )
  (block $label$62
   (br_if $label$62
    (i32.ne
     (local.get $0)
     (i32.const 70)
    )
   )
   (return
    (i32.const 1844)
   )
  )
  (block $label$63
   (br_if $label$63
    (i32.ne
     (local.get $0)
     (i32.const 71)
    )
   )
   (return
    (i32.const 2782)
   )
  )
  (block $label$64
   (br_if $label$64
    (i32.ne
     (local.get $0)
     (i32.const 72)
    )
   )
   (return
    (i32.const 2156)
   )
  )
  (block $label$65
   (br_if $label$65
    (i32.ne
     (local.get $0)
     (i32.const 13)
    )
   )
   (return
    (i32.const 3680)
   )
  )
  (block $label$66
   (br_if $label$66
    (i32.ne
     (local.get $0)
     (i32.const 73)
    )
   )
   (return
    (i32.const 2140)
   )
  )
  (block $label$67
   (br_if $label$67
    (i32.ne
     (local.get $0)
     (i32.const 74)
    )
   )
   (return
    (i32.const 3134)
   )
  )
  (block $label$68
   (br_if $label$68
    (i32.ne
     (local.get $0)
     (i32.const 10)
    )
   )
   (return
    (i32.const 3725)
   )
  )
  (block $label$69
   (br_if $label$69
    (i32.ne
     (local.get $0)
     (i32.const 75)
    )
   )
   (return
    (i32.const 3080)
   )
  )
  (block $label$70
   (br_if $label$70
    (i32.ne
     (local.get $0)
     (i32.const 14)
    )
   )
   (return
    (i32.const 3703)
   )
  )
  (block $label$71
   (br_if $label$71
    (i32.ne
     (local.get $0)
     (i32.const 76)
    )
   )
   (return
    (i32.const 2295)
   )
  )
  (block $label$72
   (br_if $label$72
    (i32.ne
     (local.get $0)
     (i32.const 8)
    )
   )
   (return
    (i32.const 3658)
   )
  )
  (block $label$73
   (br_if $label$73
    (i32.ne
     (local.get $0)
     (i32.const 77)
    )
   )
   (return
    (i32.const 1724)
   )
  )
  (block $label$74
   (br_if $label$74
    (i32.ne
     (local.get $0)
     (i32.const 78)
    )
   )
   (return
    (i32.const 3120)
   )
  )
  (block $label$75
   (br_if $label$75
    (i32.ne
     (local.get $0)
     (i32.const 79)
    )
   )
   (return
    (i32.const 2477)
   )
  )
  (block $label$76
   (br_if $label$76
    (i32.ne
     (local.get $0)
     (i32.const 80)
    )
   )
   (return
    (i32.const 1928)
   )
  )
  (block $label$77
   (br_if $label$77
    (i32.ne
     (local.get $0)
     (i32.const 81)
    )
   )
   (return
    (i32.const 1502)
   )
  )
  (block $label$78
   (br_if $label$78
    (i32.ne
     (local.get $0)
     (i32.const 82)
    )
   )
   (return
    (i32.const 2207)
   )
  )
  (block $label$79
   (br_if $label$79
    (i32.ne
     (local.get $0)
     (i32.const 83)
    )
   )
   (return
    (i32.const 3039)
   )
  )
  (block $label$80
   (br_if $label$80
    (i32.ne
     (local.get $0)
     (i32.const 84)
    )
   )
   (return
    (i32.const 2258)
   )
  )
  (block $label$81
   (br_if $label$81
    (i32.ne
     (local.get $0)
     (i32.const 85)
    )
   )
   (return
    (i32.const 1535)
   )
  )
  (block $label$82
   (br_if $label$82
    (i32.ne
     (local.get $0)
     (i32.const 86)
    )
   )
   (return
    (i32.const 1515)
   )
  )
  (block $label$83
   (br_if $label$83
    (i32.ne
     (local.get $0)
     (i32.const 87)
    )
   )
   (return
    (i32.const 2310)
   )
  )
  (block $label$84
   (br_if $label$84
    (i32.ne
     (local.get $0)
     (i32.const 88)
    )
   )
   (return
    (i32.const 1748)
   )
  )
  (block $label$85
   (br_if $label$85
    (i32.ne
     (local.get $0)
     (i32.const 89)
    )
   )
   (return
    (i32.const 2428)
   )
  )
  (block $label$86
   (br_if $label$86
    (i32.ne
     (local.get $0)
     (i32.const 90)
    )
   )
   (return
    (i32.const 2446)
   )
  )
  (block $label$87
   (br_if $label$87
    (i32.ne
     (local.get $0)
     (i32.const 91)
    )
   )
   (return
    (i32.const 1782)
   )
  )
  (block $label$88
   (br_if $label$88
    (i32.ne
     (local.get $0)
     (i32.const 92)
    )
   )
   (return
    (i32.const 1896)
   )
  )
  (block $label$89
   (br_if $label$89
    (i32.ne
     (local.get $0)
     (i32.const 93)
    )
   )
   (return
    (i32.const 1468)
   )
  )
  (block $label$90
   (br_if $label$90
    (i32.ne
     (local.get $0)
     (i32.const 94)
    )
   )
   (return
    (i32.const 1627)
   )
  )
  (block $label$91
   (br_if $label$91
    (i32.ne
     (local.get $0)
     (i32.const 95)
    )
   )
   (return
    (i32.const 1673)
   )
  )
  (block $label$92
   (br_if $label$92
    (i32.ne
     (local.get $0)
     (i32.const 96)
    )
   )
   (return
    (i32.const 3107)
   )
  )
  (block $label$93
   (br_if $label$93
    (i32.ne
     (local.get $0)
     (i32.const 97)
    )
   )
   (return
    (i32.const 1941)
   )
  )
  (block $label$94
   (br_if $label$94
    (i32.ne
     (local.get $0)
     (i32.const 98)
    )
   )
   (return
    (i32.const 2382)
   )
  )
  (block $label$95
   (br_if $label$95
    (i32.ne
     (local.get $0)
     (i32.const 99)
    )
   )
   (return
    (i32.const 2934)
   )
  )
  (block $label$96
   (br_if $label$96
    (i32.ne
     (local.get $0)
     (i32.const 100)
    )
   )
   (return
    (i32.const 1485)
   )
  )
  (block $label$97
   (br_if $label$97
    (i32.ne
     (local.get $0)
     (i32.const 101)
    )
   )
   (return
    (i32.const 3000)
   )
  )
  (block $label$98
   (br_if $label$98
    (i32.ne
     (local.get $0)
     (i32.const 102)
    )
   )
   (return
    (i32.const 1532)
   )
  )
  (block $label$99
   (br_if $label$99
    (i32.ne
     (local.get $0)
     (i32.const 103)
    )
   )
   (return
    (i32.const 3003)
   )
  )
  (block $label$100
   (br_if $label$100
    (i32.ne
     (local.get $0)
     (i32.const 104)
    )
   )
   (return
    (i32.const 2405)
   )
  )
  (block $label$101
   (br_if $label$101
    (i32.ne
     (local.get $0)
     (i32.const 105)
    )
   )
   (return
    (i32.const 3267)
   )
  )
  (block $label$102
   (br_if $label$102
    (i32.ne
     (local.get $0)
     (i32.const 106)
    )
   )
   (return
    (i32.const 2336)
   )
  )
  (block $label$103
   (br_if $label$103
    (i32.ne
     (local.get $0)
     (i32.const 107)
    )
   )
   (return
    (i32.const 1365)
   )
  )
  (block $label$104
   (br_if $label$104
    (i32.ne
     (local.get $0)
     (i32.const 108)
    )
   )
   (return
    (i32.const 1139)
   )
  )
  (block $label$105
   (br_if $label$105
    (i32.ne
     (local.get $0)
     (i32.const 109)
    )
   )
   (return
    (i32.const 2279)
   )
  )
  (block $label$106
   (br_if $label$106
    (i32.ne
     (local.get $0)
     (i32.const 110)
    )
   )
   (return
    (i32.const 3214)
   )
  )
  (block $label$107
   (br_if $label$107
    (i32.ne
     (local.get $0)
     (i32.const 111)
    )
   )
   (return
    (i32.const 1288)
   )
  )
  (block $label$108
   (br_if $label$108
    (i32.ne
     (local.get $0)
     (i32.const 112)
    )
   )
   (return
    (i32.const 1686)
   )
  )
  (block $label$109
   (br_if $label$109
    (i32.ne
     (local.get $0)
     (i32.const 113)
    )
   )
   (return
    (i32.const 2245)
   )
  )
  (block $label$110
   (br_if $label$110
    (i32.ne
     (local.get $0)
     (i32.const 114)
    )
   )
   (return
    (i32.const 2691)
   )
  )
  (block $label$111
   (br_if $label$111
    (i32.ne
     (local.get $0)
     (i32.const 115)
    )
   )
   (return
    (i32.const 1098)
   )
  )
  (block $label$112
   (br_if $label$112
    (i32.ne
     (local.get $0)
     (i32.const 116)
    )
   )
   (return
    (i32.const 1551)
   )
  )
  (block $label$113
   (br_if $label$113
    (i32.ne
     (local.get $0)
     (i32.const 117)
    )
   )
   (return
    (i32.const 2544)
   )
  )
  (block $label$114
   (br_if $label$114
    (i32.ne
     (local.get $0)
     (i32.const 118)
    )
   )
   (return
    (i32.const 2175)
   )
  )
  (block $label$115
   (br_if $label$115
    (i32.ne
     (local.get $0)
     (i32.const 119)
    )
   )
   (return
    (i32.const 1988)
   )
  )
  (block $label$116
   (br_if $label$116
    (i32.ne
     (local.get $0)
     (i32.const 120)
    )
   )
   (return
    (i32.const 1976)
   )
  )
  (block $label$117
   (br_if $label$117
    (i32.ne
     (local.get $0)
     (i32.const 121)
    )
   )
   (return
    (i32.const 1123)
   )
  )
  (block $label$118
   (br_if $label$118
    (i32.ne
     (local.get $0)
     (i32.const 122)
    )
   )
   (return
    (i32.const 1602)
   )
  )
  (block $label$119
   (br_if $label$119
    (i32.ne
     (local.get $0)
     (i32.const 123)
    )
   )
   (return
    (i32.const 3231)
   )
  )
  (block $label$120
   (br_if $label$120
    (i32.ne
     (local.get $0)
     (i32.const 124)
    )
   )
   (return
    (i32.const 1084)
   )
  )
  (block $label$121
   (br_if $label$121
    (i32.ne
     (local.get $0)
     (i32.const 125)
    )
   )
   (return
    (i32.const 3006)
   )
  )
  (block $label$122
   (br_if $label$122
    (i32.ne
     (local.get $0)
     (i32.const 126)
    )
   )
   (return
    (i32.const 1493)
   )
  )
  (block $label$123
   (br_if $label$123
    (i32.ne
     (local.get $0)
     (i32.const 127)
    )
   )
   (return
    (i32.const 1319)
   )
  )
  (select
   (i32.const 1416)
   (i32.const 4089)
   (i32.eq
    (local.get $0)
    (i32.const 128)
   )
  )
 )
 (func $GC_stack_push_value (param $0 i32)
  (local $1 i32)
  (local $2 i32)
  (local $3 i32)
  (global.set $__stack_pointer
   (local.tee $1
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 48)
    )
   )
  )
  (i32.store8
   (i32.add
    (local.tee $2
     (i32.load16_u offset=8794
      (i32.const 0)
     )
    )
    (i32.const 49760)
   )
   (i32.const 65)
  )
  (i32.store16 offset=8794
   (i32.const 0)
   (local.tee $3
    (i32.add
     (local.get $2)
     (i32.const 1)
    )
   )
  )
  (i32.store
   (i32.add
    (i32.shl
     (local.get $2)
     (i32.const 2)
    )
    (i32.const 8800)
   )
   (local.get $0)
  )
  (block $label$1
   (br_if $label$1
    (i32.lt_u
     (i32.and
      (local.get $3)
      (i32.const 65535)
     )
     (i32.const 10240)
    )
   )
   (i32.store offset=40
    (local.get $1)
    (i32.const 71)
   )
   (i32.store offset=36
    (local.get $1)
    (i32.const 3486)
   )
   (i32.store offset=32
    (local.get $1)
    (i32.const 2837)
   )
   (call $safe_printf
    (i32.const 5284)
    (i32.add
     (local.get $1)
     (i32.const 32)
    )
   )
   (i32.store offset=16
    (local.get $1)
    (i32.const 3858)
   )
   (call $safe_printf
    (i32.const 4957)
    (i32.add
     (local.get $1)
     (i32.const 16)
    )
   )
   (i64.store offset=8
    (local.get $1)
    (i64.and
     (i64.extend_i32_u
      (local.get $3)
     )
     (i64.const 65535)
    )
   )
   (i32.store
    (local.get $1)
    (i32.const 1255)
   )
   (call $safe_printf
    (i32.const 6035)
    (local.get $1)
   )
   (call $abort)
  )
  (global.set $__stack_pointer
   (i32.add
    (local.get $1)
    (i32.const 48)
   )
  )
 )
 (func $bitmap_reset (param $0 i32)
  (local $1 i32)
  (local $2 i32)
  (local $3 i32)
  (local $4 i32)
  (block $label$1
   (br_if $label$1
    (i32.eqz
     (local.tee $1
      (i32.load offset=12
       (local.get $0)
      )
     )
    )
   )
   (local.set $2
    (i32.load offset=8
     (local.get $0)
    )
   )
   (local.set $3
    (i32.and
     (local.get $1)
     (i32.const 7)
    )
   )
   (local.set $4
    (i32.const 0)
   )
   (block $label$2
    (br_if $label$2
     (i32.lt_u
      (i32.add
       (local.get $1)
       (i32.const -1)
      )
      (i32.const 7)
     )
    )
    (local.set $0
     (i32.add
      (local.get $2)
      (i32.const 32)
     )
    )
    (local.set $1
     (i32.and
      (local.get $1)
      (i32.const -8)
     )
    )
    (local.set $4
     (i32.const 0)
    )
    (loop $label$3
     (i64.store
      (local.get $0)
      (i64.const 0)
     )
     (i64.store
      (i32.add
       (local.get $0)
       (i32.const 24)
      )
      (i64.const 0)
     )
     (i64.store
      (i32.add
       (local.get $0)
       (i32.const 16)
      )
      (i64.const 0)
     )
     (i64.store
      (i32.add
       (local.get $0)
       (i32.const 8)
      )
      (i64.const 0)
     )
     (i64.store
      (i32.add
       (local.get $0)
       (i32.const -8)
      )
      (i64.const 0)
     )
     (i64.store
      (i32.add
       (local.get $0)
       (i32.const -16)
      )
      (i64.const 0)
     )
     (i64.store
      (i32.add
       (local.get $0)
       (i32.const -24)
      )
      (i64.const 0)
     )
     (i64.store
      (i32.add
       (local.get $0)
       (i32.const -32)
      )
      (i64.const 0)
     )
     (local.set $0
      (i32.add
       (local.get $0)
       (i32.const 64)
      )
     )
     (br_if $label$3
      (i32.ne
       (local.get $1)
       (local.tee $4
        (i32.add
         (local.get $4)
         (i32.const 8)
        )
       )
      )
     )
    )
   )
   (br_if $label$1
    (i32.eqz
     (local.get $3)
    )
   )
   (local.set $0
    (i32.add
     (local.get $2)
     (i32.shl
      (local.get $4)
      (i32.const 3)
     )
    )
   )
   (loop $label$4
    (i64.store
     (local.get $0)
     (i64.const 0)
    )
    (local.set $0
     (i32.add
      (local.get $0)
      (i32.const 8)
     )
    )
    (br_if $label$4
     (local.tee $3
      (i32.add
       (local.get $3)
       (i32.const -1)
      )
     )
    )
   )
  )
 )
 (func $bitmap_dead_between (param $0 i32) (param $1 i32) (param $2 i32) (result i32)
  (local $3 i32)
  (local $4 i32)
  (local $5 i32)
  (local $6 i32)
  (local $7 i32)
  (local $8 i32)
  (local $9 i32)
  (local $10 i64)
  (local.set $5
   (i32.and
    (local.tee $4
     (i32.shr_s
      (i32.sub
       (local.get $2)
       (local.tee $3
        (i32.load
         (local.get $0)
        )
       )
      )
      (i32.const 2)
     )
    )
    (i32.const 63)
   )
  )
  (local.set $3
   (i32.and
    (local.tee $6
     (i32.shr_s
      (i32.sub
       (local.get $1)
       (local.get $3)
      )
      (i32.const 2)
     )
    )
    (i32.const 63)
   )
  )
  (local.set $7
   (i32.load offset=8
    (local.get $0)
   )
  )
  (block $label$1
   (br_if $label$1
    (i32.ne
     (local.tee $0
      (i32.shr_u
       (local.get $6)
       (i32.const 6)
      )
     )
     (local.tee $8
      (i32.shr_u
       (local.get $4)
       (i32.const 6)
      )
     )
    )
   )
   (return
    (i32.sub
     (local.get $5)
     (i32.add
      (local.get $3)
      (i32.wrap_i64
       (i64.popcnt
        (i64.and
         (i64.and
          (i64.shr_u
           (local.tee $10
            (i64.shl
             (i64.shr_u
              (i64.shl
               (i64.const -1)
               (i64.extend_i32_u
                (i32.xor
                 (local.get $5)
                 (i32.const 63)
                )
               )
              )
              (i64.extend_i32_u
               (i32.add
                (i32.sub
                 (local.get $3)
                 (local.get $5)
                )
                (i32.const 63)
               )
              )
             )
             (i64.extend_i32_u
              (local.get $3)
             )
            )
           )
           (i64.const 1)
          )
          (local.get $10)
         )
         (i64.load
          (i32.add
           (local.get $7)
           (i32.shl
            (local.get $0)
            (i32.const 3)
           )
          )
         )
        )
       )
      )
     )
    )
   )
  )
  (local.set $3
   (i32.wrap_i64
    (i64.popcnt
     (i64.and
      (i64.load
       (i32.add
        (local.get $7)
        (i32.shl
         (local.get $0)
         (i32.const 3)
        )
       )
      )
      (i64.shl
       (i64.const -1)
       (i64.extend_i32_u
        (local.get $3)
       )
      )
     )
    )
   )
  )
  (block $label$2
   (br_if $label$2
    (i32.ge_u
     (local.tee $4
      (i32.add
       (local.get $0)
       (i32.const 1)
      )
     )
     (local.get $8)
    )
   )
   (local.set $9
    (i32.add
     (i32.sub
      (local.get $8)
      (local.get $0)
     )
     (i32.const -2)
    )
   )
   (block $label$3
    (br_if $label$3
     (i32.eqz
      (local.tee $6
       (i32.and
        (i32.add
         (local.get $8)
         (i32.xor
          (local.get $0)
          (i32.const -1)
         )
        )
        (i32.const 3)
       )
      )
     )
    )
    (local.set $0
     (i32.add
      (local.get $7)
      (i32.shl
       (local.get $4)
       (i32.const 3)
      )
     )
    )
    (loop $label$4
     (local.set $4
      (i32.add
       (local.get $4)
       (i32.const 1)
      )
     )
     (local.set $3
      (i32.add
       (local.get $3)
       (i32.wrap_i64
        (i64.popcnt
         (i64.load
          (local.get $0)
         )
        )
       )
      )
     )
     (local.set $0
      (i32.add
       (local.get $0)
       (i32.const 8)
      )
     )
     (br_if $label$4
      (local.tee $6
       (i32.add
        (local.get $6)
        (i32.const -1)
       )
      )
     )
    )
   )
   (br_if $label$2
    (i32.lt_u
     (local.get $9)
     (i32.const 3)
    )
   )
   (local.set $6
    (i32.sub
     (local.get $8)
     (local.get $4)
    )
   )
   (local.set $0
    (i32.add
     (local.get $7)
     (i32.shl
      (local.get $4)
      (i32.const 3)
     )
    )
   )
   (loop $label$5
    (local.set $3
     (i32.add
      (i32.add
       (i32.add
        (i32.add
         (local.get $3)
         (i32.wrap_i64
          (i64.popcnt
           (i64.load
            (local.get $0)
           )
          )
         )
        )
        (i32.wrap_i64
         (i64.popcnt
          (i64.load
           (i32.add
            (local.get $0)
            (i32.const 8)
           )
          )
         )
        )
       )
       (i32.wrap_i64
        (i64.popcnt
         (i64.load
          (i32.add
           (local.get $0)
           (i32.const 16)
          )
         )
        )
       )
      )
      (i32.wrap_i64
       (i64.popcnt
        (i64.load
         (i32.add
          (local.get $0)
          (i32.const 24)
         )
        )
       )
      )
     )
    )
    (local.set $0
     (i32.add
      (local.get $0)
      (i32.const 32)
     )
    )
    (br_if $label$5
     (local.tee $6
      (i32.add
       (local.get $6)
       (i32.const -4)
      )
     )
    )
   )
  )
  (i32.sub
   (i32.shr_s
    (i32.sub
     (local.get $2)
     (local.get $1)
    )
    (i32.const 2)
   )
   (i32.add
    (local.get $3)
    (i32.wrap_i64
     (i64.popcnt
      (i64.and
       (i64.and
        (i64.shr_u
         (local.tee $10
          (i64.shr_u
           (i64.const -1)
           (i64.extend_i32_u
            (i32.xor
             (local.get $5)
             (i32.const 63)
            )
           )
          )
         )
         (i64.const 1)
        )
        (local.get $10)
       )
       (i64.load
        (i32.add
         (local.get $7)
         (i32.shl
          (local.get $8)
          (i32.const 3)
         )
        )
       )
      )
     )
    )
   )
  )
 )
 (func $make_bitmask (param $0 i32) (param $1 i32) (result i64)
  (i64.shl
   (i64.shr_u
    (i64.shl
     (i64.const -1)
     (i64.extend_i32_u
      (i32.sub
       (i32.const 63)
       (local.get $1)
      )
     )
    )
    (i64.extend_i32_u
     (i32.add
      (i32.sub
       (local.get $0)
       (local.get $1)
      )
      (i32.const 63)
     )
    )
   )
   (i64.extend_i32_u
    (local.get $0)
   )
  )
 )
 (func $bitmap_iter_to_ptr (param $0 i32) (param $1 i32) (result i32)
  (local $2 i32)
  (local $3 i64)
  (select
   (local.tee $2
    (i32.load offset=4
     (local.get $0)
    )
   )
   (local.tee $0
    (i32.add
     (i32.add
      (i32.load
       (local.get $0)
      )
      (i32.shl
       (i32.load offset=8
        (local.get $1)
       )
       (i32.const 8)
      )
     )
     (i32.shl
      (i32.sub
       (select
        (local.tee $0
         (select
          (local.tee $0
           (select
            (local.tee $0
             (select
              (local.tee $0
               (select
                (i32.const 31)
                (i32.const 63)
                (i32.wrap_i64
                 (local.tee $3
                  (i64.load
                   (local.get $1)
                  )
                 )
                )
               )
              )
              (i32.add
               (local.get $0)
               (i32.const -16)
              )
              (i64.eqz
               (i64.and
                (local.get $3)
                (i64.const 281470681808895)
               )
              )
             )
            )
            (i32.add
             (local.get $0)
             (i32.const -8)
            )
            (i64.eqz
             (i64.and
              (local.get $3)
              (i64.const 71777214294589695)
             )
            )
           )
          )
          (i32.add
           (local.get $0)
           (i32.const -4)
          )
          (i64.eqz
           (i64.and
            (local.get $3)
            (i64.const 1085102592571150095)
           )
          )
         )
        )
        (i32.add
         (local.get $0)
         (i32.const -2)
        )
        (i64.eqz
         (i64.and
          (local.get $3)
          (i64.const 3689348814741910323)
         )
        )
       )
       (i64.ne
        (i64.and
         (local.get $3)
         (i64.const 6148914691236517205)
        )
        (i64.const 0)
       )
      )
      (i32.const 2)
     )
    )
   )
   (i32.gt_u
    (local.get $0)
    (local.get $2)
   )
  )
 )
 (func $bitmap_find (param $0 i32) (param $1 i32) (param $2 i32)
  (local $3 i32)
  (local $4 i32)
  (local $5 i32)
  (local $6 i32)
  (local $7 i64)
  (local $8 i64)
  (local $9 i64)
  (local $10 i64)
  (local.set $8
   (i64.xor
    (i64.load
     (i32.add
      (local.tee $3
       (i32.load offset=8
        (local.get $0)
       )
      )
      (i32.shl
       (local.tee $4
        (i32.load offset=8
         (local.get $2)
        )
       )
       (i32.const 3)
      )
     )
    )
    (i64.add
     (local.tee $7
      (i64.extend_i32_u
       (local.get $1)
      )
     )
     (i64.const -1)
    )
   )
  )
  (local.set $9
   (i64.load
    (local.get $2)
   )
  )
  (block $label$1
   (loop $label$2
    (br_if $label$1
     (local.tee $1
      (i64.eqz
       (local.tee $10
        (local.get $9)
       )
      )
     )
    )
    (local.set $9
     (i64.shl
      (local.get $10)
      (i64.const 1)
     )
    )
    (br_if $label$2
     (i64.eqz
      (i64.and
       (local.get $10)
       (local.get $8)
      )
     )
    )
   )
  )
  (block $label$3
   (br_if $label$3
    (local.get $1)
   )
   (i64.store
    (local.get $2)
    (local.get $10)
   )
   (return)
  )
  (local.set $6
   (select
    (local.tee $5
     (i32.load offset=12
      (local.get $0)
     )
    )
    (local.tee $1
     (i32.add
      (local.get $4)
      (i32.const 1)
     )
    )
    (i32.gt_u
     (local.get $5)
     (local.get $1)
    )
   )
  )
  (local.set $9
   (i64.add
    (local.get $7)
    (i64.const -1)
   )
  )
  (local.set $1
   (i32.add
    (local.get $3)
    (i32.shl
     (local.get $1)
     (i32.const 3)
    )
   )
  )
  (block $label$4
   (loop $label$5
    (block $label$6
     (br_if $label$6
      (i32.lt_u
       (local.tee $4
        (i32.add
         (local.get $4)
         (i32.const 1)
        )
       )
       (local.get $5)
      )
     )
     (local.set $4
      (local.get $6)
     )
     (br $label$4)
    )
    (local.set $10
     (i64.load
      (local.get $1)
     )
    )
    (local.set $1
     (i32.add
      (local.get $1)
      (i32.const 8)
     )
    )
    (br_if $label$5
     (i64.eq
      (local.get $10)
      (local.get $9)
     )
    )
   )
  )
  (block $label$7
   (br_if $label$7
    (i32.ne
     (local.get $4)
     (local.get $5)
    )
   )
   (i32.store offset=8
    (local.get $2)
    (i32.shr_u
     (local.tee $1
      (i32.shr_s
       (i32.sub
        (i32.load offset=4
         (local.get $0)
        )
        (i32.load
         (local.get $0)
        )
       )
       (i32.const 2)
      )
     )
     (i32.const 6)
    )
   )
   (i64.store
    (local.get $2)
    (i64.shl
     (i64.const 1)
     (i64.extend_i32_u
      (i32.and
       (local.get $1)
       (i32.const 63)
      )
     )
    )
   )
   (return)
  )
  (i32.store offset=8
   (local.get $2)
   (local.get $4)
  )
  (i64.store
   (local.get $2)
   (i64.and
    (local.tee $10
     (i64.xor
      (i64.load
       (i32.add
        (local.get $3)
        (i32.shl
         (local.get $4)
         (i32.const 3)
        )
       )
      )
      (i64.add
       (local.get $7)
       (i64.const -1)
      )
     )
    )
    (i64.sub
     (i64.const 0)
     (local.get $10)
    )
   )
  )
 )
 (func $calc_offsets (param $0 i32) (param $1 i32) (param $2 i32)
  (local $3 i32)
  (local $4 i32)
  (local $5 i32)
  (local $6 i32)
  (local $7 i32)
  (local $8 i32)
  (local $9 i32)
  (local $10 i32)
  (local $11 i32)
  (local $12 i32)
  (local $13 i32)
  (local $14 i32)
  (local $15 i32)
  (local $16 i32)
  (local $17 i64)
  (local.set $3
   (i32.const 0)
  )
  (i32.store
   (i32.add
    (local.tee $4
     (i32.load offset=16
      (local.get $0)
     )
    )
    (i32.shl
     (local.tee $6
      (i32.div_s
       (i32.shr_s
        (i32.sub
         (local.get $1)
         (local.tee $5
          (i32.load
           (local.get $0)
          )
         )
        )
        (i32.const 2)
       )
       (i32.const 64)
      )
     )
     (i32.const 2)
    )
   )
   (i32.const 0)
  )
  (block $label$1
   (br_if $label$1
    (i32.ge_u
     (local.tee $7
      (i32.and
       (i32.add
        (local.get $1)
        (i32.const 256)
       )
       (i32.const -256)
      )
     )
     (local.get $2)
    )
   )
   (local.set $9
    (i32.add
     (local.tee $8
      (i32.load offset=8
       (local.get $0)
      )
     )
     (i32.const 8)
    )
   )
   (loop $label$2
    (local.set $11
     (i32.and
      (local.tee $0
       (i32.shr_s
        (i32.sub
         (local.tee $10
          (local.get $7)
         )
         (local.get $5)
        )
        (i32.const 2)
       )
      )
      (i32.const 63)
     )
    )
    (local.set $7
     (i32.and
      (local.tee $12
       (i32.shr_s
        (i32.sub
         (local.get $1)
         (local.get $5)
        )
        (i32.const 2)
       )
      )
      (i32.const 63)
     )
    )
    (block $label$3
     (block $label$4
      (br_if $label$4
       (i32.ne
        (local.tee $13
         (i32.shr_u
          (local.get $12)
          (i32.const 6)
         )
        )
        (local.tee $14
         (i32.shr_u
          (local.get $0)
          (i32.const 6)
         )
        )
       )
      )
      (local.set $7
       (i32.sub
        (local.get $11)
        (i32.add
         (local.get $7)
         (i32.wrap_i64
          (i64.popcnt
           (i64.and
            (i64.and
             (i64.shr_u
              (local.tee $17
               (i64.shl
                (i64.shr_u
                 (i64.shl
                  (i64.const -1)
                  (i64.extend_i32_u
                   (i32.xor
                    (local.get $11)
                    (i32.const 63)
                   )
                  )
                 )
                 (i64.extend_i32_u
                  (i32.add
                   (i32.sub
                    (local.get $7)
                    (local.get $11)
                   )
                   (i32.const 63)
                  )
                 )
                )
                (i64.extend_i32_u
                 (local.get $7)
                )
               )
              )
              (i64.const 1)
             )
             (local.get $17)
            )
            (i64.load
             (i32.add
              (local.get $8)
              (i32.shl
               (local.get $13)
               (i32.const 3)
              )
             )
            )
           )
          )
         )
        )
       )
      )
      (br $label$3)
     )
     (local.set $0
      (i32.wrap_i64
       (i64.popcnt
        (i64.and
         (i64.load
          (i32.add
           (local.get $8)
           (local.tee $15
            (i32.shl
             (local.get $13)
             (i32.const 3)
            )
           )
          )
         )
         (i64.shl
          (i64.const -1)
          (i64.extend_i32_u
           (local.get $7)
          )
         )
        )
       )
      )
     )
     (block $label$5
      (br_if $label$5
       (i32.ge_u
        (local.tee $12
         (i32.add
          (local.get $13)
          (i32.const 1)
         )
        )
        (local.get $14)
       )
      )
      (local.set $16
       (i32.add
        (i32.sub
         (local.get $14)
         (local.get $13)
        )
        (i32.const -2)
       )
      )
      (block $label$6
       (br_if $label$6
        (i32.eqz
         (local.tee $13
          (i32.and
           (i32.add
            (local.get $14)
            (i32.xor
             (local.get $13)
             (i32.const -1)
            )
           )
           (i32.const 3)
          )
         )
        )
       )
       (local.set $7
        (i32.add
         (local.get $9)
         (local.get $15)
        )
       )
       (loop $label$7
        (local.set $12
         (i32.add
          (local.get $12)
          (i32.const 1)
         )
        )
        (local.set $0
         (i32.add
          (local.get $0)
          (i32.wrap_i64
           (i64.popcnt
            (i64.load
             (local.get $7)
            )
           )
          )
         )
        )
        (local.set $7
         (i32.add
          (local.get $7)
          (i32.const 8)
         )
        )
        (br_if $label$7
         (local.tee $13
          (i32.add
           (local.get $13)
           (i32.const -1)
          )
         )
        )
       )
      )
      (br_if $label$5
       (i32.lt_u
        (local.get $16)
        (i32.const 3)
       )
      )
      (local.set $13
       (i32.sub
        (local.get $14)
        (local.get $12)
       )
      )
      (local.set $7
       (i32.add
        (local.get $8)
        (i32.shl
         (local.get $12)
         (i32.const 3)
        )
       )
      )
      (loop $label$8
       (local.set $0
        (i32.add
         (i32.add
          (i32.add
           (i32.add
            (local.get $0)
            (i32.wrap_i64
             (i64.popcnt
              (i64.load
               (local.get $7)
              )
             )
            )
           )
           (i32.wrap_i64
            (i64.popcnt
             (i64.load
              (i32.add
               (local.get $7)
               (i32.const 8)
              )
             )
            )
           )
          )
          (i32.wrap_i64
           (i64.popcnt
            (i64.load
             (i32.add
              (local.get $7)
              (i32.const 16)
             )
            )
           )
          )
         )
         (i32.wrap_i64
          (i64.popcnt
           (i64.load
            (i32.add
             (local.get $7)
             (i32.const 24)
            )
           )
          )
         )
        )
       )
       (local.set $7
        (i32.add
         (local.get $7)
         (i32.const 32)
        )
       )
       (br_if $label$8
        (local.tee $13
         (i32.add
          (local.get $13)
          (i32.const -4)
         )
        )
       )
      )
     )
     (local.set $7
      (i32.sub
       (i32.shr_s
        (i32.sub
         (local.get $10)
         (local.get $1)
        )
        (i32.const 2)
       )
       (i32.add
        (local.get $0)
        (i32.wrap_i64
         (i64.popcnt
          (i64.and
           (i64.and
            (i64.shr_u
             (local.tee $17
              (i64.shr_u
               (i64.const -1)
               (i64.extend_i32_u
                (i32.xor
                 (local.get $11)
                 (i32.const 63)
                )
               )
              )
             )
             (i64.const 1)
            )
            (local.get $17)
           )
           (i64.load
            (i32.add
             (local.get $8)
             (i32.shl
              (local.get $14)
              (i32.const 3)
             )
            )
           )
          )
         )
        )
       )
      )
     )
    )
    (i32.store
     (i32.add
      (local.get $4)
      (i32.shl
       (local.tee $6
        (i32.add
         (local.get $6)
         (i32.const 1)
        )
       )
       (i32.const 2)
      )
     )
     (local.tee $3
      (i32.add
       (local.get $7)
       (local.get $3)
      )
     )
    )
    (local.set $1
     (local.get $10)
    )
    (br_if $label$2
     (i32.lt_u
      (local.tee $7
       (i32.add
        (local.get $10)
        (i32.const 256)
       )
      )
      (local.get $2)
     )
    )
   )
  )
 )
 (func $forwarding_address (param $0 i32) (param $1 i32) (result i32)
  (local $2 i32)
  (local $3 i32)
  (local $4 i32)
  (local $5 i32)
  (local $6 i32)
  (local $7 i32)
  (local $8 i32)
  (local $9 i32)
  (local $10 i32)
  (local $11 i64)
  (block $label$1
   (br_if $label$1
    (i32.gt_u
     (local.tee $2
      (i32.load
       (local.get $0)
      )
     )
     (local.get $1)
    )
   )
   (br_if $label$1
    (i32.le_u
     (i32.load offset=4
      (local.get $0)
     )
     (local.get $1)
    )
   )
   (local.set $4
    (i32.and
     (local.tee $3
      (i32.shr_s
       (i32.sub
        (local.get $1)
        (local.get $2)
       )
       (i32.const 2)
      )
     )
     (i32.const 63)
    )
   )
   (local.set $6
    (i32.load
     (i32.add
      (i32.load offset=16
       (local.get $0)
      )
      (i32.shl
       (local.tee $5
        (i32.div_s
         (local.get $3)
         (i32.const 64)
        )
       )
       (i32.const 2)
      )
     )
    )
   )
   (local.set $7
    (i32.load offset=8
     (local.get $0)
    )
   )
   (block $label$2
    (block $label$3
     (br_if $label$3
      (i32.ne
       (local.tee $0
        (i32.and
         (local.get $5)
         (i32.const 67108863)
        )
       )
       (local.tee $8
        (i32.shr_u
         (local.get $3)
         (i32.const 6)
        )
       )
      )
     )
     (local.set $0
      (i32.sub
       (i32.wrap_i64
        (i64.popcnt
         (i64.and
          (i64.and
           (i64.shr_u
            (local.tee $11
             (i64.shr_u
              (i64.const -1)
              (i64.extend_i32_u
               (i32.xor
                (local.get $4)
                (i32.const 63)
               )
              )
             )
            )
            (i64.const 1)
           )
           (local.get $11)
          )
          (i64.load
           (i32.add
            (local.get $7)
            (i32.shl
             (local.get $0)
             (i32.const 3)
            )
           )
          )
         )
        )
       )
       (local.get $4)
      )
     )
     (br $label$2)
    )
    (local.set $9
     (i32.add
      (local.get $2)
      (i32.shl
       (local.get $5)
       (i32.const 8)
      )
     )
    )
    (local.set $2
     (i32.wrap_i64
      (i64.popcnt
       (i64.load
        (i32.add
         (local.get $7)
         (i32.shl
          (local.get $0)
          (i32.const 3)
         )
        )
       )
      )
     )
    )
    (block $label$4
     (br_if $label$4
      (i32.ge_u
       (local.tee $3
        (i32.add
         (local.get $0)
         (i32.const 1)
        )
       )
       (local.get $8)
      )
     )
     (local.set $10
      (i32.add
       (i32.sub
        (local.get $8)
        (local.get $0)
       )
       (i32.const -2)
      )
     )
     (block $label$5
      (br_if $label$5
       (i32.eqz
        (local.tee $5
         (i32.and
          (i32.add
           (local.get $8)
           (i32.xor
            (local.get $5)
            (i32.const -1)
           )
          )
          (i32.const 3)
         )
        )
       )
      )
      (local.set $0
       (i32.add
        (local.get $7)
        (i32.shl
         (local.get $3)
         (i32.const 3)
        )
       )
      )
      (loop $label$6
       (local.set $3
        (i32.add
         (local.get $3)
         (i32.const 1)
        )
       )
       (local.set $2
        (i32.add
         (local.get $2)
         (i32.wrap_i64
          (i64.popcnt
           (i64.load
            (local.get $0)
           )
          )
         )
        )
       )
       (local.set $0
        (i32.add
         (local.get $0)
         (i32.const 8)
        )
       )
       (br_if $label$6
        (local.tee $5
         (i32.add
          (local.get $5)
          (i32.const -1)
         )
        )
       )
      )
     )
     (br_if $label$4
      (i32.lt_u
       (local.get $10)
       (i32.const 3)
      )
     )
     (local.set $5
      (i32.sub
       (local.get $8)
       (local.get $3)
      )
     )
     (local.set $0
      (i32.add
       (local.get $7)
       (i32.shl
        (local.get $3)
        (i32.const 3)
       )
      )
     )
     (loop $label$7
      (local.set $2
       (i32.add
        (i32.add
         (i32.add
          (i32.add
           (local.get $2)
           (i32.wrap_i64
            (i64.popcnt
             (i64.load
              (local.get $0)
             )
            )
           )
          )
          (i32.wrap_i64
           (i64.popcnt
            (i64.load
             (i32.add
              (local.get $0)
              (i32.const 8)
             )
            )
           )
          )
         )
         (i32.wrap_i64
          (i64.popcnt
           (i64.load
            (i32.add
             (local.get $0)
             (i32.const 16)
            )
           )
          )
         )
        )
        (i32.wrap_i64
         (i64.popcnt
          (i64.load
           (i32.add
            (local.get $0)
            (i32.const 24)
           )
          )
         )
        )
       )
      )
      (local.set $0
       (i32.add
        (local.get $0)
        (i32.const 32)
       )
      )
      (br_if $label$7
       (local.tee $5
        (i32.add
         (local.get $5)
         (i32.const -4)
        )
       )
      )
     )
    )
    (local.set $0
     (i32.add
      (i32.sub
       (local.get $2)
       (i32.shr_s
        (i32.sub
         (local.get $1)
         (local.get $9)
        )
        (i32.const 2)
       )
      )
      (i32.wrap_i64
       (i64.popcnt
        (i64.and
         (i64.and
          (i64.shr_u
           (local.tee $11
            (i64.shr_u
             (i64.const -1)
             (i64.extend_i32_u
              (i32.xor
               (local.get $4)
               (i32.const 63)
              )
             )
            )
           )
           (i64.const 1)
          )
          (local.get $11)
         )
         (i64.load
          (i32.add
           (local.get $7)
           (i32.shl
            (local.get $8)
            (i32.const 3)
           )
          )
         )
        )
       )
      )
     )
    )
   )
   (local.set $1
    (i32.add
     (i32.sub
      (local.get $1)
      (i32.shl
       (local.get $6)
       (i32.const 2)
      )
     )
     (i32.shl
      (local.get $0)
      (i32.const 2)
     )
    )
   )
  )
  (local.get $1)
 )
 (func $compact (param $0 i32) (param $1 i32)
  (local $2 i32)
  (local $3 i32)
  (local $4 i32)
  (local $5 i32)
  (local $6 i32)
  (local $7 i32)
  (local $8 i32)
  (local $9 i32)
  (local $10 i32)
  (local $11 i32)
  (local $12 i32)
  (local $13 i32)
  (local $14 i32)
  (local $15 i32)
  (local $16 i32)
  (local $17 i32)
  (local $18 i32)
  (local $19 i32)
  (local $20 i32)
  (local $21 i32)
  (local $22 i32)
  (local $23 i32)
  (local $24 i32)
  (local $25 i32)
  (local $26 i64)
  (local $27 i64)
  (local $28 i64)
  (global.set $__stack_pointer
   (local.tee $2
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 64)
    )
   )
  )
  (local.set $26
   (i64.shl
    (i64.const 1)
    (i64.extend_i32_u
     (i32.and
      (local.tee $4
       (i32.shr_s
        (i32.sub
         (local.get $1)
         (local.tee $3
          (i32.load
           (local.get $0)
          )
         )
        )
        (i32.const 2)
       )
      )
      (i32.const 63)
     )
    )
   )
  )
  (local.set $27
   (i64.xor
    (i64.load
     (i32.add
      (local.tee $5
       (i32.load offset=8
        (local.get $0)
       )
      )
      (i32.shl
       (local.tee $6
        (i32.shr_u
         (local.get $4)
         (i32.const 6)
        )
       )
       (i32.const 3)
      )
     )
    )
    (i64.const -1)
   )
  )
  (local.set $7
   (i32.load offset=4
    (local.get $0)
   )
  )
  (block $label$1
   (loop $label$2
    (br_if $label$1
     (i64.eqz
      (local.tee $28
       (local.get $26)
      )
     )
    )
    (local.set $26
     (i64.shl
      (local.get $28)
      (i64.const 1)
     )
    )
    (br_if $label$2
     (i64.eqz
      (i64.and
       (local.get $28)
       (local.get $27)
      )
     )
    )
   )
  )
  (block $label$3
   (br_if $label$3
    (i64.ne
     (local.get $28)
     (i64.const 0)
    )
   )
   (local.set $9
    (select
     (local.tee $8
      (i32.load offset=12
       (local.get $0)
      )
     )
     (local.tee $4
      (i32.add
       (local.get $6)
       (i32.const 1)
      )
     )
     (i32.gt_u
      (local.get $8)
      (local.get $4)
     )
    )
   )
   (local.set $4
    (i32.add
     (local.get $5)
     (i32.shl
      (local.get $4)
      (i32.const 3)
     )
    )
   )
   (block $label$4
    (loop $label$5
     (block $label$6
      (br_if $label$6
       (i32.lt_u
        (local.tee $6
         (i32.add
          (local.get $6)
          (i32.const 1)
         )
        )
        (local.get $8)
       )
      )
      (local.set $6
       (local.get $9)
      )
      (br $label$4)
     )
     (local.set $28
      (i64.load
       (local.get $4)
      )
     )
     (local.set $4
      (i32.add
       (local.get $4)
       (i32.const 8)
      )
     )
     (br_if $label$5
      (i64.eq
       (local.get $28)
       (i64.const -1)
      )
     )
    )
   )
   (block $label$7
    (br_if $label$7
     (i32.ne
      (local.get $6)
      (local.get $8)
     )
    )
    (local.set $6
     (i32.shr_u
      (local.tee $4
       (i32.shr_s
        (i32.sub
         (local.get $7)
         (local.get $3)
        )
        (i32.const 2)
       )
      )
      (i32.const 6)
     )
    )
    (local.set $28
     (i64.shl
      (i64.const 1)
      (i64.extend_i32_u
       (i32.and
        (local.get $4)
        (i32.const 63)
       )
      )
     )
    )
    (br $label$3)
   )
   (local.set $28
    (i64.and
     (i64.add
      (local.tee $28
       (i64.load
        (i32.add
         (local.get $5)
         (i32.shl
          (local.get $6)
          (i32.const 3)
         )
        )
       )
      )
      (i64.const 1)
     )
     (i64.xor
      (local.get $28)
      (i64.const -1)
     )
    )
   )
  )
  (block $label$8
   (br_if $label$8
    (i32.le_u
     (local.get $7)
     (local.tee $4
      (i32.add
       (i32.add
        (local.get $3)
        (i32.shl
         (local.get $6)
         (i32.const 8)
        )
       )
       (i32.shl
        (i32.sub
         (select
          (local.tee $4
           (select
            (local.tee $4
             (select
              (local.tee $4
               (select
                (local.tee $4
                 (select
                  (i32.const 31)
                  (i32.const 63)
                  (i32.wrap_i64
                   (local.get $28)
                  )
                 )
                )
                (i32.add
                 (local.get $4)
                 (i32.const -16)
                )
                (i64.eqz
                 (i64.and
                  (local.get $28)
                  (i64.const 281470681808895)
                 )
                )
               )
              )
              (i32.add
               (local.get $4)
               (i32.const -8)
              )
              (i64.eqz
               (i64.and
                (local.get $28)
                (i64.const 71777214294589695)
               )
              )
             )
            )
            (i32.add
             (local.get $4)
             (i32.const -4)
            )
            (i64.eqz
             (i64.and
              (local.get $28)
              (i64.const 1085102592571150095)
             )
            )
           )
          )
          (i32.add
           (local.get $4)
           (i32.const -2)
          )
          (i64.eqz
           (i64.and
            (local.get $28)
            (i64.const 3689348814741910323)
           )
          )
         )
         (i64.ne
          (i64.and
           (local.get $28)
           (i64.const 6148914691236517205)
          )
          (i64.const 0)
         )
        )
        (i32.const 2)
       )
      )
     )
    )
   )
   (call $calc_offsets
    (local.get $0)
    (local.get $1)
    (local.get $7)
   )
   (block $label$9
    (br_if $label$9
     (i32.le_u
      (local.tee $10
       (select
        (local.get $7)
        (local.get $4)
        (i32.gt_u
         (local.get $4)
         (local.get $7)
        )
       )
      )
      (local.get $1)
     )
    )
    (loop $label$10
     (local.set $11
      (i32.const 2)
     )
     (block $label$11
      (block $label$12
       (block $label$13
        (block $label$14
         (block $label$15
          (block $label$16
           (block $label$17
            (block $label$18
             (block $label$19
              (block $label$20
               (block $label$21
                (br_table $label$17 $label$13 $label$21 $label$15 $label$20 $label$16 $label$19 $label$16 $label$18 $label$18 $label$16
                 (i32.add
                  (i32.shr_u
                   (local.tee $4
                    (i32.load
                     (local.get $1)
                    )
                   )
                   (i32.const 28)
                  )
                  (i32.const -4)
                 )
                )
               )
               (local.set $11
                (i32.const 3)
               )
               (br $label$13)
              )
              (local.set $11
               (i32.add
                (i32.and
                 (local.get $4)
                 (i32.const 268435455)
                )
                (i32.const -1)
               )
              )
              (br $label$14)
             )
             (local.set $11
              (i32.load16_u offset=4
               (local.get $1)
              )
             )
             (br $label$14)
            )
            (local.set $11
             (i32.const 4)
            )
            (br $label$13)
           )
           (local.set $11
            (i32.const 2)
           )
           (br_if $label$13
            (i32.ne
             (i32.load offset=7844
              (i32.const 0)
             )
             (local.get $1)
            )
           )
          )
          (local.set $1
           (i32.add
            (local.get $1)
            (i32.shl
             (i32.and
              (local.get $4)
              (i32.const 268435455)
             )
             (i32.const 2)
            )
           )
          )
          (br $label$11)
         )
         (local.set $11
          (i32.add
           (i32.and
            (local.get $4)
            (i32.const 268435455)
           )
           (i32.const -2)
          )
         )
        )
        (local.set $1
         (i32.add
          (local.get $1)
          (i32.shl
           (i32.and
            (local.get $4)
            (i32.const 268435455)
           )
           (i32.const 2)
          )
         )
        )
        (br_if $label$11
         (i32.eqz
          (local.get $11)
         )
        )
        (local.set $12
         (i32.sub
          (local.get $1)
          (i32.shl
           (local.get $11)
           (i32.const 2)
          )
         )
        )
        (br $label$12)
       )
       (local.set $12
        (i32.sub
         (local.tee $1
          (i32.add
           (local.get $1)
           (i32.shl
            (i32.and
             (local.get $4)
             (i32.const 268435455)
            )
            (i32.const 2)
           )
          )
         )
         (i32.shl
          (local.get $11)
          (i32.const 2)
         )
        )
       )
      )
      (local.set $4
       (i32.const 0)
      )
      (loop $label$22
       (block $label$23
        (br_if $label$23
         (i32.le_u
          (local.tee $3
           (i32.load
            (local.tee $9
             (i32.add
              (local.get $12)
              (i32.shl
               (local.get $4)
               (i32.const 2)
              )
             )
            )
           )
          )
          (local.get $10)
         )
        )
        (block $label$24
         (br_if $label$24
          (i32.gt_u
           (local.tee $8
            (i32.load
             (local.get $0)
            )
           )
           (local.get $3)
          )
         )
         (br_if $label$24
          (i32.le_u
           (i32.load offset=4
            (local.get $0)
           )
           (local.get $3)
          )
         )
         (local.set $13
          (i32.and
           (local.tee $5
            (i32.shr_s
             (i32.sub
              (local.get $3)
              (local.get $8)
             )
             (i32.const 2)
            )
           )
           (i32.const 63)
          )
         )
         (local.set $15
          (i32.load
           (i32.add
            (i32.load offset=16
             (local.get $0)
            )
            (i32.shl
             (local.tee $14
              (i32.div_s
               (local.get $5)
               (i32.const 64)
              )
             )
             (i32.const 2)
            )
           )
          )
         )
         (local.set $16
          (i32.load offset=8
           (local.get $0)
          )
         )
         (block $label$25
          (block $label$26
           (br_if $label$26
            (i32.ne
             (local.tee $17
              (i32.and
               (local.get $14)
               (i32.const 67108863)
              )
             )
             (local.tee $18
              (i32.shr_u
               (local.get $5)
               (i32.const 6)
              )
             )
            )
           )
           (local.set $8
            (i32.sub
             (i32.wrap_i64
              (i64.popcnt
               (i64.and
                (i64.and
                 (i64.shr_u
                  (local.tee $26
                   (i64.shr_u
                    (i64.const -1)
                    (i64.extend_i32_u
                     (i32.xor
                      (local.get $13)
                      (i32.const 63)
                     )
                    )
                   )
                  )
                  (i64.const 1)
                 )
                 (local.get $26)
                )
                (i64.load
                 (i32.add
                  (local.get $16)
                  (i32.shl
                   (local.get $17)
                   (i32.const 3)
                  )
                 )
                )
               )
              )
             )
             (local.get $13)
            )
           )
           (br $label$25)
          )
          (local.set $19
           (i32.add
            (local.get $8)
            (i32.shl
             (local.get $14)
             (i32.const 8)
            )
           )
          )
          (local.set $5
           (i32.wrap_i64
            (i64.popcnt
             (i64.load
              (local.tee $8
               (i32.add
                (local.get $16)
                (i32.shl
                 (local.get $17)
                 (i32.const 3)
                )
               )
              )
             )
            )
           )
          )
          (block $label$27
           (br_if $label$27
            (i32.ge_u
             (local.tee $20
              (i32.add
               (local.get $17)
               (i32.const 1)
              )
             )
             (local.get $18)
            )
           )
           (local.set $21
            (i32.add
             (i32.sub
              (local.get $18)
              (local.get $17)
             )
             (i32.const -2)
            )
           )
           (block $label$28
            (br_if $label$28
             (i32.eqz
              (local.tee $17
               (i32.and
                (i32.add
                 (local.get $18)
                 (i32.xor
                  (local.get $14)
                  (i32.const -1)
                 )
                )
                (i32.const 3)
               )
              )
             )
            )
            (local.set $8
             (i32.add
              (local.get $8)
              (i32.const 8)
             )
            )
            (loop $label$29
             (local.set $20
              (i32.add
               (local.get $20)
               (i32.const 1)
              )
             )
             (local.set $5
              (i32.add
               (local.get $5)
               (i32.wrap_i64
                (i64.popcnt
                 (i64.load
                  (local.get $8)
                 )
                )
               )
              )
             )
             (local.set $8
              (i32.add
               (local.get $8)
               (i32.const 8)
              )
             )
             (br_if $label$29
              (local.tee $17
               (i32.add
                (local.get $17)
                (i32.const -1)
               )
              )
             )
            )
           )
           (br_if $label$27
            (i32.lt_u
             (local.get $21)
             (i32.const 3)
            )
           )
           (local.set $17
            (i32.sub
             (local.get $18)
             (local.get $20)
            )
           )
           (local.set $8
            (i32.add
             (local.get $16)
             (i32.shl
              (local.get $20)
              (i32.const 3)
             )
            )
           )
           (loop $label$30
            (local.set $5
             (i32.add
              (i32.add
               (i32.add
                (i32.add
                 (local.get $5)
                 (i32.wrap_i64
                  (i64.popcnt
                   (i64.load
                    (local.get $8)
                   )
                  )
                 )
                )
                (i32.wrap_i64
                 (i64.popcnt
                  (i64.load
                   (i32.add
                    (local.get $8)
                    (i32.const 8)
                   )
                  )
                 )
                )
               )
               (i32.wrap_i64
                (i64.popcnt
                 (i64.load
                  (i32.add
                   (local.get $8)
                   (i32.const 16)
                  )
                 )
                )
               )
              )
              (i32.wrap_i64
               (i64.popcnt
                (i64.load
                 (i32.add
                  (local.get $8)
                  (i32.const 24)
                 )
                )
               )
              )
             )
            )
            (local.set $8
             (i32.add
              (local.get $8)
              (i32.const 32)
             )
            )
            (br_if $label$30
             (local.tee $17
              (i32.add
               (local.get $17)
               (i32.const -4)
              )
             )
            )
           )
          )
          (local.set $8
           (i32.add
            (i32.sub
             (local.get $5)
             (i32.shr_s
              (i32.sub
               (local.get $3)
               (local.get $19)
              )
              (i32.const 2)
             )
            )
            (i32.wrap_i64
             (i64.popcnt
              (i64.and
               (i64.and
                (i64.shr_u
                 (local.tee $26
                  (i64.shr_u
                   (i64.const -1)
                   (i64.extend_i32_u
                    (i32.xor
                     (local.get $13)
                     (i32.const 63)
                    )
                   )
                  )
                 )
                 (i64.const 1)
                )
                (local.get $26)
               )
               (i64.load
                (i32.add
                 (local.get $16)
                 (i32.shl
                  (local.get $18)
                  (i32.const 3)
                 )
                )
               )
              )
             )
            )
           )
          )
         )
         (local.set $3
          (i32.add
           (i32.sub
            (local.get $3)
            (i32.shl
             (local.get $15)
             (i32.const 2)
            )
           )
           (i32.shl
            (local.get $8)
            (i32.const 2)
           )
          )
         )
        )
        (i32.store
         (local.get $9)
         (local.get $3)
        )
       )
       (br_if $label$22
        (i32.ne
         (local.tee $4
          (i32.add
           (local.get $4)
           (i32.const 1)
          )
         )
         (local.get $11)
        )
       )
      )
     )
     (br_if $label$10
      (i32.lt_u
       (local.get $1)
       (local.get $10)
      )
     )
    )
   )
   (local.set $4
    (local.get $10)
   )
   (local.set $22
    (i32.const 0)
   )
   (local.set $18
    (local.get $10)
   )
   (loop $label$31
    (local.set $27
     (i64.load
      (local.tee $8
       (i32.add
        (local.tee $17
         (i32.load offset=8
          (local.get $0)
         )
        )
        (i32.shl
         (local.get $6)
         (i32.const 3)
        )
       )
      )
     )
    )
    (block $label$32
     (loop $label$33
      (br_if $label$32
       (i64.eqz
        (local.tee $26
         (local.get $28)
        )
       )
      )
      (local.set $28
       (i64.shl
        (local.get $26)
        (i64.const 1)
       )
      )
      (br_if $label$33
       (i64.eqz
        (i64.and
         (local.get $26)
         (local.get $27)
        )
       )
      )
     )
    )
    (block $label$34
     (br_if $label$34
      (i64.ne
       (local.get $26)
       (i64.const 0)
      )
     )
     (local.set $5
      (select
       (local.tee $3
        (i32.load offset=12
         (local.get $0)
        )
       )
       (local.tee $5
        (i32.add
         (local.get $6)
         (i32.const 1)
        )
       )
       (i32.gt_u
        (local.get $3)
        (local.get $5)
       )
      )
     )
     (local.set $8
      (i32.add
       (local.get $8)
       (i32.const 8)
      )
     )
     (block $label$35
      (loop $label$36
       (block $label$37
        (br_if $label$37
         (i32.lt_u
          (local.tee $6
           (i32.add
            (local.get $6)
            (i32.const 1)
           )
          )
          (local.get $3)
         )
        )
        (local.set $6
         (local.get $5)
        )
        (br $label$35)
       )
       (local.set $28
        (i64.load
         (local.get $8)
        )
       )
       (local.set $8
        (i32.add
         (local.get $8)
         (i32.const 8)
        )
       )
       (br_if $label$36
        (i64.eqz
         (local.get $28)
        )
       )
      )
     )
     (block $label$38
      (br_if $label$38
       (i32.ne
        (local.get $6)
        (local.get $3)
       )
      )
      (local.set $26
       (i64.shl
        (i64.const 1)
        (i64.extend_i32_u
         (i32.and
          (local.tee $8
           (i32.shr_s
            (i32.sub
             (i32.load offset=4
              (local.get $0)
             )
             (i32.load
              (local.get $0)
             )
            )
            (i32.const 2)
           )
          )
          (i32.const 63)
         )
        )
       )
      )
      (local.set $27
       (i64.load
        (i32.add
         (local.get $17)
         (i32.shl
          (local.tee $6
           (i32.shr_u
            (local.get $8)
            (i32.const 6)
           )
          )
          (i32.const 3)
         )
        )
       )
      )
      (br $label$34)
     )
     (local.set $26
      (i64.and
       (local.tee $27
        (i64.load
         (i32.add
          (local.get $17)
          (i32.shl
           (local.get $6)
           (i32.const 3)
          )
         )
        )
       )
       (i64.sub
        (i64.const 0)
        (local.get $27)
       )
      )
     )
    )
    (local.set $20
     (i32.shr_s
      (i32.sub
       (local.tee $16
        (select
         (local.tee $5
          (i32.load offset=4
           (local.get $0)
          )
         )
         (local.tee $8
          (i32.add
           (i32.add
            (local.tee $9
             (i32.load
              (local.get $0)
             )
            )
            (i32.shl
             (local.get $6)
             (i32.const 8)
            )
           )
           (i32.shl
            (i32.sub
             (select
              (local.tee $8
               (select
                (local.tee $8
                 (select
                  (local.tee $8
                   (select
                    (local.tee $8
                     (select
                      (i32.const 31)
                      (i32.const 63)
                      (i32.wrap_i64
                       (local.get $26)
                      )
                     )
                    )
                    (i32.add
                     (local.get $8)
                     (i32.const -16)
                    )
                    (i64.eqz
                     (i64.and
                      (local.get $26)
                      (i64.const 281470681808895)
                     )
                    )
                   )
                  )
                  (i32.add
                   (local.get $8)
                   (i32.const -8)
                  )
                  (i64.eqz
                   (i64.and
                    (local.get $26)
                    (i64.const 71777214294589695)
                   )
                  )
                 )
                )
                (i32.add
                 (local.get $8)
                 (i32.const -4)
                )
                (i64.eqz
                 (i64.and
                  (local.get $26)
                  (i64.const 1085102592571150095)
                 )
                )
               )
              )
              (i32.add
               (local.get $8)
               (i32.const -2)
              )
              (i64.eqz
               (i64.and
                (local.get $26)
                (i64.const 3689348814741910323)
               )
              )
             )
             (i64.ne
              (i64.and
               (local.get $26)
               (i64.const 6148914691236517205)
              )
              (i64.const 0)
             )
            )
            (i32.const 2)
           )
          )
         )
         (i32.gt_u
          (local.get $8)
          (local.get $5)
         )
        )
       )
       (local.get $18)
      )
      (i32.const 2)
     )
    )
    (local.set $27
     (i64.xor
      (local.get $27)
      (i64.const -1)
     )
    )
    (block $label$39
     (loop $label$40
      (br_if $label$39
       (i64.eqz
        (local.tee $28
         (local.get $26)
        )
       )
      )
      (local.set $26
       (i64.shl
        (local.get $28)
        (i64.const 1)
       )
      )
      (br_if $label$40
       (i64.eqz
        (i64.and
         (local.get $28)
         (local.get $27)
        )
       )
      )
     )
    )
    (block $label$41
     (br_if $label$41
      (i64.ne
       (local.get $28)
       (i64.const 0)
      )
     )
     (local.set $11
      (select
       (local.tee $3
        (i32.load offset=12
         (local.get $0)
        )
       )
       (local.tee $8
        (i32.add
         (local.get $6)
         (i32.const 1)
        )
       )
       (i32.gt_u
        (local.get $3)
        (local.get $8)
       )
      )
     )
     (local.set $8
      (i32.add
       (i32.add
        (local.get $17)
        (i32.shl
         (local.get $6)
         (i32.const 3)
        )
       )
       (i32.const 8)
      )
     )
     (block $label$42
      (loop $label$43
       (block $label$44
        (br_if $label$44
         (i32.lt_u
          (local.tee $6
           (i32.add
            (local.get $6)
            (i32.const 1)
           )
          )
          (local.get $3)
         )
        )
        (local.set $6
         (local.get $11)
        )
        (br $label$42)
       )
       (local.set $28
        (i64.load
         (local.get $8)
        )
       )
       (local.set $8
        (i32.add
         (local.get $8)
         (i32.const 8)
        )
       )
       (br_if $label$43
        (i64.eq
         (local.get $28)
         (i64.const -1)
        )
       )
      )
     )
     (block $label$45
      (br_if $label$45
       (i32.ne
        (local.get $6)
        (local.get $3)
       )
      )
      (local.set $6
       (i32.shr_u
        (local.tee $8
         (i32.shr_s
          (i32.sub
           (local.get $5)
           (local.get $9)
          )
          (i32.const 2)
         )
        )
        (i32.const 6)
       )
      )
      (local.set $28
       (i64.shl
        (i64.const 1)
        (i64.extend_i32_u
         (i32.and
          (local.get $8)
          (i32.const 63)
         )
        )
       )
      )
      (br $label$41)
     )
     (local.set $28
      (i64.and
       (i64.add
        (local.tee $28
         (i64.load
          (i32.add
           (local.get $17)
           (i32.shl
            (local.get $6)
            (i32.const 3)
           )
          )
         )
        )
        (i64.const 1)
       )
       (i64.xor
        (local.get $28)
        (i64.const -1)
       )
      )
     )
    )
    (local.set $22
     (i32.add
      (local.get $20)
      (local.get $22)
     )
    )
    (block $label$46
     (block $label$47
      (br_if $label$47
       (i32.lt_u
        (local.get $16)
        (local.tee $23
         (select
          (local.get $5)
          (local.tee $8
           (i32.add
            (i32.add
             (local.get $9)
             (i32.shl
              (local.get $6)
              (i32.const 8)
             )
            )
            (i32.shl
             (i32.sub
              (select
               (local.tee $8
                (select
                 (local.tee $8
                  (select
                   (local.tee $8
                    (select
                     (local.tee $8
                      (select
                       (i32.const 31)
                       (i32.const 63)
                       (i32.wrap_i64
                        (local.get $28)
                       )
                      )
                     )
                     (i32.add
                      (local.get $8)
                      (i32.const -16)
                     )
                     (i64.eqz
                      (i64.and
                       (local.get $28)
                       (i64.const 281470681808895)
                      )
                     )
                    )
                   )
                   (i32.add
                    (local.get $8)
                    (i32.const -8)
                   )
                   (i64.eqz
                    (i64.and
                     (local.get $28)
                     (i64.const 71777214294589695)
                    )
                   )
                  )
                 )
                 (i32.add
                  (local.get $8)
                  (i32.const -4)
                 )
                 (i64.eqz
                  (i64.and
                   (local.get $28)
                   (i64.const 1085102592571150095)
                  )
                 )
                )
               )
               (i32.add
                (local.get $8)
                (i32.const -2)
               )
               (i64.eqz
                (i64.and
                 (local.get $28)
                 (i64.const 3689348814741910323)
                )
               )
              )
              (i64.ne
               (i64.and
                (local.get $28)
                (i64.const 6148914691236517205)
               )
               (i64.const 0)
              )
             )
             (i32.const 2)
            )
           )
          )
          (i32.gt_u
           (local.get $8)
           (local.get $5)
          )
         )
        )
       )
      )
      (local.set $18
       (local.get $16)
      )
      (br $label$46)
     )
     (local.set $21
      (i32.sub
       (i32.const 0)
       (local.get $22)
      )
     )
     (local.set $5
      (local.get $16)
     )
     (loop $label$48
      (block $label$49
       (block $label$50
        (block $label$51
         (block $label$52
          (block $label$53
           (block $label$54
            (block $label$55
             (block $label$56
              (block $label$57
               (block $label$58
                (block $label$59
                 (br_table $label$59 $label$58 $label$57 $label$56 $label$55 $label$51 $label$54 $label$51 $label$53 $label$52 $label$51
                  (i32.add
                   (local.tee $20
                    (i32.shr_u
                     (local.tee $3
                      (i32.load
                       (local.get $5)
                      )
                     )
                     (i32.const 28)
                    )
                   )
                   (i32.const -4)
                  )
                 )
                )
                (local.set $9
                 (i32.add
                  (local.tee $18
                   (i32.add
                    (local.get $5)
                    (i32.shl
                     (local.tee $8
                      (i32.and
                       (local.get $3)
                       (i32.const 268435455)
                      )
                     )
                     (i32.const 2)
                    )
                   )
                  )
                  (select
                   (i32.const 0)
                   (i32.const -8)
                   (i32.eq
                    (local.tee $3
                     (i32.load offset=7844
                      (i32.const 0)
                     )
                    )
                    (local.get $5)
                   )
                  )
                 )
                )
                (local.set $11
                 (i32.shl
                  (i32.ne
                   (local.get $3)
                   (local.get $5)
                  )
                  (i32.const 1)
                 )
                )
                (br_if $label$50
                 (i32.ne
                  (local.get $8)
                  (i32.const 3)
                 )
                )
                (br $label$49)
               )
               (local.set $11
                (i32.const 2)
               )
               (local.set $9
                (i32.add
                 (local.tee $18
                  (i32.add
                   (local.get $5)
                   (i32.shl
                    (local.tee $8
                     (i32.and
                      (local.get $3)
                      (i32.const 268435455)
                     )
                    )
                    (i32.const 2)
                   )
                  )
                 )
                 (i32.const -8)
                )
               )
               (br_if $label$50
                (i32.ne
                 (local.get $8)
                 (i32.const 3)
                )
               )
               (br $label$49)
              )
              (local.set $9
               (i32.add
                (local.tee $18
                 (i32.add
                  (local.get $5)
                  (i32.shl
                   (local.tee $8
                    (i32.and
                     (local.get $3)
                     (i32.const 268435455)
                    )
                   )
                   (i32.const 2)
                  )
                 )
                )
                (i32.const -12)
               )
              )
              (local.set $11
               (i32.const 3)
              )
              (br_if $label$50
               (i32.ne
                (local.get $8)
                (i32.const 4)
               )
              )
              (br $label$49)
             )
             (local.set $9
              (i32.add
               (local.tee $18
                (i32.add
                 (local.get $5)
                 (i32.shl
                  (local.tee $8
                   (i32.and
                    (local.get $3)
                    (i32.const 268435455)
                   )
                  )
                  (i32.const 2)
                 )
                )
               )
               (i32.shl
                (i32.sub
                 (i32.const 2)
                 (local.get $8)
                )
                (i32.const 2)
               )
              )
             )
             (br_if $label$50
              (i32.ge_u
               (local.tee $11
                (i32.add
                 (local.get $8)
                 (i32.const -2)
                )
               )
               (i32.const 512)
              )
             )
             (br $label$49)
            )
            (local.set $9
             (i32.add
              (local.tee $18
               (i32.add
                (local.get $5)
                (i32.shl
                 (local.tee $8
                  (i32.and
                   (local.get $3)
                   (i32.const 268435455)
                  )
                 )
                 (i32.const 2)
                )
               )
              )
              (i32.shl
               (i32.sub
                (i32.const 1)
                (local.get $8)
               )
               (i32.const 2)
              )
             )
            )
            (local.set $11
             (i32.add
              (local.get $8)
              (i32.const -1)
             )
            )
            (br_if $label$50
             (i32.ge_u
              (i32.add
               (local.get $8)
               (i32.const -2)
              )
              (i32.const 512)
             )
            )
            (br $label$49)
           )
           (local.set $9
            (i32.sub
             (local.tee $18
              (i32.add
               (local.get $5)
               (i32.shl
                (local.tee $8
                 (i32.and
                  (local.get $3)
                  (i32.const 268435455)
                 )
                )
                (i32.const 2)
               )
              )
             )
             (i32.shl
              (local.tee $11
               (i32.load16_u offset=4
                (local.get $5)
               )
              )
              (i32.const 2)
             )
            )
           )
           (br_if $label$50
            (i32.ge_u
             (i32.add
              (local.get $8)
              (i32.const -3)
             )
             (i32.const 512)
            )
           )
           (br $label$49)
          )
          (local.set $9
           (i32.add
            (local.tee $18
             (i32.add
              (local.get $5)
              (i32.shl
               (local.tee $8
                (i32.and
                 (local.get $3)
                 (i32.const 268435455)
                )
               )
               (i32.const 2)
              )
             )
            )
            (i32.const -16)
           )
          )
          (local.set $11
           (i32.const 4)
          )
          (br_if $label$50
           (i32.ne
            (local.get $8)
            (i32.const 6)
           )
          )
          (br $label$49)
         )
         (local.set $9
          (i32.add
           (local.tee $18
            (i32.add
             (local.get $5)
             (i32.shl
              (local.tee $8
               (i32.and
                (local.get $3)
                (i32.const 268435455)
               )
              )
              (i32.const 2)
             )
            )
           )
           (i32.const -16)
          )
         )
         (local.set $11
          (i32.const 4)
         )
         (br_if $label$50
          (i32.ne
           (local.get $8)
           (i32.const 6)
          )
         )
         (br $label$49)
        )
        (local.set $11
         (i32.const 0)
        )
        (local.set $18
         (local.tee $9
          (i32.add
           (local.get $5)
           (i32.shl
            (local.tee $8
             (i32.and
              (local.get $3)
              (i32.const 268435455)
             )
            )
            (i32.const 2)
           )
          )
         )
        )
        (block $label$60
         (block $label$61
          (block $label$62
           (block $label$63
            (block $label$64
             (block $label$65
              (br_table $label$60 $label$65 $label$64 $label$63 $label$50 $label$50 $label$50 $label$50 $label$50 $label$62 $label$50 $label$61 $label$50
               (local.get $20)
              )
             )
             (local.set $11
              (i32.const 0)
             )
             (local.set $18
              (local.get $9)
             )
             (br_if $label$50
              (i32.ne
               (local.get $8)
               (i32.const 4)
              )
             )
             (br $label$49)
            )
            (local.set $11
             (i32.const 0)
            )
            (local.set $18
             (local.get $9)
            )
            (br_if $label$50
             (i32.ne
              (local.get $8)
              (i32.const 2)
             )
            )
            (br $label$49)
           )
           (local.set $11
            (i32.const 0)
           )
           (local.set $18
            (local.get $9)
           )
           (br_if $label$50
            (i32.and
             (local.get $3)
             (i32.const 268419072)
            )
           )
           (br $label$49)
          )
          (local.set $11
           (i32.const 0)
          )
          (local.set $18
           (local.get $9)
          )
          (br_if $label$50
           (i32.ge_u
            (i32.add
             (local.get $8)
             (i32.const -2)
            )
            (i32.const 512)
           )
          )
          (br $label$49)
         )
         (local.set $11
          (i32.const 0)
         )
         (local.set $18
          (local.get $9)
         )
         (br_if $label$50
          (i32.ne
           (local.get $8)
           (i32.const 2)
          )
         )
         (br $label$49)
        )
        (local.set $11
         (i32.const 0)
        )
        (local.set $18
         (local.get $9)
        )
        (br_if $label$49
         (i32.eq
          (local.get $8)
          (i32.const 4)
         )
        )
       )
       (i32.store offset=60
        (local.get $2)
        (i32.const 108)
       )
       (i32.store offset=56
        (local.get $2)
        (i32.const 3351)
       )
       (i32.store offset=52
        (local.get $2)
        (i32.const 1619)
       )
       (i32.store offset=48
        (local.get $2)
        (i32.const 1336)
       )
       (call $safe_printf
        (i32.const 5356)
        (i32.add
         (local.get $2)
         (i32.const 48)
        )
       )
       (call $print_heap_range
        (local.get $5)
        (i32.add
         (local.get $5)
         (i32.shl
          (select
           (local.tee $8
            (select
             (local.get $8)
             (i32.const 4)
             (i32.gt_u
              (local.get $8)
              (i32.const 4)
             )
            )
           )
           (i32.const 16)
           (i32.lt_u
            (local.get $8)
            (i32.const 16)
           )
          )
          (i32.const 2)
         )
        )
       )
       (call $safe_printf
        (i32.const 6063)
        (i32.const 0)
       )
       (call $abort)
      )
      (block $label$66
       (br_if $label$66
        (i32.lt_u
         (local.get $18)
         (i32.load offset=4
          (local.get $0)
         )
        )
       )
       (i32.store offset=40
        (local.get $2)
        (i32.const 109)
       )
       (i32.store offset=36
        (local.get $2)
        (i32.const 3351)
       )
       (i32.store offset=32
        (local.get $2)
        (i32.const 1619)
       )
       (call $safe_printf
        (i32.const 5284)
        (i32.add
         (local.get $2)
         (i32.const 32)
        )
       )
       (i32.store offset=16
        (local.get $2)
        (i32.const 3174)
       )
       (call $safe_printf
        (i32.const 4957)
        (i32.add
         (local.get $2)
         (i32.const 16)
        )
       )
       (i64.store offset=8
        (local.get $2)
        (i64.extend_i32_u
         (local.get $18)
        )
       )
       (i32.store
        (local.get $2)
        (i32.const 2826)
       )
       (call $safe_printf
        (i32.const 6035)
        (local.get $2)
       )
       (call $abort)
      )
      (block $label$67
       (br_if $label$67
        (i32.ge_u
         (local.get $5)
         (local.get $9)
        )
       )
       (loop $label$68
        (i32.store
         (local.get $4)
         (i32.load
          (local.get $5)
         )
        )
        (local.set $4
         (i32.add
          (local.get $4)
          (i32.const 4)
         )
        )
        (br_if $label$68
         (i32.lt_u
          (local.tee $5
           (i32.add
            (local.get $5)
            (i32.const 4)
           )
          )
          (local.get $9)
         )
        )
       )
      )
      (block $label$69
       (br_if $label$69
        (i32.eqz
         (local.get $11)
        )
       )
       (local.set $3
        (i32.const 0)
       )
       (loop $label$70
        (block $label$71
         (br_if $label$71
          (i32.lt_u
           (local.tee $8
            (i32.load
             (i32.add
              (local.get $9)
              (i32.shl
               (local.get $3)
               (i32.const 2)
              )
             )
            )
           )
           (local.get $10)
          )
         )
         (br_if $label$71
          (i32.gt_u
           (local.get $8)
           (local.tee $20
            (i32.load offset=4
             (local.get $0)
            )
           )
          )
         )
         (block $label$72
          (br_if $label$72
           (i32.lt_u
            (local.get $8)
            (local.get $16)
           )
          )
          (br_if $label$72
           (i32.ge_u
            (local.get $8)
            (local.get $5)
           )
          )
          (local.set $8
           (i32.add
            (local.get $8)
            (i32.shl
             (local.get $21)
             (i32.const 2)
            )
           )
          )
          (br $label$71)
         )
         (br_if $label$71
          (i32.gt_u
           (local.tee $17
            (i32.load
             (local.get $0)
            )
           )
           (local.get $8)
          )
         )
         (br_if $label$71
          (i32.le_u
           (local.get $20)
           (local.get $8)
          )
         )
         (local.set $19
          (i32.and
           (local.tee $20
            (i32.shr_s
             (i32.sub
              (local.get $8)
              (local.get $17)
             )
             (i32.const 2)
            )
           )
           (i32.const 63)
          )
         )
         (local.set $24
          (i32.load
           (i32.add
            (i32.load offset=16
             (local.get $0)
            )
            (i32.shl
             (local.tee $14
              (i32.div_s
               (local.get $20)
               (i32.const 64)
              )
             )
             (i32.const 2)
            )
           )
          )
         )
         (local.set $15
          (i32.load offset=8
           (local.get $0)
          )
         )
         (block $label$73
          (block $label$74
           (br_if $label$74
            (i32.ne
             (local.tee $13
              (i32.and
               (local.get $14)
               (i32.const 67108863)
              )
             )
             (local.tee $1
              (i32.shr_u
               (local.get $20)
               (i32.const 6)
              )
             )
            )
           )
           (local.set $20
            (i32.sub
             (i32.wrap_i64
              (i64.popcnt
               (i64.and
                (i64.and
                 (i64.shr_u
                  (local.tee $26
                   (i64.shr_u
                    (i64.const -1)
                    (i64.extend_i32_u
                     (i32.xor
                      (local.get $19)
                      (i32.const 63)
                     )
                    )
                   )
                  )
                  (i64.const 1)
                 )
                 (local.get $26)
                )
                (i64.load
                 (i32.add
                  (local.get $15)
                  (i32.shl
                   (local.get $13)
                   (i32.const 3)
                  )
                 )
                )
               )
              )
             )
             (local.get $19)
            )
           )
           (br $label$73)
          )
          (local.set $25
           (i32.add
            (local.get $17)
            (i32.shl
             (local.get $14)
             (i32.const 8)
            )
           )
          )
          (local.set $17
           (i32.wrap_i64
            (i64.popcnt
             (i64.load
              (local.tee $20
               (i32.add
                (local.get $15)
                (i32.shl
                 (local.get $13)
                 (i32.const 3)
                )
               )
              )
             )
            )
           )
          )
          (block $label$75
           (br_if $label$75
            (i32.ge_u
             (local.tee $12
              (i32.add
               (local.get $13)
               (i32.const 1)
              )
             )
             (local.get $1)
            )
           )
           (local.set $13
            (i32.add
             (i32.sub
              (local.get $1)
              (local.get $13)
             )
             (i32.const -2)
            )
           )
           (block $label$76
            (br_if $label$76
             (i32.eqz
              (local.tee $14
               (i32.and
                (i32.add
                 (local.get $1)
                 (i32.xor
                  (local.get $14)
                  (i32.const -1)
                 )
                )
                (i32.const 3)
               )
              )
             )
            )
            (local.set $20
             (i32.add
              (local.get $20)
              (i32.const 8)
             )
            )
            (loop $label$77
             (local.set $12
              (i32.add
               (local.get $12)
               (i32.const 1)
              )
             )
             (local.set $17
              (i32.add
               (local.get $17)
               (i32.wrap_i64
                (i64.popcnt
                 (i64.load
                  (local.get $20)
                 )
                )
               )
              )
             )
             (local.set $20
              (i32.add
               (local.get $20)
               (i32.const 8)
              )
             )
             (br_if $label$77
              (local.tee $14
               (i32.add
                (local.get $14)
                (i32.const -1)
               )
              )
             )
            )
           )
           (br_if $label$75
            (i32.lt_u
             (local.get $13)
             (i32.const 3)
            )
           )
           (local.set $14
            (i32.sub
             (local.get $1)
             (local.get $12)
            )
           )
           (local.set $20
            (i32.add
             (local.get $15)
             (i32.shl
              (local.get $12)
              (i32.const 3)
             )
            )
           )
           (loop $label$78
            (local.set $17
             (i32.add
              (i32.add
               (i32.add
                (i32.add
                 (local.get $17)
                 (i32.wrap_i64
                  (i64.popcnt
                   (i64.load
                    (local.get $20)
                   )
                  )
                 )
               )